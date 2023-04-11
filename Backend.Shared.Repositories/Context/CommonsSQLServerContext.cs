using Backend.Shared.Repositories.Context.Config.Commons;
using Microsoft.EntityFrameworkCore;

namespace Backend.Shared.Repositories.Context
{
    public partial class SharedSQLServerContext : DbContext
    {
        public virtual DbSet<Entities.Models.Commons.Barrio> Barrio { get; set; }
        public virtual DbSet<Entities.Models.Commons.Departamento> Departamento { get; set; }
        public virtual DbSet<Entities.Models.Commons.Localidad> Localidad { get; set; }
        public virtual DbSet<Entities.Models.Commons.Municipio> Municipio { get; set; }
        public virtual DbSet<Entities.Models.Commons.Upz> Upz { get; set; }
        public virtual DbSet<Entities.Models.Commons.Dominio> Dominio { get; set; }
        public virtual DbSet<Entities.Models.Commons.TipoDominio> TipoDominio { get; set; } 
        // public virtual DbSet<Entities.Models.Commons.SubRed>  SubRed{ get; set; }

        public SharedSQLServerContext(DbContextOptions<SharedSQLServerContext> options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.AddDominio();
            modelBuilder.AddTipoDominio();
            modelBuilder.AddBarrio();
            modelBuilder.AddDepartamento();
            modelBuilder.AddLocalidad();
            modelBuilder.AddMunicipio();
            modelBuilder.AddUpz();
            //modelBuilder.AddSubRed();
        }
    }
}
