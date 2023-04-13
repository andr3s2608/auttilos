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

        #endregion

        #region Constructor

        public TrackingBusiness(Repositories.Context.dbaeusdsdevpamecContext pamecContext,
             ITrackingRepository repositorytracking,
            Utilities.Telemetry.ITelemetryException telemetryException)
        {

            _pamecContext = pamecContext;
            TelemetryException = telemetryException;
            _repositorytracking = repositorytracking;

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
                var result = await _repositorytracking.GetAllAsync(x => x.IdProcedureRequest.Equals(int.Parse(idRequest)));
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
                result.date_tracking = System.DateTime.Now;
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
        #endregion

    }
}
