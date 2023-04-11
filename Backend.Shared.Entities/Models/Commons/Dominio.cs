using System;

namespace Backend.Shared.Entities.Models.Commons
{
    public partial class Dominio
    {
        public Guid Id { get; set; }
        public Guid TipoDominio { get; set; }
        public string Descripcion { get; set; }
        public string Abreviatura { get; set; }
        public int? Orden { get; set; }
        public long Estado { get; set; }

        public virtual TipoDominio TipoDominioNavigation { get; set; }
    }
}
