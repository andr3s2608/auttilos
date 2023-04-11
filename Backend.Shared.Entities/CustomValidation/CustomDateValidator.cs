using System;
using System.ComponentModel.DataAnnotations;

namespace Backend.Shared.Entities.CustomValidation
{
    /// <summary>
    /// CustomDateValidator
    /// </summary>
    public class CustomDateValidator : ValidationAttribute
    {
        /// <summary>
        /// IsValid
        /// </summary>
        /// <param name="value"></param>
        /// <param name="validationContext"></param>
        /// <returns></returns>
        //protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        //{
        //    var dateToParse = value.ToString();
        //    _ = new DateTime();
        //    DateTime parsedDate;
        //    if (DateTime.TryParseExact(dateToParse, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.None, out parsedDate))
        //        return ValidationResult.Success;

        //    return new ValidationResult("Fecha no válida, inténtelo de nuevo con una fecha válida en el formato yyyy/MM/dd.");

        //}


        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
            => DateTime.TryParseExact(value.ToString(), "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.None, out _)
            ? ValidationResult.Success : new ValidationResult("Invalid date, please try again with a valid date in the format of DD/MM/YYYY.");

    }
}
