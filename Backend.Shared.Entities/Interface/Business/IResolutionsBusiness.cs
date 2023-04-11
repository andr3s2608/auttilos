
using Backend.Shared.Entities.Models.Pamec;
using Backend.Shared.Entities.Responses;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Shared.Entities.Interface.Business
{
    public interface IResolutionsBusiness
    {
        Task<ResponseBase<List<Entities.Models.Auttitulos.Resolutions>>> getResolutions();

    }
}
