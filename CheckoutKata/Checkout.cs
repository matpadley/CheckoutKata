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

        public double Total => _total();

        public void Scan(Item item)
        {
            _items.Add(item);
        }

        private double _total()
        {
            var nonSpecialOffer = _items.Sum(item => item.UnitPrice);

            //var groupedItem = _items.GroupBy(
            //    item => item,
            //    (key, items) => new GroupedItem(key, items.Count())
            //);
            
            
            
            
            return _items.Sum(item => item.UnitPrice);
        }
    }
}