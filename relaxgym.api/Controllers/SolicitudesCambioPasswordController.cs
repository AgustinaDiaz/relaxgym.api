using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using relaxgym.api.Entities;
using relaxgym.api.Models;
using relaxgym.api.Repository;
using relaxgym.api.Services;
using System;
using System.Threading.Tasks;

namespace relaxgym.api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class SolicitudesCambioPasswordController : ControllerBase
    {
        private readonly RelaxGymContext _dbContext;
        private readonly IMailSenderService _mailSenderService;
        public SolicitudesCambioPasswordController(RelaxGymContext dbContext,
                                                 IMailSenderService mailSenderService)
        {
            _dbContext = dbContext;
            _mailSenderService = mailSenderService;
        }

        [HttpPost]
        [Route("{emailUsuario}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> SolicitudCambioPasswordAsync(string emailUsuario)
        {
            Usuario usuario = await _dbContext.Set<Usuario>().FirstOrDefaultAsync(x => x.Email == emailUsuario);

            if (usuario == null)
            {
                return ValidationProblem($"No existe el email {emailUsuario} vinculado a alguno de nuestros usuarios.");
            }

            SolicitudCambioPassword solicitudActiva = await _dbContext.Set<SolicitudCambioPassword>()
                                                                      .FirstOrDefaultAsync(x => x.Usuario.Email == emailUsuario && x.IdEstadoSolicitud == (int)Enums.EstadosSolicitud.Activo);

            if (solicitudActiva != null)
            {
                bool sendEmailSolicitudActiva = await _mailSenderService.SendEmailSolicitudCambioPasswordAsync(usuario.Email, usuario.NombreUsuario, solicitudActiva.IdWeb);

                if (!sendEmailSolicitudActiva)
                {
                    return ValidationProblem($"Se creo la solicitud correctamente {solicitudActiva.IdWeb} pero ocurrio un error al enviar el email.");
                }

                return Ok();
            }

            SolicitudCambioPassword nuevaSolicitudCambioPassword = new SolicitudCambioPassword()
            {
                IdWeb = Guid.NewGuid().ToString("N"),
                FechaSolicitud = DateTime.Now,
                IdUsuario = usuario.Id,
                IdEstadoSolicitud = (int)Enums.EstadosSolicitud.Activo
            };

            _dbContext.Attach(nuevaSolicitudCambioPassword);

            await _dbContext.SaveChangesAsync();

            bool sendEmailNuevaSolicitud = await _mailSenderService.SendEmailSolicitudCambioPasswordAsync(usuario.Email, usuario.NombreUsuario, nuevaSolicitudCambioPassword.IdWeb);

            if (!sendEmailNuevaSolicitud)
            {
                return ValidationProblem($"Se creo la solicitud correctamente {nuevaSolicitudCambioPassword.IdWeb} pero ocurrio un error al enviar el email.");
            }

            return Ok();
        }

        [HttpGet]
        [Route("{idWebSolicitud}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(SolicitudCambioPassword))]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetSolicitudCambioPasswordAsync(string idWebSolicitud)
        {
            SolicitudCambioPassword solicitudActiva = await _dbContext.Set<SolicitudCambioPassword>()
                                                                      .Include(x => x.EstadoSolicitud)
                                                                      .Include(x => x.Usuario)
                                                                      .FirstOrDefaultAsync(x => x.IdWeb == idWebSolicitud && x.IdEstadoSolicitud == (int)Enums.EstadosSolicitud.Activo);

            if (solicitudActiva == null)
            {
                return ValidationProblem($"No existe la solicitud de cambio de password con IdWeb {idWebSolicitud}.");
            }

            return Ok(solicitudActiva);
        }

        [HttpPost]
        [Route("Confirmar/{idWebSolicitud}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> ConfirmarSolicitudCambioPasswordAsync(string idWebSolicitud, [FromQuery] string antiguaClave, [FromQuery] string nuevaClave)
        {
            SolicitudCambioPassword solicitudActiva = await _dbContext.Set<SolicitudCambioPassword>().FirstOrDefaultAsync(x => x.IdWeb == idWebSolicitud && x.IdEstadoSolicitud == (int)Enums.EstadosSolicitud.Activo);

            if (solicitudActiva == null)
            {
                return ValidationProblem($"No existe la solicitud de cambio de password con IdWeb {idWebSolicitud}.");
            }

            Usuario usuario = await _dbContext.Set<Usuario>().FirstOrDefaultAsync(x => x.Id == solicitudActiva.IdUsuario);

            if (!(usuario.ClaveUsuario == antiguaClave))
            {
                return ValidationProblem($"La antigua clave ingresada no coincide con la clave del usuario vinculado a la solicitud de cambio de password {idWebSolicitud}.");
            }

            solicitudActiva.AntiguaClave = antiguaClave;
            solicitudActiva.NuevaClave = nuevaClave;
            solicitudActiva.FechaConfirmacion = DateTime.Now;
            solicitudActiva.IdEstadoSolicitud = (int)Enums.EstadosSolicitud.Finalizado;

            usuario.ClaveUsuario = nuevaClave;

            await _dbContext.SaveChangesAsync();

            return Ok();
        }
    }
}
