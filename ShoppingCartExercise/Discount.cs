using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingCartExercise
{
    public abstract class Discount
    {
        public Cart Cart;
        public abstract void ApplyDiscount();

    }
}
