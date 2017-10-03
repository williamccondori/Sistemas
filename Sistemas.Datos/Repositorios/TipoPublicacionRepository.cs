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

        public void Crear(TipoPublicacionEntity tipoPublicacion)
        {
            Ejecutar(() =>
            {
                _sistemasContext.TiposPublicacion.Add(tipoPublicacion);

                _sistemasContext.GuardarCambios();
            });
        }

        public ICollection<TipoPublicacionEntity> ObtenerTodo()
        {
            return Ejecutar(() =>
            {
                ICollection<TipoPublicacionEntity> tiposPublicacion = _sistemasContext.TiposPublicacion.Where(p =>
                    p.IndicadorEstado == EstadoEntidad.Activo).ToList();

                return tiposPublicacion;
            });
        }
    }
}
