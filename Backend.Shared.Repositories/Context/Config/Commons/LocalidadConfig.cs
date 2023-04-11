using Microsoft.EntityFrameworkCore;

namespace Backend.Shared.Repositories.Context.Config.Commons
{
    public static class LocalidadConfig
    {
        /// <summary>
        /// Adds the localidad.
        /// </summary>
        /// <param name="modelBuilder">The model builder.</param>
        public static void AddLocalidad(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Entities.Models.Commons.Localidad>(entity =>
            {
                entity.HasKey(e => e.IdLocalidad);

                entity.ToTable("Localidad", "commons");

                entity.Property(e => e.IdLocalidad).ValueGeneratedNever();

                entity.Property(e => e.Descripcion)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.IdSubred).HasColumnName("idSubred");

                entity.Property(e => e.LocId).HasColumnName("loc_id");
            });
        }
    }
}
