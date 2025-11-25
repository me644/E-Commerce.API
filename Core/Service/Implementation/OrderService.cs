using AutoMapper;
using Domain.Contracts;
using Domain.Entites.BasketModule;
using Domain.Entites.IdentityModule;
using Domain.Entites.OrderModule;
using Domain.Entites.Product;
using Domain.Exceptions;
using Service.Abstraction.Contracts;
using Service.Specifications;
using Shared.Shared.OrderModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Address = Domain.Entites.OrderModule.Address;

namespace Service.Implementation
{
    public class OrderService(IMapper _mapp,IBasketRepository _basketRepository,IUnitOfWork _unitOfWork) : IOrderService
    {
        public async Task<OrderResult> CreateOrderAsync(OrderRequestDto orderRequestDto, string UserEmail)
        {
            ///AddressDto to Address
        var address=    _mapp.Map<Address>(orderRequestDto.Address);
            ////\
            ///Basket_Items  to OrderItems  and  check  Existence  of items && Price
            var Items = await _basketRepository.GetByIdAsync(orderRequestDto.Basket_id) ?? throw new OrderNotFoundExceptions(orderRequestDto.Basket_id);
            ICollection<OrderItems> orderItems = [];
            foreach (var item in Items.BasketItems) {

                var order = await _unitOfWork.GetRepository<Product, int>().GetbyIdAsync(item.Id) ?? throw new ProductNotFoundException(item.Id);
                orderItems.Add(new OrderItems(new ProductOrderItem(order.Id.ToString(), order.Name, order.PictureUrl), item.Quantity, order.Price));

            }

            //////\
            //check  Delv_method!!!
            var Delv_Method = await _unitOfWork.GetRepository<DeliveryMethod, int>().GetbyIdAsync(orderRequestDto.DeliveryMethodId) ?? throw new DeleviryMethodeNotfoundExceptions(orderRequestDto.DeliveryMethodId);
            ////\
            ///SubTotal
            var SubTotal = orderItems.Sum(e => e.Price * e.Quntity);

            var OrderTocreate = new Order() { UserEmail = UserEmail, orderItems = orderItems, DeliveryMethod = Delv_Method, SubTotal = SubTotal,shippingAddress=address };
            await _unitOfWork.GetRepository<Order,Guid>().Add(OrderTocreate);
           await _unitOfWork.SaveChnges();
            return _mapp.Map<OrderResult>(OrderTocreate);

        }
       

        public async Task<IEnumerable<DeleviryMethodResultDto>> GetDeleviryNethods()
        {
            var Methods= await _unitOfWork.GetRepository<DeliveryMethod, int>().GetAllAsync();

            return _mapp.Map <IEnumerable<DeleviryMethodResultDto>>(Methods);
        }

        public  async Task<IEnumerable<OrderResult>> GetOrderByEmailAsync(string UserEmail)
        {
            
            var orders=    await _unitOfWork.GetRepository<Order,Guid>().GetAllAsync(new OrderWithIncludeSpecifications(UserEmail));

            return _mapp.Map<IEnumerable<OrderResult>>(orders);

        }

        public async Task<OrderResult> GetOrderByIdAsync(Guid id)
        {
            var item = await _unitOfWork.GetRepository<Order, Guid>().GetbyIdAsync(new OrderWithIncludeSpecifications(id));
            return _mapp.Map<OrderResult>(item);
        }
    }
}
