using System;

namespace Backend.Shared.Entities.Models.Commons
{
    public partial class Municipio
    {
        public Guid IdMunicipio { get; set; }
        public string Descripcion { get; set; }
        public string Cabecera { get; set; }
        public int? MunId { get; set; }
        public int? IdDepPai { get; set; }
        public Guid? IdDepartamento { get; set; }
        public bool Estado { get; set; }
    }
}
