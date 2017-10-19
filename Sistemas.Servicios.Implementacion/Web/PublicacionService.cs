using Sistemas.Datos.Repositorios;
using Sistemas.Dtos.Shared;
using Sistemas.Dtos.Sitio;
using Sistemas.Entidades;
using Sistemas.Repositorios;
using Sistemas.Servicios.Web;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Sistemas.Servicios.Implementacion.Web
{
    public class PublicacionService : IPublicacionService
    {
        private readonly IPublicacionRepository _publicacionRepository;

        public PublicacionService()
        {
            _publicacionRepository = new PublicacionRepository();
        }

        public IList<PublicacionDto> ObtenerXTipo(string idTipoPublicacion)
        {
            int anio = DateTime.Now.Year;

            ICollection<PublicacionEntity> publicaciones = _publicacionRepository.ObtenerXTipoXAnio(idTipoPublicacion, anio);

            List<PublicacionDto> publicacionesDto = publicaciones.Select(p => MapearPublicacion(p)).OrderByDescending(p => p.Emision).ToList();

            return publicacionesDto;
        }

        public IList<PublicacionDto> ObtenerHistoricoXTipo(string idTipoPublicacion, int anio)
        {
            ICollection<PublicacionEntity> publicaciones = _publicacionRepository.ObtenerXTipoXAnio(idTipoPublicacion, anio);

            List<PublicacionDto> publicacionesDto = publicaciones.Select(p => MapearPublicacion(p)).OrderByDescending(p => p.Emision).ToList();

            return publicacionesDto;
        }

        public PublicacionDto BuscarXId(long idPublicacion)
        {
            PublicacionEntity publicacion = _publicacionRepository.ObtenerXId(idPublicacion);

            return MapearPublicacion(publicacion);
        }

        public PublicacionDto MapearPublicacion(PublicacionEntity publicacion)
        {
            PublicacionDto publicacionDto = new PublicacionDto
            {
                Estado = EstadoObjeto.SinCambios,
                Fecha = publicacion.FechaModifico ?? publicacion.FechaRegistro,
                Usuario = publicacion.UsuarioModifico ?? publicacion.UsuarioRegistro,

                Id = publicacion.IdPublicacion,
                Emision = publicacion.FechaPublicacion,
                IdTipoPublicacion = publicacion.IdTipoPublicacion,
                Recurso = publicacion.DescripcionRecurso,
                Resena = publicacion.DescripcionResena,
                Resumen = publicacion.DescripcionResumen,
                Subtitulo = publicacion.DescripcionSubtitulo,
                Titulo = publicacion.DescripcionTitulo,
                Url = publicacion.DescripcionUrl,
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
