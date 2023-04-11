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
    public class RequestBusiness : IRequestBusiness
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



        private readonly  IDocuments_typeRepository _repositorydocuments;
        private readonly IEntitiesRepository _repositoryentities;
        private readonly IProcedure_requestsRepository _repositoryprocedure;
        private readonly IResolutionsRepository _repositoryresolutions;
        private readonly IStatusRepository _repositorystatus;
        private readonly ITitle_typesRepository _repositorytittle;
        private readonly ITrackingRepository _repositorytracking;



        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="CementerioBusiness"/> class.
        /// </summary>
        /// <param name="oracleContext"></param>
        /// <param name="telemetryException"></param>
        /// <param name="cache"></param>
        public RequestBusiness(Repositories.Context.dbaeusdsdevpamecContext pamecContext,
            Utilities.Telemetry.ITelemetryException telemetryException,
              IDocuments_typeRepository repositorydocuments,
               IEntitiesRepository repositoryentities,
                IProcedure_requestsRepository repositoryprocedure,
                 IResolutionsRepository repositoryresolutions,
                  IStatusRepository repositorystatus,
                   ITitle_typesRepository repositorytittle,
                    ITrackingRepository repositorytracking,
            IDistributedCache cache)
        {
            _pamecContext = pamecContext;
            TelemetryException = telemetryException;
            _repositorydocuments= repositorydocuments;
            _repositoryentities = repositoryentities;
            _repositoryprocedure = repositoryprocedure;
            _repositoryresolutions = repositoryresolutions;
            _repositorystatus = repositorystatus;
            _repositorytittle = repositorytittle;
            _repositorytracking = repositorytracking;

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

                var resultado2 = await _repositoryentities.GetAllAsync();

                var resultado3 = await _repositoryprocedure.GetAllAsync();


                var resultado4 = await _repositoryresolutions.GetAllAsync();

                var resultado5 = await _repositorystatus.GetAllAsync();

                var resultado6 = await _repositorytittle.GetAllAsync();

                var resultado7 = await _repositorytracking.GetAllAsync();

               

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
    

