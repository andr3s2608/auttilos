using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Backend.Shared.API.Controllers.v2
{
    /// <summary>
    /// DepartamentoController
    /// </summary>
    /// <seealso cref="Microsoft.AspNetCore.Mvc.ControllerBase" />
    [ApiController, Route("api/v2/[controller]")]
    public class DepartamentoController : ControllerBase
    {
        #region Attributes
        /// <summary>
        /// The departamento business
        /// </summary>
        private readonly Entities.Interface.Business.IDepartamentoBusiness DepartamentoBusiness;
        #endregion

        #region Constructor                                                                     
        /// <summary>
        /// Initializes a new instance of the <see cref="DepartamentoController"/> class.
        /// </summary>
        /// <param name="departamentoBusiness">The departamento business.</param>
        public DepartamentoController(Entities.Interface.Business.IDepartamentoBusiness departamentoBusiness)
        {
            DepartamentoBusiness = departamentoBusiness;
        }
        #endregion

        #region Methods
        /// <summary>
        /// GetDepartamento
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetDepartamento")]
        public async Task<ActionResult> GetDepartamento()
        {
            var result = await DepartamentoBusiness.GetDepartamento();
            return StatusCode(result.Code, result);
        }


        /// <summary>
        /// GetAllDepartamento
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetAllDepartamento")]
        public async Task<ActionResult> GetAllDepartamento()
        {
            var result = await DepartamentoBusiness.GetAllDepartamento();
            return StatusCode(result.Code, result);
        }
        #endregion
    }
}
