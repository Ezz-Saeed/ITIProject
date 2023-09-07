using System.ComponentModel.DataAnnotations.Schema;

namespace ITIProject.Models
{
    public class ProductOrder
    {
        public int Id { get; set; }
        public int? OrderId { get; set; }
        public int Quantity { get; set; }
        public int ProductId { get; set; }
        private decimal _cost;
        public decimal Cost
        {
            get { return _cost; }
            set { _cost = value; }
        }
        public int CartId { get; set; }
        public Order? Order { get; set; }
        public Product? Product { get; set; }
        //[ForeignKey(nameof(CartId))]
        public Cart Cart { get; set; }

    }
}
