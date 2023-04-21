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
    public class FormatController : ControllerBase
    {
        #region Attributes
        private readonly IFormatBusiness _formatBusiness;
        #endregion

        #region Constructor
        public FormatController(IFormatBusiness formatBusiness)
        {
            this._formatBusiness = formatBusiness;
        }
        #endregion

        #region Methods
        /*
        [HttpGet("GetFormats/{idFormat}")]
        public async Task<ActionResult> GetFormats(string idFormat)
        {
            var result = _formatBusiness.GetStatusbyrol(rol);
            return StatusCode(result.Result.Code, result);
        }
        */
        #endregion
    }
}
