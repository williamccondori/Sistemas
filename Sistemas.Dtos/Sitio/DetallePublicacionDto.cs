using Sistemas.Dtos.Shared;

namespace Sistemas.Dtos.Sitio
{
    public class DetallePublicacionDto : BaseDto
    {
        public long Id { get; set; }
        public long IdPublicacion { get; set; }
        public string IdTipoDetallePublicacion { get; set; }
        public string Titulo { get; set; }
        public string Resumen { get; set; }
        public string Recurso { get; set; }
        public PublicacionDto Publicacion { get; set; }
        public TipoDetallePublicacionDto TipoDetallePublicacion { get; set; }
    }
}