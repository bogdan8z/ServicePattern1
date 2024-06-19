using ServicePattern1.DataAccess.Interfaces;
using ServicePattern1.Domain;

namespace ServicePattern1.InMemoryData
{
    public class OrderRepository : IOrderRepository
    {
        readonly IEnumerable<Order> _orders = new List<Order>
                {
                    new()
                    {
                        Id = 111,
                        OrderDate = DateTime.Now,
                        Items =
                        [
                            new()
                            {
                                Id = 2,
                                OrderId = 1,
                                Price = 45,
                                ProductName = "prod1"
                            }
                        ]
                    }
                }.AsEnumerable();

        public Task<IEnumerable<Order>> GetAllOrdersWithItems()
        {
            return Task.FromResult(_orders);
        }
    }
}
