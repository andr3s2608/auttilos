using Backend.Shared.Entities.DTOs;
using Backend.Shared.Entities.Interface.Business;
using Backend.Shared.Entities.DTOs.Auttitulos;
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

namespace Backend.Shared.BusinessRules
{
    public class DocumentBusiness : IDocumentBusiness
    {
        #region Attributes
        private readonly Utilities.Telemetry.ITelemetryException TelemetryException;
        private readonly IDocuments_typeRepository _repositorydocuments;
        private readonly IDocument_procedureRepository _repositorydocumentsprocedure;
        private readonly IProcedure_requestsRepository _repositoryprocedure;

        #endregion
        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="CementerioBusiness"/> class.
        /// </summary>
        /// <param name="oracleContext"></param>
        /// <param name="telemetryException"></param>
        /// <param name="cache"></param>
        public DocumentBusiness(Repositories.Context.dbaeusdsdevpamecContext pamecContext,
            Utilities.Telemetry.ITelemetryException telemetryException,
              IDocuments_typeRepository repositorydocuments,
              IDocument_procedureRepository repositorydocumentsprocedure,
              IProcedure_requestsRepository repositoryprocedure,

        IDistributedCache cache)
        {
           
            TelemetryException = telemetryException;
            _repositorydocuments = repositorydocuments;
            _repositorydocumentsprocedure = repositorydocumentsprocedure;
            _repositoryprocedure = repositoryprocedure;

        }

        #endregion
        #region Methods


     

        public async Task<ResponseBase<string>> addDocuments(List<DocumentsDTO> documents)
        {
            try
            {
                foreach (DocumentsDTO document in documents)
                {

                    var procedure = await _repositoryprocedure.GetAsync(x => x.IdProcedureRequest.Equals(document.IdProcedureRequest));
                    var documenttype = await _repositorydocuments.GetAsync(x => x.IdDocumentType.Equals(document.IdDocumentType));

                    var documentcreated = new Document_types_procedure();
                    //documentcreated.IdDocumentTypeProcedureRequest = null;
                    documentcreated.path = document.path;
                    documentcreated.IdProcedureRequest = document.IdProcedureRequest;
                    documentcreated.IdDocumentType = document.IdDocumentType;
                    documentcreated.is_valid = document.is_valid;
                    documentcreated.modification_date = System.DateTime.Now;
                    documentcreated.registration_date = System.DateTime.Now;

                    //documentcreated.IdProcdocNavigation = procedure;
                    //documentcreated.IdDocumentProcNavigation = documenttype;

                    await _repositorydocumentsprocedure.AddAsync(documentcreated);

                }
                return new Entities.Responses.ResponseBase<string>(code: HttpStatusCode.OK,
                   message: Middle.Messages.GetOk, data: "documentos actualizados", count: 0);

            }
            catch (Exception ex)
            {
                string msg = ex.Message;
                TelemetryException.RegisterException(ex);
                return new ResponseBase<string>(code: System.Net.HttpStatusCode.OK, message: "ha ocurrido un error mientras se traia la información", data: null);
            }
          
        }

        public async Task<ResponseBase<List<Document_types_procedure>>> getDocumentsbyid(string idrequest)
        {
            try
            {
                var result = await _repositorydocumentsprocedure.GetAllAsync(x => x.IdProcedureRequest.Equals(int.Parse(idrequest)));

                var resultlist = new List<Document_types_procedure>();
                foreach (Document_types_procedure document in result)
                {
                    resultlist.Add(document);
                }


                return new Entities.Responses.ResponseBase<List<Document_types_procedure>>(code: HttpStatusCode.OK,
                    message: Middle.Messages.GetOk, data: resultlist, count: resultlist.Count);

            }
            catch(Exception ex)
            {
                string msg = ex.Message;
                TelemetryException.RegisterException(ex);
                return new ResponseBase<List<Document_types_procedure>>(code: System.Net.HttpStatusCode.OK, message: "ha ocurrido un error mientras se traia la información", data: null);
            }
            throw new NotImplementedException();
        }

        public async Task<ResponseBase<string>> updateDocuments(List<DocumentsDTO> documents)
        {
            try
            {
                foreach (DocumentsDTO document in documents)
                {
                    var documentupdated = new Document_types_procedure();
                    documentupdated.IdDocumentTypeProcedureRequest = document.IdDocumentTypeProcedureRequest;
                    documentupdated.path = document.path;
                    documentupdated.IdProcedureRequest = document.IdProcedureRequest;
                    documentupdated.IdDocumentType = document.IdDocumentType;
                    documentupdated.is_valid = document.is_valid;
                    documentupdated.registration_date = document.registration_date;
                    documentupdated.modification_date = System.DateTime.Now;
                    
                   
                    await _repositorydocumentsprocedure.UpdateAsync(documentupdated);

                }
                return new Entities.Responses.ResponseBase<string>(code: HttpStatusCode.OK,
                   message: Middle.Messages.GetOk, data: "documentos actualizados", count: 0);

            }
            catch (Exception ex)
            {
                string msg = ex.Message;
                TelemetryException.RegisterException(ex);               
                return new ResponseBase<string>(code: System.Net.HttpStatusCode.OK, message: "ha ocurrido un error mientras se traia la información", data: "");
            }
           
        }
        #endregion

     
    }
}
