using Microsoft.EntityFrameworkCore;

namespace Backend.Shared.Repositories.Context
{
    public partial class CommonsMySQLContext : DbContext
    {
        public CommonsMySQLContext(DbContextOptions<CommonsMySQLContext> options)
            : base(options)
        {
        }

        //public virtual DbSet<Entities.Models.Tramites.Persona> Persona { get; set; }

        //public virtual DbSet<Entities.Models.Tramites.PrNiveleducativo> Niveleducativo { get; set; }

        //public virtual DbSet<Entities.Models.Tramites.PrEtnia> Etnia { get; set; }


        //public virtual DbSet<Entities.Models.Tramites.PrSexo> Sexo { get; set; }

        //public virtual DbSet<Entities.Models.Tramites.PrDepartamento> Departamento { get; set; }


        //public virtual DbSet<Entities.Models.Tramites.PrPais> Pais { get; set; }

        //public virtual DbSet<Entities.Models.Tramites.PrTipoidentificacion> Tipoidentificacion { get; set; }

        //public virtual DbSet<Entities.Models.Tramites.PrMunicipio> Municipio { get; set; }

        //public virtual DbSet<Entities.Models.Tramites.PrSubred> SubRed { get; set; }

        //public virtual DbSet<Entities.Models.Tramites.PrBarrio> Barrio { get; set; }
        //public virtual DbSet<Entities.Models.Tramites.PrLocalidad> Localidad { get; set; }
        //public virtual DbSet<Entities.Models.Tramites.PrUpz> Upz { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
          
            //modelBuilder.Entity<Entities.Models.Tramites.PrUpz>(entity =>
            //{
            //    entity.ToTable("pr_upz").HasNoKey();

            //    entity.Property(e=> e.id_upz);
            //    entity.Property(e => e.id_localidad);
            //    entity.Property(e => e.cod_upz);
            //    entity.Property(e => e.nom_upz);
            //}
            //);

            OnModelCreatingPartial(modelBuilder);
        }
        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
