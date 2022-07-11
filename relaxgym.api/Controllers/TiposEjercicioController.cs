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
    public class TiposEjercicioController : ControllerBase
    {
        private readonly RelaxGymContext _dbContext;
        public TiposEjercicioController(RelaxGymContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IList<TipoEjercicio>))]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> GetAllTiposEjercicioAsync()
        {
            IList<TipoEjercicio> tiposEjercicio = await _dbContext.Set<TipoEjercicio>().ToListAsync();

            if (tiposEjercicio == null)
            {
                return NoContent();
            }

            return Ok(tiposEjercicio);
        }
    }
}
