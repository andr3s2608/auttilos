using Microsoft.EntityFrameworkCore;

namespace Backend.Shared.Repositories.Context.Config.Security
{
    public static class RoleConfig
    {
        /// <summary>
        /// AddRole
        /// </summary>
        /// <param name="modelBuilder"></param>
        public static void AddRole(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Entities.Models.Security.Role>(entity =>
            {
                entity.HasKey(e => e.IdRole)
                   .HasName("PK_AppRoles");

                entity.ToTable("Role", "Security");

                entity.Property(e => e.IdRole).ValueGeneratedNever();

                entity.Property(e => e.Created).HasColumnType("datetime");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.DisplayName)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Value)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });
        }
    }
}
