using Sistemas.Entidades.Shared;
using System.Data.Entity;

namespace Sistemas.Datos.Helpers
{
    public class EntityStateHelper
    {
        public static EntityState ConvertirAEntityState(EstadoObjeto estadoObjeto)
        {
            switch (estadoObjeto)
            {
                case EstadoObjeto.SinCambios:
                    {
                        return EntityState.Unchanged;
                    }
                case EstadoObjeto.Nuevo:
                    {
                        return EntityState.Added;
                    }
                case EstadoObjeto.Modificado:
                    {
                        return EntityState.Modified;
                    }
                case EstadoObjeto.Borrado:
                    {
                        return EntityState.Deleted;
                    }
                default:
                    {
                        return EntityState.Unchanged;
                    }
            }
        }
    }
}
