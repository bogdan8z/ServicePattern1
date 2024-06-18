using ServicePattern1.Service.Models;

namespace ServicePattern1.Service.Interfaces
{
    public interface IOrderService
    {
        Task<IEnumerable<GetOrders>> GetAllOrders();
    }
}
