namespace AutoRegisterServices.Service
{
    public class ShoppingCartAPI : IShoppingCart
    {
        public object GetCart() => "Cart loaded through API ..";
    }
}
