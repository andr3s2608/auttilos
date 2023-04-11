using Backend.Shared.Entities.Interface.Business;
using Backend.Shared.Entities.DTOs;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Backend.Shared.API.Controllers
{

    [ApiController, Route("api/v1/[controller]")]
    public class PDFController : Controller
    {
        #region Attributes
        private readonly IPDFBussines _pdfBusiness;
        #endregion

        #region Constructor
        /// <summary>
        /// Se crear una instancia para <see cref="ConstantesController"/> class.
        /// </summary>
        /// <param name="constantesBusiness">The constantes business.</param>
        public PDFController(IPDFBussines pdfBusiness)
        {
            _pdfBusiness = pdfBusiness;
        }
        #endregion


        #region Methods
        /// <summary>
        /// Permite obtener una lista de constantes de acuerdo al idPadre
        /// </summary>
        /// <returns></returns>
      
        #endregion
    }
}