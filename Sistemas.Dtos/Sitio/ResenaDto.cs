using Sistemas.Dtos.Shared;

namespace Sistemas.Dtos.Sitio
{
    public class ResenaDto : BaseDto
    {
        public long Id { get; set; }
        public string IdTipoResena { get; set; }
        public long IdAutorResena { get; set; }
        public string Titulo { get; set; }
        public string Subtitulo { get; set; }
        public string Resumen { get; set; }
        public string Resena { get; set; }
        public string Recurso { get; set; }
        public TipoResenaDto TipoResena { get; set; }
        public AutorResenaDto AutorResena { get; set; }
    }
}