using System;
using System.Collections.Generic;
using System.Text;

namespace Backend.Shared.Entities.DTOs.Auttitulos
{
    public  class RequestDTO
    {
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
        public DateTime last_status_date { get; set; }

        public DateTime filed_date { get; set; }

        public string IdNumber { get; set; }
        public string AplicantName { get; set; }
        public string name_profession { get; set; }
   
       
    }

}
