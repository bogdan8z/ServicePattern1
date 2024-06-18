using Microsoft.EntityFrameworkCore;
using ServicePattern1.DataAccess;
using ServicePattern1.DataAccess.Interfaces;
using ServicePattern1.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicePattern1.Service
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IApplicationDbContext _context;
        private bool _disposed = false;

        public IOrderRepository OrderRepository { get; }

        public UnitOfWork(IApplicationDbContext context)
        {
            _context = context;
            OrderRepository = new OrderRepository(_context);
        }

        public async Task<int> CompleteAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed && disposing)
            {
                //todo
                if (_context is IDisposable disposableRepository)
                {
                    disposableRepository.Dispose();
                }
            }
            _disposed = true;
        }
    }
}
