using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Backend.Shared.Entities.Models.Auttitulos
{
    public class Status_types
    {
        public Status_types()
        {

            procedure_requests = new HashSet<procedure_requests>();
            Tracking = new HashSet<Tracking>();
        }

        [Key]
        public int IdStatusType { get; set; }

        public string description { get; set; }

        [InverseProperty("IdStatusTypeprocNavigation")]
        public virtual ICollection<procedure_requests> procedure_requests { get; set; }

        [InverseProperty("IdStatusTypeTracNavigation")]
        public virtual ICollection<Tracking> Tracking { get; set; }
    }
}
