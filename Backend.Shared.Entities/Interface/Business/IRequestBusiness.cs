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

        Task<ResponseBase<List<BandejaValidadorDTO>>> GetDashboard(string FinalDate, string TextToSearch,
            string selectedfilter, string pagenumber, string pagination);

        Task<ResponseBase<List<ReportsDashboardDTO>>> GetReports(string InitialDate, string FinalDate, string TextToSearch,
            string selectedfilter, string pagenumber, string pagination, string iduser);


    }
}