namespace SucursalesAPI.Models
{
    public class UsuarioModels
    {
        public string correo {  get; set; }
        public string clave { get; set; }
        public string? rol { get; set; }
    }
    public static class Roles
    {
        public const string ADMIN = "Admin";
        public const string USER = "User";
    }
}
