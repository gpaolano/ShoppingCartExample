using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace ShoppingCartExercise.Test
{
    public class CartTest
    {

        [Fact]
        public void FillCart_ListOfStrings_ReturnCorrectCount()
        {
            List<string> items = new List<string>()
            {
                "apple",
                "apple",
                "orange",
                "apple"
            };
            Cart cart = new Cart();
            cart.FillCart(items.ToArray());
            Assert.Equal(4, cart.Products.Count);
        }

        [Fact]
        public void FillCart_InvalidProduct_ThrowArgumentException()
        {
            List<string> items = new List<string>()
            {
                "kiwi",
                "soap"
            };
            Cart cart = new Cart();
            
            Assert.Throws<ArgumentException>(()=> cart.FillCart(items.ToArray()));
        }

        [Fact]
        public void CalculateTotal_GrossTotalOfItems_ReturnsCorrectResult()
        {
            List<string> items = new List<string>()
            {
                "apple",
                "apple",
                "orange",
                "apple"
            };
            Cart cart = new Cart();
            cart.FillCart(items.ToArray());
            Assert.Equal(2m, cart.CalculateTotal(false));

        }

        [Fact]
        public void CalculateTotal_BOGODiscount_ReturnCorrectResult()
        {
            List<string> items = new List<string>()
            {
                "apple",
                "apple",
                "orange",
                "apple"
            };
            Cart cart = new Cart();
            cart.FillCart(items.ToArray());
            cart.Discounts.Add(new BOGO(new List<string>{"apple"}, cart));
            Assert.Equal(1.55m, cart.CalculateTotal());
        }

        [Fact]
        public void CalculateTotal_Buy3For2Discount_ReturnCorrectResult()
        {
            List<string> items = new List<string>()
            {
                "orange",
                "orange",
                "orange",
                "apple"
            };
            Cart cart = new Cart();
            cart.FillCart(items.ToArray());
            cart.Discounts.Add(new Buy3For2(new List<string> { "orange" }, cart));
            Assert.Equal(1.75m, cart.CalculateTotal());
        }

        [Fact]
        public void CalculateTotal_BOGODiscountWithBanana_ReturnCorrectResult()
        {
            List<string> items = new List<string>()
            {
                "apple",
                "apple",
                "banana",
                "banana"
            };
            Cart cart = new Cart();
            cart.FillCart(items.ToArray());
            cart.Discounts.Add(new BOGO(new List<string> { "apple", "banana" }, cart));
            Assert.Equal(1.20m, cart.CalculateTotal());
        }

        [Fact]
        public void CalculateTotal_Buy3For2DiscountMelonOnly_ReturnCorrectResult()
        {
            List<string> items = new List<string>()
            {
                "melon",
                "melon",
                "melon",
                "orange",
                "orange",
                "orange"
            };
            Cart cart = new Cart();
            cart.FillCart(items.ToArray());
            cart.Discounts.Add(new Buy3For2(new List<string> { "melon" }, cart));
            Assert.Equal(3.95m, cart.CalculateTotal());
        }

        [Fact]
        public void AddProduct_InvalidProduct_ThrowArgumentException()
        {
           Cart cart = new Cart();

            Assert.Throws<ArgumentException>(() => cart.AddProduct("kiwi"));
        }
    }
}
