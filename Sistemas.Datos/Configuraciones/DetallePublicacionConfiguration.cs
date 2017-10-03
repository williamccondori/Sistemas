using Sistemas.Datos.Shared;
using Sistemas.Entidades;

namespace Sistemas.Datos.Configuraciones
{
    public class DetallePublicacionConfiguration : BaseConfiguration<DetallePublicacionEntity>
    {
        public DetallePublicacionConfiguration()
        {
            ToTable("DETALLES_PUBLICACION");
            HasKey(p => new { p.IdDetallePublicacion });
            Property(p => p.IdDetallePublicacion).HasColumnName("ID_DETALLE_PUBLICACION");
            Property(m => m.IdPublicacion).HasColumnName("ID_PUBLICACION");
            Property(m => m.IdTipoDetallePublicacion).HasColumnName("ID_TIPO_DETALLE_PUBLICACION").HasMaxLength(2);
            Property(m => m.DescripcionTitulo).HasColumnName("DES_TITULO").HasMaxLength(300);
            Property(m => m.DescripcionResumen).HasColumnName("DES_RESUMEN").HasMaxLength(500);
            Property(m => m.DescripcionRecurso).HasColumnName("DES_RECURSO").HasMaxLength(300);
            HasRequired(p => p.PublicacionX).WithMany().HasForeignKey(p => p.IdPublicacion);
            HasRequired(p => p.TipoDetallePublicacionX).WithMany().HasForeignKey(p => p.IdTipoDetallePublicacion);
        }
    }
}
