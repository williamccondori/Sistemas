using Sistemas.Dtos.Shared;

namespace Sistemas.Dtos.Sitio
{
    public class AutorResenaDto : BaseDto
    {
        public long Id { get; set; }
        public int IdGradoAcademico { get; set; }
        public string Cargo { get; set; }
        public string Recurso { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public GradoAcademicoDto GradoAcademico { get; set; }
    }
}
