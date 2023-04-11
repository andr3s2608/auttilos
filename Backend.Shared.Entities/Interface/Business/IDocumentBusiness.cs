using Backend.Shared.Entities.Responses;
using Backend.Shared.Entities.Models.Auttitulos;
using Backend.Shared.Entities.DTOs.Auttitulos;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Backend.Shared.Entities.Interface.Business
{
    public interface IDocumentBusiness
    {
        // Task<ResponseBase<bool>> addDocuments(DocumentDTO documents);

        Task<ResponseBase<string>> addDocuments(List<DocumentsDTO>  documents);

        Task<ResponseBase<List<Document_types_procedure>>> getDocumentsbyid(string idrequest);

        Task<ResponseBase<string>> updateDocuments(List<DocumentsDTO> documents);


    }
}
