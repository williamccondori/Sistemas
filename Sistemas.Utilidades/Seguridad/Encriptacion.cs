using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace Sistemas.Utilidades.Seguridad
{
    public class Encriptacion
    {
        private readonly byte[] _claveEncriptacion;
        private readonly byte[] _vectorInicializacion;

        public Encriptacion(string claveEncriptacion)
        {
            _vectorInicializacion = Encoding.ASCII.GetBytes("Devjoker7.37hAES");
            _claveEncriptacion = Encoding.ASCII.GetBytes(claveEncriptacion);
        }

        public string Encriptar(string cadenaEntrante)
        {

            byte[] bytesEntrantes = Encoding.ASCII.GetBytes(cadenaEntrante);
            byte[] bytesEncriptados;

            RijndaelManaged cripto = new RijndaelManaged();
            using (MemoryStream memoryStream = new MemoryStream(bytesEntrantes.Length))
            {
                using (CryptoStream encriptacion = new CryptoStream(memoryStream, cripto.CreateEncryptor(_claveEncriptacion, _vectorInicializacion), CryptoStreamMode.Write))
                {
                    encriptacion.Write(bytesEntrantes, 0, bytesEntrantes.Length);
                    encriptacion.FlushFinalBlock();
                    encriptacion.Close();
                }
                bytesEncriptados = memoryStream.ToArray();
            }

            string cadenaEncriptada = Convert.ToBase64String(bytesEncriptados);

            return cadenaEncriptada;
        }

        public string Desencriptar(string cadenaEncriptada)
        {
            byte[] bytesEntrantes = Convert.FromBase64String(cadenaEncriptada);
            byte[] bytesDesencriptados = new byte[bytesEntrantes.Length];

            string cadenaEntrante = string.Empty;

            RijndaelManaged administradorEncriptacion = new RijndaelManaged();
            using (MemoryStream memoryStream = new MemoryStream(bytesEntrantes))
            {
                using (CryptoStream encriptacion = new CryptoStream(memoryStream, administradorEncriptacion.CreateDecryptor(_claveEncriptacion, _vectorInicializacion), CryptoStreamMode.Read))
                {
                    using (StreamReader streamReader = new StreamReader(encriptacion, true))
                    {
                        cadenaEntrante = streamReader.ReadToEnd();
                    }
                }
            }
            return cadenaEntrante;
        }
    }
}
