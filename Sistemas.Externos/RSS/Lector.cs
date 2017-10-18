using Sistemas.Externos.RSS.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml;
using System.Xml.Serialization;

namespace Sistemas.Externos.RSS
{
    public class Lector
    {
        private readonly string _url;

        public Lector(string url)
        {
            _url = url;
        }

        public List<Articulo> Obtener()
        {
            try
            {
                Rss contenidoRss = new Rss();

                XmlSerializer serializador = new XmlSerializer(typeof(Rss));

                using (XmlTextReader reader = new XmlTextReader(_url))
                    contenidoRss = serializador.Deserialize(reader) as Rss;

                List<Articulo> articulos = new List<Articulo>();

                foreach (XmlNode[] propiedades in contenidoRss.channel.item)
                {
                    string id = propiedades[4].InnerText;
                    string descripcion = propiedades[1].InnerText;
                    string enlace = propiedades[3].InnerText;
                    string titulo = propiedades[0].InnerText;
                    string fechastring = propiedades[2].InnerText;
                    DateTime fecha = DateTime.Parse(fechastring);
                    var imagenes = propiedades[6].Attributes;
                    string imagen = imagenes.Count > 0 ? imagenes[0].InnerText : string.Empty;

                    articulos.Add(new Articulo
                    {
                        Id = id,
                        Descripcion = descripcion,
                        Enlace = enlace,
                        Fecha = fecha,
                        Imagen = imagen,
                        Titulo = titulo
                    });
                }

                return articulos.OrderByDescending(p => p.Fecha).ToList();
            }
            catch (Exception)
            {
                return default(List<Articulo>);
            }
        }
    }
}
