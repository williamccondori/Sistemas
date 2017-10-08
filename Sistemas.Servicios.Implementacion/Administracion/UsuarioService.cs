using Sistemas.Datos.Repositorios;
using Sistemas.Dtos.Administracion;
using Sistemas.Dtos.Shared;
using Sistemas.Entidades;
using Sistemas.Repositorios;
using Sistemas.Servicios.Administracion;
using Sistemas.Utilidades.Constantes;
using Sistemas.Utilidades.Seguridad;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace Sistemas.Servicios.Implementacion.Administracion
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly Encriptacion _encriptacion;

        public UsuarioService()
        {
            _usuarioRepository = new UsuarioRepository();
            _encriptacion = new Encriptacion("sistemasupt");
        }

        public void Guardar(UsuarioDto usuarioDto)
        {
            if (usuarioDto.Estado == EstadoObjeto.Nuevo)
            {
                string password = _encriptacion.Encriptar(usuarioDto.Password);

                usuarioDto.Username = usuarioDto.Username.ToUpper(CultureInfo.CurrentCulture);

                UsuarioEntity usuario = UsuarioEntity.Crear(usuarioDto.Username, password, usuarioDto.Nombre, usuarioDto.Apellido,
                    usuarioDto.Email, usuarioDto.Imagen, usuarioDto.Usuario);

                _usuarioRepository.Crear(usuario);
            }
            else if (usuarioDto.Estado == EstadoObjeto.Modificado)
            {
                string password = _encriptacion.Encriptar(usuarioDto.Password);

                bool passwordCorrecto = _usuarioRepository.VerificarPassword(usuarioDto.Username, password);

                if (!passwordCorrecto)
                {
                    throw new Exception("No se puede modificar el usuario, la contraseña es incorrecta");
                }

                usuarioDto.Username = usuarioDto.Username.ToUpper(CultureInfo.CurrentCulture);

                UsuarioEntity usuario = _usuarioRepository.Buscar(usuarioDto.Id);
                usuario.Modificar(usuarioDto.Username, usuarioDto.Nombre, usuarioDto.Apellido, usuarioDto.Email
                    , usuarioDto.Imagen, usuarioDto.Usuario);
                _usuarioRepository.Modificar();
            }
            else if (usuarioDto.Estado == EstadoObjeto.Borrado)
            {
                _usuarioRepository.Eliminar(usuarioDto.Id);
            }
            else
            {
                throw new Exception("El método no es el correcto");
            }
        }

        public void IniciarSesion(UsuarioDto usuarioDto)
        {
            UsuarioEntity usuario = _usuarioRepository.ObtenerUsuarioPorUsername(usuarioDto.Username);

            if (usuario == null)
            {
                throw new Exception("No se encontró un usuario válido");
            }
            else
            {
                string password = _encriptacion.Encriptar(usuarioDto.Password);

                bool passwordCorrecto = _usuarioRepository.VerificarPassword(usuarioDto.Username, password);

                if (passwordCorrecto)
                {
                    if (usuario.IndicadorHabilitado == EstadoEntidad.No)
                    {
                        throw new Exception("El usuario no se encuentra habilitado en el sistema");
                    }
                }
                else
                {
                    throw new Exception("La contraseña proporcionada no es la correcta");
                }
            }
        }

        public IList<UsuarioDto> ObtenerTodo()
        {
            ICollection<UsuarioEntity> usuarios = _usuarioRepository.ObtenerTodo();

            List<UsuarioDto> usuariosDto = usuarios.Select(p => new UsuarioDto
            {
                Apellido = p.DescripcionApellido,
                Email = p.DescripcionEmail,
                Estado = EstadoObjeto.SinCambios,
                Fecha = p.FechaModifico ?? p.FechaRegistro,
                Habilitado = p.IndicadorHabilitado == EstadoEntidad.Si,
                Id = p.IdUsuario,
                Imagen = p.DescripcionRecurso,
                Nombre = p.DescripcionNombre,
                Password = string.Empty,
                Username = p.DescripcionUsuario,
                Usuario = p.UsuarioModifico ?? p.UsuarioRegistro
            }).ToList();

            return usuariosDto;
        }
    }
}
