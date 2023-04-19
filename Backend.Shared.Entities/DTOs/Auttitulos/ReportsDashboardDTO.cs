using System;
using System.Collections.Generic;
using System.Text;

namespace Backend.Shared.Entities.DTOs.Auttitulos
{
    public class ReportsDashboardDTO
    {
        public string idfiled { get; set; }
        public string idprocedure { get; set; }
        public string idnumber { get; set; }
        public string iddoctype { get; set; }
        public string aplicantname { get; set; }
        public string titletype { get; set; }
        public string fileddate { get; set; }

        public string statusid { get; set; }
        public string statusstring { get; set; }
        public int? IdResolution { get; set; }
        public string? resolutionnumber { get; set; }
        public string? resolutionpath { get; set; }

    }
}
