using System;
namespace Art.BussinessLogic
{
    public interface IOrderBussinessLogic
    {
        Art.Data.Domain.Order AddOrder(Art.Data.Domain.Order order);
        void AddTestOrders();
        bool AuctionAccept(int id);
        bool AuctionRefuse(int id);
        void Deliver(int orderId, string companyName, string billNumber);
        Art.Data.Domain.Address GetAddress(int id);
        Art.Data.Domain.AuctionBill GetAuctionBillById(int id);
        Art.Data.Domain.Order GetOrderById(int id);
        WebExpress.Core.PagedList<Art.Data.Domain.AuctionBill> SearchAuction(Art.BussinessLogic.Entities.AuctionSearchCriteria criteria);
        WebExpress.Core.PagedList<Art.Data.Domain.Order> SearchOrders(Art.BussinessLogic.Entities.OrderSearchCriteria criteria);
    }
}
