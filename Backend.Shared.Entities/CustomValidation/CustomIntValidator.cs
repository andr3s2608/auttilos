using System.ComponentModel.DataAnnotations;

namespace Backend.Shared.Entities.CustomValidation
{
    /// <summary>
    /// CustomEmailValidator
    /// </summary>
    public class CustomIntValidator : ValidationAttribute
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
                int val = (int)value;

                if (val > 0)
                {
                    return ValidationResult.Success;
                }
                else
                {
                    return new ValidationResult("El campo " + validationContext.DisplayName + " debe ser diferente de 0");
                }
            }
            else
            {
                return new ValidationResult("El campo " + validationContext.DisplayName + " no puede ser nulo");
            }
        }
    }
}
