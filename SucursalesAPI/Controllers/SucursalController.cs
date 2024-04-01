using Azure.Core;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SucursalesAPI.Data;
using SucursalesAPI.Entities;
using SucursalesAPI.Models;

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
        public async Task<ActionResult<Sucursal>> CrearSucursal(SucursalModel sucursalModel)
        {
            Sucursal sucursal = new Sucursal();
            sucursal.nombre = sucursalModel.nombre;
            sucursal.direccion = sucursalModel.direccion;
            sucursal.telefono = sucursalModel.telefono;
            sucursal.email = sucursalModel.email;
            sucursal.horarioAtencion = sucursalModel.horarioAtencion;
            sucursal.gerenteSucursal = sucursalModel.gerenteSucursal;
            sucursal.tipoMoneda = sucursalModel.tipoMoneda;
            sucursal.fechaCreacion = new DateOnly(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
            sucursal.fechaUltimaActualizacion = new DateOnly(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);

            if (_context.Sucursales.SingleOrDefault(u => u.nombre == sucursalModel.nombre) != null)
            {
                var error = new { Mensaje = "Ya existe una sucursal con el mismo nombre" };
                return Conflict(error);
            }
            _context.Sucursales.Add(sucursal);
            await _context.SaveChangesAsync();            
            
            //TODO: Se debe agregar una tabla de auditoria que indique este evento
            return CreatedAtAction(nameof(CrearSucursal), new { id = sucursal.id }, sucursal);
        }
        
        [HttpPut("{id}")]
        [Route("ActualizarSucursal/{id}")]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> ActualizarSucursal(int id, SucursalModel sucursalModel)
        {
            var sucursal = await _context.Sucursales.FindAsync(id);

            if (sucursal == null)
            {
                return NotFound();
            }
            
            if(sucursal.nombre == sucursalModel.nombre &
            sucursal.direccion == sucursalModel.direccion &
            sucursal.telefono == sucursalModel.telefono &
            sucursal.email == sucursalModel.email &
            sucursal.horarioAtencion == sucursalModel.horarioAtencion &
            sucursal.gerenteSucursal == sucursalModel.gerenteSucursal &
            sucursal.tipoMoneda == sucursalModel.tipoMoneda)
            {
                
                var error = new { Mensaje = "No se ha realizado actualización. Los datos son iguales." };
                return BadRequest(error);
            }
            else
            {
                sucursal.nombre = sucursalModel.nombre;
                sucursal.direccion = sucursalModel.direccion;
                sucursal.telefono = sucursalModel.telefono;
                sucursal.email = sucursalModel.email;
                sucursal.horarioAtencion = sucursalModel.horarioAtencion;
                sucursal.gerenteSucursal = sucursalModel.gerenteSucursal;
                sucursal.tipoMoneda = sucursalModel.tipoMoneda;
                sucursal.fechaUltimaActualizacion = new DateOnly(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
            }

            _context.Entry(sucursal).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
                //TODO: Se debe agregar una tabla de auditoria que indique este evento
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SucursalExiste(id))
                {
                    return BadRequest();
                }
                else
                {
                    throw;
                }
            }
            var ok = new { Mensaje = "Sucursal Actualizada con éxito" };
            return Ok(ok);
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
            //TODO: Se debe agregar una tabla de auditoria que indique este evento

            var ok = new { Mensaje = "Registro id =" + id + " ha sido eliminado" };
            return Ok(ok);
        }

        private bool SucursalExiste(int id)
        {
            return _context.Sucursales.Any(e => e.id == id);
        }
    }
}
