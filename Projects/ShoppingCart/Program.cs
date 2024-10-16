using System;
using System.Collections.Generic;
using System.IO;

namespace ShoppingCart
{
    class Program
    {
        static List<Item> cart = new List<Item>();
        static string cartFileName = "cart.txt";

        static void Main(string[] args)
        {
            LoadCart();

            while (true)
            {
                Console.WriteLine("1. Add item");
                Console.WriteLine("2. Remove item");
                Console.WriteLine("3. View cart");
                Console.WriteLine("4. Checkout");
                Console.WriteLine("5. Exit");

                Console.Write("Enter your choice: ");
                int choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        AddItem();
                        break;
                    case 2:
                        RemoveItem();
                        break;
                    case 3:
                        ViewCart();
                        break;
                    case 4:
                        Checkout();
                        break;
                    case 5:
                        SaveCart();
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
        }

        static void AddItem()
        {
            Console.Write("Enter item name: ");
            string name = Console.ReadLine();
            Console.Write("Enter item price: ");
            double price = double.Parse(Console.ReadLine());
            Console.Write("Enter item quantity: ");
            int quantity = int.Parse(Console.ReadLine());

            cart.Add(new Item(name, price, quantity));
            Console.WriteLine("Item added to cart.");
        }

        static void RemoveItem()
        {
            Console.Write("Enter item name to remove: ");
            string name = Console.ReadLine();

            Item itemToRemove = cart.Find(i => i.Name == name);
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

        static void ViewCart()
        {
            Console.WriteLine("Your shopping cart:");
            foreach (Item item in cart)
            {
                Console.WriteLine($"{item.Name} - {item.Price} - {item.Quantity}");
            }
        }

        static void Checkout()
        {
            double total = 0;
            foreach (Item item in cart)
            {
                total += item.Price * item.Quantity;
            }

            Console.WriteLine("Total: $" + total);

            Console.WriteLine("Checkout complete.");
            cart.Clear();
        }

        static void SaveCart()
        {
            using (StreamWriter writer = new StreamWriter(cartFileName))
            {
                foreach (Item item in cart)
                {
                    writer.WriteLine($"{item.Name},${item.Price},{item.Quantity}");
                }
            }
        }

        static void LoadCart()
        {
            if (File.Exists(cartFileName))
            {
                using (StreamReader reader = new StreamReader(cartFileName))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        string[] parts = line.Split(',');
                        cart.Add(new Item(parts[0], double.Parse(parts[1]), int.Parse(parts[2])));
                    }
                }
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