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

        public AutorResenaEntity Buscar(object idEntidad)
        {
            return Consultar(() =>
            {
                AutorResenaEntity autorResena = _sistemasContext.AutoresResena.Find(idEntidad);

                return autorResena;
            });
        }

        public void Crear(AutorResenaEntity entidad)
        {
            Guardar(() =>
            {
                _sistemasContext.AutoresResena.Add(entidad);

                _sistemasContext.GuardarCambios();
            });
        }

        public void Eliminar(object idEntidad)
        {
            Eliminar(() =>
            {
                AutorResenaEntity autorResena = Buscar(idEntidad);
                autorResena.Borrado();
                _sistemasContext.AutoresResena.Remove(autorResena);
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

        public ICollection<AutorResenaEntity> ObtenerTodo()
        {
            return Consultar(() =>
            {
                ICollection<AutorResenaEntity> autoresResena = _sistemasContext.AutoresResena
                .Include(p => p.GradoAcademicoX)
                .Where(p => p.IndicadorEstado == EstadoEntidad.Activo).ToList();

                return autoresResena;
            });
        }
    }
}
