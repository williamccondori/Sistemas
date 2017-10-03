using Sistemas.Datos.Contextos;
using Sistemas.Datos.Shared;
using Sistemas.Entidades;
using Sistemas.Repositorios;
using Sistemas.Utilidades.Constantes;
using System.Collections.Generic;
using System.Linq;

namespace Sistemas.Datos.Repositorios
{
    public class TipoDetallePublicacionRepository : BaseRepository, ITipoDetallePublicacionRepository
    {
        private readonly SistemasContext _sistemasContext;

        public TipoDetallePublicacionRepository()
        {
            _sistemasContext = new SistemasContext();
        }

        public void Crear(TipoDetallePublicacionEntity tipoDetallePublicacion)
        {
            Ejecutar(() =>
            {
                _sistemasContext.TiposDetallePublicacion.Add(tipoDetallePublicacion);

                _sistemasContext.GuardarCambios();
            });
        }

        public ICollection<TipoDetallePublicacionEntity> ObtenerTodo()
        {
            return Ejecutar(() =>
            {
                ICollection<TipoDetallePublicacionEntity> tiposDetallePublicacion = _sistemasContext.TiposDetallePublicacion.Where(p =>
                    p.IndicadorEstado == EstadoEntidad.Activo).ToList();

                return tiposDetallePublicacion;
            });
        }
    }
}
