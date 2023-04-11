using Microsoft.EntityFrameworkCore;

namespace Backend.Shared.Repositories.Context.Config.Commons
{
    public static class UpzConfig
    {
        /// <summary>
        /// Adds the upz.
        /// </summary>
        /// <param name="modelBuilder">The model builder.</param>
        public static void AddUpz(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Entities.Models.Commons.Upz>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Upz", "commons");

                entity.Property(e => e.Descripcion)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.UpzId).HasColumnName("upz_id");

                entity.Property(e => e.UpzLocalidad).HasColumnName("upz_localidad");
            });
        }
    }
}
