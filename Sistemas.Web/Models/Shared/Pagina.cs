using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sistemas.Web.Models.Shared
{
    public class Pagina
    {
        public string Titulo { get; private set; }
        public string Subtitulo { get; set; }

        public Pagina(string titulo)
        {
            Titulo = titulo;
        }
    }
}