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

        public static UsuarioEntity Crear(string descripcionUsuario, string descripcionPassword, string descripcionNombre
            , string descripcionApellido, string descripcionEmail, string descripcionRecurso, string usuario)
        {
            UsuarioEntity usuario_ = new UsuarioEntity
            {
                DescripcionUsuario = descripcionUsuario,
                DescripcionPassword = descripcionPassword,
                DescripcionNombre = descripcionNombre,
                DescripcionApellido = descripcionApellido,
                DescripcionEmail = descripcionEmail,
                DescripcionRecurso = descripcionRecurso,
                IndicadorHabilitado = EstadoEntidad.Si
            };

            usuario_.Nuevo(usuario);

            return usuario_;
        }
    }
}
