
using Microsoft.EntityFrameworkCore;

namespace Backend.Shared.Repositories.Context.Config.Security
{
    public static class UserConfig
    {
        /// <summary>
        /// Adds the municipio.
        /// </summary>
        /// <param name="modelBuilder">The model builder.</param>
        public static void AddUser(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Entities.Models.Security.User>(entity =>
            {
                entity.ToTable("User", "Security");
                entity.HasKey(e => e.Oid)
                       .HasName("PK_Users");

              

                entity.Property(e => e.Oid).ValueGeneratedNever();

                entity.Property(e => e.Created).HasColumnType("datetime");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);


            });
        }
    }
}
