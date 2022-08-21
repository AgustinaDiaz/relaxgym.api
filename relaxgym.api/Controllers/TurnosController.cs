using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using relaxgym.api.Entities;
using relaxgym.api.Repository;
using relaxgym.api.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace relaxgym.api.Controllers
{
    [Authorize]
    [Route("[controller]")]
    [ApiController]
    public class TurnosController : ControllerBase
    {
        private readonly RelaxGymContext _dbContext;
        public TurnosController(RelaxGymContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreateTurnoAsync(CreateTurnoRequest createTurnoRequest)
        {
            Turno nuevoTurno = new Turno()
            {
                IdWeb = Guid.NewGuid().ToString("N"),
                CantidadAlumnos = createTurnoRequest.CantidadAlumnos,
                Observacion = createTurnoRequest.Observacion,
                FechaHora = createTurnoRequest.FechaHora.ToLocalTime(),
                IdClase = createTurnoRequest.IdClase
            };

            _dbContext.Attach(nuevoTurno);

            await _dbContext.SaveChangesAsync();

            return Ok();
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IList<Turno>))]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> GetAllTurnosAsync()
        {
            IList<Turno> turnos = await _dbContext.Set<Turno>()
                                   .Include(x => x.Clase)
                                   .Include(x => x.Usuarios)
                                   .ToListAsync();

            if (turnos == null)
            {
                return NoContent();
            }

            return Ok(turnos);
        }

        [HttpGet]
        [Route("{idTurno}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Turno))]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetTurnoByIdAsync(int idTurno)
        {
            Turno turno = await _dbContext.Set<Turno>()
                                   .Include(x => x.Clase)
                                   .Include(x => x.Usuarios).ThenInclude(x => x.Usuario)
                                   .FirstOrDefaultAsync(x => x.Id == idTurno);

            if (turno == null)
            {
                return NotFound();
            }

            return Ok(turno);
        }

        [HttpPut]
        [Route("{idTurno}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> UpdateTurnoByIdAsync(int idTurno, UpdateTurnoRequest updateTurnoRequest)
        {
            Turno turnoActualizar = await _dbContext.Set<Turno>()
                                                    .Where(x => x.Id == idTurno)
                                                    .FirstOrDefaultAsync();
            if (turnoActualizar == null)
            {
                return NotFound();
            }

            turnoActualizar.CantidadAlumnos = updateTurnoRequest.CantidadAlumnos;
            turnoActualizar.FechaHora = updateTurnoRequest.FechaHora;

            await _dbContext.SaveChangesAsync();

            return Ok();
        }

        [HttpPost]
        [Route("Asignar")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> AsignarTurnoAsync(AsignarTurnoRequest asignarTurnoRequest)
        {
            Turno turnoAsignar = await _dbContext.Set<Turno>().FirstOrDefaultAsync(x => x.Id == asignarTurnoRequest.IdTurno);

            if (turnoAsignar == null)
            {
                return ValidationProblem($"No existe el turno con id {asignarTurnoRequest.IdTurno}.");
            }

            foreach (int idUsuario in asignarTurnoRequest.IdUsuarios)
            {
                Usuario usuarioAsignar = await _dbContext.Set<Usuario>().FirstOrDefaultAsync(x => x.Id == idUsuario);

                if (usuarioAsignar == null)
                {
                    continue;
                }

                UsuarioTurno nuevoUsuarioTurno = new UsuarioTurno()
                {
                    Turno = turnoAsignar,
                    Usuario = usuarioAsignar,
                };

                _dbContext.Attach(nuevoUsuarioTurno);
            }

            await _dbContext.SaveChangesAsync();

            return Ok();
        }

        [HttpPost]
        [Route("Desasignar/{idTurno}/Alumno/{idUsuario}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DesasignarAlumnoAsync(int idTurno, int idUsuario)
        {
            bool turnoExist = await _dbContext.Set<Turno>().AnyAsync(x => x.Id == idTurno);

            if (!turnoExist)
            {
                return ValidationProblem($"No existe la turno con id {idTurno}.");
            }

            UsuarioTurno usuarioTurnoDelete = await _dbContext.Set<UsuarioTurno>()
                                                                .FirstOrDefaultAsync(x => x.IdUsuario == idUsuario &&
                                                                                          x.IdTurno == idTurno);

            if (usuarioTurnoDelete == null)
            {
                return ValidationProblem($"No existe usuario asignado a la turno con id {idTurno}.");
            }

            _dbContext.UsuariosTurnos.Remove(usuarioTurnoDelete);

            await _dbContext.SaveChangesAsync();

            return Ok();
        }
    }
}
