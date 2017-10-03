using Sistemas.Datos.Helpers;
using Sistemas.Entidades.Contratos;
using System;
using System.Data.Entity;
using System.Linq;

namespace Sistemas.Datos.Shared
{
    public class BaseContext : DbContext
    {
        public BaseContext()
        {

        }

        public BaseContext(string cadenaConexion)
            : base(cadenaConexion)
        {
            Database.SetInitializer<BaseContext>(null);
        }

        protected void AplicarCambios()
        {
            Aplicar();

            base.SaveChanges();
        }

        private void Aplicar()
        {
            foreach (var Entidad in ChangeTracker.Entries<IBaseEntity>().ToList())
            {
                Entidad.State = EntityStateHelper.ConvertirAEntityState(Entidad.Entity.EstadoObjeto);

                if (Entidad.State == EntityState.Modified)
                {
                    Entidad.Entity.FechaModifico = Entidad.Entity.FechaModifico ?? DateTime.Now;
                }
                else if (Entidad.State == EntityState.Added)
                {
                    Entidad.Entity.FechaRegistro = Entidad.Entity.FechaRegistro;
                }
            }

            foreach (var Entidad in ChangeTracker.Entries<IEstadoObjeto>().ToList())
            {
                Entidad.State = EntityStateHelper.ConvertirAEntityState(Entidad.Entity.EstadoObjeto);
            }
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
