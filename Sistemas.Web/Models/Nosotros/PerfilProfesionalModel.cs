using Sistemas.Web.Models.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sistemas.Web.Models.Nosotros
{
    public class PerfilProfesionalModel : Pagina
    {
        public string Sumilla { get; set; }
        public List<Lista> Secciones { get; set; }

        public PerfilProfesionalModel()
            : base("Perfil profesional")
        {

        }

        public static PerfilProfesionalModel Obtener()
        {
            return new PerfilProfesionalModel
            {
                Sumilla = "Este es el perfil profesional buscado.",
                Secciones = new List<Lista>
                {
                    new Lista
                    {
                        Titulo = "Descripción de la Carrera",
                        Elementos = new List<ElementoLista>
                        {
                            new ElementoLista{ Titulo = "Duración de la carrera profesional: ", Descripcion = "10 Ciclos Académicos." },
                            new ElementoLista{ Titulo = "Denominación de grado académico: ", Descripcion = "Bachiller en Ingeniería de Sistemas." },
                            new ElementoLista{ Titulo = "Denominación de título profesional: ", Descripcion = "Ingeniero de Sistemas." }
                        }
                    },
                    new Lista
                    {
                        Titulo = "Formamos Profesionales:",
                        Elementos = new List<ElementoLista>
                        {
                            new ElementoLista{ Descripcion = "Capacitados para desarrollar Sistemas de Información." },
                            new ElementoLista{ Descripcion = "Preparados para administrar Base de Datos." },
                            new ElementoLista{ Descripcion = "Preparados para administrar Redes, Telecomunicaciones e Infraestructura de Tecnologías de Información." },
                            new ElementoLista{ Descripcion = "Capacitados para ser integradores de Sistemas de Información." }
                        }
                    },
                    new Lista
                    {
                        Titulo = "Con las Competencias para:",
                        Elementos = new List<ElementoLista>
                        {
                            new ElementoLista{ Descripcion = "Analizar, diseñar e implementar sistemas de información, aplicando metodologías y tecnologías de información, para proponer soluciones informáticas que permitan el desarrollo de las organizaciones." },
                            new ElementoLista{ Descripcion = "Modelar, construir y gestionar la arquitectura de datos de la organización, utilizando programas de administración de base de datos que permitan administrar la información, de acuerdo a los requerimientos, políticas, seguridad y  organización." },
                            new ElementoLista{ Descripcion = "Diseñar, instalar y gestionar redes informáticas y de telecomunicaciones, aplicando conceptos y técnicas de comunicación de datos y redes de ordenadores." },
                            new ElementoLista{ Descripcion = "Traducir las nuevas herramientas y soluciones tecnológicas a través de la interacción de los subsistemas: empresa, sistemas de información y arquitectura de TI." }
                        }
                    },
                    new Lista
                    {
                        Titulo = "Podrás desarrollarte en:",
                        Elementos = new List<ElementoLista>
                        {
                            new ElementoLista{ Descripcion = "Áreas de informática, tecnología de información, desarrollo o sistemas en empresas de todo rubro." },
                            new ElementoLista{ Descripcion = "Áreas de auditoría y control de sistemas." },
                            new ElementoLista{ Descripcion = "Empresas especializadas en desarrollo y consultoría en tecnologías de información." },
                            new ElementoLista{ Descripcion = "Empresas especializadas en outsourcing de sistemas." },
                            new ElementoLista{ Descripcion = "Empresas especializadas en venta y representación de soluciones informáticas." },
                            new ElementoLista{ Descripcion = "Desarrollo independiente de soluciones informáticas." }
                        }
                    },
                    new Lista
                    {
                        Titulo = "Marcamos la Diferencia:",
                        Elementos = new List<ElementoLista>
                        {
                            new ElementoLista{ Descripcion = "Plana docente especializada." },
                            new ElementoLista{ Descripcion = "Infraestructura implementada con equipos y laboratorios de última generación." },
                            new ElementoLista{ Descripcion = "Plan de estudios actualizado, basado en estándares internacionales." },
                            new ElementoLista{ Descripcion = "La escuela se encuentra en proceso de acreditación." }
                        }
                    }
                }
            };
        }
    }
}