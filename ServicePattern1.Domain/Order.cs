﻿namespace ServicePattern1.Domain
{
    public class Order
    {
        public int Id { get; set; }
        public DateTime OrderDate { get; set; }
        public List<OrderItem>? Items { get; set; }

        public Order()
        {
            Items = [];
        }
    }
}