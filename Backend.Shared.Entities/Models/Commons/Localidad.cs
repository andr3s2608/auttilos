using System;

namespace Backend.Shared.Entities.Models.Commons
{
    public partial class Localidad
    {
        public Guid IdLocalidad { get; set; }
        public string Descripcion { get; set; }
        public int? LocId { get; set; }
        public int? IdSubred { get; set; }
        public bool Estado { get; set; }
    }
}
