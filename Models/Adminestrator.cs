using ITIProject.Validator;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ITIProject.Models
{
    public class Adminestrator
    {
        //public int Id { get; set; }

        public int Id { get; set; }
        [RegularExpression("[a-zA-Z]{4,10}",ErrorMessage ="User name must be letters only")]
        [DisplayName("User Name")]
        public   string Name { get; set; }

        [AdminValidation]
        public  string Password { get; set; } 
    }
}
