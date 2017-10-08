using Sistemas.Datos.Contextos;
using Sistemas.Datos.Shared;
using Sistemas.Entidades;
using Sistemas.Entidades.Dtos;
using Sistemas.Entidades.Shared;
using Sistemas.Repositorios;
using Sistemas.Utilidades.Constantes;
using System.Collections.Generic;
using System.Linq;

namespace Sistemas.Datos.Repositorios
{
    public class UsuarioRepository : BaseRepository, IUsuarioRepository
    {
        private readonly SistemasContext _sistemasContext;

        public UsuarioRepository()
        {
            _sistemasContext = new SistemasContext();
        }

        public void Crear(UsuarioEntity entidad)
        {
            Guardar(() =>
            {
                _sistemasContext.Usuarios.Add(entidad);

                _sistemasContext.GuardarCambios();
            });
        }

        public void Eliminar(object idEntidad)
        {
            Eliminar(() =>
            {
                UsuarioEntity usuario = _sistemasContext.Usuarios.Find(idEntidad);
                _sistemasContext.Usuarios.Remove(usuario);
                _sistemasContext.GuardarCambios();
            });
        }

        public void Modificar()
        {
            Guardar(() =>
            {
                _sistemasContext.GuardarCambios();
            });
        }

        public ICollection<UsuarioEntity> ObtenerTodo()
        {
            return Consultar(() =>
            {
                ICollection<UsuarioSinPasswordDto> usuariosSinPassword = (from us in _sistemasContext.Usuarios
                                                                          where
                                                                          us.IndicadorEstado == EstadoEntidad.Activo
                                                                          select new UsuarioSinPasswordDto
                                                                          {
                                                                              IdUsuario = us.IdUsuario,
                                                                              DescripcionApellido = us.DescripcionApellido,
                                                                              DescripcionEmail = us.DescripcionEmail,
                                                                              DescripcionImagen = us.DescripcionRecurso,
                                                                              DescripcionNombre = us.DescripcionNombre,
                                                                              DescripcionUsuario = us.DescripcionUsuario,
                                                                              FechaModifico = us.FechaModifico,
                                                                              FechaRegistro = us.FechaRegistro,
                                                                              IndicadorEstado = us.IndicadorEstado,
                                                                              IndicadorHabilitado = us.IndicadorHabilitado,
                                                                              UsuarioModifico = us.UsuarioModifico,
                                                                              UsuarioRegistro = us.UsuarioRegistro
                                                                          }).ToList();

                ICollection<UsuarioEntity> usuarios = usuariosSinPassword.Select(p => new UsuarioEntity
                {
                    UsuarioRegistro = p.UsuarioRegistro,
                    UsuarioModifico = p.UsuarioModifico,
                    IndicadorHabilitado = p.IndicadorHabilitado,
                    IndicadorEstado = p.IndicadorEstado,
                    FechaRegistro = p.FechaRegistro,
                    FechaModifico = p.FechaModifico,
                    DescripcionApellido = p.DescripcionApellido,
                    DescripcionEmail = p.DescripcionEmail,
                    DescripcionRecurso = p.DescripcionImagen,
                    DescripcionNombre = p.DescripcionNombre,
                    DescripcionPassword = string.Empty,
                    DescripcionUsuario = p.DescripcionUsuario,
                    EstadoObjeto = EstadoObjeto.SinCambios,
                    IdUsuario = p.IdUsuario
                }).ToList();

                return usuarios;
            });
        }

        public UsuarioEntity ObtenerUsuarioPorUsername(string username)
        {
            return Consultar(() =>
            {
                UsuarioSinPasswordDto usuarioSinPassword = (from us in _sistemasContext.Usuarios
                                                            where
                                                            us.IndicadorEstado == EstadoEntidad.Activo &&
                                                            us.DescripcionUsuario == username
                                                            select new UsuarioSinPasswordDto
                                                            {
                                                                IdUsuario = us.IdUsuario,
                                                                DescripcionUsuario = us.DescripcionUsuario,
                                                                IndicadorHabilitado = us.IndicadorHabilitado
                                                            }).FirstOrDefault();
                if (usuarioSinPassword == null)
                {
                    throw new KeyNotFoundException();
                }

                UsuarioEntity usuario = new UsuarioEntity
                {
                    IdUsuario = usuarioSinPassword.IdUsuario,
                    DescripcionUsuario = usuarioSinPassword.DescripcionUsuario,
                    IndicadorHabilitado = usuarioSinPassword.IndicadorHabilitado
                };

                return usuario;
            });
        }

        public bool VerificarPassword(string username, string password)
        {
            return Consultar(() =>
            {
                bool passwordCorrecto = _sistemasContext.Usuarios.Any(p => p.IndicadorEstado == EstadoEntidad.Activo
                    && p.DescripcionUsuario == username && p.DescripcionPassword == password);

                return passwordCorrecto;
            });
        }
    }
}
