using Art.BussinessLogic.Entities;
using Art.Data.Domain;
using System;
using WebExpress.Core;
namespace Art.BussinessLogic
{
    public interface IOrderBussinessLogic
    {
        Order AddOrder(Order order);
        void AddTestOrders();
        bool AuctionAccept(int id);
        bool AuctionRefuse(int id);
        void Deliver(int orderId, string companyName, string billNumber);
        Address GetAddress(int id);
        AuctionBill GetAuctionBillById(int id);
        Order GetOrderById(int id);
        PagedList<AuctionBill> SearchAuction(AuctionSearchCriteria criteria);
        PagedList<Order> SearchOrders(OrderSearchCriteria criteria);

        ShoppingCartItem AddShoppingCartItem(int artworkId, int customerId);

        ShoppingCartItem GetShoppingCart(int artworkId, int customerId);
    }
}
