using System;

namespace Sistemas.Utilidades.Extensiones
{
    public static class DateTimeExtension
    {
        public static string ObtenerCadenaFecha(this DateTime fecha)
        {
            if (fecha == null)
                return string.Empty;

            return fecha.ToShortDateString();
        }
    }
}
