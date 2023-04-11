using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Backend.Shared.Entities.Models.Auttitulos
{
    public class Tracking
    {

        public Tracking()
        {
           
        }

        [Key]
        public int IdTracking { get; set; }
        public int IdStatusTypes { get; set; }
        public int IdProcedureRequest { get; set; }
        public string IdUser { get; set; }
        public DateTime date_tracking { get; set; }
        public string? observations { get; set; }
        public string? negation_causes { get; set; }
        public string? other_negation_causes { get; set; }
        public string? recurrent_argument { get; set; }
        public string? consideration { get; set; }
        public string? exposed_merits { get; set; }
        public string? articles { get; set; }
        public int? additional_information { get; set; }
        public string? clarification_types_motives { get; set; }
        public int? paragraph_MA { get; set; }
        public string? paragraph_JMA1 { get; set; }
        public string? paragraph_JMA2 { get; set; }
        public string? paragraph_AMA { get; set; }



        [ForeignKey(nameof(IdProcedureRequest))]
        [InverseProperty(nameof(procedure_requests.Tracking))]
        public virtual procedure_requests IdTrackProcNavigation { get; set; }


        [ForeignKey(nameof(IdStatusTypes))]
        [InverseProperty(nameof(Status_types.Tracking))]
        public virtual Status_types IdStatusTypeTracNavigation { get; set; }

    }
}
