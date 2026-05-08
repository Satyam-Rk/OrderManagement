using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManagement.Domain.Entities
{
    public class Order
    {
        public Guid Id { get; private set; }
        public Guid UserId { get; private set; }
        public DateTime OrderDate { get; private set; }
        public decimal TotalAmount { get; private set; }
        public List<OrderItem> OrderItems { get; private set; } = new();

        public Order(Guid userId)
        {
            Id = Guid.NewGuid();
            UserId = userId;
            OrderDate = DateTime.UtcNow;
        }

        public void AddItem(Guid productId, int quantity, decimal price)
        {
            if (quantity <= 0)
                throw new Exception("Quantity must be greater than zero");

            var orderItem = new OrderItem(productId, quantity, price);

            OrderItems.Add(orderItem);

            TotalAmount += quantity * price;
        }
    }
}
