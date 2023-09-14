using ITIProject.Models;
using System.ComponentModel.DataAnnotations;

namespace ITIProject.Validator
{
    public class CustomerValidationAttribute : ValidationAttribute
    {
        ECommerceAContextApp _context = new ECommerceAContextApp();
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            var pass = value as string;
            Customer customer = validationContext.ObjectInstance as Customer;
            var user = _context.Customers.FirstOrDefault(x => x.Password == pass && x.Name == customer.Name);
            if (user != null)
            {
                return ValidationResult.Success;
            }
            else
                return new ValidationResult("Invalid user name or passowrd.");
            
        }
    }
}
