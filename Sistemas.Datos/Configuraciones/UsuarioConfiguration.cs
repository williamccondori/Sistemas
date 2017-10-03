using Sistemas.Datos.Shared;
using Sistemas.Entidades;

namespace Sistemas.Datos.Configuraciones
{
    public class UsuarioConfiguration : BaseConfiguration<UsuarioEntity>
    {
        public UsuarioConfiguration()
        {
            ToTable("USUARIOS");
            HasKey(m => new { m.IdUsuario });
            Property(m => m.IdUsuario).HasColumnName("ID_USUARIO");
            Property(m => m.DescripcionUsuario).HasColumnName("DES_USUARIO").HasMaxLength(20);
            Property(m => m.DescripcionPassword).HasColumnName("DES_PASSWORD").HasMaxLength(100);
            Property(m => m.DescripcionNombre).HasColumnName("DES_NOMBRE").HasMaxLength(100);
            Property(m => m.DescripcionApellido).HasColumnName("DES_APELLIDO").HasMaxLength(100);
            Property(m => m.DescripcionEmail).HasColumnName("DES_EMAIL").HasMaxLength(100);
            Property(m => m.DescripcionRecurso).HasColumnName("DES_RECURSO").HasMaxLength(300);
            Property(m => m.IndicadorHabilitado).HasColumnName("IND_HABILITADO").HasMaxLength(1);
        }
    }
}
