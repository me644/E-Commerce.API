using Shared.Shared.OrderModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Abstraction.Contracts
{
    public interface IOrderService
    {

        Task<OrderResult> GetOrderByIdAsync(Guid id);

        Task<IEnumerable<OrderResult>> GetOrderByEmailAsync(string UserEmail);


        Task<OrderResult> CreateOrderAsync(OrderRequestDto orderRequestDto, string UserEmail);

        Task<IEnumerable<DeleviryMethodResultDto>> GetDeleviryNethods();

    }
}
