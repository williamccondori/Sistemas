using Sistemas.Entidades.Shared;

namespace Sistemas.Entidades
{
    public class TipoDetallePublicacionEntity : BaseEntity
    {
        public string IdTipoDetallePublicacion { get; set; }
        public string DescripcionTipoDetallePublicacion { get; set; }

        public static TipoDetallePublicacionEntity Crear(string idTipoDetallePublicacion, string descripcionTipoDetallePublicacion, string usuario)
        {
            TipoDetallePublicacionEntity tipoDetallePublicacion = new TipoDetallePublicacionEntity
            {
                IdTipoDetallePublicacion = idTipoDetallePublicacion,
                DescripcionTipoDetallePublicacion = descripcionTipoDetallePublicacion
            };

            tipoDetallePublicacion.Nuevo(usuario);

            return tipoDetallePublicacion;
        }

        public void Modificar(string descripcion, string usuario)
        {
            DescripcionTipoDetallePublicacion = descripcion;
            Modificado(usuario);
        }
    }
}
