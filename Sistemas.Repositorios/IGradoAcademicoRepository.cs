using Sistemas.Entidades;
using System.Collections.Generic;

namespace Sistemas.Repositorios
{
    public interface IGradoAcademicoRepository
    {
        void Crear(GradoAcademicoEntity gradoAcademico);
        ICollection<GradoAcademicoEntity> ObtenerTodo();
    }
}
