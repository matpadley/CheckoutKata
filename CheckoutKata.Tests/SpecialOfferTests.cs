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
            SpecialOfferService.Setup(g => g.GetSpecialOffers()).Returns(
                new List<SpecialOffer>() { GetSpecialOffer("A99SO"), GetSpecialOffer("B15SO") });
            
            Checkout = new Checkout(SpecialOfferService.Object);
            
            Checkout.Scan(A99);
            Checkout.Scan(A99);
            Checkout.Scan(A99);
            
            Assert.AreEqual(1.3, Checkout.Total);
        }

        [TestCase("A99", 3, "A99SO", 1.3)]
        [TestCase("A99", 4, "A99SO", 1.8)]
        [TestCase("B15", 3, "A99SO", 0.9)]
        [TestCase("B15", 4, "B15SO", 0.9)]
        public void Grouped_Item_Total_Test(string sku, int quantity, string offer, double expectedAmount)
        {
            var groupedItem = new GroupedItem(GetItem(sku), quantity, GetSpecialOffer(offer));
            
            Assert.AreEqual(expectedAmount, groupedItem.TotalPrice);
        }

        [Test]
        public void Mixed_Item_Total_With_Special_Offers()
        {    
            SpecialOfferService.Setup(g => g.GetSpecialOffers()).Returns(
                new List<SpecialOffer>(){ GetSpecialOffer("A99SO"), GetSpecialOffer("B15SO") });
            
            var checkout = new Checkout(SpecialOfferService.Object);
            
            // Total 2.6
            checkout.Scan(GetItem("A99"));
            checkout.Scan(GetItem("A99"));
            checkout.Scan(GetItem("A99"));
            checkout.Scan(GetItem("A99"));
            checkout.Scan(GetItem("A99"));
            checkout.Scan(GetItem("A99"));
            
            // Total 0.75
            checkout.Scan(GetItem("B15"));
            checkout.Scan(GetItem("B15"));
            checkout.Scan(GetItem("B15"));
            
            // Total 0.6
            checkout.Scan(GetItem("C40"));
            
            Assert.AreEqual(3.95, checkout.Total);
        }

        [Test]
        public void Mixed_Item_Total_With_Single_Special_Offer()
        {    
            SpecialOfferService.Setup(g => g.GetSpecialOffers()).Returns(
                new List<SpecialOffer>(){ GetSpecialOffer("B15SO") });
            
            var checkout = new Checkout(SpecialOfferService.Object);
            
            // Total 3
            checkout.Scan(GetItem("A99"));
            checkout.Scan(GetItem("A99"));
            checkout.Scan(GetItem("A99"));
            checkout.Scan(GetItem("A99"));
            checkout.Scan(GetItem("A99"));
            checkout.Scan(GetItem("A99"));
            
            // Total 0.75
            checkout.Scan(GetItem("B15"));
            checkout.Scan(GetItem("B15"));
            checkout.Scan(GetItem("B15"));
            
            // Total 0.6
            checkout.Scan(GetItem("C40"));
            
            Assert.AreEqual(3.95, checkout.Total);
        }
    }
}