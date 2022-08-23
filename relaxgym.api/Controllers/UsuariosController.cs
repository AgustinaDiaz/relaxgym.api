using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using relaxgym.api.Entities;
using relaxgym.api.Models;
using relaxgym.api.Repository;
using relaxgym.api.Requests;
using relaxgym.api.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace relaxgym.api.Controllers
{
    [Authorize]
    [Route("[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        private readonly RelaxGymContext _dbContext;
        private readonly IUsuariosService _usuarioService;
        public UsuariosController(IUsuariosService usuarioService,
                                  RelaxGymContext dbContext)
        {
            _usuarioService = usuarioService;
            _dbContext = dbContext;
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("Login")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(UserToken))]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> AuthenticateAsync(LoginRequest loginRequest)
        {
            Usuario usuario = await _dbContext.Set<Usuario>()
                                   .Include(x => x.EstadoUsuario)
                                   .Include(x => x.Rol)
                                   .FirstOrDefaultAsync(x => x.NombreUsuario == loginRequest.NombreUsuario && x.ClaveUsuario == loginRequest.ClaveUsuario);

            if (usuario == null)
            {
                return ValidationProblem($"El Usuario/Password son incorrectos.");
            }

            UserToken token = _usuarioService.Authenticate(usuario);

            return Ok(token);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreateUsuarioAsync(CreateUsuarioRequest createUsuarioRequest)
        {
            Usuario nuevoUsuario = new Usuario()
            {
                IdWeb = Guid.NewGuid().ToString("N"),
                Nombre = createUsuarioRequest.Nombre,
                Apellido = createUsuarioRequest.Apellido,
                Email = createUsuarioRequest.Email,
                Telefono = createUsuarioRequest.Telefono,
                NombreUsuario = createUsuarioRequest.NombreUsuario,
                ClaveUsuario = createUsuarioRequest.ClaveUsuario,
                IdEstadoUsuario = createUsuarioRequest.IdEstadoUsuario,
                IdRol = createUsuarioRequest.IdRol,
                FechaAlta = DateTime.Now
            };

            _dbContext.Attach(nuevoUsuario);

            await _dbContext.SaveChangesAsync();

            return Ok();
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IList<Usuario>))]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> GetAllUsuariosAsync()
        {
            IList<Usuario> usuarios = await _dbContext.Set<Usuario>()
                                   .Include(x => x.EstadoUsuario)
                                   .Include(x => x.Rol)
                                   .ToListAsync();

            if (usuarios == null)
            {
                return NoContent();
            }

            return Ok(usuarios);
        }

        [HttpGet]
        [Route("{idUsuario}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Usuario))]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetUsuarioByIdAsync(int idUsuario)
        {
            Usuario usuario = await _dbContext.Set<Usuario>()
                                   .Include(x => x.EstadoUsuario)
                                   .Include(x => x.Rol)
                                   .FirstOrDefaultAsync(x => x.Id == idUsuario);

            if (usuario == null)
            {
                return NotFound();
            }

            return Ok(usuario);
        }

        [HttpGet]
        [Route("Rol/{idRol}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IList<Usuario>))]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetUsuarioByIdRolAsync(int idRol)
        {
            IList<Usuario> usuarios = await _dbContext.Set<Usuario>()
                                   .Include(x => x.EstadoUsuario)
                                   .Include(x => x.Rol)
                                   .Where(x => x.IdRol == idRol && x.IdEstadoUsuario == (int)Enums.EstadosUsuario.Activo)
                                   .ToListAsync();

            if (usuarios == null)
            {
                return NotFound();
            }

            return Ok(usuarios);
        }

        [HttpGet]
        [Route("Rol/{idRol}/Rutina/{idRutina}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IList<Usuario>))]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetUsuarioByIdRolForRutinaAsync(int idRol, int idRutina)
        {
            IList<Usuario> usuarios = await _dbContext.Set<Usuario>()
                                   .Include(x => x.EstadoUsuario)
                                   .Include(x => x.Rol)
                                   .Where(x => x.IdRol == idRol && x.IdEstadoUsuario == (int)Enums.EstadosUsuario.Activo && !x.Rutinas.Any(x => x.IdRutina == idRutina))
                                   .ToListAsync();

            if (usuarios == null)
            {
                return NotFound();
            }

            return Ok(usuarios);
        }

        [HttpGet]
        [Route("Rol/{idRol}/Turno/{idTurno}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IList<Usuario>))]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetUsuarioByIdRolForTurnoAsync(int idRol, int idTurno)
        {
            IList<Usuario> usuarios = await _dbContext.Set<Usuario>()
                                   .Include(x => x.EstadoUsuario)
                                   .Include(x => x.Rol)
                                   .Where(x => x.IdRol == idRol && x.IdEstadoUsuario == (int)Enums.EstadosUsuario.Activo && !x.Turnos.Any(x => x.IdTurno == idTurno))
                                   .ToListAsync();

            if (usuarios == null)
            {
                return NotFound();
            }

            return Ok(usuarios);
        }

        [HttpDelete]
        [Route("{idUsuario}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Usuario))]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteUsuarioByIdAsync(int idUsuario)
        {
            Usuario usuario = await _dbContext.Set<Usuario>()
                                    .Include(x => x.Rutinas)
                                    .Include(x => x.Turnos)
                                    .FirstOrDefaultAsync(x => x.Id == idUsuario);

            if (usuario == null)
            {
                return NotFound();
            }

            foreach (UsuarioRutina usuarioRutina in usuario.Rutinas)
            {
                _dbContext.UsuariosRutinas.Remove(usuarioRutina);
            }

            foreach (UsuarioTurno usuarioTurno in usuario.Turnos)
            {
                _dbContext.UsuariosTurnos.Remove(usuarioTurno);
            }

            _dbContext.Usuarios.Remove(usuario);

            await _dbContext.SaveChangesAsync();

            return Ok();
        }

        [HttpPut]
        [Route("{idUsuario}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> UpdateUsuarioByIdAsync(int idUsuario, UpdateUsuarioRequest updateUsuarioRequest)
        {
            bool estadoActualizarExists = await _dbContext.Set<EstadoUsuario>().AnyAsync(x => x.Id == updateUsuarioRequest.IdEstadoUsuario);

            if (!estadoActualizarExists)
            {
                return ValidationProblem($"No existe el estado usuario con id {updateUsuarioRequest.IdEstadoUsuario}.");
            }

            bool rolExists = await _dbContext.Set<Rol>().AnyAsync(x => x.Id == updateUsuarioRequest.IdRol);

            if (!rolExists)
            {
                return ValidationProblem($"No existe el rol con id {updateUsuarioRequest.IdRol}.");
            }

            Usuario usuarioActualizar = await _dbContext.Set<Usuario>()
                                                        .Where(x => x.Id == idUsuario)
                                                        .FirstOrDefaultAsync();
            if (usuarioActualizar == null)
            {
                return NotFound();
            }

            usuarioActualizar.Nombre = updateUsuarioRequest.Nombre;
            usuarioActualizar.Apellido = updateUsuarioRequest.Apellido;
            usuarioActualizar.Email = updateUsuarioRequest.Email;
            usuarioActualizar.Telefono = updateUsuarioRequest.Telefono;
            usuarioActualizar.NombreUsuario = updateUsuarioRequest.NombreUsuario;
            usuarioActualizar.ClaveUsuario = updateUsuarioRequest.ClaveUsuario;
            usuarioActualizar.IdEstadoUsuario = updateUsuarioRequest.IdEstadoUsuario;
            usuarioActualizar.IdRol = updateUsuarioRequest.IdRol;

            await _dbContext.SaveChangesAsync();

            return Ok();
        }
    }
}
