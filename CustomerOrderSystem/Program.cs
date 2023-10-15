using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerOrderSystem
{
    class Product
    {
        public int ProductId { get; }
        public string Name { get; }
        public double Price { get; }

        public Product(int productId, string name, double price)
        {
            ProductId = productId;
            Name = name;
            Price = price;
        }
    }

    class Order
    {
        public int OrderId { get; }
        public List<Product> Products { get; }
        public DateTime OrderDate { get; }

        public Order(int orderId, List<Product> products)
        {
            OrderId = orderId;
            Products = products;
            OrderDate = DateTime.Now;
        }
    }

    class Customer
    {
        public string CustomerId { get; }
        public string Name { get; }
        private List<Order> OrderHistory { get; }

        public Customer(string customerId, string name)
        {
            CustomerId = customerId;
            Name = name;
            OrderHistory = new List<Order>();
        }

        public void AddToOrderHistory(Order order)
        {
            OrderHistory.Add(order);
        }

        public void ViewOrderHistory()
        {
            Console.WriteLine($"Order history for {Name}:");
            foreach (var order in OrderHistory)
            {
                Console.WriteLine($"Order ID: {order.OrderId}, Order Date: {order.OrderDate}");
                Console.WriteLine("Products:");
                foreach (var product in order.Products)
                {
                    Console.WriteLine($"- {product.Name} (${product.Price})");
                }
                Console.WriteLine();
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Create some products
            Product product1 = new Product(1, "Product A", 10.0);
            Product product2 = new Product(2, "Product B", 15.0);
            Product product3 = new Product(3, "Product C", 5.0);

            // Create a customer
            Customer customer = new Customer("12345", "Kanika");

            // Create an order and add products to the cart
            List<Product> cartProducts = new List<Product> { product1, product2 };
            Order order1 = new Order(1, cartProducts);

            // Add the order to the customer's history
            customer.AddToOrderHistory(order1);

            // Display the customer's order history
            customer.ViewOrderHistory();

            Console.Read();
        }
    }
}