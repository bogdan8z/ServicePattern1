using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ServicePattern1.API.Models;
using ServicePattern1.Service.Interfaces;

namespace ServicePattern1.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrderController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IOrderService _orderService;

        public OrderController(IMapper mapper, IOrderService orderService)
        {
            _mapper = mapper;
            _orderService = orderService;
        }

        [HttpGet(Name = "GetAllOrders")]
        [ProducesResponseType(typeof(List<GetAllOrdersModel>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAsync()
        {
            var result = await _orderService.GetAllOrders();

            var orders = _mapper.Map<List<GetAllOrdersModel>>(result).ToList();
            return Ok(orders);
        }
    }
}