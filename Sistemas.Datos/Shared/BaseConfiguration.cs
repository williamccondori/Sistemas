using Sistemas.Entidades.Contratos;
using System.Data.Entity.ModelConfiguration;

namespace Sistemas.Datos.Shared
{
    public class BaseConfiguration<TEntidad> : EntityTypeConfiguration<TEntidad> where TEntidad : class, IBaseEntity
    {
        public BaseConfiguration()
        {
            Property(p => p.IndicadorEstado).HasColumnName("IND_ESTADO").HasMaxLength(1);
            Property(p => p.UsuarioRegistro).HasColumnName("USU_REGISTRO").HasMaxLength(20);
            Property(p => p.UsuarioModifico).HasColumnName("USU_MODIFICO").HasMaxLength(20);
            Property(p => p.FechaRegistro).HasColumnName("FEC_REGISTRO");
            Property(p => p.FechaModifico).HasColumnName("FEC_MODIFICO");
            Ignore(p => p.EstadoObjeto);
        }
    }
}
