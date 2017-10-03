using Sistemas.Dtos.Shared;

namespace Sistemas.Dtos.Sitio
{
    public class GradoAcademicoDto : BaseDto
    {
        public int Id { get; set; }
        public string Abreviatura { get; set; }
        public string Titulo { get; set; }
    }
}
