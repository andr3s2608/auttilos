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
using Backend.Shared.Entities.Models.Auttitulos;
using Backend.Shared.Entities.DTOs.Auttitulos;
using Microsoft.EntityFrameworkCore;

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
        /// Gets Request by id
        /// </summary>
        /// <returns></returns>
        public async Task<ResponseBase<procedure_requests>> getRequestbyid(string idrequest)
        {
            try
            {
                var result = await _repositoryprocedure.GetAsync(x => x.IdProcedureRequest.Equals(int.Parse(  idrequest)),include: inc => (Microsoft.EntityFrameworkCore.Query.IIncludableQueryable<procedure_requests, object>)inc
                                                                                                                                   .Include(i => i.IdStatusTypeprocNavigation));

                return new Entities.Responses.ResponseBase<procedure_requests>(code: HttpStatusCode.OK,
                   message: Middle.Messages.GetOk, data:result, count: 1);

            }
            catch(Exception ex )
            {
                return new Entities.Responses.ResponseBase<procedure_requests>(code: HttpStatusCode.OK,
                 message: "ha ocurrido un error mientras se traia la información", data: null);
            }
            
        }



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
                return new Entities.Responses.ResponseBase<List<Entities.Models.Auttitulos.Resolutions>>(code: HttpStatusCode.OK,
                    message: "ha ocurrido un error mientras se traia la información", data: null);
            }
        }

        public async Task<ResponseBase<string>> UpdateRequest(RequestDTO request)
        {
            try
            {
                var result = await _repositoryprocedure.GetAsync(x => x.IdProcedureRequest.Equals(request.IdProcedureRequest));

                result.IdTitleTypes = request.IdTitleTypes;
                result.IdStatus_types = request.IdStatus_types;
                result.IdInstitute = request.IdInstitute;
                result.IdProfessionInstitute = request.IdProfessionInstitute;
                result.IdUser = request.IdUser;
                result.user_code_ventanilla = request.user_code_ventanilla;
                result.filed_number = request.filed_number;
                result.IdProfession = request.IdProfession;
                result.diploma_number = request.diploma_number;
                result.graduation_certificate = request.graduation_certificate;
                result.end_date = request.end_date;
                result.book = request.book;
                result.folio = request.folio;
                result.year_title = request.year_title;
                result.professional_card = request.professional_card;
                result.name_international_university = request.name_institute_international;
                result.IdCountry = request.IdCountry;
                result.number_resolution_convalidation = request.number_resolution_convalidation;
                result.date_resolution_convalidation = request.date_resolution_convalidation;
                result.IdEntity = request.IdEntity;
                result.name_institute_international = request.name_institute_international;

                await _repositoryprocedure.UpdateAsync(result);

                return new Entities.Responses.ResponseBase<string>(code: HttpStatusCode.OK,
                   message: Middle.Messages.GetOk, data: "Solicitud Actualizada Exitosamente", count: 1);

            }
            catch (Exception ex)
            {
                return new Entities.Responses.ResponseBase<string>(code: HttpStatusCode.OK,
                 message: "ha ocurrido un error mientras se Actualizaba la información", data: null);
            }
        }




        #endregion

    }
}
    

