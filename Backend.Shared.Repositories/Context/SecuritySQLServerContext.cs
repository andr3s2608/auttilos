using System;
using System.Collections.Generic;
using System.Text;
using Backend.Shared.Repositories.Context.Config.Security;

using Microsoft.EntityFrameworkCore;

namespace Backend.Shared.Repositories.Context
{
    public partial class SecuritySQLServerContext: DbContext
    {
        
            public virtual DbSet<Entities.Models.Security.UserRole> UserRole { get; set; }
            public virtual DbSet<Entities.Models.Security.User> User { get; set; }
        public virtual DbSet<Entities.Models.Security.Role> Role { get; set; }


        public SecuritySQLServerContext(DbContextOptions<SecuritySQLServerContext> options)
                : base(options)
            {
            }
            protected override void OnModelCreating(ModelBuilder modelBuilder)
            {
                base.OnModelCreating(modelBuilder);            
                modelBuilder.AddUser();
                modelBuilder.AddUserRole();
                modelBuilder.AddRole();
            }
        
      
    }
}
