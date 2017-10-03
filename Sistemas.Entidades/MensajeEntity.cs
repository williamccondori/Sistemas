using Sistemas.Entidades.Shared;

namespace Sistemas.Entidades
{
    public class MensajeEntity : BaseEntity
    {
        public long IdMensaje { get; set; }
        public string IdCliente { get; set; }
        public string DescripcionMensaje { get; set; }
        public ClienteEntity ClienteX { get; set; }

        public static MensajeEntity Crear(string idCliente, string descripcionMensaje, string usuario)
        {
            MensajeEntity mensaje = new MensajeEntity
            {
                IdCliente = idCliente,
                DescripcionMensaje = descripcionMensaje
            };

            mensaje.Nuevo(usuario);

            return mensaje;
        }
    }
}
