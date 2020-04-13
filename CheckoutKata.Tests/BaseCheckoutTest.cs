using System;
using System.Data;
using NUnit.Framework;

namespace CheckoutKata.Tests
{
    public abstract class BaseCheckoutTest
    {
        protected Checkout Checkout;

        protected static Item A99;

        protected Item B15;

        protected Item C40;

        protected SpecialOffer A99SO;
        protected SpecialOffer B15SO;

        
        [SetUp]
        public void Setup()
        {
            Checkout = new Checkout();
            
            A99 = new Item("A99", 0.5);
            B15 = new Item("B15", 0.3);
            C40 = new Item("C40", 0.6);
            
            A99SO = new SpecialOffer("A99", 3, 1.3);
            B15SO = new SpecialOffer("B15", 2, 0.4);
        }

        protected Item GetItem(string sku)
        {
            return sku.ToUpper() switch
            {
                "A99" => A99,
                "B15" => B15,
                "C40" => C40,
                _ => throw new NotSupportedException()
            };
        }
    }
}