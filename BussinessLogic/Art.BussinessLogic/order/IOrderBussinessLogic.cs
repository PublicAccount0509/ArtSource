﻿using Art.BussinessLogic.Entities;
using Art.Data.Common;
using Art.Data.Domain;
using System;
using System.Collections.Generic;
using WebExpress.Core;
namespace Art.BussinessLogic
{
    public interface IOrderBussinessLogic
    {
        Order AddOrder(Order order);

        void CloseOrder(Order order);

        void AddTestOrders();
        bool AuctionAccept(int id);
        bool AuctionRefuse(int id);
        void Deliver(int orderId, string companyName, string billNumber);
        Address GetAddress(int id);
        AuctionBill GetAuctionBillById(int id);
        Order GetOrderById(int id);
        void UpdateOrder(Order model);
        IList<Order> GetOrderListByCustomerId(int customerId);
        PagedList<AuctionBill> SearchAuction(AuctionSearchCriteria criteria);
        PagedList<Order> SearchOrders(OrderSearchCriteria criteria);

        ShoppingCartItem AddShoppingCartItem(int artworkId, int customerId);

        ShoppingCartItem GetShoppingCart(int artworkId, int customerId);

        IList<ShoppingCartItem> GetShoppingCartItems(int id);

        IList<Order> GetOrders();

        IList<Order> GetOrdersByStatus(OrderStatus status);

        IList<Order> GetOrdersByArtworkId(int artworkId);

        IList<Order> GetOrdersByArtworkId(int artworkId, OrderStatus status);
        AuctionBill AddAuction(AuctionBill auctionBill);
    }
}
