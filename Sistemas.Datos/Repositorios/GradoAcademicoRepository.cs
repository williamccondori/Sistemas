using Sistemas.Datos.Contextos;
using Sistemas.Datos.Shared;
using Sistemas.Entidades;
using Sistemas.Repositorios;
using Sistemas.Utilidades.Constantes;
using System.Collections.Generic;
using System.Linq;

namespace Sistemas.Datos.Repositorios
{
    public class GradoAcademicoRepository : BaseRepository, IGradoAcademicoRepository
    {
        private readonly SistemasContext _sistemasContext;

        public GradoAcademicoRepository()
        {
            _sistemasContext = new SistemasContext();
        }

        public GradoAcademicoEntity Buscar(object idEntidad)
        {
            return Consultar(() =>
            {
                GradoAcademicoEntity gradoAcademico = _sistemasContext.GradosAcademicos.Find(idEntidad);

                return gradoAcademico;
            });
        }

        public void Crear(GradoAcademicoEntity entidad)
        {
            Guardar(() =>
            {
                _sistemasContext.GradosAcademicos.Add(entidad);

                _sistemasContext.GuardarCambios();
            });
        }

        public void Eliminar(object idEntidad)
        {
            Eliminar(() =>
            {
                GradoAcademicoEntity gradoAcademico = Buscar(idEntidad);
                gradoAcademico.Borrado();
                _sistemasContext.GradosAcademicos.Remove(gradoAcademico);
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

        public ICollection<GradoAcademicoEntity> ObtenerTodo()
        {
            return Consultar(() =>
            {
                ICollection<GradoAcademicoEntity> gradosAcademicos = _sistemasContext.GradosAcademicos
                .Where(p => p.IndicadorEstado == EstadoEntidad.Activo).ToList();

                return gradosAcademicos;
            });
        }
    }
}
