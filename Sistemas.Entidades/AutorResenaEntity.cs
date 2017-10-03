using Sistemas.Entidades.Shared;

namespace Sistemas.Entidades
{
    public class AutorResenaEntity : BaseEntity
    {
        public long IdAutorResena { get; set; }
        public int IdGradoAcademico { get; set; }
        public string DescripcionNombre { get; set; }
        public string DescripcionApellido { get; set; }
        public string DescripcionCargo { get; set; }
        public string DescripcionRecurso { get; set; }
        public GradoAcademicoEntity GradoAcademicoX { get; set; }

        public static AutorResenaEntity Crear(int idGradoAcademico, string descripcionNombre, string descripcionApellido
            , string descripcionCargo, string descripcionRecurso, string usuario)
        {
            AutorResenaEntity autorResena = new AutorResenaEntity
            {
                DescripcionApellido = descripcionApellido,
                DescripcionCargo = descripcionCargo,
                DescripcionNombre = descripcionNombre,
                DescripcionRecurso = descripcionRecurso,
                IdGradoAcademico = idGradoAcademico
            };

            autorResena.Nuevo(usuario);

            return autorResena;
        }
    }
}
