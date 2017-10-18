using System;

namespace Sistemas.Externos.RSS.Modelos
{
    public class Articulo
    {
        public string Titulo { get; set; }
        public string Enlace { get; set; }
        public string Id { get; set; }
        public string Descripcion { get; set; }
        public DateTime Fecha { get; set; }
        public string Imagen { get; set; }
    }
}
