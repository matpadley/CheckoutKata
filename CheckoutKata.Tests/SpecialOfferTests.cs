using System;
using System.Collections.Generic;
using System.Security.Cryptography;
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

        [TestCase("A99", 3, 1.3)]
        [TestCase("B15", 2, 0.45)]
        public void Special_Offer_Can_Be_Created(string sku, int quantity, double offerPrice)
        {
            var specialOffer = new SpecialOffer(sku, quantity, offerPrice);
            
            Assert.AreEqual(sku, specialOffer.Sku);
            
            Assert.AreEqual(quantity, specialOffer.Quantity);
            
            Assert.AreEqual(offerPrice, specialOffer.OfferPrice);
        }

        [Test]
        public void Can_Apply_Special_Offer_For_A99()
        {   
            Checkout = new Checkout(new List<SpecialOffer>() { A99SO, B15SO });
            
            Checkout.Scan(A99);
            Checkout.Scan(A99);
            Checkout.Scan(A99);
            
            Assert.AreEqual(1.3, Checkout.Total);
        }

        [TestCase("A99", 3, "A99SO", 1.3)]
        [TestCase("A99", 4, "A99SO", 1.8)]
        [TestCase("B15", 3, "A99SO", 0.9)]
        [TestCase("B15", 4, "B15SO", 0.9)]
        public void Grouped_Item_Total_Test(string sku, int quanity, string offer, double expectedAmount)
        {
            var groupedItem = new GroupedItem(GetItem(sku), quanity, GetSpecialOffer(offer));
            
            Assert.AreEqual(expectedAmount, groupedItem.TotalPrice);
        }
        
        

        public class GroupedItem
        {
            private readonly SpecialOffer _associatedSpecialOffer;
            public Item Item { get; }
            public int Count { get; }

            public GroupedItem(Item item, int count, SpecialOffer associatedSpecialOffer = null)
            {
                _associatedSpecialOffer = associatedSpecialOffer;
                
                Item = item;
                Count = count;
            }

            public double TotalPrice => _totalPrice();

            private double _totalPrice()
            {
                if (_associatedSpecialOffer == null || _associatedSpecialOffer.Sku != Item.Sku)
                    return Math.Round(Item.UnitPrice * Count, 2);
                
                var offerCount = (Count / _associatedSpecialOffer.Quantity);
                var nonOfferCount = Count - (offerCount * _associatedSpecialOffer.Quantity);

                return Math.Round(offerCount * _associatedSpecialOffer.OfferPrice,2) + Math.Round(nonOfferCount * Item.UnitPrice, 2);

            }
        }
        
    }
}