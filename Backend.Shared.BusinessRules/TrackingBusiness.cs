using Backend.Shared.Entities.DTOs;
using Backend.Shared.Entities.Interface.Business;
using Backend.Shared.Entities.Models.Pamec;
using Backend.Shared.Entities.Models.Sirep;
using Backend.Shared.Entities.Responses;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Shared.BusinessRules
{
    public class TrackingBusiness : ITrackingBusiness
    {
        #region Attributes
        private readonly Repositories.Context.dbaeusdsdevpamecContext _pamecContext;


        /// <summary>
        /// The telemetry exception
        /// </summary>
        private readonly Utilities.Telemetry.ITelemetryException TelemetryException;

        #endregion

        #region Constructor

        public TrackingBusiness(Repositories.Context.dbaeusdsdevpamecContext pamecContext,
            Utilities.Telemetry.ITelemetryException telemetryException)
        {

            _pamecContext = pamecContext;
            TelemetryException = telemetryException;

        }
        #endregion

        #region Methods
       
        #endregion

    }
}
