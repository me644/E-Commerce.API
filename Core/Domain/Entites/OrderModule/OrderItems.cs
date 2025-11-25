namespace Domain.Entites.OrderModule
{
    public class OrderItems:Base<Guid>
    {

        public OrderItems() { }
        public OrderItems(ProductOrderItem productOrder, int quntity, decimal price)
        {
            this.productOrder = productOrder;
            Quntity = quntity;
            Price = price;
        }

        public ProductOrderItem  productOrder {get; set;}

    public int Quntity { get;set; }

        public decimal Price { get; set; }

       

    }
}