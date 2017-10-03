using Sistemas.Entidades.Shared;

namespace Sistemas.Entidades
{
    public class ResenaEntity : BaseEntity
    {
        public long IdResena { get; set; }
        public string IdTipoResena { get; set; }
        public long IdAutorResena { get; set; }
        public string DescripcionTitulo { get; set; }
        public string DescripcionSubtitulo { get; set; }
        public string DescripcionResumen { get; set; }
        public string DescripcionResena { get; set; }
        public string DescripcionRecurso { get; set; }
        public TipoResenaEntity TipoResenaX { get; set; }
        public AutorResenaEntity AutorResenaX { get; set; }

        public static ResenaEntity Crear(string idTipoResena, long idAutorResena, string descripcionTitulo, string descripcionSubtitulo
            , string descripcionResumen, string descripcionResena, string descripcionRecurso, string usuario)
        {
            ResenaEntity resena = new ResenaEntity
            {
                DescripcionRecurso = descripcionRecurso,
                DescripcionResena = descripcionResena,
                DescripcionResumen = descripcionResumen,
                DescripcionSubtitulo = descripcionSubtitulo,
                DescripcionTitulo = descripcionTitulo,
                IdAutorResena = idAutorResena,
                IdTipoResena = idTipoResena
            };

            resena.Nuevo(usuario);

            return resena;
        }
    }
}
