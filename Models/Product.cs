using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ITIProject.Models
{
    public class Product
    {
        public int Id { get; set; }
        //[MinLength(3,ErrorMessage ="Name must be at least 3 letters")]
        [MaxLength(15, ErrorMessage = "Name must be at most 15 letters")]
        [DisplayName("Name ")]
        [Required(ErrorMessage = "Name is required.")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Description is required.")]
        [DisplayName("Description ")]
        public string Description { get; set; }
      
        [DisplayName("Image ")]
        public string? ImagePath { get; set; }
        [Required(ErrorMessage ="Price is required.")]
        [DisplayName("Price ")]
        [Range(30,20000, ErrorMessage ="Price must be greater than or equal 30 L.E and less than or equal 20000 L.E")]
        public decimal Price { get; set; }
        [Required(ErrorMessage = "Quantity is required.")]
        public int Quantity { get; set; }
        [DisplayName("Category ")]
        public int CategoryId { get; set; }
       
        public int? OrderId { get; set; }
        public Category? Category { get; set; }
        public ICollection<Order>? Orsders { get; set; }
        public ICollection<ProductOrder>? ProductOrders { get; set; }
        
    }
}
