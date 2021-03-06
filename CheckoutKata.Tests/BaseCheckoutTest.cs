using System;
using CheckoutKata.Interface;
using CheckoutKata.Model;
using Moq;
using NUnit.Framework;

namespace CheckoutKata.Tests
{
    public abstract class BaseCheckoutTest
    {
        protected Checkout Checkout;

        protected Mock<ISpecialOfferService> SpecialOfferService;

        protected Mock<IItemService> ItemService;

        protected static Item A99;

        protected Item B15;

        protected Item C40;

        protected SpecialOffer A99SO;
        protected SpecialOffer B15SO;

        
        [SetUp]
        public void Setup()
        {
            A99 = new Item("A99", 0.5);
            B15 = new Item("B15", 0.3);
            C40 = new Item("C40", 0.6);
            
            A99SO = new SpecialOffer("A99", 3, 1.3);
            B15SO = new SpecialOffer("B15", 2, 0.45);
            
            SpecialOfferService = new Mock<ISpecialOfferService>();
            
            ItemService = new Mock<IItemService>();
            ItemService.Setup(g => g.GetItem("A99")).Returns(A99);
            ItemService.Setup(g => g.GetItem("B15")).Returns(B15);
            ItemService.Setup(g => g.GetItem("C40")).Returns(C40);
            
            Checkout = new Checkout(SpecialOfferService.Object, ItemService.Object);
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

        protected SpecialOffer GetSpecialOffer(string offerCode)
        {
            return offerCode.ToUpper() switch
            {
                "A99SO" => A99SO,
                "B15SO" => B15SO,
                _ => throw new NotSupportedException()
            };
        }
    }
}