using Backend.Shared.Entities.Models.Pamec;
using Backend.Shared.Entities.Interface.Repository;
using Backend.Shared.Entities.Interface.Business;
using Backend.Shared.Utilities.Telemetry;
using Backend.Shared.Entities.Responses;
using Backend.Shared.Entities.DTOs;
using System.Threading.Tasks;
using System.Net;
using System.IO;
using System;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Backend.Shared.BusinessRules
{
    public class DocumentBusiness : IDocumentBusiness
    {
        #region Attributes
        private readonly ITelemetryException _telemetryException;
        //private readonly IDocumentRepository _documentoRegistroPamecRegistroSic;
      
        #endregion

        #region Constructor
        public DocumentBusiness(//IDocumentRepository documentoRegistroPamecRegistroSic, 
          
            ITelemetryException telemetryException)
        {
            _telemetryException = telemetryException;
            //_documentoRegistroPamecRegistroSic = documentoRegistroPamecRegistroSic;
           
        }
        #endregion

        #region Methods

       

       
        #endregion
    }
}
