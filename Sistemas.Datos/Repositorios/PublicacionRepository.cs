using Sistemas.Datos.Contextos;
using Sistemas.Datos.Shared;
using Sistemas.Entidades;
using Sistemas.Entidades.Shared;
using Sistemas.Repositorios;
using Sistemas.Utilidades.Constantes;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Globalization;
using System.Linq;

namespace Sistemas.Datos.Repositorios
{
    public class PublicacionRepository : BaseRepository, IPublicacionRepository
    {
        private readonly SistemasContext _sistemasContext;

        public PublicacionRepository()
        {
            _sistemasContext = new SistemasContext();
        }

        public PublicacionEntity Buscar(object idEntidad)
        {
            return Consultar(() =>
            {
                PublicacionEntity publicacion = _sistemasContext.Publicaciones.Find(idEntidad);

                return publicacion;
            });
        }

        public void Crear(PublicacionEntity entidad)
        {
            Guardar(() =>
            {
                PublicacionEntity nuevaPublicacion = _sistemasContext.Publicaciones.Add(entidad);
                _sistemasContext.GuardarCambios();

                string tituloFormateado = nuevaPublicacion.DescripcionTitulo.Replace(' ', '-').ToLower(CultureInfo.CurrentCulture);
                string[] caracteres = { "\"", "“", "”", "!", "¡", "#", "¿", "?" };
                foreach (var caracter in caracteres)
                {
                    tituloFormateado = tituloFormateado.Replace(caracter, "");
                }

                string url = string.Format("{0}-{1}", tituloFormateado, nuevaPublicacion.IdPublicacion);
                nuevaPublicacion.DescripcionUrl = url;
                nuevaPublicacion.EstadoObjeto = EstadoObjeto.Modificado;

                _sistemasContext.GuardarCambios();
            });
        }

        public void Eliminar(object idEntidad)
        {
            Eliminar(() =>
            {
                PublicacionEntity publicacion = Buscar(idEntidad);
                publicacion.Borrado();
                _sistemasContext.Publicaciones.Remove(publicacion);
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

        public ICollection<PublicacionEntity> ObtenerPorTipo(string idTipoPublicacion)
        {
            return Consultar(() =>
            {
                IQueryable<PublicacionEntity> consulta = GenerarConsultaConDetalles();

                ICollection<PublicacionEntity> publicaciones = consulta
                .Where(p => p.IdTipoPublicacion == idTipoPublicacion && p.IndicadorEstado == EstadoEntidad.Activo).ToList();

                return publicaciones;
            });
        }

        public ICollection<PublicacionEntity> ObtenerTodo()
        {
            return Consultar(() =>
            {
                IQueryable<PublicacionEntity> consulta = GenerarConsultaConDetalles();

                ICollection<PublicacionEntity> publicaciones = consulta
                .Where(p => p.IndicadorEstado == EstadoEntidad.Activo).Take(100).ToList();

                return publicaciones;
            });
        }

        public PublicacionEntity ObtenerXId(long idPublicacion)
        {
            return Consultar(() =>
            {
                IQueryable<PublicacionEntity> consulta = GenerarConsultaConDetalles();

                PublicacionEntity publicacion = consulta
                .Where(p => p.IdPublicacion == idPublicacion && p.IndicadorEstado == EstadoEntidad.Activo).Take(100).FirstOrDefault();

                return publicacion;
            });
        }

        public ICollection<PublicacionEntity> ObtenerXTipoXAnio(string idTipoPublicacion, int anio)
        {
            return Consultar(() =>
            {
                DateTime fechaInicio = DateTime.Parse(string.Format("01/01/{0}", anio));
                DateTime fechaFin = DateTime.Parse(string.Format("31/12/{0}", anio));

                IQueryable<PublicacionEntity> consulta = GenerarConsultaConDetalles();

                ICollection<PublicacionEntity> publicaciones = consulta.Where(p => p.IdTipoPublicacion == idTipoPublicacion
                && p.FechaPublicacion > fechaInicio && p.FechaPublicacion < fechaFin && p.IndicadorEstado == EstadoEntidad.Activo).Take(100).ToList();

                return publicaciones;
            });
        }

        private IQueryable<PublicacionEntity> GenerarConsultaConDetalles()
        {
            IQueryable<PublicacionEntity> consulta = _sistemasContext.Publicaciones
                .Include(p => p.TipoPublicacionX)
                .Include(p => p.DetallePublicacionS)
                .Include(p => p.DetallePublicacionS.Select(g => g.TipoDetallePublicacionX));

            return consulta;
        }
    }
}