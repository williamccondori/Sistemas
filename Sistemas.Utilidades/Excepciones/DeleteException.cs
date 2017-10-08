using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistemas.Utilidades.Excepciones
{
    public class DeleteException : Exception
    {

        public DeleteException()
            : base("Se ha producido un error al momento de eliminar el registro, vefifique si tiene detalles asociados o si el registro no ha sido eliminado anteriormente")
        {
            
        }
    }
}
