using System;

namespace Backend.Shared.Entities.Models.Security
{
    public partial class UserRole
    {
        public Guid IdUser { get; set; }
        public Guid IdRole { get; set; }
        public DateTime Created { get; set; }

        public virtual Role IdRoleNavigation { get; set; }
        public virtual User IdUserNavigation { get; set; }

    }
}