using Sistemas.Datos.Shared;
using Sistemas.Entidades;

namespace Sistemas.Datos.Configuraciones
{
    public class TipoResenaConfiguration : BaseConfiguration<TipoResenaEntity>
    {
        public TipoResenaConfiguration()
        {
            ToTable("TIPOS_RESENA");
            HasKey(m => new { m.IdTipoResena });
            Property(m => m.IdTipoResena).HasColumnName("ID_TIPO_RESENA").HasMaxLength(2);
            Property(m => m.DescripcionTipoResena).HasColumnName("DES_TIPO_RESENA").HasMaxLength(100);
        }
    }
}
