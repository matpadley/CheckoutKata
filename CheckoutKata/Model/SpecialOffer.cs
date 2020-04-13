namespace CheckoutKata.Model
{
    public class SpecialOffer
    {
        public string Sku { get; }
        public int Quantity { get; }
        public double OfferPrice { get; }

        public SpecialOffer(string sku, in int quantity, in double offerPrice)
        {
            Sku = sku;
            Quantity = quantity;
            OfferPrice = offerPrice;
        }
    }
}