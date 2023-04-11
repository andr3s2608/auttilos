using System;

namespace Backend.Shared.Entities.Models.Commons
{
    public partial class Upz
    {
        public Guid IdUpz { get; set; }
        public string Descripcion { get; set; }
        public int? UpzId { get; set; }
        public int? UpzLocalidad { get; set; }
        public Guid? IdLocalidad { get; set; }
        public bool Estado { get; set; }
    }
}
