using Sistemas.Entidades;
using Sistemas.Repositorios.Base;
using System.Collections.Generic;

namespace Sistemas.Repositorios
{
    public interface IPublicacionRepository : IBaseRepository<PublicacionEntity>
    {
        ICollection<PublicacionEntity> ObtenerPorTipo(string idTipoPublicacion);
        ICollection<PublicacionEntity> ObtenerXTipoXAnio(string idTipoPublicacion, int anio);
        PublicacionEntity ObtenerXId(long idPublicacion);
    }
}
