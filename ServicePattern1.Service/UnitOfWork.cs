using ServicePattern1.DataAccess.Interfaces;
using ServicePattern1.Service.Interfaces;

namespace ServicePattern1.Service
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IApplicationDbContext? _context;
        private bool _disposed = false;

        public IOrderRepository OrderRepository { get; }

        public UnitOfWork(IOrderRepository orderRepository, IApplicationDbContext context) : this(orderRepository)
        {
            _context = context;
        }

        // Constructor when using in-memory repository
        public UnitOfWork(IOrderRepository orderRepository)
        {
            OrderRepository = orderRepository;
        }

        public async Task<int> CompleteAsync()
        {
            if(_context == null)
            {
                return 0;
            }

            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    if (_context is IDisposable disposableContext)
                    {
                        disposableContext.Dispose();
                    }
                }

                _disposed = true;
            }
        }

        ~UnitOfWork()
        {
            Dispose(false);
        }
    }
}
