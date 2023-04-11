using System;
using System.Collections.Generic;
using System.Text;

namespace Backend.Shared.Entities.Responses
{
    public class TipoDocumentoResponse
    {
        public int IdCriterioTipoDocumento { get; set; }
        public int IdTipoDocumento { get; set; }
        public string Nombre { get; set; }
    }
}
