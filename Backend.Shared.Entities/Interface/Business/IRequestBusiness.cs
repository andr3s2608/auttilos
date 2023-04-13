using Backend.Shared.Entities.DTOs.Auttitulos;
using Backend.Shared.Entities.Models.Auttitulos;
using Backend.Shared.Entities.Responses;

using System.Collections.Generic;
using System.Threading.Tasks;

namespace Backend.Shared.Entities.Interface.Business
{
    public interface IRequestBusiness
    {

        Task<ResponseBase<procedure_requests>> getRequestbyid(string idrequest);

        Task<ResponseBase<List<Entities.Models.Auttitulos.Resolutions>>> getResolutions();

        Task<ResponseBase<string>> UpdateRequest(RequestDTO request);


    }
}