using ITIProject.Models;
using System.ComponentModel.DataAnnotations;

namespace ITIProject.Validator
{
    public class UniqueAttribute : ValidationAttribute
    {
        ECommerceAContextApp _context = new ECommerceAContextApp();
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            var name = value as string;
            var obj = _context.Categories.FirstOrDefault(c => c.Name == name);
            if (obj == null)
            {
                return ValidationResult.Success;
            }
            return new ValidationResult("This category already exists");
        }
    }
}
