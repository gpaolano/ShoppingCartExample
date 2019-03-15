using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Xml.Schema;

namespace ShoppingCartExercise
{
    class Program
    {
        static void Main(string[] args)
        {
            // *****For entering list of items.  Steps 1-4 
            //Console.WriteLine("Enter items:");
            //string itemsString = Console.ReadLine();
            //if (String.IsNullOrEmpty(itemsString))
            //{
            //    Console.WriteLine("No items.");
            //    return;
            //}

            //var itemArray = itemsString.Split(',');

            //Cart cart = new Cart();
            //cart.FillCart(itemArray);

            //cart.Discounts.Add(new BOGO(cart.Products.Where(x => x.Name == "apple" || x.Name == "banana").ToList(), cart));
            //cart.Discounts.Add(new Buy3For2(cart.Products.Where(x => x.Name == "orange").ToList(), cart));

            //var totalCost = cart.CalculateTotal();
            //Console.WriteLine(string.Format("{0:#.00}", totalCost.ToString()));
            //Console.ReadLine();

            Cart cart = new Cart();
            cart.Discounts.Add(new BOGO(new List<string>{"apple", "banana"}, cart));
            cart.Discounts.Add(new Buy3For2(new List<string> { "orange" }, cart));
            cart.Discounts.Add(new Buy3For2(new List<string> { "melon" }, cart));

            while (true)
            {
                Console.WriteLine("Scan item:");
                string itemString = Console.ReadLine();
                if (string.IsNullOrEmpty(itemString))
                {
                    Console.WriteLine("No item.");
                    return;
                }
                cart.AddProduct(itemString);
                Console.WriteLine(string.Format("Subtotal:  {0:#.00}", cart.CalculateTotal()));
            }


        }

    }
}
