using Sistemas.Dtos.Sitio;
using Sistemas.Externos.RSS;
using Sistemas.Externos.RSS.Modelos;
using Sistemas.Servicios.Web;
using System.Collections.Generic;
using System.Linq;

namespace Sistemas.Servicios.Implementacion.Web
{
    public class ActualidadService : IActualidadService
    {
        public string _url = "http://rpp.pe/feed/tecnologia";

        public IList<PublicacionDto> Obtener()
        {
            Lector lectorRss = new Lector(_url);

            List<Articulo> articulos = lectorRss.Obtener();

            List<PublicacionDto> publicaciones = articulos.Select(p => new PublicacionDto
            {
                Titulo = p.Titulo,
                Fecha = p.Fecha,
                Resena = p.Descripcion,
                Url = p.Enlace,
                Id = 0,
                Recurso = p.Imagen
            }).ToList();

            return publicaciones;
        }

        public IList<PublicacionDto> ObtenerHistorico(int anio)
        {
            throw new System.NotImplementedException();
        }
    }
}
