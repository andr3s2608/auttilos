using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using AutoMapper;
using Backend.Shared.BusinessRules.Middle;
using Backend.Shared.Entities.DTOs.Auttitulos;
using Backend.Shared.Entities.Interface.Business;
using Backend.Shared.Entities.Interface.Repository;
using Backend.Shared.Entities.Models.Auttitulos;
using Backend.Shared.Entities.Responses;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using Microsoft.Extensions.Caching.Distributed;

namespace Backend.Shared.BusinessRules
{
    public class RequestBusiness : IRequestBusiness
    {
        #region Attributes

        //private readonly IMapper mapper;
        private readonly IDocuments_typeRepository _repositorydocuments;
        private readonly IDocument_procedureRepository _repositoryDocumentsProcedure;
        private readonly IEntitiesRepository _repositoryentities;
        private readonly IProcedure_requestsRepository _repositoryprocedure;
        private readonly IResolutionsRepository _repositoryresolutions;
        private readonly IStatusRepository _repositorystatus;
        private readonly ITitle_typesRepository _repositorytittle;
        private readonly ITrackingRepository _repositorytracking;

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="RequestBusiness"/> class.
        /// </summary>
        /// <param name="cache"></param>
        public RequestBusiness(
            IDocuments_typeRepository repositorydocuments,
            IEntitiesRepository repositoryentities,
            IProcedure_requestsRepository repositoryprocedure,
            IResolutionsRepository repositoryresolutions,
            IStatusRepository repositorystatus,
            ITitle_typesRepository repositorytittle,
            ITrackingRepository repositorytracking,
            IDistributedCache cache)
        {
            _repositorydocuments = repositorydocuments;
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
        /// Get Request by id
        /// </summary>
        ///  <param name="idRequest">Request`s id</param>
        /// <returns>Request by id</returns>
        public async Task<ProcedureRequest_ResponseDTO> getRequestById(int idRequest)
        {
            try
            {
                var resultQuery =
                    await _repositoryprocedure.GetAsync(x => x.IdProcedureRequest == idRequest,
                        include: inc =>
                            inc
                                .Include(i => i.IdStatusTypeprocNavigation)
                                .Include(i => i.IdTitleTypeprocNavigation));

                var resultDocuments =
                    await _repositoryDocumentsProcedure.GetAllAsync(x => x.IdProcedureRequest == idRequest,
                        include:inc =>
                            inc
                                .Include(i => i.IdDocumentProcNavigation));

                var listDocuments = new List<DocumentSupportResponseDTO>();

                if (listDocuments.Count != 0)
                {
                    foreach (var document in resultDocuments)
                    {
                        var newDocument = new DocumentSupportResponseDTO
                        {
                            IdDocumentTypeProcedureRequest = document.IdDocumentTypeProcedureRequest,
                            description = document.IdDocumentProcNavigation.description,
                            path = document.path,
                            is_valid = document.is_valid
                        };
                        listDocuments.Add(newDocument);
                    }
                }

                var procedureDto = new ProcedureRequest_ResponseDTO
                {
                    idProcedureRequest = resultQuery.IdProcedureRequest,
                    idTitleTypes = resultQuery.IdTitleTypes,
                    titleType = resultQuery.IdTitleTypeprocNavigation.description,
                    idStatus = resultQuery.IdStatus_types,
                    status = resultQuery.IdStatusTypeprocNavigation.description,
                    IdInstitute = resultQuery.IdInstitute,
                    name_institute = resultQuery.name_institute,
                    IdProfessionInstitute = resultQuery.IdProfessionInstitute,
                    name_profession = resultQuery.name_profession,
                    IdUser = resultQuery.IdUser,
                    user_code_ventanilla = resultQuery.user_code_ventanilla,
                    AplicantName = resultQuery.AplicantName,
                    last_status_date = resultQuery.last_status_date,
                    filed_date = resultQuery.filed_date,
                    filed_number = resultQuery.filed_number,
                    diploma_number = resultQuery.diploma_number,
                    graduation_certificate = resultQuery.graduation_certificate,
                    end_date = resultQuery.end_date,
                    book = resultQuery.book,
                    folio = resultQuery.folio,
                    year_title = resultQuery.year_title,
                    professional_card = resultQuery.professional_card,
                    idCountry = resultQuery.IdCountry,
                    number_resolution_convalidation = resultQuery.number_resolution_convalidation,
                    date_resolution_convalidation = resultQuery.date_resolution_convalidation,
                    idEntity = resultQuery.IdEntity,
                    documentsSupport = listDocuments
                };
                
                return procedureDto;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<RequestReponseTableUserDto>> getAllByUser(string idUser)
        {
            try
            {
                var result =
                    await _repositoryprocedure.GetAllAsync(x => x.IdUser.Equals(idUser),
                        orderBy: order => order.OrderByDescending(x => x.last_status_date),
                        include: inc =>
                            inc
                                .Include(i => i.IdStatusTypeprocNavigation)
                                .Include(i => i.IdTitleTypeprocNavigation));


                var resulList = new List<RequestReponseTableUserDto>();

                foreach (var item in result)
                {
                    var resultResolutions =
                        await _repositoryresolutions.GetAllAsync(x => x.IdProcedureRequest == item.IdProcedureRequest);

                    var lastResolution = "";
                    if (resultResolutions.Count != 0)
                    {
                        lastResolution = resultResolutions[0].path;
                    }

                    var nuevoObjeto = new RequestReponseTableUserDto
                    {
                        IdProcedureRequest = item.IdProcedureRequest,
                        filed_number = item.filed_number,
                        titleType = item.IdTitleTypeprocNavigation.description,
                        filedDate = item.filed_date,
                        institute = item.name_institute,
                        profession = item.name_profession,
                        statusId = item.IdStatus_types,
                        status = item.IdStatusTypeprocNavigation.description,
                        colorTime = "verde",
                        resolutionPath = lastResolution
                        //completar color con dias habiles
                    };
                    resulList.Add(nuevoObjeto);
                }

                return resulList;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public async Task<ResponseBase<string>> updateRequest(RequestDTO request)
        {
            try
            {
                var result =
                    await _repositoryprocedure.GetAsync(x => x.IdProcedureRequest.Equals(request.IdProcedureRequest));

                result.IdTitleTypes = request.IdTitleTypes;
                result.IdStatus_types = request.IdStatus_types;
                result.IdInstitute = request.IdInstitute;
                result.name_institute = request.name_institute;
                result.IdProfessionInstitute = request.IdProfessionInstitute;
                result.IdUser = request.IdUser;
                result.user_code_ventanilla = request.user_code_ventanilla;
                result.AplicantName = request.AplicantName;
                result.last_status_date = request.last_status_date;
                result.filed_number = request.filed_number;
                result.IdProfessionInstitute = request.IdProfessionInstitute;
                result.diploma_number = request.diploma_number;
                result.graduation_certificate = request.graduation_certificate;
                result.end_date = request.end_date;
                result.book = request.book;
                result.folio = request.folio;
                result.year_title = request.year_title;
                result.professional_card = request.professional_card;
                result.name_profession = request.name_profession;
                result.IdCountry = request.IdCountry;
                result.number_resolution_convalidation = request.number_resolution_convalidation;
                result.date_resolution_convalidation = request.date_resolution_convalidation;
                result.IdEntity = request.IdEntity;

                await _repositoryprocedure.UpdateAsync(result);

                return new ResponseBase<string>(code: HttpStatusCode.OK,
                    message: Messages.GetOk, data: "Solicitud Actualizada Exitosamente", count: 1);
            }
            catch (Exception ex)
            {
                return new ResponseBase<string>(code: HttpStatusCode.OK,
                    message: "ha ocurrido un error mientras se Actualizaba la información", data: null);
            }
        }

        #endregion
    }
}