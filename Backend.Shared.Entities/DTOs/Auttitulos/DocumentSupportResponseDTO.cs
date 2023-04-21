using System;

namespace Backend.Shared.Entities.DTOs.Auttitulos
{
    public class DocumentSupportResponseDTO
    {
        public int IdDocumentTypeProcedureRequest { get; set; }
        public string description { get; set; }
        public string path { get; set; }
        public bool is_valid { get; set; }
    }
}