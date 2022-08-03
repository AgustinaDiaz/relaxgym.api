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
    public class EstadosNotificacionesController : ControllerBase
    {
        private readonly RelaxGymContext _dbContext;
        public EstadosNotificacionesController(RelaxGymContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IList<EstadoNotificacion>))]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> GetAllEstadosNotificacionesAsync()
        {
            IList<EstadoNotificacion> estadosNotificaciones = await _dbContext.Set<EstadoNotificacion>().ToListAsync();

            if (estadosNotificaciones == null)
            {
                return NoContent();
            }

            return Ok(estadosNotificaciones);
        }
    }
}
