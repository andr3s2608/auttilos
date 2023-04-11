using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Backend.Shared.Entities.CustomValidation
{
    /// <summary>
    /// ValidationFailedResult
    /// </summary>
    public class ValidationFailedResult : ObjectResult
    {
        /// <summary>
        /// ValidationFailedResult
        /// </summary>
        /// <param name="modelState"></param>
        public ValidationFailedResult(ModelStateDictionary modelState) : base(new ValidationResultModel(modelState))
        {
            StatusCode = StatusCodes.Status202Accepted;
        }
    }
}
