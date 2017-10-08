using Sistemas.Entidades.Shared;

namespace Sistemas.Entidades
{
    public class GradoAcademicoEntity : BaseEntity
    {
        public int IdGradoAcademico { get; set; }
        public string DescripcionTitulo { get; set; }
        public string DescripcionAbreviatura { get; set; }

        public static GradoAcademicoEntity Crear(string descripcionTitulo, string descripcionAbreviatura, string usuario)
        {
            GradoAcademicoEntity gradoAcademico = new GradoAcademicoEntity
            {
                DescripcionTitulo = descripcionTitulo,
                DescripcionAbreviatura = descripcionAbreviatura
            };

            gradoAcademico.Nuevo(usuario);

            return gradoAcademico;
        }

        public void Modificar(string titulo, string abreviatura, string usuario)
        {
            DescripcionTitulo = titulo;
            DescripcionAbreviatura = abreviatura;
            Modificado(usuario);
        }
    }
}
