using System;
using System.Collections.Generic;
using System.Text;

namespace Backend.Shared.Entities.DTOs.Auttitulos
{
    public class DashboardfilterDTO
    {
        public int? StatusId { get; set; }
        public DateTime? InitialDate { get; set; }
        public DateTime FinalDate { get; set; }
     
        public string? TextToSearch { get; set; }

        public string? selectedfilter { get; set; }

        public string? pagenumber { get; set; }

        public string? pagination { get; set; }
    }
}
