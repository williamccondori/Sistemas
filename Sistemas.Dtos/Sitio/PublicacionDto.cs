using Sistemas.Dtos.Shared;
using System;
using System.Collections.Generic;

namespace Sistemas.Dtos.Sitio
{
    public class PublicacionDto : BaseDto
    {
        public long Id { get; set; }
        public string IdTipoPublicacion { get; set; }
        public string Titulo { get; set; }
        public string Subtitulo { get; set; }
        public string Resumen { get; set; }
        public string Resena { get; set; }
        public string Recurso { get; set; }
        public DateTime Emision { get; set; }
        public TipoPublicacionDto TipoPublicacion { get; set; }
        public List<DetallePublicacionDto> Detalles { get; set; }
    }
}
