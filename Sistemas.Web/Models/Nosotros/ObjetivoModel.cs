using Sistemas.Web.Models.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sistemas.Web.Models.Nosotros
{
    public class ObjetivoModel
    {
        public string Titulo { get; set; }
        public string Sumilla { get; set; }
        public string Subtitulo { get; set; }
        public List<ElementoLista> Objetivos { get; set; }

        public ObjetivoModel()
        {
            Objetivos = new List<ElementoLista>();
        }

        public static ObjetivoModel Obtener()
        {
            return new ObjetivoModel
            {
                Titulo = "Objetivos",
                Sumilla = "Objetivos",
                Subtitulo = "Estos son nuestros objetivos:",
                Objetivos = new List<ElementoLista>
                {
                    new ElementoLista { Descripcion = "Formar profesionales con una sólida competencia técnica en el análisis, diseño, implementación y gestión de sistemas de información basados en software para optimizar los procesos en las organizaciones, que les permita desenvolverse en diferentes entornos organizacionales." },
                    new ElementoLista { Descripcion = "Formamos Ingenieros  que se integran en forma activa a equipos multidisciplinarios siendo reconocidos como líderes asertivos, respetando los principios éticos de la profesión, asumiendo sus responsabilidades sociales y profesionales." },
                    new ElementoLista { Descripcion = "Fomentar entre nuestros graduados el aprendizaje continuo." },
                    new ElementoLista { Descripcion = "Fomentar el desarrollo de actividades permanentes de proyección social y extensión universitaria a través de la ejecución de proyectos que benefician a la comunidad en general y la prestación de servicios." }
                }
            };
        }
    }
}