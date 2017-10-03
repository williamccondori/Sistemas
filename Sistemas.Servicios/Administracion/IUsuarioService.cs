using Sistemas.Dtos.Administracion;
using System.Collections.Generic;

namespace Sistemas.Servicios.Administracion
{
    public interface IUsuarioService
    {
        void IniciarSesion(UsuarioDto usuarioDto);
        void Guardar(UsuarioDto usuarioDto);
        IList<UsuarioDto> ObtenerTodo();
    }
}
