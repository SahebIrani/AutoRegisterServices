namespace AutoRegisterServices.Service
{
    public class ShoppingCartCache : IShoppingCart
    {
        public object GetCart() => "Cart loaded from cache ..";
    }
}
