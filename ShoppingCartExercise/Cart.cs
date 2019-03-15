using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ShoppingCartExercise
{
    public class Cart
    {
        public List<Product> Products;
        public List<Discount> Discounts;
        public decimal DiscountAmount;

        public Cart()
        {
            Products = new List<Product>();
            Discounts = new List<Discount>();
        }

        //For Step 1.  Base calculate total
        //For Step 2.  Added ability to apply discounts
        public decimal CalculateTotal(bool applyDiscount = true)
        {
            var total = Products.Sum(x => x.Price);
            if (applyDiscount)
            {
                foreach (var discount in Discounts)
                {
                    discount.ApplyDiscount();
                }
            }

            total = total - DiscountAmount;
            DiscountAmount = 0;
            return total;
        }

        //Fill the cart with an array of item names
        public void FillCart(string[] itemArray)
        {
            foreach (string item in itemArray)
            {
                switch (item.Trim().ToLower())
                {
                    case "apple":
                        this.Products.Add(new Product("apple", .45m));
                        break;
                    case "orange":
                        this.Products.Add(new Product("orange", .65m));
                        break;
                    case "banana":
                        this.Products.Add(new Product("banana", .60m));
                        break;
                    case "melon":
                        this.Products.Add(new Product("melon", 1m));
                        break;
                    default:
                        throw new ArgumentException("Not a valid product name!");

                }
            }
        }

        //For Step 5, add one item at a time to the cart
        public void AddProduct(string item)
        {
            switch (item.Trim().ToLower())
            {
                case "apple":
                    this.Products.Add(new Product("apple", .45m));
                    break;
                case "orange":
                    this.Products.Add(new Product("orange", .65m));
                    break;
                case "banana":
                    this.Products.Add(new Product("banana", .60m));
                    break;
                case "melon":
                    this.Products.Add(new Product("melon", 1m));
                    break;
                default:
                    throw new ArgumentException("Not a valid product name!");

            }
        }
    }
}
