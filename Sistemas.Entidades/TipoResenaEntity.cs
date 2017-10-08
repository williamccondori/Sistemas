using Sistemas.Entidades.Shared;

namespace Sistemas.Entidades
{
    public class TipoResenaEntity : BaseEntity
    {
        public string IdTipoResena { get; set; }
        public string DescripcionTipoResena { get; set; }

        public static TipoResenaEntity Crear(string idTipoResena, string descripcionTipoResena, string usuario)
        {
            TipoResenaEntity tipoResena = new TipoResenaEntity
            {
                IdTipoResena = idTipoResena,
                DescripcionTipoResena = descripcionTipoResena
            };

            tipoResena.Nuevo(usuario);

            return tipoResena;
        }

        public void Modificar(string descripcion, string usuario)
        {
            DescripcionTipoResena = descripcion;
            Modificado(usuario);
        }
    }
}
