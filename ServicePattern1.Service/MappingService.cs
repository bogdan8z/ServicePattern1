using AutoMapper;
using ServicePattern1.DataAccess.Models;
using ServicePattern1.Domain;
using ServicePattern1.Service.Interfaces;
using ServicePattern1.Service.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicePattern1.Service
{
    public class MappingService : IMappingService
    {
        private readonly IMapper _mapper;
        public MappingService(IMapper mapper)
        {
            _mapper = mapper;
        }

        public IEnumerable<GetAaaModel> MapOrderToDto(IEnumerable<OrderModel111> order)
        {
            return _mapper.Map<IEnumerable<GetAaaModel>>(order);
        }
    }
}
