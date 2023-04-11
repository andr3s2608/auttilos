using Microsoft.AspNetCore.Mvc.Filters;

namespace Backend.Shared.Entities.CustomValidation
{
    /// <summary>
    /// ValidateModelAttribute
    /// </summary>
    public class ValidateModelAttribute : ActionFilterAttribute
    {
        /// <summary>
        /// OnActionExecuting
        /// </summary>
        /// <param name="context"></param>
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (!context.ModelState.IsValid)
            {
                context.Result = new ValidationFailedResult(context.ModelState);
            }
        }
    }
}
