using Sistemas.Entidades.Shared;
using System;

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

        public static ResenaEntity Crear(string idTipoResena, long idAutorResena, string titulo, string subtitulo
            , string resumen, string resena, string recurso, string usuario)
        {
            ResenaEntity _resena = new ResenaEntity
            {
                DescripcionRecurso = recurso,
                DescripcionResena = resena,
                DescripcionResumen = resumen,
                DescripcionSubtitulo = subtitulo,
                DescripcionTitulo = titulo,
                IdAutorResena = idAutorResena,
                IdTipoResena = idTipoResena
            };

            _resena.Nuevo(usuario);

            return _resena;
        }

        public void Modificar(string idTipoResena, long idAutorResena, string titulo, string subtitulo, string resumen
            , string resena, string recurso, string usuario)
        {
            IdTipoResena = idTipoResena;
            IdAutorResena = idAutorResena;
            DescripcionTitulo = titulo;
            DescripcionSubtitulo = subtitulo;
            DescripcionResumen = resumen;
            DescripcionResena = resena;
            DescripcionRecurso = recurso;
            Modificado(usuario);
        }

        public void ValidarObligatorios()
        {
            if (string.IsNullOrEmpty(DescripcionTitulo)) throw new Exception("El campo 'título' es obligatorio");
        }

        public TipoResenaEntity ObtenerTipo()
        {
            if (TipoResenaX == null)
            {
                throw new Exception("No se ha asignado un valor para el tipo de reseña");
            }

            return TipoResenaX;
        }

        public AutorResenaEntity ObtenerAutor()
        {
            if (AutorResenaX == null)
            {
                throw new Exception("No se ha asignado un valor para el autor de la reseña");
            }

            return AutorResenaX;
        }
    }
}