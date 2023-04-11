using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Backend.Shared.Entities.Models.Auttitulos
{
    public class Title_types
    {
        public Title_types()
        {
            Documents_type = new HashSet<Documents_type>();

            procedure_requests = new HashSet<procedure_requests>();
        }

        [Key]
        public int IdTitleType { get; set; }

        public string description { get; set; }

        [InverseProperty("IdTitleTypeNavigation")]
        public virtual ICollection<Documents_type> Documents_type { get; set; }

        [InverseProperty("IdTitleTypeprocNavigation")]
        public virtual ICollection<procedure_requests> procedure_requests { get; set; }
        /*
         [InverseProperty("IdTitleTypeNavigation")]
         public virtual Documents_type Documents_type { get; set; }
          */
    }
}
