using Sistemas.Entidades;
using Sistemas.Repositorios.Base;

namespace Sistemas.Repositorios
{
    public interface IUsuarioRepository : IBaseRepository<UsuarioEntity>
    {
        bool VerificarPassword(string username, string password);
        UsuarioEntity ObtenerUsuarioPorUsername(string username);
    }
}
