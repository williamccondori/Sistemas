using Sistemas.Datos.Shared;
using Sistemas.Entidades;

namespace Sistemas.Datos.Configuraciones
{
    public class ClienteConfiguration : BaseConfiguration<ClienteEntity>
    {
        public ClienteConfiguration()
        {
            ToTable("CLIENTES");
            HasKey(p => new { p.IdCliente });
        }
    }
}
