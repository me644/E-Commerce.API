using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Shared.OrderModel
{
    public class OrderITemsDto
    {


        public string ProductId { get; set; } = null!;
        public string ProductName { get; set; } = null!;

        public string PictureUrl { get; set; } = null!;

        public int Quntity { get; set; }

        public decimal Price { get; set; }

    }
}
