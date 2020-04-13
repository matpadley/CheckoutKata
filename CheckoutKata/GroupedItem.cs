using System;

namespace CheckoutKata
{
    public class GroupedItem
    {
        private readonly SpecialOffer _associatedSpecialOffer;
        private Item Item { get; }
        private int Count { get; }

        public GroupedItem(Item item, int count, SpecialOffer associatedSpecialOffer = null)
        {
            _associatedSpecialOffer = associatedSpecialOffer;
                
            Item = item;
            Count = count;
        }

        public double TotalPrice => _totalPrice();

        private double _totalPrice()
        {
            if (_associatedSpecialOffer == null)
            {
                return Math.Round(Item.UnitPrice * Count, 2);
            }

            if (_associatedSpecialOffer.Sku == Item.Sku)
            {
                var offerCount = (Count / _associatedSpecialOffer.Quantity);
                var nonOfferCount = Count - (offerCount * _associatedSpecialOffer.Quantity);
                return Math.Round(offerCount * _associatedSpecialOffer.OfferPrice,2) + Math.Round(nonOfferCount * Item.UnitPrice, 2);
            }
            
            return Math.Round(Item.UnitPrice * Count, 2);
        }
    }
}