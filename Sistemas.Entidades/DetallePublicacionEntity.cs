using Sistemas.Entidades.Shared;

namespace Sistemas.Entidades
{
    public class DetallePublicacionEntity : BaseEntity
    {
        public long IdDetallePublicacion { get; set; }
        public long IdPublicacion { get; set; }
        public string IdTipoDetallePublicacion { get; set; }
        public string DescripcionTitulo { get; set; }
        public string DescripcionResumen { get; set; }
        public string DescripcionRecurso { get; set; }
        public PublicacionEntity PublicacionX { get; set; }
        public TipoDetallePublicacionEntity TipoDetallePublicacionX { get; set; }

        public static DetallePublicacionEntity Crear(string idTipoDetallePublicacion, string descripcionTitulo
            , string descripcionResumen, string descripcionRecurso, string usuario)
        {
            DetallePublicacionEntity detallePublicacion = new DetallePublicacionEntity
            {
                IdTipoDetallePublicacion = idTipoDetallePublicacion,
                DescripcionTitulo = descripcionTitulo,
                DescripcionResumen = descripcionResumen,
                DescripcionRecurso = descripcionRecurso,
            };

            detallePublicacion.Nuevo(usuario);

            return detallePublicacion;
        }
    }
}
