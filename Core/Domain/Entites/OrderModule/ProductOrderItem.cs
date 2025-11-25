using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entites.OrderModule
{
    public class ProductOrderItem
    {


        public ProductOrderItem() { }
        public ProductOrderItem(string productId, string productName, string pictureUrl)
        {
            ProductId = productId;
            ProductName = productName;
            PictureUrl = pictureUrl;
        }

        public string ProductId { get; set; } = null!;
        public string ProductName { get; set; } = null!;

        public string PictureUrl { get; set; } = null!;



    }
}
