using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace Backend.Shared.Entities.CustomValidation
{
    /// <summary>
    /// CustomEmailValidator
    /// </summary>
    public class CustomEmailValidator : ValidationAttribute
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
                string email = value.ToString();

                if (Regex.IsMatch(email, @"[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}", RegexOptions.IgnoreCase))
                {
                    return ValidationResult.Success;
                }
                else
                {
                    return new ValidationResult("Introduce un correo electrónico válido.");
                }
            }
            else
            {
                return new ValidationResult("" + validationContext.DisplayName + " es requerido");
            }
        }
    }
}
