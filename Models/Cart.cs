﻿namespace ITIProject.Models
{
    public class Cart
    {
        public int Id { get; set; }
        public int? CustomerId { get; set; }
        public Customer? Customer { get; set; }
        public ICollection<ProductOrder>? ProductOrders { get; set; }
        //public ICollection<Order>? Orders { get; }
        //public ICollection<CartOrder>? CartOrders { get; set; }

    }
}
