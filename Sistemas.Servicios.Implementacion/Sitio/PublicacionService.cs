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

                _publicacionRepository.Crear(publicacion);
            }
            else if (publicacionDto.Estado == EstadoObjeto.Modificado)
            {

            }
            else if (publicacionDto.Estado == EstadoObjeto.Borrado)
            {

            }
            else
            {
                throw new Exception("El método no es el correcto");
            }
        }

        public IList<PublicacionDto> ObtenerPorTipo(string idTipoPublicacion)
        {
            ICollection<PublicacionEntity> publicaciones = _publicacionRepository.ObtenerPorTipo(idTipoPublicacion);

            List<PublicacionDto> publicacionesDto = publicaciones.Select(p => new PublicacionDto
            {
                Estado = EstadoObjeto.SinCambios,
                Fecha = p.FechaModifico ?? p.FechaRegistro,
                Usuario = p.UsuarioModifico ?? p.UsuarioRegistro,

                Id = p.IdPublicacion,
                Emision = p.FechaPublicacion,
                IdTipoPublicacion = p.IdTipoPublicacion,
                Recurso = p.DescripcionRecurso,
                Resena = p.DescripcionResena,
                Resumen = p.DescripcionResumen,
                Subtitulo = p.DescripcionSubtitulo,
                Titulo = p.DescripcionTitulo,
                TipoPublicacion = new TipoPublicacionDto
                {
                    Id = p.TipoPublicacionX.IdTipoPublicacion,
                    Descripcion = p.TipoPublicacionX.DescripcionTipoPublicacion
                },
                Detalles = p.DetallePublicacionS.Select(g => new DetallePublicacionDto
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
            }).ToList();

            return publicacionesDto;
        }
    }
}
