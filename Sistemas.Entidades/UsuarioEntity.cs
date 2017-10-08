using Sistemas.Entidades.Shared;
using Sistemas.Utilidades.Constantes;

namespace Sistemas.Entidades
{
    public class UsuarioEntity : BaseEntity
    {
        public int IdUsuario { get; set; }
        public string DescripcionUsuario { get; set; }
        public string DescripcionPassword { get; set; }
        public string DescripcionNombre { get; set; }
        public string DescripcionApellido { get; set; }
        public string DescripcionEmail { get; set; }
        public string DescripcionRecurso { get; set; }
        public string IndicadorHabilitado { get; set; }

        public static UsuarioEntity Crear(string username, string password, string nombre
            , string apellido, string email, string imagen, string usuario)
        {
            UsuarioEntity usuario_ = new UsuarioEntity
            {
                DescripcionUsuario = username,
                DescripcionPassword = password,
                DescripcionNombre = nombre,
                DescripcionApellido = apellido,
                DescripcionEmail = email,
                DescripcionRecurso = imagen,
                IndicadorHabilitado = EstadoEntidad.Si
            };

            usuario_.Nuevo(usuario);

            return usuario_;
        }

        public void Modificar(string username, string nombre, string apellido, string email, string imagen, string usuario)
        {
            DescripcionUsuario = username;
            DescripcionNombre = nombre;
            DescripcionApellido = apellido;
            DescripcionEmail = email;
            DescripcionRecurso = imagen;
            Modificado(usuario);
        }
    }
}
