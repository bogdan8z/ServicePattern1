using Microsoft.EntityFrameworkCore;
using ServicePattern1.DataAccess.Interfaces;
using ServicePattern1.DataAccess.Mapper;
using ServicePattern1.Domain;
using System.Xml;

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
         //   return _context.Orders
         return await _context.Set<Order>()
           .Include(o => o.Items)
           .ToListAsync();
        }

        private void AddMapper()
        {
            //var config = new MapperConfiguration(cfg =>
            //{
            //    cfg.CreateMap<Order, EntityDto>().ForMember(dto => dto.Currency, map => map.MapFrom(source => new Currency
            //    {
            //        Code = source.CurrencyCode,
            //        Value = source.CurrencyValue.ToString("0.00")
            //    }));
            //});

            //_iMapper = config.CreateMapper();
            
        }
    }
}
