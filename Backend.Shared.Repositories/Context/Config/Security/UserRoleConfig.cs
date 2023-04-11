using Microsoft.EntityFrameworkCore;

namespace Backend.Shared.Repositories.Context.Config.Security
{
    public static class UserRoleConfig
    {
        /// <summary>
        /// AddUserRole
        /// </summary>
        /// <param name="modelBuilder"></param>
        public static void AddUserRole(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Entities.Models.Security.UserRole>(entity =>
            {
                entity.HasKey(e => new { e.IdUser, e.IdRole });
                entity.ToTable("UserRole", "Security");
                entity.Property(e => e.Created).HasColumnType("datetime");
                //entity.Property(e => e.IdUser).HasColumnName("IdUser");
                //entity.Property(e => e.IdRole).HasColumnName("IdRole");
                entity.HasOne(d => d.IdRoleNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.IdRole)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_UserRole_Role");

                entity.HasOne(d => d.IdUserNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.IdUser)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_UserRole_User");
            });
        }
    }
}
