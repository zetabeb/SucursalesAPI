using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SucursalesAPI.Data;
using SucursalesAPI.Entities;

namespace SucursalesAPI.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class SucursalController : ControllerBase
    {
        private readonly DataContext _context;

        public SucursalController(DataContext context)
        {
            _context = context;
        }
        
        [HttpGet]
        [Route("ObtenerSucursales")]        
        public async Task<ActionResult<List<Sucursal>>> ObtenerSucursales()
        {
            var sucursales = await _context.Sucursales.ToListAsync();

            return Ok(sucursales);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Sucursal>> ObtenerSucursal(int id)
        {
            var sucursal = await _context.Sucursales.FindAsync(id);

            if (sucursal == null)
            {
                return NotFound();
            }

            return sucursal;
        }

        [HttpPost]
        [Route("CrearSucursal")]
        [Authorize(Roles = "admin")]        
        public async Task<ActionResult<Sucursal>> CrearSucursal(Sucursal sucursal)
        {
            _context.Sucursales.Add(sucursal);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(CrearSucursal), new { id = sucursal.id }, sucursal);
        }
        
        [HttpPut("{id}")]
        [Route("ActualizarSucursal/{id}")]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> ActualizarSucursal(int id, Sucursal sucursal)
        {
            if (id != sucursal.id)
            {
                return BadRequest();
            }

            _context.Entry(sucursal).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SucursalExiste(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }
        
        [HttpDelete("{id}")]
        [Route("EliminarSucursal/{id}")]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> EliminarSucursal(int id)
        {
            var sucursal = await _context.Sucursales.FindAsync(id);
            if (sucursal == null)
            {
                return NotFound();
            }

            _context.Sucursales.Remove(sucursal);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SucursalExiste(int id)
        {
            return _context.Sucursales.Any(e => e.id == id);
        }
    }
}
