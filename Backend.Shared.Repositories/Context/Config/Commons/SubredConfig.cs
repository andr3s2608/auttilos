using Microsoft.EntityFrameworkCore;

namespace Backend.Shared.Repositories.Context.Config.Commons
{
    public static class SubredConfig
    {
        /// <summary>
        /// Adds the subRed.
        /// </summary>
        /// <param name="modelBuilder">The model builder.</param>
        public static void AddSubRed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Backend.Shared.Entities.Models.Commons.SubRed>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("SubRed", "commons");

                entity.Property(e => e.Codigo)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);
                
                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.IdSubRed).HasColumnName("IdSubRed");
            });
        }
    }
}