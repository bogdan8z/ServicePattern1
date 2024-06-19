﻿
namespace ServicePattern1.Domain
{
    public class OrderItem
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public string? ProductName { get; set; }
        public decimal Price { get; set; }
    }
}