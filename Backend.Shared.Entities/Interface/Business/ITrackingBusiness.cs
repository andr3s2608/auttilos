using Backend.Shared.Entities.DTOs.Auttitulos;
using Backend.Shared.Entities.Models.Auttitulos;
using Backend.Shared.Entities.Responses;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Shared.Entities.Interface.Business
{
    public interface ITrackingBusiness
    {
        //Task<ResponseBase<SeguimientoSIC>> saveSeguimientoSic(RequestSeguimientoSIC toSave);

        Task<ResponseBase<List<Tracking>>> GetTrackingbyid(string idRequest);

        Task<ResponseBase<string>> AddTracking(TrackingDTO tracking);

        Task<ResponseBase<List<DuplicatedidDTO>>> GetDuplicatedbyid(string iddocument);
    }
}
