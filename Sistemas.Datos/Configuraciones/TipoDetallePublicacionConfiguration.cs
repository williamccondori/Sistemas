using Sistemas.Datos.Shared;
using Sistemas.Entidades;

namespace Sistemas.Datos.Configuraciones
{
    public class TipoDetallePublicacionConfiguration : BaseConfiguration<TipoDetallePublicacionEntity>
    {
        public TipoDetallePublicacionConfiguration()
        {
            ToTable("TIPOS_DETALLE_PUBLICACION");
            HasKey(m => new { m.IdTipoDetallePublicacion });
            Property(m => m.IdTipoDetallePublicacion).HasColumnName("ID_TIPO_DETALLE_PUBLICACION").HasMaxLength(2);
            Property(m => m.DescripcionTipoDetallePublicacion).HasColumnName("DES_TIPO_DETALLE_PUBLICACION").HasMaxLength(100);
        }
    }
}
