using Backend.Shared.Entities.DTOs;
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
       
        #endregion
    }
}
