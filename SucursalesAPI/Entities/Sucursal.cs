namespace SucursalesAPI.Entities
{
    public class Sucursal
    {
        public int id { get; set; }
        public string nombre { get; set; }
        public string direccion { get; set; }
        public string telefono { get; set; }
        public string email { get; set; }
        public string horarioAtencion { get; set; }
        public string gerenteSucursal { get; set; }
        public short tipoMoneda { get; set; }
        public DateOnly fechaCreacion { get; set; }
        public DateOnly fechaUltimaActualizacion { get; set; }
    }
}
