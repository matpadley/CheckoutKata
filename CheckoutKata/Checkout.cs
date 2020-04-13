using System.Collections.Generic;
using System.Linq;

namespace CheckoutKata
{
    public class Checkout
    {
        private readonly List<SpecialOffer> _specialOffers;
        
        public Checkout(List<SpecialOffer> specialOffers = null)
        {
            _specialOffers = specialOffers;
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