using System;
using System.Collections.Generic;
using System.Text;

namespace Backend.Shared.Entities.DTOs.Auttitulos
{
    public class DocumentsDTO
    {


        public int IdDocumentTypeProcedureRequest { get; set; }
        public int IdDocumentType { get; set; }
        public int IdProcedureRequest { get; set; }
        public string path { get; set; }
        public bool is_valid { get; set; }
        public DateTime registration_date { get; set; }



    }
}
