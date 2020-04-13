using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace CheckoutKata.Tests
{
    public class ScanItemTests
    {
        private Checkout _checkout;

        private Item _a99;

        private Item _b15;

        private Item _c40;
        
        [SetUp]
        public void Setup()
        {
            _checkout = new Checkout();
            _a99 = new Item("A99", 0.5);
            _b15 = new Item("B15", 0.3);
            _c40 = new Item("C40", 0.6);
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

        [Test]
        public void Assert_Single_Item_Can_Be_Added_And_Total_Requested()
        {
            _checkout.Scan(_a99);
            
            Assert.AreEqual(0.5, _checkout.Total);
        }

        [Test]
        public void Assert_Multiple_Item_Can_Be_Added_And_Total_Requested()
        {
            _checkout.Scan(_a99);
            _checkout.Scan(_a99);
            _checkout.Scan(_b15);
            
            Assert.AreEqual(0.5, _checkout.Total);
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

        public double Total => _items.Sum(item => item.UnitPrice);

        public void Scan(Item item)
        {
            _items.Add(item);
        }
    }
}