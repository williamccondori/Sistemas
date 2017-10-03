using Sistemas.Entidades.Shared;
using System;
using System.Collections.Generic;

namespace Sistemas.Entidades
{
    public class PublicacionEntity : BaseEntity
    {
        public long IdPublicacion { get; set; }
        public string IdTipoPublicacion { get; set; }
        public string DescripcionTitulo { get; set; }
        public string DescripcionSubtitulo { get; set; }
        public string DescripcionResumen { get; set; }
        public string DescripcionResena { get; set; }
        public string DescripcionRecurso { get; set; }
        public string DescripcionUrl { get; set; }
        public DateTime FechaPublicacion { get; set; }
        public TipoPublicacionEntity TipoPublicacionX { get; set; }
        public ICollection<DetallePublicacionEntity> DetallePublicacionS { get; set; }

        public static PublicacionEntity Crear(string idTipoPublicacion, string descripcionTitulo, string descripcionSubtitulo
            , string descripcionResumen, string descripcionResena, string descripcionRecurso, List<DetallePublicacionEntity> detallePublicacionS, string usuario)
        {
            PublicacionEntity publicacion = new PublicacionEntity
            {
                DescripcionRecurso = descripcionRecurso,
                DescripcionResena = descripcionResena,
                DescripcionResumen = descripcionResumen,
                DescripcionSubtitulo = descripcionSubtitulo,
                DescripcionTitulo = descripcionTitulo,
                IdTipoPublicacion = idTipoPublicacion,
                DetallePublicacionS = detallePublicacionS,
                FechaPublicacion = DateTime.Now
            };

            publicacion.Nuevo(usuario);

            return publicacion;
        }

        public void ValidarObligatorios()
        {
            if (string.IsNullOrEmpty(DescripcionTitulo)) throw new Exception("El campo 'título' es obligatorio");
        }
    }
}
