using Sistemas.Datos.Contextos;
using Sistemas.Datos.Shared;
using Sistemas.Entidades;
using Sistemas.Repositorios;
using Sistemas.Utilidades.Constantes;
using System.Collections.Generic;
using System.Linq;

namespace Sistemas.Datos.Repositorios
{
    public class TipoPublicacionRepository : BaseRepository, ITipoPublicacionRepository
    {
        private readonly SistemasContext _sistemasContext;

        public TipoPublicacionRepository()
        {
            _sistemasContext = new SistemasContext();
        }

        public void Crear(TipoPublicacionEntity entidad)
        {
            Guardar(() =>
            {
                _sistemasContext.TiposPublicacion.Add(entidad);

                _sistemasContext.GuardarCambios();
            });
        }

        public void Eliminar(object idEntidad)
        {
            Eliminar(() =>
            {
                TipoPublicacionEntity tipoPublicacion = _sistemasContext.TiposPublicacion.Find(idEntidad);
                _sistemasContext.TiposPublicacion.Remove(tipoPublicacion);
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

        public ICollection<TipoPublicacionEntity> ObtenerTodo()
        {
            return Consultar(() =>
            {
                ICollection<TipoPublicacionEntity> tiposPublicacion = _sistemasContext.TiposPublicacion.Where(p =>
                    p.IndicadorEstado == EstadoEntidad.Activo).ToList();

                return tiposPublicacion;
            });
        }
    }
}
