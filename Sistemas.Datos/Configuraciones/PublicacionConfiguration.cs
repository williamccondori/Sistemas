using Sistemas.Datos.Shared;
using Sistemas.Entidades;

namespace Sistemas.Datos.Configuraciones
{
    public class PublicacionConfiguration : BaseConfiguration<PublicacionEntity>
    {
        public PublicacionConfiguration()
        {
            ToTable("PUBLICACIONES");
            HasKey(p => new { p.IdPublicacion });
            Property(m => m.IdPublicacion).HasColumnName("ID_PUBLICACION");
            Property(m => m.IdTipoPublicacion).HasColumnName("ID_TIPO_PUBLICACION").HasMaxLength(2);
            Property(m => m.DescripcionTitulo).HasColumnName("DES_TITULO").HasMaxLength(300);
            Property(m => m.DescripcionSubtitulo).HasColumnName("DES_SUBTITULO").HasMaxLength(300);
            Property(m => m.DescripcionResumen).HasColumnName("DES_RESUMEN").HasMaxLength(500);
            Property(m => m.DescripcionResena).HasColumnName("DES_RESENA").HasMaxLength(8000);
            Property(m => m.DescripcionRecurso).HasColumnName("DES_RECURSO").HasMaxLength(300);
            Property(m => m.FechaPublicacion).HasColumnName("FEC_PUBLICACION");
            HasRequired(p => p.TipoPublicacionX).WithMany().HasForeignKey(p => p.IdTipoPublicacion);
            HasMany(p => p.DetallePublicacionS).WithRequired().HasForeignKey(p => p.IdPublicacion);
        }
    }
}
