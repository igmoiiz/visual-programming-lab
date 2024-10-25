// Static Libraries
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Timers;

// Represents a product with its details
public class Product
{
    public int Id { get; set; } // Product ID
    public string Name { get; set; } // Product name
    public decimal Price { get; set; } // Product price
    public int Quantity { get; set; } // Quantity of the product

    // Constructor to initialize a new product
    public Product(int id, string name, decimal price, int quantity = 1)
    {
        Id = id;
        Name = name;
        Price = price;
        Quantity = quantity;
    }
}

// Represents a user with their details
public class User
{
    public string Id { get; set; } // User ID
    public string Name { get; set; } // User name
    public string ContactNumber { get; set; } // User contact number
}

// Manages the shopping cart functionality
public class ShoppingCart
{
    private List<Product> _products; // List to hold products in the cart
    private const string DataFile = "cart.txt"; // File to store cart data
    private System.Timers.Timer _cartExpiryTimer; // Specify the Timer explicitly

    // Hardcoded list of available products
    public static List<Product> AvailableProducts = new List<Product>
    {
        new Product(1, "Milk", 150),
        new Product(2, "Eggs", 200),
        new Product(3, "Bread", 100),
        new Product(4, "Rice", 150),
        new Product(5, "Pasta", 120),
        new Product(6, "Cereal", 250),
        new Product(7, "Meat", 800),
        new Product(8, "Fish", 600),
        new Product(9, "Cheese", 300),
        new Product(10, "Butter", 250),
        new Product(11, "Yogurt", 100),
        new Product(12, "Coffee", 500),
        new Product(13, "Tea", 200),
        new Product(14, "Sugar", 100),
        new Product(15, "Salt", 50),
        new Product(16, "Oil", 300),
        new Product(17, "Spices", 150),
        new Product(18, "Biscuits", 100),
        new Product(19, "Noodles", 80),
        new Product(20, "Soda", 120)
    };

    // Constructor to load existing cart products from file
    public ShoppingCart()
    {
        _products = LoadCart();
        InitializeCartExpiryTimer(); // Initialize the cart expiry timer
    }

    // Initializes the cart expiry timer
    private void InitializeCartExpiryTimer()
    {
        _cartExpiryTimer = new System.Timers.Timer(160000); // 160 seconds or 2 Minutes and 40 Seconds
        _cartExpiryTimer.Elapsed += CartExpiryTimer_Elapsed;
        _cartExpiryTimer.AutoReset = false; // Stop the timer after it elapses
        _cartExpiryTimer.Start();
    }

    // Event handler for the cart expiry timer
    private void CartExpiryTimer_Elapsed(object sender, ElapsedEventArgs e)
    {
        DisposeCart(); // Dispose of the cart when the timer expires
    }

    // Disposes of the cart by clearing its contents
    private void DisposeCart()
    {
        _products.Clear();
        SaveCart(); // Save an empty cart to file
        Console.WriteLine("Cart has expired and been disposed.");
    }

    // Adds a product to the cart
    public void AddProduct(int productId, int quantity)
    {
        var product = AvailableProducts.FirstOrDefault(p => p.Id == productId);
        if (product != null)
        {
            var existingProduct = _products.FirstOrDefault(p => p.Id == product.Id);
            if (existingProduct != null)
            {
                // If product already exists, increase its quantity
                existingProduct.Quantity += quantity;
            }
            else
            {
                // Otherwise, add the new product to the cart
                _products.Add(new Product(product.Id, product.Name, product.Price, quantity));
            }
            SaveCart(); // Save the updated cart to file
        }
        else
        {
            Console.WriteLine("Invalid product selection.");
        }
    }

    // Removes a product from the cart by ID
    public void RemoveProduct(int productId)
    {
        var product = _products.First(p => p.Id == productId);
        if (product != null)
        {
            _products.Remove(product);
            SaveCart(); // Save the updated cart to file
        }
        else
        {
            Console.WriteLine("Product not found in cart.");
        }
    }

    // Displays the cart contents
    public void ViewCart()
    {
        Console.WriteLine("Your Cart:");
        if (_products.Count == 0)
        {
            Console.WriteLine("Your cart is empty.");
        }
        else
        {
            foreach (var product in _products)
            {
                Console.WriteLine($"ID: {product.Id}, Name: {product.Name}, Price: {product.Price}, Quantity: {product.Quantity}");
            }
        }
    }

    // Saves the cart to a file
    private void SaveCart()
    {
        using (var writer = new StreamWriter(DataFile))
        {
            foreach (var product in _products)
            {
                writer.WriteLine($"{product.Id},{product.Name},{product.Price},{product.Quantity}");
            }
        }
    }

    // Loads the cart from a file
    private List<Product> LoadCart()
    {
        var products = new List<Product>();
        if (File.Exists(DataFile))
        {
            using (var reader = new StreamReader(DataFile))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    var parts = line.Split(',');
                    products.Add(new Product(int.Parse(parts[0]), parts[1], decimal.Parse(parts[2]), int.Parse(parts[3])));
                }
            }
        }
        return products;
    }

    // Simulates a checkout process
    public void Checkout()
    {
        decimal total = 0;
        foreach (var product in _products)
        {
            total += product.Price * product.Quantity;
        }

        // Calculate sales tax
        decimal salesTax = total * 0.18m; // 18% sales tax
        decimal totalAfterTax = total + salesTax;

        // Apply discount
        decimal discount = totalAfterTax * 0.05m; // 5% discount
        decimal finalTotal = totalAfterTax - discount;

        // Display calculations
        Console.WriteLine($"Subtotal: {total:C}");
        Console.WriteLine($"Sales Tax (18%): {salesTax:C}");
        Console.WriteLine($"Total after Tax: {totalAfterTax:C}");
        Console.WriteLine($"Discount (5%): -{discount:C}");
        Console.WriteLine($"Final Total: {finalTotal:C}");

        // Confirm checkout
        Console.Write("Are you sure you want to checkout? (yes/no): ");
        string confirmation = Console.ReadLine()?.Trim().ToLower();

        if (confirmation == "yes")
        {
            Console.Write("Enter your name: ");
            string userName = Console.ReadLine();
            Console.Write("Enter your contact number: ");
            string userContactNumber = Console.ReadLine();
            Console.Write("Enter a unique ID for your checkout: ");
            string checkoutId = Console.ReadLine();

            using (var writer = new StreamWriter($"checkout_{checkoutId}.txt"))
            {
                writer.WriteLine($"Customer Name: {userName}");
                writer.WriteLine($"Customer Contact Number: {userContactNumber}");
                writer.WriteLine($"Date and Time of Purchase: {DateTime.Now}");
                writer.WriteLine("Products Purchased:");
                foreach (var product in _products)
                {
                    writer.WriteLine($"ID: {product.Id}, Name: {product.Name}, Price: {product.Price}, Quantity: {product.Quantity}");
                }
                writer.WriteLine($"Final Total: {finalTotal:C}");
            }
            Console.WriteLine("Checkout Successful!\n");
            DisposeCart(); // Dispose of the cart after checkout
        }
        else
        {
            Console.WriteLine("Checkout canceled. Returning to main menu.");
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
            Console.Clear();
        }
    }

    // Exits the shopping cart application
    public void Exit()
    {
        DisposeCart(); // Dispose of the cart before exiting
        Environment.Exit(0);
    }
}

// Main program entry point
class Program
{
    static void Main(string[] args)
    {
        var cart = new ShoppingCart();
        while (true)
        {
            Console.Clear();
            Console.WriteLine("Shopping Cart Menu:");
            Console.WriteLine("1. Add Product");
            Console.WriteLine("2. View Cart");
            Console.WriteLine("3. Remove Product");
            Console.WriteLine("4. Checkout");
            Console.WriteLine("5. Exit");
            Console.Write("Enter your choice: ");
            if (int.TryParse(Console.ReadLine(), out int choice))
            {
                switch (choice)
                {
                    case 1:
                        Console.WriteLine("Select a product:");
                        for (int i = 0; i < ShoppingCart.AvailableProducts.Count; i++)
                        {
                            Console.WriteLine($"{i + 1}. {ShoppingCart.AvailableProducts[i].Name}");
                        }
                        Console.Write("Enter the product number: ");
                        if (int.TryParse(Console.ReadLine(), out int productId))
                        {
                            productId -= 1;
                            Console.Write("Enter the quantity: ");
                            if (int.TryParse(Console.ReadLine(), out int quantity))
                            {
                                cart.AddProduct(ShoppingCart.AvailableProducts[productId].Id, quantity);
                            }
                            else
                            {
                                Console.WriteLine("Invalid quantity. Please try again.");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Invalid product selection. Please try again.");
                        }
                        Console.WriteLine("Press any key to continue...");
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    case 2:
                        cart.ViewCart();
                        Console.WriteLine("Press any key to continue...");
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    case 3:
                        Console.Write("Enter the product ID to remove: ");
                        if (int.TryParse(Console.ReadLine(), out int removeProductId))
                        {
                            cart.RemoveProduct(removeProductId);
                        }
                        else
                        {
                            Console.WriteLine("Invalid product ID. Please try again.");
                        }
                        Console.WriteLine("Press any key to continue...");
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    case 4:
                        cart.Checkout();
                        Console.WriteLine("Press any key to continue...");
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    case 5:
                        cart.Exit();
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        Console.WriteLine("Press any key to continue...");
                        Console.ReadKey();
                        Console.Clear();
                        break;
                }
            }
            else
            {
                Console.WriteLine("Invalid choice. Please try again.");
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
                Console.Clear();
            }
        }
    }
}