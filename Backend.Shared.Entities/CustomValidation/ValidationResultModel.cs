using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Backend.Shared.Entities.CustomValidation
{
    /// <summary>
    /// ValidationResultModel
    /// </summary>
    public class ValidationResultModel
    {
        #region Attributes
        /// <summary>
        /// Message
        /// </summary>
        public string Message { get; }

        /// <summary>
        /// ResponseTime
        /// </summary>
        public DateTime ResponseTime { get; }

        /// <summary>
        /// Code
        /// </summary>
        public int Code { get; }

        /// <summary>
        /// ValidationError
        /// </summary>
        public List<ValidationError> Data { get; }
        #endregion

        #region Constructor
        /// <summary>
        /// ValidationResultModel
        /// </summary>
        /// <param name="modelState"></param>
        public ValidationResultModel(ModelStateDictionary modelState)
        {
            Message = "Validación fallida";
            ResponseTime = DateTime.UtcNow.AddHours(-5);
            Data = modelState.Keys
                    .SelectMany(key => modelState[key].Errors.Select(x => new ValidationError(key, x.ErrorMessage)))
                    .ToList();

            Code = StatusCodes.Status202Accepted;
        }
        #endregion
    }
}
