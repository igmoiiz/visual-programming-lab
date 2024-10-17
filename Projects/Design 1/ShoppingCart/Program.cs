using System;
using System.Collections.Generic;
using System.IO;

namespace ShoppingCart
{
    class Program
    {
        static void Main(string[] args)
        {
            ShoppingCart shoppingCart = new ShoppingCart(@"D:\Programming\Visual Programming\Projects\Design 1\ShoppingCart\shoppingCart.txt");
            shoppingCart.LoadCart();

            while (true)
            {
                shoppingCart.DisplayMenu();

                Console.Write("Enter your choice: ");
                if (int.TryParse(Console.ReadLine(), out int choice))
                {
                    switch (choice)
                    {
                        case 1:
                            shoppingCart.AddItem();
                            break;
                        case 2:
                            shoppingCart.RemoveItem();
                            break;
                        case 3:
                            shoppingCart.ViewCart();
                            break;
                        case 4:
                            shoppingCart.Checkout();
                            break;
                        case 5:
                            shoppingCart.SaveCart();
                            Environment.Exit(0);
                            break;
                        default:
                            Console.WriteLine("Invalid choice. Please try again.");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a number.");
                }
            }
        }
    }

    class ShoppingCart
    {
        private List<Item> cart;
        private string cartFileName;

        public ShoppingCart(string fileName)
        {
            cart = new List<Item>();
            cartFileName = fileName;
        }

        public void DisplayMenu()
        {
            Console.WriteLine("\nShopping Cart Menu:");
            Console.WriteLine("1. Add item");
            Console.WriteLine("2. Remove item");
            Console.WriteLine("3. View cart");
            Console.WriteLine("4. Checkout");
            Console.WriteLine("5. Exit");
        }

        public void AddItem()
        {
            Console.Write("Enter item name: ");
            string name = Console.ReadLine();
            Console.Write("Enter item price: ");
            if (double.TryParse(Console.ReadLine(), out double price) && price >= 0)
            {
                Console.Write("Enter item quantity: ");
                if (int.TryParse(Console.ReadLine(), out int quantity) && quantity > 0)
                {
                    cart.Add(new Item(name, price, quantity));
                    Console.WriteLine("Item added to cart.");
                }
                else
                {
                    Console.WriteLine("Invalid quantity. Please enter a positive integer.");
                }
            }
            else
            {
                Console.WriteLine("Invalid price. Please enter a valid number.");
            }
        }

        public void RemoveItem()
        {
            Console.Write("Enter item name to remove: ");
            string name = Console.ReadLine();

            Item itemToRemove = cart.Find(i => i.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
            if (itemToRemove != null)
            {
                cart.Remove(itemToRemove);
                Console.WriteLine("Item removed from cart.");
            }
            else
            {
                Console.WriteLine("Item not found in cart.");
            }
        }

        public void ViewCart()
        {
            Console.WriteLine("Your shopping cart:");
            if (cart.Count == 0)
            {
                Console.WriteLine("Your cart is empty.");
                return;
            }

            foreach (Item item in cart)
            {
                Console.WriteLine($"{item.Name} - ${item.Price:F2} - Quantity: {item.Quantity}");
            }
        }

        public void Checkout()
        {
            double total = 0;
            foreach (Item item in cart)
            {
                total += item.Price * item.Quantity;
            }

            Console.WriteLine($"Total: ${total:F2}");
            Console.WriteLine("Checkout complete.");
            cart.Clear();
        }

        public void SaveCart()
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(cartFileName))
                {
                    foreach (Item item in cart)
                    {
                        // Removed the space before the dollar sign
                        writer.WriteLine($"{item.Name},{item.Price},{item.Quantity}");
                    }
                }
                Console.WriteLine("Cart saved successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error saving cart: " + ex.Message);
            }
        }

        public void LoadCart()
        {
            if (File.Exists(cartFileName))
            {
                try
                {
                    using (StreamReader reader = new StreamReader(cartFileName))
                    {
                        string line;
                        while ((line = reader.ReadLine()) != null)
                        {
                            string[] parts = line.Split(',');
                            if (parts.Length == 3 &&
                                double.TryParse(parts[1], out double price) &&
                                int.TryParse(parts[2], out int quantity))
                            {
                                cart.Add(new Item(parts[0], price, quantity));
                            }
                            else
                            {
                                Console.WriteLine($"Error parsing line: {line}");
                            }
                        }
                    }
                    Console.WriteLine("Cart loaded successfully.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error loading cart: " + ex.Message);
                }
            }
            else
            {
                Console.WriteLine("Cart file not found.");
            }
        }
    }

    class Item
    {
        public string Name { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }

        public Item(string name, double price, int quantity)
        {
            Name = name;
            Price = price;
            Quantity = quantity;
        }
    }
}