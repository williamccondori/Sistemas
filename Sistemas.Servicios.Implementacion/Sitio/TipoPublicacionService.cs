using Sistemas.Datos.Repositorios;
using Sistemas.Dtos.Shared;
using Sistemas.Dtos.Sitio;
using Sistemas.Entidades;
using Sistemas.Repositorios;
using Sistemas.Servicios.Sitio;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Sistemas.Servicios.Implementacion.Sitio
{
    public class TipoPublicacionService : ITipoPublicacionService
    {
        private readonly ITipoPublicacionRepository _tipoPublicacionRepository;

        public TipoPublicacionService()
        {
            _tipoPublicacionRepository = new TipoPublicacionRepository();
        }

        public void Guardar(TipoPublicacionDto tipoPublicacionDto)
        {
            if (tipoPublicacionDto.Estado == EstadoObjeto.Nuevo)
            {
                TipoPublicacionEntity tipoPublicacion = TipoPublicacionEntity.Crear(tipoPublicacionDto.Id
                    , tipoPublicacionDto.Descripcion, tipoPublicacionDto.Usuario);
                _tipoPublicacionRepository.Crear(tipoPublicacion);
            }
            else if (tipoPublicacionDto.Estado == EstadoObjeto.Modificado)
            {
                TipoPublicacionEntity tipoPublicacion = _tipoPublicacionRepository.Buscar(tipoPublicacionDto.Id);
                tipoPublicacion.Modificar(tipoPublicacionDto.Descripcion, tipoPublicacionDto.Usuario);
                _tipoPublicacionRepository.Modificar();
            }
            else if (tipoPublicacionDto.Estado == EstadoObjeto.Borrado)
            {
                _tipoPublicacionRepository.Eliminar(tipoPublicacionDto.Id);
            }
            else
            {
                throw new Exception("El método no es el correcto");
            }
        }

        public IList<TipoPublicacionDto> ObtenerTodo()
        {
            ICollection<TipoPublicacionEntity> tiposPublicacion = _tipoPublicacionRepository.ObtenerTodo();

            List<TipoPublicacionDto> tiposPublicacionDto = tiposPublicacion.Select(p => new TipoPublicacionDto
            {
                Estado = EstadoObjeto.SinCambios,
                Fecha = p.FechaModifico ?? p.FechaRegistro,
                Usuario = p.UsuarioModifico ?? p.UsuarioRegistro,
                Descripcion = p.DescripcionTipoPublicacion,
                Id = p.IdTipoPublicacion
            }).ToList();

            return tiposPublicacionDto;
        }
    }
}
