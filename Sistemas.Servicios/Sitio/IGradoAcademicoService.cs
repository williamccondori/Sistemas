using System.Collections.Generic;
using Sistemas.Dtos.Sitio;

namespace Sistemas.Servicios.Sitio
{
    public interface IGradoAcademicoService
    {
        void Guardar(GradoAcademicoDto gradoAcademicoDto);
        IList<GradoAcademicoDto> ObtenerTodo();
    }
}
