using Sistemas.Web.Models.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sistemas.Web.Models.Nosotros
{
    public class ObjetivoEducacionalModel
    {
        public string Titulo { get; set; }
        public string Sumilla { get; set; }
        public string Subtitulo { get; set; }
        public List<ElementoLista> Objetivos { get; set; }

        public ObjetivoEducacionalModel()
        {
            Objetivos = new List<ElementoLista>();
        }

        public static ObjetivoEducacionalModel Obtener()
        {
            return new ObjetivoEducacionalModel
            {
                Titulo = "Objetivos Educacionales",
                Sumilla = "Son declaraciones generales que describen lo que se espera que los graduados logren algunos años después de la graduación. Los objetivos educacionales del programa están basados en las necesidades de los constituyentes del programa.",
                Subtitulo = "Estos son nuestros objetivos educacionales:",
                Objetivos = new List<ElementoLista>
                {
                    new ElementoLista { Titulo = "Competencia técnica", Descripcion = "Demuestran una sólida competencia técnica en el análisis, diseño, implementación y gestión de sistemas de información basados en software para optimizar los procesos en las organizaciones." },
                    new ElementoLista { Titulo = "Versatilidad", Descripcion = "Se desenvuelven en los diferentes entornos y etapas de un proyecto de ingeniería logrando las metas y objetivos propuestos. " },
                    new ElementoLista { Titulo = "Colaboración y comunicación", Descripcion = "Se intergran en forma activa a equipos multidisciplinarios siendo reconocidos como líderes asertivos." },
                    new ElementoLista { Titulo = "Profesionalismo", Descripcion = "Se conducen correctamente respetando los principios éticos de la profesión, asumiendo sus responsabilidades sociales y profesionales." },
                    new ElementoLista { Titulo = "Aprendizaje permanente", Descripcion = "Se actualizan continuamente y completan estudios de especialización y postgrado." }
                }
            };
        }
    }
}