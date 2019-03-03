namespace AutoRegisterServices.Service
{
    public class ShoppingCartDB : IShoppingCart
    {
        public object GetCart() => "Cart loaded from DB ..";
    }
}
