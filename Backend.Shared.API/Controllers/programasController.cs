using Backend.Shared.Entities.DTOs;
using Backend.Shared.Entities.Interface.Business;
using Backend.Shared.Entities.Models.Pamec;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Backend.Shared.API.Controllers
{
    /// <summary>
    /// PamecController 
    /// </summary>
    /// <seealso cref="Microsoft.AspNetCore.Mvc.ControllerBase" />
    [ApiController, Route("api/v1/[controller]")]
    public class programasController : ControllerBase
    {
        #region Attributes
        private readonly IProgramasBusiness _programasBusiness;
        #endregion

        #region Constructor
        /// <summary>
        /// Initializes a new instance of the <see cref="programasController"/> class.
        /// </summary>
        /// <param name="pamecBusiness">The pamec business.</param>
        public programasController(IProgramasBusiness programasBusiness)
        {
            this._programasBusiness = programasBusiness;
        }
        #endregion

        #region Methods

       
        #endregion
    }
    }
