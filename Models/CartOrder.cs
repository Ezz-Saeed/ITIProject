namespace ITIProject.Models
{
    public class CartOrder
    {
        public int CartId { get; set; }
        public int OrderId { get; set; }
        public Order? Order { get; set; }
        public Cart? Cart { get; set; }

    }
}
