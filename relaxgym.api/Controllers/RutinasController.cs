using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using relaxgym.api.Entities;
using relaxgym.api.Repository;
using System.Collections.Generic;
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

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IList<Rutina>))]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> GetAllEjerciciosAsync()
        {
            IList<Rutina> rutinas = await _dbContext.Set<Rutina>()
                                   .Include(x => x.Ejercicios).ThenInclude(x => x.Ejercicio).ThenInclude(x => x.TipoEjercicio)
                                   .ToListAsync();

            if (rutinas == null)
            {
                return NoContent();
            }

            return Ok(rutinas);
        }
    }
}
