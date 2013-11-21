namespace Ets.SingleApi.Caches
{
    using Ets.SingleApi.Model;
    using Ets.SingleApi.Model.CacheServices;
    using Ets.SingleApi.Services.ICacheServices;

    public class ShoppingCartCacheServices : IShoppingCartCacheServices
    {
        public CacheServicesResult<ShoppingCartSupplier> GetShoppingCartSupplier(int businessId)
        {
            throw new System.NotImplementedException();
        }

        public CacheServicesResult<bool> SaveShoppingCartSupplier(ShoppingCartSupplier supplier)
        {
            throw new System.NotImplementedException();
        }

        public CacheServicesResult<ShoppingCartCustomer> GetShoppingCartCustomer(int userId)
        {
            throw new System.NotImplementedException();
        }

        public CacheServicesResult<bool> SaveShoppingCartCustomer(ShoppingCartCustomer customer)
        {
            throw new System.NotImplementedException();
        }

        public CacheServicesResult<ShoppingCartOrder> GetShoppingCartOrder(string id)
        {
            throw new System.NotImplementedException();
        }

        public CacheServicesResult<bool> SaveShoppingCartOrder(ShoppingCartOrder order)
        {
            throw new System.NotImplementedException();
        }

        public CacheServicesResult<ShoppingCart> GetShoppingCart(string id)
        {
            throw new System.NotImplementedException();
        }

        public CacheServicesResult<bool> SaveShoppingCart(ShoppingCart shoppingCart)
        {
            throw new System.NotImplementedException();
        }

        public CacheServicesResult<ShoppingCartLink> GetShoppingCartLink(string shoppingCartLinkId)
        {
            throw new System.NotImplementedException();
        }

        public CacheServicesResult<bool> SaveShoppingCartLink(ShoppingCartLink shoppingCartLink)
        {
            throw new System.NotImplementedException();
        }
    }
}
