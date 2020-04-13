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
        public void Assert_Can_Apply_Special_Offer_For_A99()
        {
            Checkout.Scan(A99);
            Checkout.Scan(A99);
            Checkout.Scan(A99);
            
            Assert.AreEqual(1.3, Checkout.Total);
        }
    }
}