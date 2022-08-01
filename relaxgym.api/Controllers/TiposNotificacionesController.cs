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
    public class TiposNotificacionesController : ControllerBase
    {
        private readonly RelaxGymContext _dbContext;
        public TiposNotificacionesController(RelaxGymContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IList<TipoNotificacion>))]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> GetAllTiposNotificacionesAsync()
        {
            IList<TipoNotificacion> tiposNotificaciones = await _dbContext.Set<TipoNotificacion>().ToListAsync();

            if (tiposNotificaciones == null)
            {
                return NoContent();
            }

            return Ok(tiposNotificaciones);
        }
    }
}
