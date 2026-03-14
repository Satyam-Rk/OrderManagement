using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManagement.Domain.Entities
{
    public class Product
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; } = default!;
        public string Category { get; private set; } = default!;
        public decimal Price { get; private set; }
        public int StockQuantity { get; private set; }
        public DateTime CreatedDate { get; private set; }
        public bool IsDeleted { get; private set; }

        private Product() { } //Required for FE core //EF Core needs a parameterless constructor.

        public Product(string name, string category, decimal price, int stockQuantity)
        {
            Id = Guid.NewGuid();
            SetName(name);
            SetCategory(category);
            SetPrice(price);
            SetStock(stockQuantity);
            CreatedDate = DateTime.UtcNow;
        }

        public void SetName(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Product name cannot be empty.");

            Name = name;
        }

        public void SetCategory(string category)
        {
            if (string.IsNullOrWhiteSpace(category))
                throw new ArgumentException("Catgory cannot be empty.");

            Category = category;
        }

        public void SetPrice(decimal price)
        {
            if (price <= 0)
                throw new ArgumentException("Price must be greater than zero");

            Price = price;
        }

        public void SetStock(int quantity)
        {
            if (quantity <= 0)
                throw new ArgumentException("Stock cannot be negative.");

            StockQuantity = quantity;
        }

        public void ReduceStock(int quantity)
        {
            if (quantity <= 0)
                throw new ArgumentException("Quantity must be greater than zero.");

            if (StockQuantity < quantity)
                throw new InvalidOperationException("Insufficient stock.");

            StockQuantity -= quantity;
        }

        public void MarkAsDeleted()
        {
            IsDeleted = true;
        }
    }
}
