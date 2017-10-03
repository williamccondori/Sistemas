using System;
using System.Web;
using System.Web.SessionState;

namespace Sistemas.Administracion.Infraestructura
{
    public class Sesion
    {
        public static string Usuario()
        {
            HttpSessionState session = HttpContext.Current.Session;
            object username = session["USERNAME"];

            if (username == null)
            {
                throw new Exception("La sesión del usuario ha caducado o no existe");
            }

            return username.ToString();
        }

        public static void IniciarSesion(string username)
        {
            HttpSessionState session = HttpContext.Current.Session;
            session.Add("USERNAME", username);
        }

        public static void CerrarSesion()
        {
            HttpSessionState session = HttpContext.Current.Session;
            session.Abandon();
        }

        public static bool ValidarSesion()
        {
            HttpSessionState session = HttpContext.Current.Session;
            object username = session["USERNAME"];

            if (username == null)
            {
                return false;
            }

            return true;
        }
    }
}