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
    public class NotificacionesController : ControllerBase
    {
        private readonly RelaxGymContext _dbContext;
        public NotificacionesController(RelaxGymContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IList<Notificacion>))]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> GetAllNotificacionesAsync()
        {
            IList<Notificacion> notificaciones = await _dbContext.Set<Notificacion>()
                                   .ToListAsync();

            if (notificaciones == null)
            {
                return NoContent();
            }

            return Ok(notificaciones);
        }
    }
}
