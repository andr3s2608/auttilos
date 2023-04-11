using Backend.Shared.Entities.DTOs;
using Backend.Shared.Entities.Models.Pamec;
using Backend.Shared.Entities.Responses;

using System.Collections.Generic;
using System.Threading.Tasks;

namespace Backend.Shared.Entities.Interface.Business
{
    public interface IRequestBusiness
    {
      //
        Task<ResponseBase<List<Entities.Models.Auttitulos.Resolutions>>> getResolutions();
      
       
    }
}