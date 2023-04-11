using Microsoft.EntityFrameworkCore;

namespace Backend.Shared.Repositories.Context.Config.Commons
{
    public static class MunicipioConfig
    {
        /// <summary>
        /// Adds the municipio.
        /// </summary>
        /// <param name="modelBuilder">The model builder.</param>
        public static void AddMunicipio(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Entities.Models.Commons.Municipio>(entity =>
            {
                entity.HasKey(e => e.IdMunicipio);

                entity.ToTable("Municipio", "commons");

                entity.Property(e => e.IdMunicipio).ValueGeneratedNever();

                entity.Property(e => e.Cabecera)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Descripcion)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.MunId).HasColumnName("mun_id");
            });
        }
    }
}
