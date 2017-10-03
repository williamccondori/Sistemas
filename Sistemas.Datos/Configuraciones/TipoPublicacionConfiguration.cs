using Sistemas.Datos.Shared;
using Sistemas.Entidades;

namespace Sistemas.Datos.Configuraciones
{
    public class TipoPublicacionConfiguration : BaseConfiguration<TipoPublicacionEntity>
    {
        public TipoPublicacionConfiguration()
        {
            ToTable("TIPOS_PUBLICACION");
            HasKey(m => new { m.IdTipoPublicacion });
            Property(m => m.IdTipoPublicacion).HasColumnName("ID_TIPO_PUBLICACION").HasMaxLength(2);
            Property(m => m.DescripcionTipoPublicacion).HasColumnName("DES_TIPO_PUBLICACION").HasMaxLength(100);
        }
    }
}
