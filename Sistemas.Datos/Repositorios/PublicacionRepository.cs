using Sistemas.Datos.Contextos;
using Sistemas.Datos.Shared;
using Sistemas.Entidades;
using Sistemas.Repositorios;
using Sistemas.Utilidades.Constantes;
using System.Collections.Generic;
using System.Data.Entity;
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

        public void Crear(PublicacionEntity entidad)
        {
            Guardar(() =>
            {
                _sistemasContext.Publicaciones.Add(entidad);

                _sistemasContext.GuardarCambios();
            });
        }

        public void Eliminar(object idEntidad)
        {
            Eliminar(() =>
            {
                PublicacionEntity publicacion = _sistemasContext.Publicaciones.Find(idEntidad);
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