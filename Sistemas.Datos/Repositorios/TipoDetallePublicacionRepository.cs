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

        public TipoDetallePublicacionEntity Buscar(object idEntidad)
        {
            return Consultar(() =>
            {
                TipoDetallePublicacionEntity tipoDetallePublicacion = _sistemasContext.TiposDetallePublicacion.Find(idEntidad);

                return tipoDetallePublicacion;
            });
        }

        public void Crear(TipoDetallePublicacionEntity entidad)
        {
            Guardar(() =>
            {
                _sistemasContext.TiposDetallePublicacion.Add(entidad);

                _sistemasContext.GuardarCambios();
            });
        }

        public void Eliminar(object idEntidad)
        {
            Eliminar(() =>
            {
                TipoDetallePublicacionEntity tipoDetallePublicacion = Buscar(idEntidad);
                tipoDetallePublicacion.Borrado();
                _sistemasContext.TiposDetallePublicacion.Remove(tipoDetallePublicacion);
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

        public ICollection<TipoDetallePublicacionEntity> ObtenerTodo()
        {
            return Consultar(() =>
            {
                ICollection<TipoDetallePublicacionEntity> tiposDetallePublicacion = _sistemasContext.TiposDetallePublicacion
                .Where(p => p.IndicadorEstado == EstadoEntidad.Activo).ToList();

                return tiposDetallePublicacion;
            });
        }
    }
}
