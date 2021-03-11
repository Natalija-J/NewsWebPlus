using System;
using Day3_Classes;

namespace ShopConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            ShopManager shop = new ShopManager();
            Console.WriteLine("Items available:");
            foreach (var item in shop.GetAvailableItems())
            {
                Console.WriteLine("{0}: EUR {1}", item.Name, item.Price);
            }


            //begin the shopping process
            while (true)
            {
                Console.WriteLine("Enter item's name: ");
                string input = Console.ReadLine();

                if (input == "0")
                {
                    break;
                }

                var itemsAdded = shop.AddToBasket(input);
                if (itemsAdded == null)
                {
                    Console.WriteLine("Item is not available!");
                }
                else
                {
                    Console.WriteLine("Item {0} added!", itemsAdded.Name);
                }
            }

            Console.WriteLine("Total price: EUR {0}", shop.CheckOut());
            Console.WriteLine("Your purchase:");
            foreach (var product in shop.Pay())
            {
                Console.WriteLine("{0}: EUR {1}", product.Name, product.Price);
            }

        }
    }
}
