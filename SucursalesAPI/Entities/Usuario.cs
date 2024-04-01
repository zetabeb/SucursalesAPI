namespace SucursalesAPI.Entities
{
    public class Usuario
    {
        public int id { get; set; }
        public string nombre { get; set; }                
        public string email { get; set; }
        public string clave { get; set; }
        public DateOnly fechaCreacion { get; set; }
        public DateOnly fechaUltimaActualizacion { get; set; }
        public string rol {  get; set; }
    }
}
