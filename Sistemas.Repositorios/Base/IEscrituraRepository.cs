namespace Sistemas.Repositorios.Base
{
    public interface IEscrituraRepository<T>
    {
        void Crear(T entidad);
        void Modificar();
        void Eliminar(object idEntidad);
    }
}
