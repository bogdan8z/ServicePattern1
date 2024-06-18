
namespace ServicePattern1.Domain
{
    public class OrderItem
    {
        public int Id { get; private set; }
        public int OrderId { get; private set; }
        public string? ProductName { get; private set; }
        public decimal Price { get; private set; }
    }
}