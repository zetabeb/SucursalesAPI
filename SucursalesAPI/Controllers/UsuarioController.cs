using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SucursalesAPI.Data;
using SucursalesAPI.Entities;
using SucursalesAPI.Models;

namespace SucursalesAPI.Controllers
{
    [Authorize(Roles = "admin")]
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : Controller
    {
        private readonly DataContext _context;

        public UsuarioController(DataContext context)
        {
            _context = context;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Usuario>> GetUsuario(int id)
        {
            var usuario = await _context.Usuarios.FindAsync(id);

            if (usuario == null)
            {
                return NotFound();
            }

            return usuario;
        }

        [HttpGet]
        [Route("ObtenerUsuarios")]
        public async Task<ActionResult<List<Sucursal>>> GetUsuarios()
        {
            var usuarios = await _context.Usuarios.ToListAsync();

            return Ok(usuarios);
        }

        [HttpPost]
        [Route("CrearUsuario")]
        public async Task<ActionResult<Usuario>> PostUsuario(UsuarioModel usuarioModel)
        {
            Usuario usuario = new Usuario();
            usuario.nombre = usuarioModel.nombre;
            usuario.email = usuarioModel.email;
            usuario.rol = usuarioModel.rol;
            usuario.clave = usuarioModel.clave;
            usuario.fechaCreacion = new DateOnly(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
            usuario.fechaUltimaActualizacion = new DateOnly(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
            if (_context.Usuarios.SingleOrDefault(u => u.email == usuarioModel.email) != null)
            {
                var error = new { Mensaje = "Ya existe un usuario con el mismo email" };
                return Conflict(error);
            }
            _context.Usuarios.Add(usuario);
            await _context.SaveChangesAsync();
            //TODO: Se debe agregar una tabla de auditoria que indique este evento
            return CreatedAtAction(nameof(GetUsuario), new { id = usuario.id }, usuario);
        }
        
        [HttpPut]
        [Route("ActualizarUsuario/{id}")]
        public async Task<IActionResult> PutUsuario(int id, UsuarioModel usuarioModel)
        {
            var usuario = await _context.Usuarios.FindAsync(id);

            if (usuario == null)
            {
                return NotFound();
            }

            if (usuario.nombre == usuarioModel.nombre &&
            usuario.email == usuarioModel.email &&
            usuario.rol == usuarioModel.rol &&
            usuario.clave == usuarioModel.clave)
            {

                var error = new { Mensaje = "No se ha realizado actualización. Los datos son iguales." };
                return BadRequest(error);
            }
            else
            {
                usuario.nombre = usuarioModel.nombre;
                usuario.email = usuarioModel.email;
                usuario.rol = usuarioModel.rol;
                usuario.clave = usuarioModel.clave;
                usuario.fechaUltimaActualizacion = new DateOnly(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
            }

            _context.Entry(usuario).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
                //TODO: Se debe agregar una tabla de auditoria que indique este evento
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UsuarioExiste(id))
                {
                    return BadRequest();
                }
                else
                {
                    throw;
                }
            }
            var ok = new { Mensaje = "Usuario Actualizado con éxito" };
            return Ok(ok);
        }

        [HttpDelete]
        [Route("EliminarUsuario/{id}")]
        public async Task<IActionResult> DeleteUsuario(int id)
        {
            var usuario = await _context.Usuarios.FindAsync(id);
            if (usuario == null)
            {
                return NotFound();
            }

            _context.Usuarios.Remove(usuario);
            await _context.SaveChangesAsync();
            //TODO: Se debe agregar una tabla de auditoria que indique este evento

            var ok = new { Mensaje = "Usuario id = " + id + " ha sido eliminado" };
            return Ok(ok);
        }

        private bool UsuarioExiste(int id)
        {
            return _context.Usuarios.Any(e => e.id == id);
        }
    }
}

