using Backend.Shared.Entities.Interface.Business;
using Backend.Shared.Entities.DTOs.Auttitulos;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Net;
using System.Collections.Generic;

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
        [HttpGet("GetDocumentsByid/{idrequest}")]
        public async Task<ActionResult> getDocumentsbyid(string idrequest)
        {
            var result = _documentBusiness.getDocumentsbyid(idrequest);
            return StatusCode(result.Result.Code, result);
        }

        /// <summary>
        /// Permite agregar un documento a base de datos
        /// </summary>
        /// <returns></returns>
        [HttpPost("AddDocuments")]
        public async Task<ActionResult> AddDocuments(List<DocumentsDTO>  documents)
        {
            var result = _documentBusiness.addDocuments(documents);
            return StatusCode(result.Result.Code, result);
        }

        /// <summary>
        /// Permite agregar un documento a base de datos
        /// </summary>
        /// <returns></returns>
        [HttpPut("UpdateDocuments")]
        public async Task<ActionResult> up(List<DocumentsDTO> documents)
        {
            var result = _documentBusiness.updateDocuments(documents);
            return StatusCode(result.Result.Code, result);
        }

        #endregion
    }
}
