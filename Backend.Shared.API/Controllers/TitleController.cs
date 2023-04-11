using Backend.Shared.BusinessRules;
using Backend.Shared.Entities.DTOs;
using Backend.Shared.Entities.Interface.Business;

using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Shared.API.Controllers
{
    /// <summary>
    /// FirmasController 
    /// </summary>
    /// <seealso cref="Microsoft.AspNetCore.Mvc.ControllerBase" />
    [ApiController, Route("api/v1/[controller]")]
    public class TitleController : ControllerBase
    {
        #region Attributes
        private readonly ITitleBusiness _tittleBusiness;
        #endregion

        #region Constructor
        public TitleController(ITitleBusiness tittleBusiness)
        {
            this._tittleBusiness = tittleBusiness;
        }
        #endregion

        #region Methods
       
        #endregion
    }
}
