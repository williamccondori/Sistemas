using Sistemas.Datos.Shared;
using Sistemas.Entidades;

namespace Sistemas.Datos.Configuraciones
{
    public class CanalConfiguration : BaseConfiguration<CanalEntity>
    {
        public CanalConfiguration()
        {
            ToTable("CANALES");
            HasKey(p => new { p.IdCanal });
            Property(m => m.IdCanal).HasColumnName("ID_CANAL").HasMaxLength(10);
            Property(m => m.DescripcionCanal).HasColumnName("DES_CANAL").HasMaxLength(100);
        }
    }
}
