using Backend.Shared.Entities.DTOs.Auttitulos;
using Backend.Shared.Entities.Models.Auttitulos;
using Backend.Shared.Entities.Responses;

using System.Collections.Generic;
using System.Threading.Tasks;

namespace Backend.Shared.Entities.Interface.Business
{
    public interface IRequestBusiness
    {

        Task<ResponseBase<procedure_requests>> getRequestById(string idRequest);

        Task<List<RequestReponseTableUserDto>> getAllByUser(string idUser);

        Task<ResponseBase<string>> updateRequest(RequestDTO request);


    }
}