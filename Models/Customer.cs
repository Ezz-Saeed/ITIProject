using ITIProject.Validator;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ITIProject.Models
{
    public class Customer
    {
        public int Id { get; set; }
        [DisplayName("User name ")]
        [Required]
        public string Name { get; set; }
        [Required]
        [CustomerValidation]
        public string Password { get; set; }
       
        public string? Email { get; set; }
        //[Required]
        public string? Address { get; set; }
        //[Required]
        [Remote("AgeValidation","Customer", ErrorMessage ="Age must be greater than or equal 18.")]
        public int? Age { get; set; }
        //[Required]
        public string? Phone { get; set; }
        public int CartId { get; set; }
        public Cart? Cart { get; set; }
    }
}
