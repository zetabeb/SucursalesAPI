namespace SucursalesAPI.Models
{
    public class SucursalModel
    {
        public string nombre { get; set; }
        public string direccion { get; set; }
        public string telefono { get; set; }
        public string email { get; set; }
        public string horarioAtencion { get; set; } // TODO: podría agregarse una tabla que contenga los distitos horarios de atención
        public string gerenteSucursal { get; set; } // TODO: Se debe crear una tabla que contenga las personas (según normalización) y sus cargos, dejando acá el ID del gerente asignado
        public string tipoMoneda { get; set; }
    }
}
