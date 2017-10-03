using Sistemas.Entidades.Shared;
using Sistemas.Utilidades;

namespace Sistemas.Entidades
{
    public class ClienteEntity : BaseEntity
    {
        public string IdCliente { get; set; }
        public string IdCanal { get; set; }
        public string DescripcionNombre { get; set; }
        public CanalEntity CanalX { get; set; }

        public static ClienteEntity Crear(string idCliente, string idCanal
            , string descripcionNombre, string usuario = UsuarioSistema.Administrador)
        {
            ClienteEntity cliente = new ClienteEntity
            {
                IdCliente = idCliente,
                IdCanal = idCanal,
                DescripcionNombre = descripcionNombre
            };

            cliente.Nuevo(usuario);

            return cliente;
        }
    }
}
