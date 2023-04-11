using Backend.Shared.Entities.Interface.Business;
using Backend.Shared.Entities.DTOs;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Net;

namespace Backend.Shared.API.Controllers
{
    [ApiController, Route("api/v1/[controller]")]
    public class DocumentController: Controller
    {

        #region Attributes
        private readonly IDocumentBusiness _documentBusiness;
        #endregion

        #region Contructor
        public DocumentController(IDocumentBusiness documentBusiness)
        {
            _documentBusiness = documentBusiness;
        }
        #endregion

        #region Methods
        /// <summary>
        /// Permite agregar un documento a base de datos
        /// </summary>
        /// <returns></returns>
       
        #endregion
    }
}
