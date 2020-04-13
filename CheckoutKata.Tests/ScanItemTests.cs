using System.Collections.Generic;
using NUnit.Framework;

namespace CheckoutKata.Tests
{
    public class ScanItemTests
    {
        private Checkout _checkout;
        
        [SetUp]
        public void Setup()
        {
            _checkout = new Checkout();
        }
        [Test]
        public void Assert_Can_Add_Item_At_Checkout()
        {
            Assert.DoesNotThrow(() => _checkout.Scan(new Item(string.Empty, 0)));
        }

        [TestCase("A99", 0.5)]
        [TestCase("B15", 0.3)]
        [TestCase("C40", 0.6)]
        public void Assert_Item_Can_Be_Created(string sku, double unitPrice)
        {
            var item = new Item(sku, unitPrice);
            
            Assert.AreEqual(sku, item.Sku);
            
            Assert.AreEqual(unitPrice, item.UnitPrice);
        }
    }

    public class Item
    {
        public string Sku { get; }
        public double UnitPrice { get; }

        public Item(string sku, double unitPrice)
        {
            Sku = sku;
            UnitPrice = unitPrice;
        }
    }

    internal class Checkout
    {
        public Checkout()
        {
            _items = new List<Item>();
        }
        
        private readonly ICollection<Item> _items;
        
        public void Scan(Item item)
        {
            _items.Add(item);
        }
    }
}