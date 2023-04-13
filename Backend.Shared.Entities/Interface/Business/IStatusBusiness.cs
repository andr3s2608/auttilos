using Backend.Shared.Entities.DTOs;
using Backend.Shared.Entities.Models.Auttitulos;
using Backend.Shared.Entities.Responses;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Shared.Entities.Interface.Business
{
    public interface IStatusBusiness
    {


        Task<ResponseBase<List<Status_types>>> GetStatusbyrol(string rol);

    }
}
