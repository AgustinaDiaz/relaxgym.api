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
    public class EjerciciosController : ControllerBase
    {
        private readonly RelaxGymContext _dbContext;
        public EjerciciosController(RelaxGymContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreateEjercicioAsync(CreateEjercicioRequest createEjercicioRequest)
        {
            Ejercicio nuevoEjercicio = new Ejercicio()
            {
                IdWeb = Guid.NewGuid().ToString("N"),
                Nombre = createEjercicioRequest.Nombre,
                Descripcion = createEjercicioRequest.Descripcion,
                UrlEjercicio = createEjercicioRequest.UrlEjercicio,
                IdTipoEjercicio = createEjercicioRequest.IdTipoEjercicio
            };

            _dbContext.Attach(nuevoEjercicio);

            await _dbContext.SaveChangesAsync();

            return Ok();
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IList<Ejercicio>))]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> GetAllEjerciciosAsync()
        {
            IList<Ejercicio> ejercicios = await _dbContext.Set<Ejercicio>()
                                   .Include(x => x.TipoEjercicio)
                                   .ToListAsync();

            if (ejercicios == null)
            {
                return NoContent();
            }

            return Ok(ejercicios);
        }

        [HttpGet]
        [Route("{idEjercicio}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Ejercicio))]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetEjercicioByIdAsync(int idEjercicio)
        {
            Ejercicio ejercicio = await _dbContext.Set<Ejercicio>()
                                   .Include(x => x.TipoEjercicio)
                                   .FirstOrDefaultAsync(x => x.Id == idEjercicio);

            if (ejercicio == null)
            {
                return NotFound();
            }

            return Ok(ejercicio);
        }

        [HttpDelete]
        [Route("{idEjercicio}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteEjercicioByIdAsync(int idEjercicio)
        {
            Ejercicio ejercicio = await _dbContext.Set<Ejercicio>()
                                   .Include(x => x.TipoEjercicio)
                                   .FirstOrDefaultAsync(x => x.Id == idEjercicio);

            if (ejercicio == null)
            {
                return NotFound();
            }

            _dbContext.Ejercicios.Remove(ejercicio);

            await _dbContext.SaveChangesAsync();

            return Ok();
        }

        [HttpPut]
        [Route("{idEjercicio}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> UpdateEjercicioByIdAsync(int idEjercicio, UpdateEjercicioRequest updateEjercicioRequest)
        {

            bool tipoEjercicioExists = await _dbContext.Set<TipoEjercicio>().AnyAsync(x => x.Id == updateEjercicioRequest.IdTipoEjercicio);

            if (!tipoEjercicioExists)
            {
                return ValidationProblem($"No existe el tipo de ejercicio con id {updateEjercicioRequest.IdTipoEjercicio}.");
            }

            Ejercicio ejercicioActualizar = await _dbContext.Set<Ejercicio>()
                                                        .Where(x => x.Id == idEjercicio)
                                                        .FirstOrDefaultAsync();
            if (ejercicioActualizar == null)
            {
                return NotFound();
            }

            ejercicioActualizar.Nombre = updateEjercicioRequest.Nombre;
            ejercicioActualizar.Descripcion = updateEjercicioRequest.Descripcion;
            ejercicioActualizar.UrlEjercicio = updateEjercicioRequest.UrlEjercicio;
            ejercicioActualizar.IdTipoEjercicio = updateEjercicioRequest.IdTipoEjercicio;

            await _dbContext.SaveChangesAsync();

            return Ok();
        }
    }
}
