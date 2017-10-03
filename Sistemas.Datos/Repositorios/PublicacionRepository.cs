using Sistemas.Datos.Contextos;
using Sistemas.Datos.Shared;
using Sistemas.Entidades;
using Sistemas.Repositorios;
using Sistemas.Utilidades.Constantes;
using System.Collections.Generic;
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

        public void Crear(PublicacionEntity publicacion)
        {
            Ejecutar(() =>
            {
                _sistemasContext.Publicaciones.Add(publicacion);

                _sistemasContext.GuardarCambios();
            });
        }

        public ICollection<PublicacionEntity> ObtenerPorTipo(string idTipoPublicacion)
        {
            return Ejecutar(() =>
            {
                ICollection<PublicacionEntity> publicaciones = _sistemasContext.Publicaciones.Where(
                    p => p.IdTipoPublicacion == idTipoPublicacion && p.IndicadorEstado == EstadoEntidad.Activo).ToList();

                return publicaciones;
            });
        }
    }
}
