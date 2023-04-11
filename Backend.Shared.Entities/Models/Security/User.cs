using System;

namespace Backend.Shared.Entities.Models.Security
{
    public partial class User
    {
        public Guid Oid { get; set; }

        public string Email { get; set; }
        public string NombreCompleto { get; set; }

        public DateTime Created { get; set; }

        public int IdPersonaVentanilla { get; set; }

        public bool IsEnabled { get; set; }
        
    }
}