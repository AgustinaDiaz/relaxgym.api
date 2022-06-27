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
    public class RolesController : ControllerBase
    {
        private RelaxGymContext _dbContext;

        public RolesController(RelaxGymContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IList<Rol>))]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> GetAsync()
        {
            IList<Rol> estadosUsuario = await _dbContext.Roles.ToListAsync();

            if (estadosUsuario == null)
            {
                return NoContent();
            }

            return Ok(estadosUsuario);
        }
    }
}
