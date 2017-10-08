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
    public class ResenaRepository : BaseRepository, IResenaRepository
    {
        private readonly SistemasContext _sistemasContext;

        public ResenaRepository()
        {
            _sistemasContext = new SistemasContext();
        }

        public void Crear(ResenaEntity entidad)
        {
            Guardar(() =>
            {
                _sistemasContext.Resenas.Add(entidad);

                _sistemasContext.GuardarCambios();
            });
        }

        public void Eliminar(object idEntidad)
        {
            Eliminar(() =>
            {
                ResenaEntity resena = _sistemasContext.Resenas.Find(idEntidad);
                _sistemasContext.Resenas.Remove(resena);
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

        public ICollection<ResenaEntity> ObtenerPorTipo(string idTipoResena)
        {
            return Consultar(() =>
            {
                IQueryable<ResenaEntity> consulta = GenerarConsultaConDetalles();

                ICollection<ResenaEntity> resenas = consulta
                .Where(p => p.IdTipoResena == idTipoResena && p.IndicadorEstado == EstadoEntidad.Activo).ToList();

                return resenas;
            });
        }

        public ICollection<ResenaEntity> ObtenerTodo()
        {
            return Consultar(() =>
            {
                IQueryable<ResenaEntity> consulta = GenerarConsultaConDetalles();

                ICollection<ResenaEntity> resenas = consulta
                .Where(p => p.IndicadorEstado == EstadoEntidad.Activo).Take(100).ToList();

                return resenas;
            });
        }

        private IQueryable<ResenaEntity> GenerarConsultaConDetalles()
        {
            IQueryable<ResenaEntity> consulta = _sistemasContext.Resenas
               .Include(p => p.TipoResenaX)
               .Include(p => p.AutorResenaX)
               .Include(p => p.AutorResenaX.GradoAcademicoX);

            return consulta;
        }
    }
}
