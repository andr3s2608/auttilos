using Backend.Shared.Entities.Interface.Repository;
using Backend.Shared.Entities.Interface.Business;
using Backend.Shared.Utilities.Telemetry;
using Backend.Shared.Entities.Responses;
using Backend.Shared.Entities.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using Backend.Shared.Entities.Models.Pamec;

namespace Backend.Shared.BusinessRules
{
    public class ConstantesBusiness : IConstantesBusiness
    {
        #region Attributes
        private readonly ITelemetryException _telemetryException;
        private readonly IConstantesRepository _respositoryConstantes;
        #endregion 

        #region Constructor
        public ConstantesBusiness(IConstantesRepository respositoryConstantes, ITelemetryException telemetryException)
        {
            _telemetryException = telemetryException;
            _respositoryConstantes = respositoryConstantes;
        }
        #endregion

        #region Methods
      

        #endregion
    }
}
