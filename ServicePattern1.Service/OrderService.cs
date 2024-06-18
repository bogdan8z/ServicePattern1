using AutoMapper;
using ServicePattern1.DataAccess.Models;
using ServicePattern1.Service.Interfaces;
using ServicePattern1.Service.Models;

namespace ServicePattern1.Service
{
    public class OrderService : IOrderService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;       


        public OrderService(
            IUnitOfWork unitOfWork,
            IMapper mapper
            )
        {
            _unitOfWork = unitOfWork;            
            _mapper = mapper;
        }

        public async Task<IEnumerable<GetOrders>> GetAllOrders()
        {
            var dbResults = await _unitOfWork.OrderRepository.GetAllOrdersWithItems();
            var mappedOrders = _mapper.Map<List<GetDbOrderModel>>(dbResults).ToList();             
            var results = _mapper.Map<List<GetOrders>>(mappedOrders).ToList();
            return results;
        }
    }
}
