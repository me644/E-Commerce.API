using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entites.OrderModule
{
    public class ProductOrderItem
    {
        public string ProductId { get; set; } = null!;
        public string ProductName { get; set; } = null!;

        public string PictureUrl { get; set; } = null!;



    }
}
