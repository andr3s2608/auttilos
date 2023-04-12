using System;
using System.Collections.Generic;
using System.Text;

namespace Backend.Shared.Entities.DTOs.Auttitulos
{
    public class TrackingDTO
    {  public int IdStatusTypes { get; set; }
        public int IdProcedureRequest { get; set; }
        public string IdUser { get; set; }
        public string? observations { get; set; }
        public string? negation_causes { get; set; }
        public string? other_negation_causes { get; set; }
        public string? recurrent_argument { get; set; }
        public string? consideration { get; set; }
        public string? exposed_merits { get; set; }
        public string? articles { get; set; }
        public string? additional_information { get; set; }
        public string? clarification_types_motives { get; set; }
        public string? paragraph_MA { get; set; }
        public string? paragraph_JMA1 { get; set; }
        public string? paragraph_JMA2 { get; set; }
        public string? paragraph_AMA { get; set; }
    }
}
