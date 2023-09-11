using ITIProject.Validator;
using System.ComponentModel.DataAnnotations;

namespace ITIProject.Models
{
    public class Category
    {
        public int Id { get; set; }
        [MaxLength(20,ErrorMessage ="Category nmae must be less than or equal 15 Letters.")]
        [Required]
        [Unique]
        public string Name { get; set; }
        public ICollection<Product>? Products { get; set; }
    }
}
