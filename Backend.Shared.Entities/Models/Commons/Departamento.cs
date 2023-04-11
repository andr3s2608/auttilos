using System;

namespace Backend.Shared.Entities.Models.Commons
{
    public partial class Departamento
    {
        public Guid IdDepartamento { get; set; }
        public string Descripcion { get; set; }
        public int? IdDepPai { get; set; }
        public Guid IdPais { get; set; }
        public bool Estado { get; set; }
    }
}
