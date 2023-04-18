using Backend.Shared.Entities.Interface.Business;
using Backend.Shared.Entities.Models.Auttitulos;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Backend.Shared.API.Controllers
{
    [ApiController, Route("api/v1/[controller]")]
    public class ResolutionsController : Controller
    {

        #region Attributes
        private readonly IResolutionsBusiness _resolutionsBusiness;
        #endregion

        #region Constructor
        public ResolutionsController(IResolutionsBusiness resolutionsBusiness)
        {
            _resolutionsBusiness = resolutionsBusiness;

        }
        #endregion

        #region Methods

        [HttpGet("GetAllResolutions")]
        public async Task<ActionResult> GetResolutions()
        {
            var result = _resolutionsBusiness.getResolutions();
            return StatusCode(result.Result.Code, result);
        }

        [HttpPost("AddResolution")]
        public async Task<ActionResult> AddResolution(Resolutions resolution)
        {
            var result = _resolutionsBusiness.AddResolution(resolution);
            return StatusCode(result.Result.Code, result);
        }
        #endregion
    }
}
