using Sistemas.Web.Models.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sistemas.Web.Models.Investigacion
{
    public class Trabajo
    {

    }

    public class TrabajoModel : Pagina
    {
        public List<Trabajo> Trabajos { get; set; }

        public TrabajoModel() 
            : base("Trabajos académicos")
        {
            Trabajos = new List<Trabajo>();
        }

        public static TrabajoModel Obtener()
        {
            return new TrabajoModel
            {
                Subtitulo = "Encuentra los mejores trabajos de investigación publicados por los estudiantes de la Escuela Profesional de Ingeniería de Sistemas."
            };
        }
    }
}