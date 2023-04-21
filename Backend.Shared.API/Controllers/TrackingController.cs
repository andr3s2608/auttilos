using Backend.Shared.Entities.DTOs.Auttitulos;
using Backend.Shared.Entities.Interface.Business;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Backend.Shared.API.Controllers
{
    [ApiController, Route("api/v1/[controller]")]
    public class TrackingController : Controller
    {

        #region Attributes
  
        private readonly ITrackingBusiness _trackingBusiness;
        #endregion


        #region Constructor
        /// <summary>
        /// Se crear una instancia para <see cref="TrackingController"/> class.
        /// </summary>
        /// <param name="">The Seguimiento business.</param>
        public TrackingController ( ITrackingBusiness trackingBusiness)
        {

            _trackingBusiness = trackingBusiness;
        }
        #endregion

        #region Methods
        [HttpGet("GetTracking/{idRequest}")]
        public async Task<ActionResult> GetTracking(string idRequest)
        {
            var result = _trackingBusiness.GetTrackingbyid(idRequest);
            return StatusCode(result.Result.Code, result);
        }

        [HttpPost("AddTracking")]
        public async Task<ActionResult> AddTracking(TrackingDTO tracking)
        {
            var result = _trackingBusiness.AddTracking(tracking);
            return StatusCode(result.Result.Code, result);
        }

        [HttpGet("GetDuplicated/{iddocument}")]
        public async Task<ActionResult> GetDuplicated(string iddocument)
        {
            var result = _trackingBusiness.GetDuplicatedbyid(iddocument);
            return StatusCode(result.Result.Code, result);
        }
        #endregion
    }
}
