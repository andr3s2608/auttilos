using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Backend.Shared.Entities.Models.Auttitulos
{
    public class procedure_requests
    {
        public procedure_requests()
        {
            Resolutions = new HashSet<Resolutions>();
            Document_types_procedure = new HashSet<Document_types_procedure>();
            Tracking = new HashSet<Tracking>();
        }

        [Key]
        public int IdProcedureRequest { get; set; }
        public int IdTitleTypes { get; set; }
        public int IdStatus_types { get; set; }
        public int IdInstitute { get; set; }
        public int IdProfessionInstitute { get; set; }
        public string IdUser { get; set; }
        public int user_code_ventanilla { get; set; }
        public string filed_number { get; set; }
        public int? diploma_number { get; set; }
        public string? graduation_certificate { get; set; }
        public DateTime end_date { get; set; }
        public string? book { get; set; }
        public string? folio { get; set; }
        public decimal year_title { get; set; }
        public string? professional_card { get; set; }     
        public int IdCountry { get; set; }
        public string? number_resolution_convalidation { get; set; }
        public DateTime? date_resolution_convalidation { get; set; }
        public int? IdEntity { get; set; }
        public string? name_institute { get; set; }
        public DateTime? last_status_date { get; set; }
        public DateTime? filed_date { get; set; }
        public string IdNumber { get; set; }
        public string AplicantName { get; set; }
        public string? name_profession { get; set; }

        [InverseProperty("IdProcdocNavigation")]
        public virtual ICollection<Document_types_procedure>  Document_types_procedure { get; set; }

        [InverseProperty("IdResProcNavigation")]
        public virtual ICollection<Resolutions> Resolutions { get; set; }

        [InverseProperty("IdTrackProcNavigation")]
        public virtual ICollection<Tracking> Tracking { get; set; }



        [ForeignKey(nameof(IdTitleTypes))]
        [InverseProperty(nameof(Title_types.procedure_requests))]
        public virtual Title_types IdTitleTypeprocNavigation { get; set; }

        [ForeignKey(nameof(IdStatus_types))]
        [InverseProperty(nameof(Status_types.procedure_requests))]
        public virtual Status_types IdStatusTypeprocNavigation { get; set; }


    }
}
