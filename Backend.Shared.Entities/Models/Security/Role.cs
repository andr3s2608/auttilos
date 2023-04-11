using System;


namespace Backend.Shared.Entities.Models.Security
{
    public partial class Role
    {
        public Guid IdRole { get; set; }
        public string Description { get; set; }
        public string DisplayName { get; set; }
        public string Value { get; set; }
        public DateTime Created { get; set; }
        public bool IsEnabled { get; set; }
    }
}
