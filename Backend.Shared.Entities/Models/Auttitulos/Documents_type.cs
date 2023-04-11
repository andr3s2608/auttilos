using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Backend.Shared.Entities.Models.Auttitulos
{
    public class Documents_type
    {
       
            public Documents_type()
            {
            Document_types_procedure = new HashSet<Document_types_procedure>();
            }

            [Key]
            public int IdDocumentType { get; set; }

            public int IdTitleType { get; set; }

             public string description { get; set; }

        [ForeignKey(nameof(IdTitleType))]
        [InverseProperty(nameof(Title_types.Documents_type))]
        public virtual Title_types IdTitleTypeNavigation { get; set; }

        [InverseProperty("IdDocumentProcNavigation")]
        public virtual ICollection<Document_types_procedure> Document_types_procedure { get; set; }

    }
}
