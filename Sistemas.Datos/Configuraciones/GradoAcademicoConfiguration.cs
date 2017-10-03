using Sistemas.Datos.Shared;
using Sistemas.Entidades;

namespace Sistemas.Datos.Configuraciones
{
    public class GradoAcademicoConfiguration : BaseConfiguration<GradoAcademicoEntity>
    {
        public GradoAcademicoConfiguration()
        {
            ToTable("GRADOS_ACADEMICOS");
            HasKey(p => new { p.IdGradoAcademico });
            Property(m => m.IdGradoAcademico).HasColumnName("ID_GRADO_ACADEMICO");
            Property(m => m.DescripcionTitulo).HasColumnName("DES_TITULO").HasMaxLength(100);
            Property(m => m.DescripcionAbreviatura).HasColumnName("DES_ABREVIATURA").HasMaxLength(5);
        }
    }
}
