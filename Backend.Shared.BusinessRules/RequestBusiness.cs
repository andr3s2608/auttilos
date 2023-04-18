using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using AutoMapper;
using Backend.Shared.BusinessRules.Middle;
using Backend.Shared.Repositories.Context;
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
        private readonly IEntitiesRepository _repositoryentities;
        private readonly IProcedure_requestsRepository _repositoryprocedure;
        private readonly IResolutionsRepository _repositoryresolutions;
        private readonly IStatusRepository _repositorystatus;
        private readonly ITitle_typesRepository _repositorytittle;
        private readonly ITrackingRepository _repositorytracking;
        private readonly dbaeusdsdevpamecContext _pamecContext;

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="RequestBusiness"/> class.
        /// </summary>
        /// <param name="cache"></param>
        public RequestBusiness(
            IDocuments_typeRepository repositorydocuments,
            IEntitiesRepository repositoryentities,
            dbaeusdsdevpamecContext pamecContext,
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
            _pamecContext = pamecContext;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Get Request by id
        /// </summary>
        ///  <param name="idRequest">Request`s id</param>
        /// <returns>Request by id</returns>
        public async Task<ResponseBase<procedure_requests>> getRequestById(string idRequest)
        {
            try
            {
                var result = await _repositoryprocedure.GetAsync(x => x.IdProcedureRequest.Equals(int.Parse(idRequest)),
                    include: inc =>
                        (IIncludableQueryable<procedure_requests, object>)inc
                            .Include(i => i.IdStatusTypeprocNavigation));

                return new ResponseBase<procedure_requests>(code: HttpStatusCode.OK,
                    message: Messages.GetOk, data: result, count: 1);
            }
            catch (Exception ex)
            {
                return new ResponseBase<procedure_requests>(code: HttpStatusCode.OK,
                    message: "Ha ocurrido un error mientras se consultaba la información", data: null);
            }
        }

        public async Task<List<RequestReponseTableUserDto>> getAllByUser(string idUser)
        {
            try
            {
                var result = await _repositoryprocedure.GetAllAsync(x => x.IdUser.Equals(idUser), 
                    orderBy: order=> order.OrderByDescending(x => x.last_status_date),
                    include: inc => 
                        inc.Include(i => i.IdStatusTypeprocNavigation)
                        .Include(i => i.IdTitleTypeprocNavigation));
               
                
                var resulList = new List<RequestReponseTableUserDto>();
                
                foreach (var item in result)
                {
                    var resultResolutions = await _repositoryresolutions.GetAllAsync(x => x.IdProcedureRequest == item.IdProcedureRequest);

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
                result.IdProfessionInstitute = request.IdProfessionInstitute;
                result.IdUser = request.IdUser;
                result.user_code_ventanilla = request.user_code_ventanilla;                
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
                result.name_institute = request.name_institute;
                result.last_status_date = request.last_status_date;
                result.AplicantName = request.AplicantName;
                result.IdNumber=request.IdNumber;
                result.IdDocument_type = request.IdDocument_type;
               

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


        /// <summary>
        /// Gets requests to dashboard
        /// </summary>
        /// <returns></returns>
        public async Task<ResponseBase<List<BandejaValidadorDTO>>> GetDashboard(string FinalDate, string TextToSearch,
            string selectedfilter, string pagenumber, string pagination)
        {
            try
            {
                var days = "";
                selectedfilter = selectedfilter + "";
                TextToSearch = TextToSearch + "";
                if (selectedfilter.Equals("tiempo"))
                {
                    days = TextToSearch;
                    TextToSearch = "";
                    selectedfilter = "";
                }
              

                var initialpage = int.Parse(pagination) * (int.Parse(pagenumber)-1);
                var finalpage = initialpage + int.Parse(pagination);


                var resultExecuteSP = await _pamecContext.SP_DashboardValidator.
                    FromSqlInterpolated($"EXEC auttitulos.SP_DashboardValidator @filtertype = {selectedfilter}, @filter = {TextToSearch}, @date = {FinalDate}, @days = {days}, @pagination = {initialpage+""}, @paginationfinal = {finalpage+""}").ToListAsync();

                var resultExecuteSP_response = resultExecuteSP.Select(item => new BandejaValidadorDTO
                {
                    idfiled = item.idfiled,
                    idprocedure = item.idProcedureRequest,
                    aplicantname = item.AplicantName,
                    daysleft ="Quedan "+ item.days+" días,estos son los dias transcurridos "+(item.days - 20),
                    color= item.days >= 15 ? "darkseagreen":(item.days >= 5 ? "khaki" :"coral"),
                    fileddate = item.fileddate,
                    idnumber = item.IdNumber,
                    statusdate = item.statusdate,
                    statusid = item.idstatus,
                    statusstring = item.estadostring,
                    titletype=item.titletype
                }).ToList();

                return new Entities.Responses.ResponseBase<List<BandejaValidadorDTO>>(code: HttpStatusCode.OK,
                message: "Solicitud OK", data: resultExecuteSP_response, count: resultExecuteSP_response.Count);
               

            }
            catch (Exception ex)
            {
                return new Entities.Responses.ResponseBase<List<BandejaValidadorDTO>>(code: HttpStatusCode.OK,
                 message: "ha ocurrido un error mientras se traia la información", data: null);
            }
        }



        /// <summary>
        /// Gets requests to dashboard
        /// </summary>
        /// <returns></returns>
        public async Task<ResponseBase<List<ReportsDashboardDTO>>> GetReports(string InitialDate,string FinalDate, string TextToSearch,
            string selectedfilter, string pagenumber, string pagination, string iduser)
        {
            try
            {
                
                selectedfilter = selectedfilter + "";
                TextToSearch = TextToSearch + "";
                iduser = iduser + "";


                var initialpage = int.Parse(pagination) * (int.Parse(pagenumber) - 1);
                var finalpage = initialpage + int.Parse(pagination);


                var resultExecuteSP = await _pamecContext.SP_ReportsDashboard.
                    FromSqlInterpolated($"EXEC auttitulos.SP_ReportsDashboard @iduser = {iduser}, @filtertype = {selectedfilter}, @filter = {TextToSearch}, @startdate = {InitialDate}, @endate = {FinalDate}, @pagination = {initialpage + ""}, @paginationfinal = {finalpage + ""}").ToListAsync();

                var resultExecuteSP_response = resultExecuteSP.Select(item => new ReportsDashboardDTO
                {
                    idfiled = item.idfiled,
                    idprocedure = item.idProcedureRequest,
                    idnumber = item.IdNumber,
                    iddoctype=item.IdDocument_type,
                    titletype = item.titletype,
                    aplicantname = item.AplicantName,                    
                    fileddate = item.fileddate,  
                    statusid = item.idstatus,
                    statusstring = item.estadostring,
                    IdResolution=item.IdResolution,
                    resolutionnumber=item.resolutionnumber+"",
                    resolutionpath=item.resolutionpath+""
                   
                }).ToList();

                return new Entities.Responses.ResponseBase<List<ReportsDashboardDTO>>(code: HttpStatusCode.OK,
                message: "Solicitud OK", data: resultExecuteSP_response,count: resultExecuteSP_response.Count);


            }
            catch (Exception ex)
            {
                return new Entities.Responses.ResponseBase<List<ReportsDashboardDTO>>(code: HttpStatusCode.OK,
                 message: "ha ocurrido un error mientras se traia la información", data: null);
            }
        }



        #endregion
    }
}
