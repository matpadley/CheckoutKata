using System.Collections.Generic;
using System.Linq;

namespace CheckoutKata
{
    public class Checkout
    {
        private readonly IEnumerable<SpecialOffer> _specialOffers;

        public Checkout(ISpecialOfferService specialOfferService)
        {
            _specialOffers = specialOfferService.GetSpecialOffers();
            _items = new List<Item>();
        }
        
        private readonly ICollection<Item> _items;

        public double Total => _total();

        public void Scan(Item item)
        {
            _items.Add(item);
        }

        private double _total()
        {
            return _items.GroupBy(
               item => item,
                (key, items) => new GroupedItem(key, items.Count(), _specialOffers.FirstOrDefault(so => so.Sku == key.Sku))
            ).Sum(items => items.TotalPrice);
        }
    }

    public interface ISpecialOfferService
    {
        IEnumerable<SpecialOffer> GetSpecialOffers();
    }
} 