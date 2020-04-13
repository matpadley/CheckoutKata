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
            Assert.DoesNotThrow(() => _checkout.Scan(new Item()));
        }
    }

    public class Item
    {
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