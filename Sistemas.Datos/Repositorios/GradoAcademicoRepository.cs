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

        public void Crear(GradoAcademicoEntity gradoAcademico)
        {
            Ejecutar(() =>
            {
                _sistemasContext.GradosAcademicos.Add(gradoAcademico);

                _sistemasContext.GuardarCambios();
            });
        }

        public ICollection<GradoAcademicoEntity> ObtenerTodo()
        {
            return Ejecutar(() =>
            {
                ICollection<GradoAcademicoEntity> gradosAcademicos = _sistemasContext.GradosAcademicos.Where(p =>
                    p.IndicadorEstado == EstadoEntidad.Activo).ToList();

                return gradosAcademicos;
            });
        }
    }
}
