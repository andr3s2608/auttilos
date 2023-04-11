using Backend.Shared.Entities.Interface.Business;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Backend.Shared.API.Controllers
{
    /// <summary>
    /// CriterioTipoDocumentoController
    /// </summary>
    /// <seealso cref="Microsoft.AspNetCore.Mvc.ControllerBase" />
    [ApiController, Route("api/v1/[controller]")]
    public class StatusController : ControllerBase
    {
        #region Attributes
        private readonly IStatusBusiness _statusBusiness;
        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="StatusController"/> class.
        /// </summary>
        /// <param name="pamecContext">The CriterioTipoDocumento business.</param>
        /// <param name="CriterioTipoDocumentoBusiness">The CriterioTipoDocumento business.</param>
        public StatusController(IStatusBusiness statusBusiness)
        {
            this._statusBusiness = statusBusiness;
        }

        #endregion

        #region Methods


        #endregion
    }
}
