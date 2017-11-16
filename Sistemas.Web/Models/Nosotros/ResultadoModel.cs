using Sistemas.Web.Models.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sistemas.Web.Models.Nosotros
{
    public class ResultadoModel
    {
        public string Titulo { get; set; }
        public string Sumilla { get; set; }
        public string Subtitulo { get; set; }
        public List<ElementoLista> Resultados { get; set; }

        public static ResultadoModel Obtener()
        {
            return new ResultadoModel
            {
                Titulo = "Resultados del Aprendizaje",
                Sumilla = "Son declaraciones breves que describen lo que el estudiante debe saber y ser capaz de hacer al momento de la graduación. Estos se relacionan con las habilidades, conocimiento y comportamiento que los estudiantes adquieren a lo largo de su progreso en la carrera.",
                Subtitulo = "Estos son los resultados del aprendizaje:",
                Resultados = new List<ElementoLista>
                {
                    new ElementoLista{ Titulo = "1A. Aplicación de Ciencias", Descripcion = "Aplica los conocimientos y habilidades en matemáticas, ciencias e ingeniería para resolver problemas de ingeniería sistemas." },
                    new ElementoLista{ Titulo = "2B. Experimentación y Pruebas", Descripcion = "Diseñan y conducen experimentos, analizan e interpretan datos." },
                    new ElementoLista{ Titulo = "3C. Diseño en Ingeniería", Descripcion = "Diseña sistemas informáticos, componentes y / o procesos para satisfacer requerimientos considerando restricciones realistas de seguridad y sostenibilidad." },
                    new ElementoLista{ Titulo = "4D. Trabajo en Equipo", Descripcion = "Participa activa y efectivamente en grupos multidisciplinarios siendo capaces de liderarlos." },
                    new ElementoLista{ Titulo = "5E. Solución de Problemas de Ingeniería", Descripcion = "Identifica, formula y resuelve problemas de ingeniería usando las técnicas, métodos y herramientas apropiados." },
                    new ElementoLista{ Titulo = "6F. Responsabilidad Ética y Profesional", Descripcion = "Entienden sus responsabilidades profesionales, éticas, sociales y legales, y cumplen los compromisos asumidos." },
                    new ElementoLista{ Titulo = "7G. Comunicación", Descripcion = "Se comunican clara y efectivamente en forma oral, escrita y gráfica, interactuando con diferentes tipos de audiencias." },
                    new ElementoLista{ Titulo = "8H. Perspectiva Local y Global", Descripcion = "Comprende el impacto que tienen las soluciones de ingeniería en la sociedad en un contexto local y global." },
                    new ElementoLista{ Titulo = "9I. Educación Continua", Descripcion = "Reconocen la necesidad de mantener sus conocimientos y habilidades actualizadas de acuerdo a los avances de la ingeniería de software y sistemas de información y se compromete con un aprendizaje para toda la vida." },
                    new ElementoLista{ Titulo = "10J. Asuntos Contemporáneos", Descripcion = "Conoce y analiza asuntos contemporáneos relevantes en contextos locales, nacionales y globales." },
                    new ElementoLista{ Titulo = "11K. Práctica de la Ingeniería Moderna", Descripcion = "Usa las técnicas, métodos y herramientas de la ingeniería moderna necesarias para la práctica de la ingeniería de software y sistemas de información." },
                    new ElementoLista{ Titulo = "12L. Gestión de Proyectos", Descripcion = "Planifica y gestiona proyectos de ingeniería tomando en cuenta criterios de eficiencia y productividad." },
                    new ElementoLista{ Titulo = "13M. Desarrollo de Software e Implementación de SI.", Descripcion = "Desarrolla e implementa software y sistemas de información satisfaciendo requerimientos y aplicando metodologías, técnicas y herramientas apropiadas." }
                }
            };
        }
    }
}