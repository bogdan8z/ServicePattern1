using Microsoft.EntityFrameworkCore;
using ServicePattern1.DataAccess.Interfaces;
using ServicePattern1.Domain;

namespace ServicePattern1.DataAccess
{
    public class OrderRepository : IOrderRepository
    {
        private readonly IApplicationDbContext _context;

        public OrderRepository(IApplicationDbContext context)
        {
            _context = context;           
        }

        public async Task<IEnumerable<Order>> GetAllOrdersWithItems()
        {
            return await _context.Set<Order>()
                .Include(o => o.Items)
                .ToListAsync();
        }        
    }
}
