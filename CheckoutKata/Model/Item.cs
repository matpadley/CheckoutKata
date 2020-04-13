namespace CheckoutKata.Model
{
    public class Item
    {
        public string Sku { get; }
        public double UnitPrice { get; }

        public Item(string sku, double unitPrice)
        {
            Sku = sku;
            UnitPrice = unitPrice;
        }
    }
}