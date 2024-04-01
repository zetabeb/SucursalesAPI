using Microsoft.EntityFrameworkCore;
using SucursalesAPI.Entities;

namespace SucursalesAPI.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) 
        {
        }
        public DbSet<Sucursal> Sucursales { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
    }
}
