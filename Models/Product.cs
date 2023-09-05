using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ITIProject.Models
{
    public class Product
    {
        public int Id { get; set; }
        //[MinLength(3,ErrorMessage ="Name must be at least 3 letters")]
        //[MaxLength(15, ErrorMessage = "Name must be at most 15 letters")]
        [DisplayName("Name: ")]
        public string Name { get; set; }
        [DisplayName("Description: ")]
        public string Description { get; set; }

        public string? ImagePath { get; set; }

        [DisplayName("Price: ")]
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        [DisplayName("Category: ")]
        public int CategoryId { get; set; }
       
        public int? OrderId { get; set; }
        public Category? Category { get; set; }
        public ICollection<Order>? Orsders { get; set; }
        public ICollection<ProductOrder>? ProductOrders { get; set; }
        
    }
}
