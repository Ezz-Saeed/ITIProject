using ITIProject.Validator;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace ITIProject.Models
{
    public class Adminestrator
    {
        //public int Id { get; set; }

        public int Id { get; set; }
        [RegularExpression("[a-zA-Z]{4,10}",ErrorMessage ="User name must be letters only")]
        public  string Name { get; set; }
        //[Remote("ValidateAdminIdentity", "Adminestrator", ErrorMessage = "Wrong user name or password.", AdditionalFields = "Name")]

        [AdminValidation]
        public  string Password { get; set; } 
    }
}
