using CheckoutKata.Model;

namespace CheckoutKata.Interface
{
    public interface IItemService
    {
        Item GetItem(string sku);
    }
}