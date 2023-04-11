using Backend.Shared.BusinessRules;
using Backend.Shared.Entities.Interface.Business;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Backend.Shared.API.Controllers
{
    [ApiController, Route("api/v1/[controller]")]
    public class EntitiesController : Controller
    {
        #region Attributes
        private readonly IEntitiesBusiness _entitiesBusiness;
        #endregion

        #region Contructor
        public EntitiesController(IEntitiesBusiness entitiesBusiness)
        {
            _entitiesBusiness = entitiesBusiness;
        }
        #endregion


        #region Methods

        #endregion
    }
}
