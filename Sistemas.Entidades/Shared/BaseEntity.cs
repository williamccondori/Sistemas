using Sistemas.Entidades.Contratos;
using Sistemas.Utilidades.Constantes;
using System;

namespace Sistemas.Entidades.Shared
{
    public class BaseEntity : IBaseEntity
    {
        public string IndicadorEstado { get; set; }
        public string UsuarioRegistro { get; set; }
        public string UsuarioModifico { get; set; }
        public DateTime FechaRegistro { get; set; }
        public DateTime? FechaModifico { get; set; }
        public EstadoObjeto EstadoObjeto { get; set; }

        public void Nuevo(string usuario)
        {
            IndicadorEstado = EstadoEntidad.Activo;
            UsuarioRegistro = usuario;
            FechaRegistro = DateTime.Now;
            EstadoObjeto = EstadoObjeto.Nuevo;
        }
    }

    public enum EstadoObjeto
    {
        SinCambios,
        Nuevo,
        Modificado,
        Borrado
    }
}
