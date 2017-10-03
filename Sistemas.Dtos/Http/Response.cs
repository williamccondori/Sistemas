namespace Sistemas.Dtos.Http
{
    public class Response<T>
    {
        public int Codigo { get; set; }
        public bool Estado { get; set; }
        public string Mensaje { get; set; }
        public string Traza { get; set; }
        public T Datos { get; set; }

        public static Response<T> Correcto(T datos)
        {
            return new Response<T>
            {
                Codigo = 200,
                Estado = true,
                Mensaje = string.Empty,
                Traza = string.Empty,
                Datos = datos
            };
        }

        public static Response<T> Incorrecto(string mensaje, string traza, int codigo = 500)
        {
            return new Response<T>
            {
                Codigo = codigo,
                Estado = false,
                Mensaje = mensaje,
                Traza = traza,
                Datos = default(T)
            };
        }
    }
}
