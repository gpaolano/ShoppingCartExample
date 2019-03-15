using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ShoppingCartExercise
{
    public class BOGO : Discount
    {
        public BOGO(IList<string> allowedProducts, Cart cart)
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

            //Need to separate apples from bananas to offer lower discount for Step 3.
            //TODO:  Better way to abstract and generalize this
            var appleCount = Cart.Products.Count(x => x.Name == "apple");
            var bananaCount = Cart.Products.Count(x => x.Name == "banana");

            decimal discountPrice = appleCount >= bananaCount ? .45m : .60m;

            Cart.DiscountAmount += (appleCount + bananaCount) / 2 * discountPrice;

            //Customers would save money by checking out with bananas only, then checking out with apples.  Could set up a separate discount for each product.


        }
    }
}
