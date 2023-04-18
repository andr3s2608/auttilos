using Backend.Shared.BusinessRules;
using Backend.Shared.Entities.DTOs.Auttitulos;
using Backend.Shared.Entities.Interface.Business;

using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Shared.API.Controllers
{
    /// <summary>
    /// CargoController 
    /// </summary>
    /// <seealso cref="Microsoft.AspNetCore.Mvc.ControllerBase" />
    [ApiController, Route("api/v1/[controller]")]
    public class RequestController : ControllerBase
    {
        #region Attributes
        private readonly IRequestBusiness _requestBusiness;
        #endregion

        #region Constructor
        /// <summary>
        /// Initializes a new instance of the <see cref="RequestController"/> class.
        /// </summary>
        /// <param name="pamecContext">The cementerio business.</param>
        /// <param name="cargoBusiness">The cementerio business.</param>
        public RequestController(IRequestBusiness requestBusiness)
        {
            this._requestBusiness = requestBusiness;
        }
        #endregion

        #region Methods

        [HttpGet("GetRequestByid/{idrequest}")]
        public async Task<ActionResult> Getrequestbyid(string idrequest)
        {
            var result = _requestBusiness.getRequestbyid(idrequest);
            return StatusCode(result.Result.Code, result);
        }



        [HttpGet("GetAllResolutions")]
        public async Task<ActionResult> GetResolutions()
        {
            var result = _requestBusiness.getResolutions();
            return StatusCode(result.Result.Code, result);
        }

        [HttpGet("GetDashboard/{FinalDate}/{TextToSearch}/{selectedfilter}/{pagenumber}/{pagination}")]
        public async Task<ActionResult> GetDashboard(DateTime FinalDate,string? TextToSearch,
            string? selectedfilter, string pagenumber, string pagination)
        {
            var result = _requestBusiness.GetDashboard(FinalDate, TextToSearch,
                selectedfilter, pagenumber, pagination);
            return StatusCode(result.Result.Code, result);
        }

        [HttpPut("UpdateRequest")]
        public async Task<ActionResult> UpdateRequest(RequestDTO request)
        {
            var result = _requestBusiness.UpdateRequest(request);
            return StatusCode(result.Result.Code, result);
        }


        #endregion
    }
}
