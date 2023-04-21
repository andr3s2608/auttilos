using System;
using System.Collections.Generic;

namespace Backend.Shared.Entities.DTOs.Auttitulos
{
    public class ProcedureRequest_ResponseDTO
    {
        public int idProcedureRequest { get; set; }
        public int idTitleTypes { get; set; }
        public string titleType { get; set; }
        public int idStatus { get; set; }
        public string status { get; set; }
        public int IdInstitute { get; set; }
        public string name_institute { get; set; }
        public int IdProfessionInstitute { get; set; }
        public string name_profession { get; set; }
        public string IdUser { get; set; }
        public int user_code_ventanilla { get; set; }
        public string AplicantName { get; set; }
        public DateTime last_status_date { get; set; }
        
        public DateTime filed_date { get; set; }
        public string filed_number { get; set; }
        public int? diploma_number { get; set; }
        public string? graduation_certificate { get; set; }
        public DateTime end_date { get; set; }
        public string? book { get; set; }
        public string? folio { get; set; }
        public decimal year_title { get; set; }
        public string? professional_card { get; set; }
        public int idCountry { get; set; }
        public string? number_resolution_convalidation { get; set; }
        public DateTime? date_resolution_convalidation { get; set; }
        public int? idEntity { get; set; }

        public List<DocumentSupportResponseDTO>? documentsSupport { get; set; }
    }
}