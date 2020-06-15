using System;
using System.ComponentModel.DataAnnotations;

namespace ChefsNDishes.Models
{
    public class AdultValidationAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if ((DateTime)value > DateTime.Now)
                return new ValidationResult("Date Out of Bounds");
            return ValidationResult.Success;
        }

    }
}