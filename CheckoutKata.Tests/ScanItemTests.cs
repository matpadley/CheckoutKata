using NUnit.Framework;

namespace CheckoutKata.Tests
{
    public class ScanItemTests: BaseCheckoutTest
    {
        [SetUp]
        public void Setup()
        {
            base.Setup();
        }
        [Test]
        public void Can_Add_Item_At_Checkout()
        {
            Assert.DoesNotThrow(() => Checkout.Scan(string.Empty));
        }

        [TestCase("A99", 0.5)]
        [TestCase("B15", 0.3)]
        [TestCase("C40", 0.6)]
        public void Item_Can_Be_Created(string sku, double unitPrice)
        {
            var item = new Item(sku, unitPrice);
            
            Assert.AreEqual(sku, item.Sku);
            
            Assert.AreEqual(unitPrice, item.UnitPrice);
        }

        [TestCase("A99")]
        [TestCase("B15")]
        [TestCase("C40")]
        public void Single_Item_Can_Be_Added_And_Total_Requested(string sku)
        {
            var item = GetItem(sku);
            
            Checkout.Scan(item.Sku);
            
            Assert.AreEqual(item.UnitPrice, Checkout.Total);
        }

        [Test]
        public void Multiple_Item_Can_Be_Added_And_Total_Requested()
        {
            Checkout.Scan("A99");
            Checkout.Scan("A99");
            Checkout.Scan("B15");
            
            Assert.AreEqual(1.3, Checkout.Total);
        }
    }
}