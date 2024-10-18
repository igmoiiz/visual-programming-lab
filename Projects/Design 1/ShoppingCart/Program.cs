
//Static Libraries

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

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

// Manages the shopping cart functionality
public class ShoppingCart
{
    private List<Product> _products; // List to hold products in the cart
    private const string DataFile = "cart.txt"; // File to store cart data

    // Constructor to load existing cart products from file
    public ShoppingCart()
    {
        _products = LoadCart();
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

        // Ask user if they want to apply a discount
        Console.WriteLine("Do you want to apply a discount? (yes/no)");
        string applyDiscountResponse = Console.ReadLine();

        if (applyDiscountResponse?.ToLower() == "yes")
        {
            Console.WriteLine("Enter discount amount:");
            string discountInput = Console.ReadLine();
            if (decimal.TryParse(discountInput, out decimal discount))
            {
                totalAfterTax -= discount; // Apply discount if valid
                Console.WriteLine($"Discount applied: {discount:C}");
            }
            else
            {
                Console.WriteLine("Invalid discount amount. No discount applied.");
            }
        }

        // Display final amount and ask for checkout confirmation
        Console.WriteLine($"Final amount due: {totalAfterTax:C}");
        Console.WriteLine("Are you sure you want to checkout? (yes/no)");
        string checkoutResponse = Console.ReadLine();

        if (checkoutResponse?.ToLower() == "yes")
        {
            Console.WriteLine("Enter your Buyer ID:");
            string buyerId = Console.ReadLine();
            SaveCheckoutDetails(buyerId, totalAfterTax); // Save checkout details
            ClearCart(); // Clear the cart after checkout
            Console.WriteLine("Checkout successful! Thank you for your purchase.");
        }
        else
        {
            Console.WriteLine("Checkout canceled.");
        }
    }

    // Saves checkout details to a file
    private void SaveCheckoutDetails(string buyerId, decimal totalAmount)
    {
        string checkoutFile = $"checkout_{buyerId}.txt"; // Create a file for the checkout
        using (var writer = new StreamWriter(checkoutFile))
        {
            writer.WriteLine($"Buyer ID: {buyerId}");
            writer.WriteLine($"Total Amount: {totalAmount:C}");
            writer.WriteLine($"Date: {DateTime.Now}");
            writer.WriteLine("Products Purchased:");
            foreach (var product in _products)
            {
                writer.WriteLine($"ID: {product.Id}, Name: {product.Name}, Price: {product.Price:C}, Quantity: {product.Quantity}");
            }
        }
    }

    // Clears the cart by removing all products
    private void ClearCart()
    {
        _products.Clear();
        SaveCart(); // Save an empty cart to file
    }

    // Loads existing cart products from file
    private List<Product> LoadCart()
    {
        if (!File.Exists(DataFile)) return new List<Product>();

        var lines = File.ReadAllLines(DataFile);
        var products = new List<Product>();

        foreach (var line in lines)
        {
            var parts = line.Split(',');
            if (parts.Length != 4 ||
                !int.TryParse(parts[0], out int id) ||
                string.IsNullOrWhiteSpace(parts[1]) ||
                !decimal.TryParse(parts[2], out decimal price) ||
                !int.TryParse(parts[3], out int quantity))
            {
                Console.WriteLine($"Invalid line format: {line}");
                continue;
            }

            products.Add(new Product(id, parts[1], price, quantity));
        }

        return products;
    }

    // Saves the current cart products to file
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