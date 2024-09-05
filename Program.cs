using System;
using System.Collections.Generic;
using System.Linq;

namespace CoffeeShopApp
{
    public class MenuItem
    {
        public string Name { get; set; }
        public decimal Price { get; set; }

        public MenuItem(string name, decimal price)
        {
            Name = name;
            Price = price;
        }

        public override string ToString()
        {
            return $"{Name} - ${Price:F2}";
        }
    }

    public class CoffeeShop
    {
        private List<MenuItem> menu = new List<MenuItem>();
        private List<MenuItem> order = new List<MenuItem>();

        public void AddMenuItem(string name, decimal price)
        {
            menu.Add(new MenuItem(name, price));
            Console.WriteLine("Item added successfully!");
        }

        public void ViewMenu()
        {
            Console.WriteLine("Menu:");
            for (int i = 0; i < menu.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {menu[i]}");
            }
        }

        public void PlaceOrder(int itemIndex)
        {
            if (itemIndex >= 1 && itemIndex <= menu.Count)
            {
                order.Add(menu[itemIndex - 1]);
                Console.WriteLine("Item added to order!");
            }
            else
            {
                Console.WriteLine("Invalid item number.");
            }
        }

        public void ViewOrder()
        {
            Console.WriteLine("Your Order:");
            foreach (var item in order)
            {
                Console.WriteLine(item);
            }
        }

        public void CalculateTotal()
        {
            decimal total = order.Sum(item => item.Price);
            Console.WriteLine($"Total Amount Payable: ${total:F2}");
        }
    }

    public static class Program
    {
        public static void Main()
        {
            CoffeeShop shop = new CoffeeShop();
            bool exit = false;

            while (!exit)
            {
                Console.WriteLine("\n1. Add Menu Item\n2. View Menu\n3. Place Order\n4. View Order\n5. Calculate Total\n6. Exit");
                Console.Write("Select an option: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        Console.Write("Enter item name: ");
                        string name = Console.ReadLine();
                        Console.Write("Enter item price: ");
                        if (decimal.TryParse(Console.ReadLine(), out decimal price) && price > 0)
                        {
                            shop.AddMenuItem(name, price);
                        }
                        else
                        {
                            Console.WriteLine("Invalid price!");
                        }
                        break;

                    case "2":
                        shop.ViewMenu();
                        break;

                    case "3":
                        shop.ViewMenu();
                        Console.Write("Select item number to order: ");
                        if (int.TryParse(Console.ReadLine(), out int itemIndex))
                        {
                            shop.PlaceOrder(itemIndex);
                        }
                        else
                        {
                            Console.WriteLine("Invalid input.");
                        }
                        break;

                    case "4":
                        shop.ViewOrder();
                        break;

                    case "5":
                        shop.CalculateTotal();
                        break;

                    case "6":
                        Console.WriteLine("Thank you, come again!");
                        exit = true;
                        break;

                    default:
                        Console.WriteLine("Invalid choice. Try again.");
                        break;
                }
            }
        }
    }
}
