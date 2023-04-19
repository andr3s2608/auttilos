using Backend.Shared.Entities.DTOs;
using Backend.Shared.Entities.Interface.Business;
using Backend.Shared.Entities.Models.Auttitulos;
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



        private readonly IResolutionsRepository _repositoryresolution;



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
              IResolutionsRepository repositoryresolution,
            IDistributedCache cache)
        {
            _pamecContext = pamecContext;
            TelemetryException = telemetryException;
            _repositoryresolution = repositoryresolution;

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
                
                var resultado1 = await _repositoryresolution.GetAllAsync();

                var resultlist = new List<Resolutions>();
                foreach (var item in resultado1)
                {
                    resultlist.Add(item);
                }




                return new Entities.Responses.ResponseBase<List<Entities.Models.Auttitulos.Resolutions>>(code: HttpStatusCode.OK,
                    message: Middle.Messages.GetOk, data: resultlist, count: resultlist.Count);
            }
            catch (Exception ex)
            {
                TelemetryException.RegisterException(ex);
                return new Entities.Responses.ResponseBase<List<Entities.Models.Auttitulos.Resolutions>>(code: HttpStatusCode.InternalServerError,
                    message: Middle.Messages.ServerError);
            }
        }
        /// <summary>
        /// adds a new  Resolution.
        /// </summary>
        /// <returns></returns>
        public async Task<ResponseBase<string>> AddResolution(Resolutions resolution)
        {
            try
            {
                
                
                await _repositoryresolution.AddAsync(resolution);
                




                return new Entities.Responses.ResponseBase<string>(code: HttpStatusCode.OK,
                    message: Middle.Messages.GetOk, data: "resolucion creada exitosamente", count: 0);
            }
            catch (Exception ex)
            {
                TelemetryException.RegisterException(ex);
                return new Entities.Responses.ResponseBase<string>(code: HttpStatusCode.OK,
                    message: "ha ocurrido un error mientras que guardaba la resolucion en base de datos");
            }
        }
        #endregion


    }
}
