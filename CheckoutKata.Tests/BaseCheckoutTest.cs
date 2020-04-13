using NUnit.Framework;

namespace CheckoutKata.Tests
{
    public abstract class BaseCheckoutTest
    {
        protected Checkout Checkout;

        protected Item A99;

        protected Item B15;

        protected Item C40;
        
        [SetUp]
        public void Setup()
        {
            Checkout = new Checkout();
            A99 = new Item("A99", 0.5);
            B15 = new Item("B15", 0.3);
            C40 = new Item("C40", 0.6);
        }
    }
}