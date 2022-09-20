using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using relaxgym.api.Entities;
using relaxgym.api.Repository;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace relaxgym.api.Controllers
{
    [Authorize]
    [Route("[controller]")]
    [ApiController]
    public class ClasesController : ControllerBase
    {
        private readonly RelaxGymContext _dbContext;
        public ClasesController(RelaxGymContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IList<Clase>))]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> GetAllClasesAsync()
        {
            IList<Clase> clases = await _dbContext.Set<Clase>()
                                                  .ToListAsync();

            if (clases == null)
            {
                return NoContent();
            }

            return Ok(clases);
        }

        [HttpGet]
        [Route("{idClase}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Clase))]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetClaseByIdAsync(int idClase)
        {
            Clase clase = await _dbContext.Set<Clase>()
                                   .FirstOrDefaultAsync(x => x.Id == idClase);


            if (clase == null)
            {
                return NotFound();
            }

            return Ok(clase);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreateClaseAsync([FromForm] string nombre, [FromForm] string descripcion, IFormFile imagen)
        {
            Clase nuevaClase = new Clase()
            {
                IdWeb = Guid.NewGuid().ToString("N"),
                Nombre = nombre,
                Descripcion = descripcion
            };

            if (imagen.Length > 0)
            {
                using (MemoryStream ms = new MemoryStream())
                {
                    imagen.CopyTo(ms);
                    byte[] fileBytes = ms.ToArray();
                    nuevaClase.Imagen = fileBytes;
                }
            }

            _dbContext.Attach(nuevaClase);

            await _dbContext.SaveChangesAsync();

            return Ok();
        }

        [HttpDelete]
        [Route("{idClase}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteClaseByIdAsync(int idClase)
        {
            Clase clase = await _dbContext.Set<Clase>()
                                    .FirstOrDefaultAsync(x => x.Id == idClase);

            if (clase == null)
            {
                return NotFound();
            }


            IList<Turno> turnosList = await _dbContext.Set<Turno>()
                                                       .Where(x => x.IdClase == idClase)
                                                       .ToListAsync();

            foreach (Turno turno in turnosList)
            {
                IList<UsuarioTurno> usuarioTurnoList = await _dbContext.Set<UsuarioTurno>()
                                                                       .Where(x => x.IdTurno == turno.Id)
                                                                       .ToListAsync();
                foreach (UsuarioTurno usuarioTurno in usuarioTurnoList)
                {
                    _dbContext.UsuariosTurnos.Remove(usuarioTurno);
                }

                _dbContext.Turnos.Remove(turno);
            }

            _dbContext.Clases.Remove(clase);

            await _dbContext.SaveChangesAsync();

            return Ok();
        }

        [HttpPut]
        [Route("{idClase}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> UpdateClaseByIdAsync([FromRoute] int idClase, [FromForm] string nombre, [FromForm] string descripcion, [FromForm] IFormFile imagen)
        {

            Clase claseActualizar = await _dbContext.Set<Clase>()
                                                        .Where(x => x.Id == idClase)
                                                        .FirstOrDefaultAsync();
            if (claseActualizar == null)
            {
                return NotFound();
            }

            if (imagen.Length > 0)
            {
                using (MemoryStream ms = new MemoryStream())
                {
                    imagen.CopyTo(ms);
                    byte[] fileBytes = ms.ToArray();
                    claseActualizar.Imagen = fileBytes;
                }
            }

            claseActualizar.Nombre = nombre;
            claseActualizar.Descripcion = descripcion;

            await _dbContext.SaveChangesAsync();

            return Ok();
        }
    }
}
