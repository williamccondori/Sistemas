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
    public class TipoDetallePublicacionService : ITipoDetallePublicacionService
    {
        private readonly ITipoDetallePublicacionRepository _tipoDetallePublicacionRepository;

        public TipoDetallePublicacionService()
        {
            _tipoDetallePublicacionRepository = new TipoDetallePublicacionRepository();
        }

        public void Guardar(TipoDetallePublicacionDto tipoDetallePublicacionDto)
        {
            if (tipoDetallePublicacionDto.Estado == EstadoObjeto.Nuevo)
            {
                TipoDetallePublicacionEntity TipoDetallePublicacion = TipoDetallePublicacionEntity.Crear(tipoDetallePublicacionDto.Id
                    , tipoDetallePublicacionDto.Descripcion, tipoDetallePublicacionDto.Usuario);

                _tipoDetallePublicacionRepository.Crear(TipoDetallePublicacion);
            }
            else if (tipoDetallePublicacionDto.Estado == EstadoObjeto.Modificado)
            {

            }
            else if (tipoDetallePublicacionDto.Estado == EstadoObjeto.Borrado)
            {

            }
            else
            {
                throw new Exception("El método no es el correcto");
            }
        }

        public IList<TipoDetallePublicacionDto> ObtenerTodo()
        {
            ICollection<TipoDetallePublicacionEntity> tiposDetallePublicacion = _tipoDetallePublicacionRepository.ObtenerTodo();

            List<TipoDetallePublicacionDto> tiposDetallePublicacionDto = tiposDetallePublicacion.Select(p => new TipoDetallePublicacionDto
            {
                Estado = EstadoObjeto.SinCambios,
                Fecha = p.FechaModifico ?? p.FechaRegistro,
                Usuario = p.UsuarioModifico ?? p.UsuarioRegistro,
                Descripcion = p.DescripcionTipoDetallePublicacion,
                Id = p.IdTipoDetallePublicacion
            }).ToList();

            return tiposDetallePublicacionDto;
        }
    }
}
