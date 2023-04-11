using Backend.Shared.Entities.DTOs;
using Backend.Shared.Entities.Interface.Business;
using Backend.Shared.Entities.Models.Pamec;
using Backend.Shared.Entities.Interface.Repository;
using Backend.Shared.Entities.Responses;
using Backend.Shared.Repositories.Context;
using Backend.Shared.Utilities.Telemetry;
using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
namespace Backend.Shared.BusinessRules
{
    public class ResolutionsBusiness :IResolutionsBusiness
    {


        #region Attributes



        /// <summary>
        /// The oracle context
        /// </summary>
        private readonly Repositories.Context.dbaeusdsdevpamecContext _pamecContext;

        /// <summary>
        /// The telemetry exception
        /// </summary>
        private readonly Utilities.Telemetry.ITelemetryException TelemetryException;



        private readonly IDocuments_typeRepository _repositorydocuments;



        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="CementerioBusiness"/> class.
        /// </summary>
        /// <param name="oracleContext"></param>
        /// <param name="telemetryException"></param>
        /// <param name="cache"></param>
        public ResolutionsBusiness(Repositories.Context.dbaeusdsdevpamecContext pamecContext,
            Utilities.Telemetry.ITelemetryException telemetryException,
              IDocuments_typeRepository repositorydocuments,
            IDistributedCache cache)
        {
            _pamecContext = pamecContext;
            TelemetryException = telemetryException;
            _repositorydocuments = repositorydocuments;

        }

        #endregion

        #region Methods



        /// <summary>
        /// Gets all Resolutiones.
        /// </summary>
        /// <returns></returns>
        public async Task<ResponseBase<List<Entities.Models.Auttitulos.Resolutions>>> getResolutions()
        {
            try
            {
                //var resultList = _pamecContext.Resolutions.ToList();
                var resultado1 = await _repositorydocuments.GetAllAsync();
                //var resultado1 = _pamecContext.Documents_type.ToList();




                return new Entities.Responses.ResponseBase<List<Entities.Models.Auttitulos.Resolutions>>(code: HttpStatusCode.OK,
                    message: Middle.Messages.GetOk, data: null, count: 0);
            }
            catch (Exception ex)
            {
                TelemetryException.RegisterException(ex);
                return new Entities.Responses.ResponseBase<List<Entities.Models.Auttitulos.Resolutions>>(code: HttpStatusCode.InternalServerError,
                    message: Middle.Messages.ServerError);
            }
        }
        #endregion


    }
}
