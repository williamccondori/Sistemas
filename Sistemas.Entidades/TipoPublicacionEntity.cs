using Sistemas.Entidades.Shared;

namespace Sistemas.Entidades
{
    public class TipoPublicacionEntity : BaseEntity
    {
        public string IdTipoPublicacion { get; set; }
        public string DescripcionTipoPublicacion { get; set; }

        public static TipoPublicacionEntity Crear(string idTipoPublicacion, string descripcionTipoPublicacion, string usuario)
        {
            TipoPublicacionEntity tipoPublicacion = new TipoPublicacionEntity
            {
                DescripcionTipoPublicacion = descripcionTipoPublicacion,
                IdTipoPublicacion = idTipoPublicacion,
            };

            tipoPublicacion.Nuevo(usuario);

            return tipoPublicacion;
        }
    }
}
