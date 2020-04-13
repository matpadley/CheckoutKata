using Microsoft.VisualStudio.TestPlatform.Common.Utilities;
using NUnit.Framework;

namespace CheckoutKata.Tests
{
    public class SpecialOfferTests: BaseCheckoutTest
    {
        [SetUp]
        public void Setup()
        {
            base.Setup();
        }

        [Test]
        public void Can_Apply_Special_Offer_For_A99()
        {   
            Checkout.Scan(A99);
            Checkout.Scan(A99);
            Checkout.Scan(A99);
            
            Assert.AreEqual(1.3, Checkout.Total);
        }

        [TestCase("A99", 3, 1.3)]
        [TestCase("B15", 2, 0.45)]
        public void Special_Offer_Can_Be_Created(string sku, int quantity, double offerPrice)
        {
            var specialOffer = new SpecialOffer(sku, quantity, offerPrice);
        }
        
    }

    public class SpecialOffer
    {
        public SpecialOffer(string sku, in int quantity, in double offerPrice)
        {
            throw new System.NotImplementedException();
        }
    }
}