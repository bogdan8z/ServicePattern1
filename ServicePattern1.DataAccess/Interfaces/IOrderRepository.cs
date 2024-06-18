using ServicePattern1.Domain;

namespace ServicePattern1.DataAccess.Interfaces
{
    public interface IOrderRepository
    {
        Task<IEnumerable<Order>> GetAllOrdersWithItems();
    }
}
