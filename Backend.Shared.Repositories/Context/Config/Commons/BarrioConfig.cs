using Microsoft.EntityFrameworkCore;

namespace Backend.Shared.Repositories.Context.Config.Commons
{
    public static class BarrioConfig
    {
        /// <summary>
        /// Adds the barrio.
        /// </summary>
        /// <param name="modelBuilder">The model builder.</param>
        public static void AddBarrio(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Backend.Shared.Entities.Models.Commons.Barrio>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Barrio", "commons");

                entity.Property(e => e.Descripcion)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.UpzId).HasColumnName("upz_id");
            });
        }
    }
}
