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
            Guardar(() =>
            {
                _sistemasContext.TiposResena.Add(tipoResena);

                _sistemasContext.GuardarCambios();
            });
        }

        public void Eliminar(object idEntidad)
        {
            Eliminar(() =>
            {
                TipoResenaEntity tipoResena = _sistemasContext.TiposResena.Find(idEntidad);
                _sistemasContext.TiposResena.Remove(tipoResena);
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

        public ICollection<TipoResenaEntity> ObtenerTodo()
        {
            return Consultar(() =>
            {
                ICollection<TipoResenaEntity> tiposResena = _sistemasContext.TiposResena
                .Where(p => p.IndicadorEstado == EstadoEntidad.Activo).ToList();

                return tiposResena;
            });
        }
    }
}
