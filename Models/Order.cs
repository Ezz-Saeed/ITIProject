namespace ITIProject.Models
{
    public class Order
    {
        public int Id { get; set; }
        public int CartId { get; set; }
        public int ProductId { get; set; }
        public int TotalQuantity { get; set; }
        public decimal TotalCost { get; set; }
        public ICollection<Cart> Carts { get; set; }
        public ICollection<CartOrder> CartOrders { get; set; }
        public ICollection<ProductOrder> ProductOrders { get; set; }
        public ICollection<Product> Products { get; set; }
    }
}
