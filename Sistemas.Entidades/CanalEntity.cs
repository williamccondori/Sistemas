using Sistemas.Entidades.Shared;

namespace Sistemas.Entidades
{
    public class CanalEntity : BaseEntity
    {
        public string IdCanal { get; set; }
        public string DescripcionCanal { get; set; }
        public static CanalEntity Crear(string idCanal, string descripcionCanal, string usuario)
        {
            CanalEntity canal = new CanalEntity
            {
                IdCanal = idCanal,
                DescripcionCanal = descripcionCanal
            };

            canal.Nuevo(usuario);

            return canal;
        }
    }
}
