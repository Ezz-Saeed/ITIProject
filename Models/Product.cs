using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ITIProject.Models
{
    public class Product
    {
        public int Id { get; set; }
        //[MinLength(3,ErrorMessage ="Name must be at least 3 letters")]
        //[MaxLength(15, ErrorMessage = "Name must be at most 15 letters")]
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        [DisplayName("Category")]
        public int CategoryId { get; set; }
       
        //public int CartId { get; set; }
        public int? OrderId { get; set; }
        public Category? Category { get; set; }
        public ICollection<Order>? Orsders { get; set; }
        public ICollection<ProductOrder>? ProductOrders { get; set; }
        
    }
}
