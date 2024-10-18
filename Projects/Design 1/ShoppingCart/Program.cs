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
}

// Manages the shopping cart functionality
public class ShoppingCart
{
    private List<Product> _products; // List to hold products in the cart
    private const string DataFile = "cart.txt"; // File to store cart data
    private System.Timers.Timer _cartExpiryTimer; // Specify the Timer explicitly

    // Constructor to load existing cart products from file
    public ShoppingCart()
    {
        _products = LoadCart();
        InitializeCartExpiryTimer(); // Initialize the cart expiry timer
    }

    // Initializes the cart expiry timer
    private void InitializeCartExpiryTimer()
    {
        _cartExpiryTimer = new System.Timers.Timer(120000); // 120 seconds or 2 Minutes
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
    public void AddProduct(Product product)
    {
        var existingProduct = _products.FirstOrDefault(p => p.Id == product.Id);
        if (existingProduct != null)
        {
            // If product already exists, increase its quantity
            existingProduct.Quantity += product.Quantity;
        }
        else
        {
            // Otherwise, add the new product to the cart
            _products.Add(product);
        }
        SaveCart(); // Save the updated cart to file
    }

    // Removes a product from the cart by ID
    public void RemoveProduct(int productId)
    {
        var product = _products.FirstOrDefault(p => p.Id == productId);
        if (product != null)
        {
            _products.Remove(product); // Remove product if found
        }
        SaveCart(); // Save the updated cart to file
    }

    // Displays the current contents of the cart
    public void ViewCart()
    {
        if (_products.Count == 0)
        {
            Console.WriteLine("Your shopping cart is empty."); // Notify if cart is empty
            return;
        }

        Console.WriteLine("Your Shopping Cart:");
        foreach (var product in _products)
        {
            // Display each product's details
            Console.WriteLine($"ID: {product.Id}, Name: {product.Name}, Price: {product.Price:C}, Quantity: {product.Quantity}");
        }
    }

    // Calculates the total amount due, including tax and discounts
    public void CalculateTotal(decimal salesTax = 0.1m)
    {
        var total = _products.Sum(p => p.Price * p.Quantity); // Calculate total product price
        Console.WriteLine($"Total amount of cart products: {total:C}");

        var salesTaxAmount = total * salesTax; // Calculate sales tax
        Console.WriteLine($"Sales tax (10%): {salesTaxAmount:C}");

        var totalAfterTax = total + salesTaxAmount; // Calculate total after tax
        Console.WriteLine($"Total amount after tax: {totalAfterTax:C}");

        // Apply a hardcoded 5% discount
        decimal discount = totalAfterTax * 0.05m; totalAfterTax -= discount;
        Console.WriteLine($"Discount (5%): {discount:C}");

        // Ask user for their name
        Console.WriteLine("Enter your name:");
        string buyerName = Console.ReadLine();

        // Create a new User object
        User buyer = new User { Id = Guid.NewGuid().ToString(), Name = buyerName };

        // Ask user for their ID input to name the checkout file
        Console.WriteLine("Enter your ID:");
        string userIdInput = Console.ReadLine();

        // Display final amount and ask user to confirm checkout
        Console.WriteLine($"Final total: {totalAfterTax:C}");
        Console.WriteLine("Do you want to checkout? (yes/no)");
        string checkoutResponse = Console.ReadLine();

        if (checkoutResponse?.ToLower() == "yes")
        {
            // Save the checkout products to a file named with the user ID
            SaveCheckoutToFile(userIdInput, buyer, totalAfterTax);

            DisposeCart(); // Dispose of the cart after checkout
            Console.WriteLine("Checkout successful. Thank you for shopping!");
        }
        else
        {
            Console.WriteLine("Checkout cancelled. Your cart remains active.");
        }
    }

    // Saves the checkout products to a file named with the user ID
    private void SaveCheckoutToFile(string userId, User buyer, decimal totalAfterTax)
    {
        string filename = $"checkout_{userId}.txt"; // Create a filename based on the user ID
        using (StreamWriter writer = new StreamWriter(filename))
        {
            writer.WriteLine($"Buyer Name: {buyer.Name}");
            writer.WriteLine($"Buyer ID: {buyer.Id}");
            writer.WriteLine("Products:");
            foreach (var product in _products)
            {
                writer.WriteLine($"ID: {product.Id}, Name: {product.Name}, Price: {product.Price:C}, Quantity: {product.Quantity}");
            }
            writer.WriteLine($"Total Bill: {totalAfterTax:C}");
            writer.WriteLine($"Time of Purchase: {DateTime.Now}"); // Include the time of purchase
        }
        Console.WriteLine($"Checkout products saved to {filename}");
    }

    // Loads the cart from a file
    private List<Product> LoadCart()
    {
        if (File.Exists(DataFile))
        {
            string[] lines = File.ReadAllLines(DataFile);
            List<Product> products = new List<Product>();
            foreach (string line in lines)
            {
                string[] parts = line.Split(',');
                if (parts.Length == 4)
                {
                    int id = int.Parse(parts[0]);
                    string name = parts[1];
                    decimal price = decimal.Parse(parts[2]);
                    int quantity = int.Parse(parts[3]);
                    products.Add(new Product(id, name, price, quantity));
                }
            }
            return products;
        }
        else
        {
            return new List<Product>();
        }
    }

    // Saves the cart to a file
    private void SaveCart()
    {
        List<string> lines = new List<string>();
        foreach (var product in _products)
        {
            lines.Add($"{product.Id},{product.Name},{product.Price},{product.Quantity}");
        }
        File.WriteAllLines(DataFile, lines);
    }
}

class Program
{
    static void Main(string[] args)
    {
        var cart = new ShoppingCart();
        bool running = true;

        while (running)
        {
            Console.WriteLine("1. Add Product\n2. Remove Product\n3. View Cart\n4. Checkout\n5. Exit\n");
            Console.WriteLine("Please Select any of the Following Options(1-5): ");
            var choice = Console.ReadLine();

            switch (choice)
            {
                //  Add a New item
                case "1":
                    Console.WriteLine("Enter Product ID:");
                    string idInput = Console.ReadLine();
                    if (!int.TryParse(idInput, out int id))
                    {
                        Console.WriteLine("Invalid ID. Please enter a valid number.");
                        break;
                    }

                    Console.WriteLine("Enter Product Name:");
                    string name = Console.ReadLine();
                    if (string.IsNullOrWhiteSpace(name))
                    {
                        Console.WriteLine("Product name cannot be empty.");
                        break;
                    }

                    Console.WriteLine("Enter Product Price:");
                    string priceInput = Console.ReadLine();
                    if (!decimal.TryParse(priceInput, out decimal price))
                    {
                        Console.WriteLine("Invalid price. Please enter a valid decimal number.");
                        break;
                    }

                    Console.WriteLine("Enter Product Quantity:");
                    string quantityInput = Console.ReadLine();
                    if (!int.TryParse(quantityInput, out int quantity))
                    {
                        Console.WriteLine("Invalid quantity. Please enter a valid number.");
                        break;
                    }

                    cart.AddProduct(new Product(id, name, price, quantity));
                    break;

                //  Remove a Product
                case "2":
                    Console.WriteLine("Enter Product ID to remove:");
                    string productIdInput = Console.ReadLine();
                    if (!int.TryParse(productIdInput, out int productId))
                    {
                        Console.WriteLine("Invalid ID. Please enter a valid number.");
                        break;
                    }
                    cart.RemoveProduct(productId);
                    break;

                //  View Your Cart
                case "3":
                    cart.ViewCart();
                    break;

                //  Checkout Froom the Cart
                case "4":
                    cart.CalculateTotal();
                    break;

                //  Exit The Program
                case "5":
                    running = false;
                    break;

                //  What if the things go Sideways? Wrong input! Exception
                default:
                    Console.WriteLine("Invalid choice. Please choose a valid option.");
                    break;
            }
        }
    }
}