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
    public class RutinasController : ControllerBase
    {
        private readonly RelaxGymContext _dbContext;
        public RutinasController(RelaxGymContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreateRutinaAsync(CreateRutinaRequest createRutinaRequest)
        {
            Rutina nuevaRutina = new Rutina()
            {
                IdWeb = Guid.NewGuid().ToString("N"),
                Nombre = createRutinaRequest.Nombre,
                Descripcion = createRutinaRequest.Descripcion,
                IdUsuarioCreador = createRutinaRequest.IdUsuarioCreador,
                Nivel = createRutinaRequest.Nivel
            };

            _dbContext.Attach(nuevaRutina);

            foreach (CreateRutinaEjercicioRequest ejercicio in createRutinaRequest.Ejercicios)
            {
                Ejercicio ejercicioAsignar = await _dbContext.Set<Ejercicio>().FirstOrDefaultAsync(x => x.Id == ejercicio.IdEjercicio);

                if (ejercicioAsignar == null)
                {
                    continue;
                }

                EjercicioRutina nuevoEjercicioRutina = new EjercicioRutina()
                {
                    Ejercicio = ejercicioAsignar,
                    Rutina = nuevaRutina,
                    Series = ejercicio.Series,
                    CantidadRepeticiones = ejercicio.CantidadRepeticiones
                };

                _dbContext.Attach(nuevoEjercicioRutina);
            }

            await _dbContext.SaveChangesAsync();

            return Ok();
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IList<Rutina>))]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> GetAllRutinasAsync()
        {
            IList<Rutina> rutinas = await _dbContext.Set<Rutina>()
                                   .Include(x => x.Ejercicios).ThenInclude(x => x.Ejercicio).ThenInclude(x => x.TipoEjercicio)
                                   .Include(x => x.Usuarios).ThenInclude(x => x.Usuario)
                                   .ToListAsync();

            if (rutinas == null)
            {
                return NoContent();
            }

            return Ok(rutinas);
        }

        [HttpGet]
        [Route("{idRutina}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Rutina))]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetRutinaByIdAsync(int idRutina)
        {
            Rutina rutina = await _dbContext.Set<Rutina>()
                                   .Include(x => x.Usuarios).ThenInclude(x => x.Usuario)
                                   .FirstOrDefaultAsync(x => x.Id == idRutina);

            if (rutina == null)
            {
                return NotFound();
            }

            return Ok(rutina);
        }

        [HttpGet]
        [Route("Usuario/{idUsuario}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IList<Rutina>))]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetRutinaByIdUsuarioAsync(int idUsuario)
        {
            IList<Rutina> rutinas = await _dbContext.Set<Rutina>()
                                   .Include(x => x.Ejercicios).ThenInclude(x => x.Ejercicio).ThenInclude(x => x.TipoEjercicio)
                                   .Where(x => x.Usuarios.Any(x => x.IdUsuario == idUsuario))
                                   .ToListAsync();

            if (rutinas == null)
            {
                return NotFound();
            }

            return Ok(rutinas);
        }

        [HttpGet]
        [Route("UsuarioCreador/{idUsuario}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IList<Rutina>))]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetRutinaByIdUsuarioCreadorAsync(int idUsuario)
        {
            IList<Rutina> rutinas = await _dbContext.Set<Rutina>()
                                   .Include(x => x.Ejercicios).ThenInclude(x => x.Ejercicio).ThenInclude(x => x.TipoEjercicio)
                                   .Where(x => x.IdUsuarioCreador == idUsuario)
                                   .ToListAsync();

            if (rutinas == null)
            {
                return NotFound();
            }

            return Ok(rutinas);
        }

        [HttpDelete]
        [Route("{idRutina}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteRutinaByIdAsync(int idRutina)
        {
            Rutina rutina = await _dbContext.Set<Rutina>()
                                            .Include(x => x.Ejercicios)
                                            .Include(x => x.Usuarios)
                                            .FirstOrDefaultAsync(x => x.Id == idRutina);

            if (rutina == null)
            {
                return NotFound();
            }

            if (rutina.Usuarios != null && rutina.Usuarios.Any())
            {
                return ValidationProblem($"No se puede eliminar esta rutina porque tiene usuarios asignados.");
            }

            foreach (EjercicioRutina ejercioRutina in rutina.Ejercicios)
            {
                _dbContext.EjerciciosRutinas.Remove(ejercioRutina);
            }

            _dbContext.Rutinas.Remove(rutina);

            await _dbContext.SaveChangesAsync();

            return Ok();
        }

        [HttpPost]
        [Route("Asignar")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> AsignarRutinaAsync(AsignarRutinaRequest asignarRutinaRequest)
        {
            Rutina rutinaAsignar = await _dbContext.Set<Rutina>().FirstOrDefaultAsync(x => x.Id == asignarRutinaRequest.IdRutina);

            if (rutinaAsignar == null)
            {
                return ValidationProblem($"No existe la rutina con id {asignarRutinaRequest.IdRutina}.");
            }

            foreach (int idUsuario in asignarRutinaRequest.IdUsuarios)
            {
                Usuario usuarioAsignar = await _dbContext.Set<Usuario>().FirstOrDefaultAsync(x => x.Id == idUsuario);

                if (usuarioAsignar == null)
                {
                    continue;
                }

                UsuarioRutina nuevoUsuarioRutina = new UsuarioRutina()
                {
                    Rutina = rutinaAsignar,
                    Usuario = usuarioAsignar,
                    Observacion = asignarRutinaRequest.Observacion
                };

                _dbContext.Attach(nuevoUsuarioRutina);
            }

            await _dbContext.SaveChangesAsync();

            return Ok();
        }

        [HttpPost]
        [Route("Desasignar/{idRutina}/Alumno/{idUsuario}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DesasignarAlumnoAsync(int idRutina, int idUsuario)
        {
            bool rutinaExist = await _dbContext.Set<Rutina>().AnyAsync(x => x.Id == idRutina);

            if (!rutinaExist)
            {
                return ValidationProblem($"No existe la rutina con id {idRutina}.");
            }

            UsuarioRutina usuarioRutinaDelete = await _dbContext.Set<UsuarioRutina>()
                                                                .FirstOrDefaultAsync(x => x.IdUsuario == idUsuario &&
                                                                                          x.IdRutina == idRutina);

            if (usuarioRutinaDelete == null)
            {
                return ValidationProblem($"No existe usuario asignado a la rutina con id {idRutina}.");
            }

            _dbContext.UsuariosRutinas.Remove(usuarioRutinaDelete);

            await _dbContext.SaveChangesAsync();

            return Ok();
        }
    }
}
