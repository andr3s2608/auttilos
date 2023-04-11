using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Backend.Shared.Entities.Models.Auttitulos
{
    public class Entities
    {
        public Entities()
        {
        }

        [Key]
        public int IdEntity { get; set; }

        public string description { get; set; }
    }
}
