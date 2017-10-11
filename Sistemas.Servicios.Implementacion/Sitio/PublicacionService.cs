using Sistemas.Datos.Repositorios;
using Sistemas.Dtos.Shared;
using Sistemas.Dtos.Sitio;
using Sistemas.Entidades;
using Sistemas.Repositorios;
using Sistemas.Servicios.Sitio;
using Sistemas.Utilidades.Extensiones;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Sistemas.Servicios.Implementacion.Sitio
{
    public class PublicacionService : IPublicacionService
    {
        private readonly IPublicacionRepository _publicacionRepository;

        public PublicacionService()
        {
            _publicacionRepository = new PublicacionRepository();
        }

        public void Guardar(PublicacionDto publicacionDto)
        {
            if (publicacionDto.Estado == EstadoObjeto.Nuevo)
            {
                PublicacionEntity publicacion = PublicacionEntity.Crear(publicacionDto.IdTipoPublicacion, publicacionDto.Titulo
                    , publicacionDto.Subtitulo, publicacionDto.Resumen, publicacionDto.Resena, publicacionDto.Recurso
                    , publicacionDto.Detalles.Select(p => DetallePublicacionEntity.Crear(p.IdTipoDetallePublicacion, p.Titulo
                    , p.Resumen, p.Recurso, publicacionDto.Usuario)).ToList()
                    , publicacionDto.Usuario);

                publicacion.ValidarObligatorios();

                _publicacionRepository.Crear(publicacion);
            }
            else if (publicacionDto.Estado == EstadoObjeto.Modificado)
            {

            }
            else if (publicacionDto.Estado == EstadoObjeto.Borrado)
            {
                _publicacionRepository.Eliminar(publicacionDto.Id);
            }
            else
            {
                throw new Exception("El método no es el correcto");
            }
        }

        public IList<PublicacionDto> ObtenerPorTipo(string idTipoPublicacion)
        {
            ICollection<PublicacionEntity> publicaciones = _publicacionRepository.ObtenerPorTipo(idTipoPublicacion);

            List<PublicacionDto> publicacionesDto = publicaciones.Select(p => MapearPublicacion(p)).ToList();

            return publicacionesDto;
        }

        public IList<PublicacionDto> ObtenerTodo(int numeroElementos = 0)
        {
            ICollection<PublicacionEntity> publicaciones = _publicacionRepository.ObtenerTodo();

            List<PublicacionDto> publicacionesDto = numeroElementos == 0
                ? publicaciones.Select(p => MapearPublicacion(p)).ToList()
                : publicaciones.Select(p => MapearPublicacion(p)).Take(numeroElementos).ToList();

            return publicacionesDto;
        }

        public PublicacionDto MapearPublicacion(PublicacionEntity publicacion)
        {
            PublicacionDto publicacionDto = new PublicacionDto
            {
                Estado = EstadoObjeto.SinCambios,
                Fecha = publicacion.FechaModifico ?? publicacion.FechaRegistro,
                Usuario = publicacion.UsuarioModifico ?? publicacion.UsuarioRegistro,

                Id = publicacion.IdPublicacion,
                Emision = publicacion.FechaPublicacion.ObtenerCadenaFecha(),
                IdTipoPublicacion = publicacion.IdTipoPublicacion,
                Recurso = publicacion.DescripcionRecurso,
                Resena = publicacion.DescripcionResena,
                Resumen = publicacion.DescripcionResumen,
                Subtitulo = publicacion.DescripcionSubtitulo,
                Titulo = publicacion.DescripcionTitulo,
                TipoPublicacion = new TipoPublicacionDto
                {
                    Id = publicacion.TipoPublicacionX.IdTipoPublicacion,
                    Descripcion = publicacion.TipoPublicacionX.DescripcionTipoPublicacion
                },
                Detalles = publicacion.DetallePublicacionS.Select(g => new DetallePublicacionDto
                {
                    Estado = EstadoObjeto.SinCambios,
                    Fecha = g.FechaModifico ?? g.FechaRegistro,
                    Usuario = g.UsuarioModifico ?? g.UsuarioRegistro,

                    Id = g.IdDetallePublicacion,
                    Titulo = g.DescripcionTitulo,
                    Resumen = g.DescripcionResumen,
                    Recurso = g.DescripcionRecurso,
                    IdPublicacion = g.IdPublicacion,
                    IdTipoDetallePublicacion = g.IdTipoDetallePublicacion,
                    TipoDetallePublicacion = new TipoDetallePublicacionDto
                    {
                        Id = g.TipoDetallePublicacionX.IdTipoDetallePublicacion,
                        Descripcion = g.TipoDetallePublicacionX.DescripcionTipoDetallePublicacion
                    }
                }).ToList()
            };

            return publicacionDto;
        }
    }
}
