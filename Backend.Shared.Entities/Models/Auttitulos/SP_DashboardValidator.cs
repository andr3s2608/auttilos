using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Backend.Shared.Entities.Models.Pamec
{
    public class SP_DashboardValidator
    {
        [Key]
        public long rn { get; set; }
        public string days { get; set; }
        public string fileddate { get; set; }
        public string statusdate { get; set; }
        public string idProcedureRequest { get; set; }
        public string idfiled { get; set; }
        public string IdNumber { get; set; }
        public string AplicantName { get; set; }
        public string idstatus { get; set; }
        public string estadostring { get; set; }
        public string titletype { get; set; }




      

    }
}
