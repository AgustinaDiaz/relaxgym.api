using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using relaxgym.api.Entities;
using relaxgym.api.Models;
using relaxgym.api.Models.Requests;
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
    public class NotificacionesController : ControllerBase
    {
        private readonly RelaxGymContext _dbContext;
        public NotificacionesController(RelaxGymContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpPut]
        [Route("{idNotificacion}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> UpdateNotificacionByIdAsync(int idNotificacion, UpdateNotificacionRequest updateNotificacionRequest)
        {
            bool estadoActualizarExists = await _dbContext.Set<EstadoNotificacion>().AnyAsync(x => x.Id == updateNotificacionRequest.IdEstadoNotificacion);

            if (!estadoActualizarExists)
            {
                return ValidationProblem($"No existe el estado notificacion con id {updateNotificacionRequest.IdEstadoNotificacion}.");
            }

            bool tipoNotificacionExists = await _dbContext.Set<TipoNotificacion>().AnyAsync(x => x.Id == updateNotificacionRequest.IdTipoNotificacion);

            if (!tipoNotificacionExists)
            {
                return ValidationProblem($"No existe el tipo notificacion con id {updateNotificacionRequest.IdTipoNotificacion}.");
            }

            Notificacion notificacionActualizar = await _dbContext.Set<Notificacion>()
                                                        .Where(x => x.Id == idNotificacion)
                                                        .FirstOrDefaultAsync();
            if (notificacionActualizar == null)
            {
                return NotFound();
            }

            notificacionActualizar.Titulo = updateNotificacionRequest.Titulo;
            notificacionActualizar.Descripcion = updateNotificacionRequest.Descripcion;
            notificacionActualizar.IdEstadoNotificacion = updateNotificacionRequest.IdEstadoNotificacion;
            notificacionActualizar.IdTipoNotificacion = updateNotificacionRequest.IdTipoNotificacion;

            await _dbContext.SaveChangesAsync();

            return Ok();
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreateNotificacionAsync(CreateNotificacionRequest createNotificacionRequest)
        {
            EstadoNotificacion estadoNotificacionEnviada = await _dbContext.Set<EstadoNotificacion>()
                                                               .FirstOrDefaultAsync(x => x.Id == (int)Enums.EstadosNotifiacion.Enviada);

            TipoNotificacion tipoNotificacion = await _dbContext.Set<TipoNotificacion>()
                                                               .FirstOrDefaultAsync(x => x.Id == createNotificacionRequest.IdTipoNotificacion);

            if (tipoNotificacion == null)
            {
                return ValidationProblem($"No existe el Tipo de Notificacion con id {tipoNotificacion.Id}.");
            }

            Notificacion notificacion = new Notificacion()
            {
                IdWeb = Guid.NewGuid().ToString("N"),
                Titulo = createNotificacionRequest.Titulo,
                Descripcion = createNotificacionRequest.Descripcion,
                EstadoNotificacion = estadoNotificacionEnviada,
                TipoNotificacion = tipoNotificacion
            };


            _dbContext.Attach(notificacion);

            await _dbContext.SaveChangesAsync();

            foreach (int idUsuario in createNotificacionRequest.IdUsuarios)
            {
                Usuario usuarioAsignar = await _dbContext.Set<Usuario>().FirstOrDefaultAsync(x => x.Id == idUsuario);

                if (usuarioAsignar == null)
                {
                    continue;
                }

                UsuarioNotificacion nuevoUsuarioNotificacion = new UsuarioNotificacion()
                {
                    Notificacion = notificacion,
                    Usuario = usuarioAsignar,
                };

                _dbContext.Attach(nuevoUsuarioNotificacion);
            }

            await _dbContext.SaveChangesAsync();

            return Ok();
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IList<Notificacion>))]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> GetAllNotificacionesAsync()
        {
            IList<Notificacion> notificaciones = await _dbContext.Set<Notificacion>()
                                                                    .Include(x => x.EstadoNotificacion)
                                                                    .Include(x => x.TipoNotificacion)
                                                                    .ToListAsync();

            if (notificaciones == null)
            {
                return NoContent();
            }

            return Ok(notificaciones);
        }

        [HttpGet]
        [Route("Usuario/{idUsuario}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IList<Notificacion>))]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetNotificacionByIdUsuarioAsync(int idUsuario)
        {
            IList<Notificacion> notificaciones = await _dbContext.Set<Notificacion>()
                                   .Include(x => x.EstadoNotificacion)
                                   .Include(x => x.TipoNotificacion)
                                   .Where(x => x.Usuarios.Any(x => x.IdUsuario == idUsuario))
                                   .ToListAsync();


            if (notificaciones == null)
            {
                return NotFound();
            }

            return Ok(notificaciones);
        }

    }
}
