using System.Collections.Generic;

namespace CheckoutKata
{
    public interface ISpecialOfferService
    {
        IEnumerable<SpecialOffer> GetSpecialOffers();
    }
}