using System;

namespace Sistemas.Dtos.Shared
{
    public class BaseDto
    {
        public string Usuario { get; set; }
        public DateTime Fecha { get; set; }
        public EstadoObjeto Estado { get; set; }
    }

    public enum EstadoObjeto
    {
        SinCambios,
        Nuevo,
        Modificado,
        Borrado
    }
}
