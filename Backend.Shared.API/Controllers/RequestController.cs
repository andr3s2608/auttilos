using Backend.Shared.BusinessRules;
using Backend.Shared.Entities.DTOs;
using Backend.Shared.Entities.Interface.Business;

using Microsoft.AspNetCore.Mvc;
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



        [HttpGet("GetAllResolutions")]
        public async Task<ActionResult> GetResolutions()
        {
            var result = _requestBusiness.getResolutions();
            return StatusCode(result.Result.Code, result);
        }


        #endregion
    }
}
