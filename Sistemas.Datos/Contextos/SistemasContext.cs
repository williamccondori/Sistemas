using Sistemas.Datos.Configuraciones;
using Sistemas.Datos.Shared;
using Sistemas.Entidades;
using System.Data.Entity;

namespace Sistemas.Datos.Contextos
{
    public class SistemasContext : BaseContext
    {
        public SistemasContext()
            : base("name=SistemasConnection")
        {
            Database.SetInitializer<SistemasContext>(null);
        }

        public DbSet<AutorResenaEntity> AutoresResena { get; set; }
        public DbSet<CanalEntity> Canales { get; set; }
        public DbSet<ClienteEntity> Clientes { get; set; }
        public DbSet<DetallePublicacionEntity> DetallesPublicacion { get; set; }
        public DbSet<GradoAcademicoEntity> GradosAcademicos { get; set; }
        public DbSet<MensajeEntity> Mensajes { get; set; }
        public DbSet<PublicacionEntity> Publicaciones { get; set; }
        public DbSet<ResenaEntity> Resenas { get; set; }
        public DbSet<TipoDetallePublicacionEntity> TiposDetallePublicacion { get; set; }
        public DbSet<TipoPublicacionEntity> TiposPublicacion { get; set; }
        public DbSet<TipoResenaEntity> TiposResena { get; set; }
        public DbSet<UsuarioEntity> Usuarios { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new AutorResenaConfiguration());
            modelBuilder.Configurations.Add(new CanalConfiguration());
            modelBuilder.Configurations.Add(new ClienteConfiguration());
            modelBuilder.Configurations.Add(new DetallePublicacionConfiguration());
            modelBuilder.Configurations.Add(new GradoAcademicoConfiguration());
            modelBuilder.Configurations.Add(new MensajeConfiguration());
            modelBuilder.Configurations.Add(new PublicacionConfiguration());
            modelBuilder.Configurations.Add(new ResenaConfiguration());
            modelBuilder.Configurations.Add(new TipoDetallePublicacionConfiguration());
            modelBuilder.Configurations.Add(new TipoPublicacionConfiguration());
            modelBuilder.Configurations.Add(new TipoResenaConfiguration());
            modelBuilder.Configurations.Add(new UsuarioConfiguration());

            base.OnModelCreating(modelBuilder);
        }

        public void GuardarCambios()
        {
            base.AplicarCambios();
        }
    }
}
