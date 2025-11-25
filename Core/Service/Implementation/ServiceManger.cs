using AutoMapper;
using Domain.Contracts;
using Service.Abstraction.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Implementation
{
    public class ServiceManger : ISerivceMnager
    {

        private readonly Lazy<IProductService> _ProductSerive;

       
       // public IProductService ProductService => throw new NotImplementedException();

        private readonly IUnitOfWork _unitOfWork;
        private readonly IBasketRepository _basketRepository;
        private readonly Lazy<IBasketService> _basketService;
        private readonly IMapper _mapper;

        private readonly Lazy<IOrderService> _orderService;
        public ServiceManger(IUnitOfWork unitOfWork,IMapper mapper, IBasketRepository basketRepositor)
        {
            _mapper = mapper;

            _ProductSerive = new Lazy<IProductService>(() => new ProductSerivce(unitOfWork, _mapper));
            _unitOfWork = unitOfWork;
            _basketRepository= basketRepositor;
            _basketService = new Lazy<IBasketService>(() => new BasketService(_basketRepository, _mapper));
            _orderService = new Lazy<IOrderService>(() => new OrderService(_mapper, _basketRepository, _unitOfWork));

        }
        public IProductService ProductService => _ProductSerive.Value;

        public IBasketService BasketService => _basketService.Value;

       // IOrderService ISerivceMnager.OrderService => throw new NotImplementedException();

        public IOrderService  OrderService=> _orderService.Value;


    }
}
