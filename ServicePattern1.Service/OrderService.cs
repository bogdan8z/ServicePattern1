using AutoMapper;
using ServicePattern1.DataAccess.Mapper;
using ServicePattern1.DataAccess.Models;
using ServicePattern1.Service.Interfaces;
using ServicePattern1.Service.Models;
using ServicePattern1.Service.Mapper;

namespace ServicePattern1.Service
{
    public class OrderService : IOrderService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
       // private readonly IMapper _mapper2;

        private readonly IMappingService _mappingService;

        public OrderService(
            IUnitOfWork unitOfWork,
            IMappingService mappingService
            )
        {
            _unitOfWork = unitOfWork;
            _mapper = ConfigureDataAccessMapper.CreateMapper();
            //_mapper2 = ConfigureServiceMapper.CreateMapper();
            _mappingService = mappingService;
        }

        public async Task<IEnumerable<GetAaaModel>> GetAllOrders()
        {
            var dbResults = await _unitOfWork.OrderRepository.GetAllOrdersWithItems();
            var mappedOrders = _mapper.Map<List<OrderModel111>>(dbResults).ToList();
            //  var results = _mapper2.Map<List<GetAaaModel>>(mappedOrders).ToList();

            var results = _mappingService.MapOrderToDto(mappedOrders).ToList();

            return results;
        }
    }
}
