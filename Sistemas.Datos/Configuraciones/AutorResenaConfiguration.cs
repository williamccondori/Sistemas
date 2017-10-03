using Sistemas.Datos.Shared;
using Sistemas.Entidades;

namespace Sistemas.Datos.Configuraciones
{
    public class AutorResenaConfiguration : BaseConfiguration<AutorResenaEntity>
    {
        public AutorResenaConfiguration()
        {
            ToTable("AUTORES_RESENA");
            HasKey(p => new { p.IdAutorResena });
            Property(m => m.IdAutorResena).HasColumnName("ID_AUTOR_RESENA");
            Property(m => m.IdGradoAcademico).HasColumnName("ID_GRADO_ACADEMICO");
            Property(m => m.DescripcionNombre).HasColumnName("DES_NOMBRE").HasMaxLength(100);
            Property(m => m.DescripcionApellido).HasColumnName("DES_APELLIDO").HasMaxLength(100);
            Property(m => m.DescripcionCargo).HasColumnName("DES_CARGO").HasMaxLength(100);
            Property(m => m.DescripcionRecurso).HasColumnName("DES_RECURSO").HasMaxLength(300);
            HasRequired(p => p.GradoAcademicoX).WithMany().HasForeignKey(p => p.IdGradoAcademico);
        }
    }
}
