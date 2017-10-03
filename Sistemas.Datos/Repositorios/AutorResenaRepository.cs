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
    public class AutorResenaRepository : BaseRepository, IAutorResenaRepository
    {
        private readonly SistemasContext _sistemasContext;

        public AutorResenaRepository()
        {
            _sistemasContext = new SistemasContext();
        }

        public void Crear(AutorResenaEntity autorResena)
        {
            Ejecutar(() =>
            {
                _sistemasContext.AutoresResena.Add(autorResena);

                _sistemasContext.GuardarCambios();
            });
        }

        public ICollection<AutorResenaEntity> ObtenerTodo()
        {
            return Ejecutar(() =>
            {
                ICollection<AutorResenaEntity> autoresResena = _sistemasContext.AutoresResena
                .Include(p => p.GradoAcademicoX)
                .Where(p => p.IndicadorEstado == EstadoEntidad.Activo).ToList();

                return autoresResena;
            });
        }
    }
}
