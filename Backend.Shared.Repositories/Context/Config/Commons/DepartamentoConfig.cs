using Microsoft.EntityFrameworkCore;

namespace Backend.Shared.Repositories.Context.Config.Commons
{
    public static class DepartamentoConfig
    {
        /// <summary>
        /// Adds the departamento.
        /// </summary>
        /// <param name="modelBuilder">The model builder.</param>
        public static void AddDepartamento(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Entities.Models.Commons.Departamento>(entity =>
            {
                entity.HasKey(e => e.IdDepartamento);

                entity.ToTable("Departamento", "commons");

                entity.Property(e => e.IdDepartamento).ValueGeneratedNever();

                entity.Property(e => e.Descripcion)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });
        }
    }
}
