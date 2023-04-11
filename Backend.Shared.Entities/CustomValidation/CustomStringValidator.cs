using System.ComponentModel.DataAnnotations;

namespace Backend.Shared.Entities.CustomValidation
{
    /// <summary>
    /// CustomEmailValidator
    /// </summary>
    public class CustomStringValidator : ValidationAttribute
    {
        /// <summary>
        /// IsValid
        /// </summary>
        /// <param name="value"></param>
        /// <param name="validationContext"></param>
        /// <returns></returns>
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value != null)
            {
                string str = value.ToString();

                if (!string.IsNullOrEmpty(str))
                {
                    return ValidationResult.Success;
                }
                else
                {
                    return new ValidationResult("El campo " + validationContext.DisplayName + " es requerido");
                }
            }
            else
            {
                return new ValidationResult("El campo " + validationContext.DisplayName + " no puede ser nulo");
            }
        }
    }
}
