using Sistemas.Datos.Shared;
using Sistemas.Entidades;

namespace Sistemas.Datos.Configuraciones
{
    public class ResenaConfiguration : BaseConfiguration<ResenaEntity>
    {
        public ResenaConfiguration()
        {
            ToTable("RESENAS");
            HasKey(p => new { p.IdResena });
            Property(p => p.IdResena).HasColumnName("ID_RESENA");
            Property(p => p.IdTipoResena).HasColumnName("ID_TIPO_RESENA").HasMaxLength(2);
            Property(p => p.IdAutorResena).HasColumnName("ID_AUTOR_RESENA");
            Property(p => p.DescripcionTitulo).HasColumnName("DES_TITULO").HasMaxLength(300);
            Property(p => p.DescripcionSubtitulo).HasColumnName("DES_SUBTITULO").HasMaxLength(300);
            Property(p => p.DescripcionResumen).HasColumnName("DES_RESUMEN").HasMaxLength(500);
            Property(p => p.DescripcionResena).HasColumnName("DES_RESENA").HasMaxLength(8000);
            Property(p => p.DescripcionRecurso).HasColumnName("DES_RECURSO").HasMaxLength(300);
            HasRequired(p => p.TipoResenaX).WithMany().HasForeignKey(p => p.IdTipoResena);
            HasRequired(p => p.AutorResenaX).WithMany().HasForeignKey(p => p.IdAutorResena);
        }
    }
}
