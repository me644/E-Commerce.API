using Microsoft.AspNetCore.Mvc;
using Service.Abstraction.Contracts;
using Shared.Shared.OrderModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation.Controller
{

    [ApiController]
    [Route("api/[Controller]")]
    public class OrderController(ISerivceMnager _serivceMnager) : ControllerBase
    {
        [HttpPost]
        public async Task<ActionResult<OrderResult>> CreateOrderAsync(OrderRequestDto orderRequest)
        {
            var oreder = await _serivceMnager.OrderService.CreateOrderAsync(orderRequest,"mmk06@gmail,com");
            return Ok(oreder);
        }

    }
}
