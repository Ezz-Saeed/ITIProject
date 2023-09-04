using ITIProject.Models;
using System.ComponentModel.DataAnnotations;

namespace ITIProject.Validator
{
    public class AdminValidationAttribute : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            ECommerceAContextApp _context = new ECommerceAContextApp();
            var password = value as string;
            var admin = _context.Adminestrator.FirstOrDefault(a => a.Password == password);
            if (admin != null)
            {
                return ValidationResult.Success;
            }
            else
                return new ValidationResult("Wrong Password.");
        }
    }
}
