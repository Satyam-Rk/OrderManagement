using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManagement.Domain.Entities
{
    public class OrderItem
    {
        public Guid Id { get; private set; }
        public Guid OrderId { get; private set; }
        public Guid ProductId { get; private set; }
        public int Quantity { get; private set; }
        public decimal Price { get; private set; }
        public Order Order { get; private set; } = default!;
        public Product Product { get; private set; } = default!;

        public OrderItem(Guid productId, int quantity, decimal price)
        {
            Id = Guid.NewGuid();

            if (quantity <= 0)
                throw new Exception("Quantity must be greater than zero");

            ProductId = productId;
            Quantity = quantity;
            Price = price;
        }
    }
}
