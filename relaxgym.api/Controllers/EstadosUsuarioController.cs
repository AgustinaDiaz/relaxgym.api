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
    public class EstadosUsuarioController : ControllerBase
    {
        private RelaxGymContext _dbContext;
        public EstadosUsuarioController(RelaxGymContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IList<EstadoUsuario>))]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> GetAllEstadosUsuarioAsync()
        {
            IList<EstadoUsuario> estadosUsuario = await _dbContext.Set<EstadoUsuario>().ToListAsync();

            if (estadosUsuario == null)
            {
                return NoContent();
            }

            return Ok(estadosUsuario);
        }
    }
}