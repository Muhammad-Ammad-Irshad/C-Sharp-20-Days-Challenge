using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day_9
{
    internal class E_Commerce_Cart
    {
        class Product
        {
            public int Id { get; }
            public string Name { get; }
            public double Price { get; }
            public Product(int id, string name, double price)
            {
                Id = id;
                Name = name;
                Price = price;
            }
            public void Display()
            {
                Console.WriteLine($"ID: {Id} | {Name} - ${Price}");
            }
        }
        class Cart
        {
            private List<Product> products = new List<Product>();
            public void AddProduct(Product product)
            {
                products.Add(product);
                Console.WriteLine($"{product.Name} added to the cart.");
            }
            public void RemoveProduct(int id)
            {
                Product productToRemove = products.Find(p => p.Id == id);
                if(productToRemove != null)
                {
                    products.Remove(productToRemove);
                    Console.WriteLine($"{productToRemove} removed from cart.");
                }
                else
                {
                    Console.WriteLine("Product not found in cart.");
                }
            }
            public void ViewCart()
            {
                Console.WriteLine("\nCart Contents:");
                if(products.Count == 0)
                {
                    Console.WriteLine("Your cart is empty.");
                    return;
                }

                foreach (var product in products)
                {
                    product.Display();
                }
                Console.WriteLine($"Total: Rs{GetTotal():0.00}");
            }
            public double GetTotal()
            {
                double total = 0;
                foreach(var product in products)
                    total += product.Price;

                return total;
            }
        }
        class User
        {
            public string Name { get; }
            public Cart UserCart { get; }
            public User(string name)
            {
                Name = name;
                UserCart = new Cart();
            }
        }
        static void Main(string[] args)
        {
            List<Product> storeProducts = new List<Product>
            {
                new Product(1, "Laptop", 90000),
                new Product(2, "HeadPhones", 2000),
                new Product(3, "glasses", 2000),
                new Product(4, "Shoes", 10000)
            };

            Console.WriteLine("Enter your name: ");
            string userName = Console.ReadLine();
            User user = new User(userName);
            int choice;
            do
            {
                Console.Clear();
                Console.WriteLine("\n---E-Commerce Menu---");
                Console.WriteLine("1. View Products");
                Console.WriteLine("2. Add Product to Cart");
                Console.WriteLine("3. Remove Product from Cart");
                Console.WriteLine("4. View Cart");
                Console.WriteLine("5. Exit");
                Console.Write("Enter your choice: ");
                int.TryParse(Console.ReadLine(), out choice);

                switch (choice)
                {
                    case 1:
                        Console.Clear();
                        Console.WriteLine("\n Available Products:");
                        foreach (var p in storeProducts)
                            p.Display();
                        Console.ReadKey();
                        break;
                    case 2:
                        Console.Clear();
                        Console.Write("Enter Product Id to Add: ");
                        int addId = int.Parse(Console.ReadLine());
                        Product productToAdd = storeProducts.Find(p => p.Id == addId);
                        if (productToAdd != null)
                            user.UserCart.AddProduct(productToAdd);
                        else
                            Console.WriteLine("Invalid Product ID.");
                        break;
                    case 3:
                        Console.Clear();
                        Console.Write("Enter Product ID to remove: ");
                        int removeId = int.Parse(Console.ReadLine());
                        user.UserCart.RemoveProduct(removeId);
                        break;
                    case 4:Console.Clear();
                        user.UserCart.ViewCart();
                        Console.ReadKey();
                        break;
                    case 5: 
                        Console.WriteLine("Thank you for shopping. Goodbye!");
                        break;
                    default:
                        Console.WriteLine("Invalid choice.");
                        break;
                }
            } while (choice != 5);
        }
    }
}
