using System;
using Backend.Shared.BusinessRules;
using Backend.Shared.Entities.DTOs.Auttitulos;
using Backend.Shared.Entities.Interface.Business;

using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using MySqlX.XDevAPI.Common;

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

        [HttpGet("GetRequestById/{idRequest}")]
        public async Task<ActionResult> GetRequestById(int idRequest)
        {
            try
            {
                return Ok(await _requestBusiness.getRequestById(idRequest));
            }
            catch (Exception e)
            {
                return NotFound(e.Message);
            }
        }
        
        [HttpGet("GetRequestByUser/{idUser}")]
        public async Task<ActionResult> GetRequestsByIdUser(string idUser)
        {
            try
            {
                return Ok(await _requestBusiness.getAllByUser(idUser));
            }
            catch (Exception e)
            {
                return NotFound(e.Message);
            }
            
            
        }
        

        [HttpPut("UpdateRequest")]
        public async Task<ActionResult> UpdateRequest(RequestDTO request)
        {
            var result = _requestBusiness.updateRequest(request);
            return StatusCode(result.Result.Code, result);
        }


        #endregion
    }
}
