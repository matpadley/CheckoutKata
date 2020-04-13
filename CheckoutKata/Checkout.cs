using System.Collections.Generic;
using System.Linq;
using CheckoutKata.Interface;
using CheckoutKata.Model;

namespace CheckoutKata
{
    public class Checkout
    {
        private readonly IItemService _itemService;
        private readonly IEnumerable<SpecialOffer> _specialOffers;

        public Checkout(ISpecialOfferService specialOfferService, IItemService itemService)
        {
            _itemService = itemService;
            _specialOffers = specialOfferService.GetSpecialOffers();
            _items = new List<Item>();
        }
        
        private readonly ICollection<Item> _items;

        public double Total => _total();

        public void Scan(string sku)
        {
            _items.Add(_itemService.GetItem(sku));
        }

        private double _total()
        {
            return _items.GroupBy(
               item => item,
                (key, items) => new GroupedItem(key, items.Count(), _specialOffers.FirstOrDefault(so => so.Sku == key.Sku))
            ).Sum(items => items.TotalPrice);
        }
    }
} 