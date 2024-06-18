namespace ServicePattern1.Domain
{
    public class Order
    {
        public int Id { get; set; }
        public DateTime OrderDate { get; private set; }
        public List<OrderItem>? Items { get; private set; }

        public Order()
        {
            Items = [];
        }
    }
}