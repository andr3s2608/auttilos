using Backend.Shared.Entities.DTOs.Auttitulos;
using Backend.Shared.Entities.Models.Auttitulos;
using Backend.Shared.Entities.Responses;

using System.Collections.Generic;
using System.Threading.Tasks;

namespace Backend.Shared.Entities.Interface.Business
{
    public interface IRequestBusiness
    {

        Task<ProcedureRequest_ResponseDTO> getRequestById(int idRequest);

        Task<List<RequestReponseTableUserDto>> getAllByUser(string idUser);

        Task<ResponseBase<string>> updateRequest(RequestDTO request);


    }
}