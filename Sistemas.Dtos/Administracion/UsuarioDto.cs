using Sistemas.Dtos.Shared;

namespace Sistemas.Dtos.Administracion
{
    public class UsuarioDto : BaseDto
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Email { get; set; }
        public string Imagen { get; set; }
        public bool Habilitado { get; set; }
    }
}
