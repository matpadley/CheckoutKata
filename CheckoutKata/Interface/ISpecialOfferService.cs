using System.Collections.Generic;
using CheckoutKata.Model;

namespace CheckoutKata.Interface
{
    public interface ISpecialOfferService
    {
        IEnumerable<SpecialOffer> GetSpecialOffers();
    }
}