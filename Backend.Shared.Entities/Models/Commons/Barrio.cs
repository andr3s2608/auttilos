using System;
namespace Backend.Shared.Entities.Models.Commons
{
    public partial class Barrio
    {
        public Guid IdBarrio { get; set; }
        public string Descripcion { get; set; }
        public int? UpzId { get; set; }
        public Guid? IdUpz { get; set; }
        public bool Estado { get; set; }
    }
}
