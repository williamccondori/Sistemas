using System;

namespace Sistemas.Entidades.Dtos
{
    public class UsuarioSinPasswordDto
    {
        public int IdUsuario { get; set; }
        public string DescripcionUsuario { get; set; }
        public string DescripcionNombre { get; set; }
        public string DescripcionApellido { get; set; }
        public string DescripcionEmail { get; set; }
        public string DescripcionImagen { get; set; }
        public string IndicadorHabilitado { get; set; }
        public string IndicadorEstado { get; set; }
        public string UsuarioRegistro { get; set; }
        public string UsuarioModifico { get; set; }
        public DateTime FechaRegistro { get; set; }
        public DateTime? FechaModifico { get; set; }
    }
}
