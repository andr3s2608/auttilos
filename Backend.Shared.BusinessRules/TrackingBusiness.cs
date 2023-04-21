using Backend.Shared.Entities.DTOs.Auttitulos;
using Backend.Shared.Entities.Interface.Business;
using Backend.Shared.Entities.Models.Auttitulos;
using Backend.Shared.Entities.Interface.Repository;
using Backend.Shared.Entities.Models.Pamec;
using Backend.Shared.Entities.Models.Sirep;
using Backend.Shared.Entities.Responses;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

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

        private readonly ITrackingRepository _repositorytracking;
        private readonly IProcedure_requestsRepository _repositoryprocedure;
        private readonly IResolutionsRepository _repositoryresolutions;


        #endregion

        #region Constructor

        public TrackingBusiness(Repositories.Context.dbaeusdsdevpamecContext pamecContext,
             ITrackingRepository repositorytracking,
              IProcedure_requestsRepository repositoryprocedure,
               IResolutionsRepository repositoryresolutions,
            Utilities.Telemetry.ITelemetryException telemetryException)
        {

            _pamecContext = pamecContext;
            TelemetryException = telemetryException;
            _repositorytracking = repositorytracking;
            _repositoryprocedure = repositoryprocedure;
            _repositoryresolutions = repositoryresolutions;

        }


        #endregion

        #region Methods

        /// <summary>
        /// Gets Tracking by id
        /// </summary>
        /// <returns></returns>
        public async Task<ResponseBase<List<Tracking>>> GetTrackingbyid(string idRequest)
        {

            try
            {
                var result = await _repositorytracking.GetAllAsync(x => x.IdProcedureRequest.Equals(int.Parse(idRequest)), include: inc => (Microsoft.EntityFrameworkCore.Query.IIncludableQueryable<Tracking, object>)inc
                                                                                                                                    .Include(i => i.IdStatusTypeTracNavigation));
                var resullist = new List<Tracking>();

                foreach(var item in result)
                {
                    resullist.Add(item);

                }

                return new Entities.Responses.ResponseBase<List<Tracking>>(code: HttpStatusCode.OK,
                   message: Middle.Messages.GetOk, data: resullist, count: resullist.Count);

            }
            catch (Exception ex)
            {
                return new Entities.Responses.ResponseBase<List<Tracking>>(code: HttpStatusCode.OK,
                 message: "ha ocurrido un error mientras se traia la información", data: null);
            }


          
        }

        /// <summary>
        /// Gets Tracking by id
        /// </summary>
        /// <returns></returns>
        public async Task<ResponseBase<string>> AddTracking(TrackingDTO tracking)
        {

            try
            {
                var result = new Tracking();



                result.IdStatusTypes = tracking.IdStatusTypes;
                result.IdProcedureRequest = tracking.IdProcedureRequest;
                result.IdUser = tracking.IdUser;
                result.date_tracking = tracking.dateTracking;
                result.observations = tracking.observations;
                result.negation_causes = tracking.negation_causes;
                result.other_negation_causes = tracking.other_negation_causes;
                result.recurrent_argument = tracking.recurrent_argument;
                result.consideration = tracking.consideration;
                result.exposed_merits = tracking.exposed_merits;
                result.articles = tracking.articles;
                result.additional_information = tracking.additional_information;
                result.clarification_types_motives = tracking.clarification_types_motives;
                result.paragraph_MA = tracking.paragraph_MA;
                result.paragraph_JMA1 = tracking.paragraph_JMA1;
                result.paragraph_JMA2 = tracking.paragraph_JMA2;
                result.paragraph_AMA = tracking.paragraph_AMA;

               await _repositorytracking.AddAsync(result);



                return new Entities.Responses.ResponseBase<string>(code: HttpStatusCode.OK,
                   message: Middle.Messages.GetOk, data: "Seguimiento guardado", count: 0);

            }
            catch (Exception ex)
            {
                return new Entities.Responses.ResponseBase<string>(code: HttpStatusCode.OK,
                 message: "ha ocurrido un error mientras se traia la información", data: null);
            }



        }

        /// <summary>
        /// Gets Tracking by id
        /// </summary>
        /// <returns></returns>
        public async Task<ResponseBase<List<DuplicatedidDTO>>> GetDuplicatedbyid(string iddocument)
        {

            try
            {
                var procedures = await _repositoryprocedure.GetAllAsync(x => x.IdNumber.Equals(iddocument));

                var resultlist = new List<DuplicatedidDTO>();
                foreach (var item in procedures)
                {
                    var resolution= await _repositoryresolutions.GetAsync(x => x.IdProcedureRequest.Equals(item.IdProcedureRequest));
                    var date =resolution!=null ?  resolution.date.ToString() : "";

                    var temporal = new DuplicatedidDTO();
                    temporal.name_institute = item.name_institute;
                    temporal.name_profesion = item.name_profession;
                    temporal.IdProcedureRequest = item.IdProcedureRequest;
                    temporal.date_resolution = date + (resolution!=null ? resolution.number :"");
                    resultlist.Add(temporal);
                    


                }
                

                return new Entities.Responses.ResponseBase<List<DuplicatedidDTO>>(code: HttpStatusCode.OK,
                   message: Middle.Messages.GetOk, data: resultlist, count: resultlist.Count);

            }
            catch (Exception ex)
            {
                return new Entities.Responses.ResponseBase<List<DuplicatedidDTO>>(code: HttpStatusCode.InternalServerError,
                 message: "ha ocurrido un error mientras se traia la información", data: null);
            }



        }
        #endregion

    }
}
