using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ShoppingCartExercise
{
    public class Buy3For2 : Discount
    {
        public Buy3For2(IList<string> allowedProducts, Cart cart)
        {
            Cart = cart;
            AllowedProducts = allowedProducts;
        }

        public IList<string> AllowedProducts { get; set; }

        public override void ApplyDiscount()
        {
            if (!Cart.Products.Any(x => AllowedProducts.Contains(x.Name)))
            {
                return;
            }

            var count = Cart.Products.Count(x => AllowedProducts.Contains(x.Name));

            Cart.DiscountAmount += (count / 3) * Cart.Products.Where(x=>AllowedProducts.Contains(x.Name)).First().Price;


        }
        
    }
}
