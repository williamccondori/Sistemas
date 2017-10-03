using Sistemas.Datos.Contextos;
using Sistemas.Datos.Shared;
using Sistemas.Entidades;
using Sistemas.Repositorios;
using Sistemas.Utilidades.Constantes;
using System.Collections.Generic;
using System.Linq;

namespace Sistemas.Datos.Repositorios
{
    public class TipoResenaRepository : BaseRepository, ITipoResenaRepository
    {
        private readonly SistemasContext _sistemasContext;

        public TipoResenaRepository()
        {
            _sistemasContext = new SistemasContext();
        }

        public void Crear(TipoResenaEntity tipoResena)
        {
            Ejecutar(() =>
            {
                _sistemasContext.TiposResena.Add(tipoResena);

                _sistemasContext.GuardarCambios();
            });
        }

        public ICollection<TipoResenaEntity> ObtenerTodo()
        {
            return Ejecutar(() =>
            {
                ICollection<TipoResenaEntity> tiposResena = _sistemasContext.TiposResena.Where(p =>
                    p.IndicadorEstado == EstadoEntidad.Activo).ToList();

                return tiposResena;
            });
        }
    }
}
