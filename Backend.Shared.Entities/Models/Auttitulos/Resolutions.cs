using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Backend.Shared.Entities.Models.Auttitulos
{   

    //[Table("resolutions", Schema = "auttitulos")]
    public partial class Resolutions
    {
        public Resolutions()
        {
        }

        [Key]
        public int IdResolution { get; set; }
     
        public int IdProcedureRequest { get; set; }
     
        public string number { get; set; }

        public DateTime date { get; set; }

        public string path { get; set; }

        [ForeignKey(nameof(IdProcedureRequest))]
        [InverseProperty(nameof(procedure_requests.Resolutions))]
        public virtual procedure_requests IdResProcNavigation { get; set; }



    }
}
