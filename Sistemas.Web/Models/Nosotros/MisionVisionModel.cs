using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sistemas.Web.Models.Nosotros
{
    public class MisionVisionModel
    {
        public string Titulo { get; set; }
        public string Sumilla { get; set; }
        public string Mision { get; set; }
        public string Vision { get; set; }
        public string UrlImagen { get; set; }

        public static MisionVisionModel Obtener()
        {
            return new MisionVisionModel
            {
                Titulo = "Misión y Visión",
                Sumilla = "Nos resumimos en:",
                Mision = "La Escuela de Ingeniería de Sistemas de la UPT, tiene como propósito formar profesionales altamente competitivos, con bases sólidas de formación humanística, que diseñan, desarrollan e implementan soluciones integrales que agreguen valor a las organizaciones y les permita competir en un entorno globalizado.",
                Vision = "Ser líderes en la formación académica, ética, moral y humana de los futuros Ingenieros de Sistemas del País y de los países fronterizos.",
                UrlImagen = "http://www.upn.edu.pe/sites/default/files/upn_mision_vision_interna.jpg"
            };
        }
    }
}