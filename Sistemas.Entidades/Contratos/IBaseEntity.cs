using System;

namespace Sistemas.Entidades.Contratos
{
    public interface IBaseEntity : IEstadoObjeto
    {
        string IndicadorEstado { get; set; }
        string UsuarioRegistro { get; set; }
        string UsuarioModifico { get; set; }
        DateTime FechaRegistro { get; set; }
        DateTime? FechaModifico { get; set; }
    }
}
