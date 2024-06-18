using ServicePattern1.DataAccess.Interfaces;

namespace ServicePattern1.Service.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IOrderRepository OrderRepository { get; }
        Task<int> CompleteAsync();
    }
}
