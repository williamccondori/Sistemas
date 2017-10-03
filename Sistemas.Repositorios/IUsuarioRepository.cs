using Sistemas.Entidades;
using System.Collections.Generic;

namespace Sistemas.Repositorios
{
    public interface IUsuarioRepository
    {
        void Crear(UsuarioEntity usuario);
        bool VerificarPassword(string username, string password);
        UsuarioEntity ObtenerUsuarioPorUsername(string username);
        ICollection<UsuarioEntity> ObtenerTodo();
    }
}
