using Sistemas.Datos.Shared;
using Sistemas.Entidades;

namespace Sistemas.Datos.Configuraciones
{
    public class MensajeConfiguration : BaseConfiguration<MensajeEntity>
    {
        public MensajeConfiguration()
        {
            ToTable("MENSAJES");
            HasKey(p => new { p.IdMensaje });
        }
    }
}
