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
    public class TurnosController : ControllerBase
    {
        private readonly RelaxGymContext _dbContext;
        public TurnosController(RelaxGymContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IList<Turno>))]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> GetAllTurnosAsync()
        {
            IList<Turno> turnos = await _dbContext.Set<Turno>()
                                   .Include(x => x.Clase)
                                   .ToListAsync();

            if (turnos == null)
            {
                return NoContent();
            }

            return Ok(turnos);
        }

        [HttpGet]
        [Route("{idTurno}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Turno))]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetTurnoByIdAsync(int idTurno)
        {
            Turno turno = await _dbContext.Set<Turno>()
                                   .Include(x => x.Clase)
                                   .Include(x => x.Usuarios).ThenInclude(x => x.Usuario)
                                   .FirstOrDefaultAsync(x => x.Id == idTurno);

            if (turno == null)
            {
                return NotFound();
            }

            return Ok(turno);
        }
    }
}
