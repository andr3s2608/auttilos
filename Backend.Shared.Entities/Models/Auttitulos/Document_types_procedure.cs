using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Backend.Shared.Entities.Models.Auttitulos
{
    public class Document_types_procedure
    {
        public Document_types_procedure()
        {

        }

      
        public int IdDocumentTypeProcedureRequest { get; set; }
        public int IdDocumentType { get; set; }
        public int IdProcedureRequest { get; set; }
        public string path { get; set; }
        public bool is_valid { get; set; }
        public DateTime registration_date { get; set; }

        public DateTime modification_date { get; set; }

        [ForeignKey(nameof(IdDocumentType))]
        [InverseProperty(nameof(Documents_type.Document_types_procedure))]
        public virtual Documents_type IdDocumentProcNavigation { get; set; }

        [ForeignKey(nameof(IdProcedureRequest))]
        [InverseProperty(nameof(procedure_requests.Document_types_procedure))]
        public virtual procedure_requests IdProcdocNavigation { get; set; }

    }
}
