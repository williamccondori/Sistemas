using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sistemas.Web.Models.Shared
{
    public class Lista
    {
        public string Titulo { get; set; }
        public string Descripcion { get; set; }
        public List<ElementoLista> Elementos { get; set; }

        public Lista()
        {
            Elementos = new List<ElementoLista>();
        }
    }
}