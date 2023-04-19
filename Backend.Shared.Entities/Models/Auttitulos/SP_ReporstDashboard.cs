using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Backend.Shared.Entities.Models.Pamec
{
    public class SP_ReportsDashboard
    {
        [Key]
        public long rn { get; set; }       
        public string fileddate { get; set; }        
        public string idProcedureRequest { get; set; }
        public string idfiled { get; set; }
        public string IdNumber { get; set; }
        public string IdDocument_type { get; set; }
        public string AplicantName { get; set; }
        public string IdUser { get; set; }
        public string titletype { get; set; }
        public string idstatus { get; set; }
        public string estadostring { get; set; }

        public int? IdResolution { get; set; }
        public string? resolutionnumber { get; set; }
        public string? resolutionpath { get; set; }

        





    }
}
