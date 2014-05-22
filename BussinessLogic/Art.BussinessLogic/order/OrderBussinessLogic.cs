using Art.BussinessLogic.Entities;
using Art.Data.Common;
using Art.Data.Domain;
using Art.Data.Domain.Access;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebExpress.Core;

namespace Art.BussinessLogic
{
    public class OrderBussinessLogic : IOrderBussinessLogic
    {
        //public static readonly OrderBussinessLogic Instance = new OrderBussinessLogic();

        private IRepository<Order> _orderRepository;
        private IRepository<Customer> _customerRepository;
        private IRepository<Artwork> _artworkRepository;
        private IRepository<Address> _addressRepository;
        private IRepository<ShoppingCartItem> _shoppingCartRepository;

        private IRepository<AuctionBill> _auctionBillRepository;
        public OrderBussinessLogic(IRepository<Order> orderRepository,
            IRepository<Customer> customerRepository,
            IRepository<Address> addressRepository,
            IRepository<Artwork> artworkRepository,
            IRepository<AuctionBill> auctionBillRepository,
            IRepository<ShoppingCartItem> shoppingCartRepository)
        {
            _orderRepository = orderRepository;
            _customerRepository = customerRepository;
            _addressRepository = addressRepository;
            _artworkRepository = artworkRepository;
            _auctionBillRepository = auctionBillRepository;
            _shoppingCartRepository = shoppingCartRepository;
        }


        public void AddTestOrders()
        {

        }

        public PagedList<Order> SearchOrders(OrderSearchCriteria criteria)
        {
            var query = _orderRepository.Table;
            if (criteria.StartDate.HasValue)
            {
                var dateBegin = criteria.StartDate.Value.BeginOfDay();
                query = query.Where(i => i.FADateTime >= dateBegin);
            }

            if (criteria.EndDate.HasValue)
            {
                var dateEnd = criteria.EndDate.Value.EndOfDay();
                query = query.Where(i => i.FADateTime <= dateEnd);
            }

            if (!string.IsNullOrEmpty(criteria.OrderNumber))
            {
                query = query.Where(i => i.OrderNumber == criteria.OrderNumber);
            }

            if (criteria.Status.HasValue)
            {
                query = query.Where(i => i.Status == criteria.Status.Value);
            }

            if (criteria.IsPaid.HasValue)
            {
                query = criteria.IsPaid.Value
                            ? query.Where(i => i.PayStatus == PayStatus.支付成功)
                            : query.Where(i => i.PayStatus == PayStatus.支付失败);
            }

            //var query =
            //    _orderRepository.Table.Where(
            //        p => (!criteria.StartDate.HasValue || p.FADateTime >= criteria.StartDate.Value.BeginOfDay())
            //             && (!criteria.EndDate.HasValue || p.FADateTime <= criteria.EndDate.Value.EndOfDay())
            //             && (string.IsNullOrEmpty(criteria.OrderNumber) || p.OrderNumber == criteria.OrderNumber)
            //             && (!criteria.Status.HasValue || p.Status == criteria.Status.Value))
            //                    .OrderByDescending(p => p.Id);


            query = query.OrderByDescending(i => i.Id);

            var result = new PagedList<Order>(query, criteria.PagingRequest.PageIndex, criteria.PagingRequest.PageSize);
            return result;
        }

        /// <summary>
        /// Gets the order by identifier.
        /// </summary>
        /// <param name="id">The id</param>
        /// <returns>
        /// Order
        /// </returns>
        /// 创建者：黄磊
        /// 创建日期：5/13/2014 2:13 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public Order GetOrderById(int id)
        {
            return _orderRepository.GetById(id);
        }
        public void UpdateOrder(Order model)
        {
            _orderRepository.Update(model);
        }
        public IList<Order> GetOrderListByCustomerId(int customerId)
        {
            return _orderRepository.Table.Where(p => p.Customer.Id == customerId).ToList();
        }
        /// <summary>
        /// Gets the address.
        /// </summary>
        /// <param name="id">The id</param>
        /// <returns>
        /// Address
        /// </returns>
        /// 创建者：黄磊
        /// 创建日期：5/13/2014 3:14 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public Address GetAddress(int id)
        {
            return _addressRepository.GetById(id);
        }
        /// <summary>
        /// Searches the auction.
        /// </summary>
        /// <param name="criteria">The criteria</param>
        /// <returns>
        /// PagedList{AuctionBill}
        /// </returns>
        /// 创建者：黄磊
        /// 创建日期：5/12/2014 11:21 AM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public PagedList<AuctionBill> SearchAuction(AuctionSearchCriteria criteria)
        {
            var query = _auctionBillRepository.Table;
            query = query.Where(p =>
                            (criteria.ArtistsId == null || p.Artwork.Artist.Id == criteria.ArtistsId)
                            && (criteria.ArtworkId == null || p.ArtworkId == criteria.ArtworkId));


            if (criteria.StartDate.HasValue)
            {
                var dateBegin = criteria.StartDate.Value.BeginOfDay();
                query = query.Where(i => i.BidDateTime >= dateBegin);
            }

            if (criteria.EndDate.HasValue)
            {
                var dateEnd = criteria.EndDate.Value.EndOfDay();
                query = query.Where(i => i.BidDateTime <= dateEnd);
            }
            query = query.OrderByDescending(i => i.Id);

            var result = new PagedList<AuctionBill>(query, criteria.PagingRequest.PageIndex,
                                                    criteria.PagingRequest.PageSize);
            return result;
        }

        /// <summary>
        /// Gets the auction bill by identifier.
        /// </summary>
        /// <param name="id">The id</param>
        /// <returns>
        /// AuctionBill
        /// </returns>
        /// 创建者：黄磊
        /// 创建日期：5/12/2014 3:40 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public AuctionBill GetAuctionBillById(int id)
        {
            return _auctionBillRepository.GetById(id);
        }

        /// <summary>
        /// 操作拍卖操作--拒绝
        /// </summary>
        /// <param name="id">The id</param>
        /// 创建者：黄磊
        /// 创建日期：5/12/2014 3:51 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public bool AuctionRefuse(int id)
        {
            var auctionBill = GetAuctionBillById(id);
            if (auctionBill == null)
            {
                return false;
            }
            auctionBill.AuctionResult = AuctionResult.Refuse;
            //SaveChanges
            _auctionBillRepository.Update(auctionBill);
            return true;
        }

        /// <summary>
        /// 操作拍卖操作--接受
        /// </summary>
        /// <param name="id">The id</param>
        /// 创建者：黄磊
        /// 创建日期：5/12/2014 3:51 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public bool AuctionAccept(int id)
        {
            var auctionBill = GetAuctionBillById(id);
            if (auctionBill == null)
            {
                return false;
            }
            auctionBill.AuctionResult = AuctionResult.Accept;
            var otherAuctions =
                _auctionBillRepository.Table.Where(p => p.ArtworkId == auctionBill.ArtworkId && p.Id != auctionBill.Id);
            //接受一个出价人，相关的出价全部为拒绝
            foreach (var otherAuction in otherAuctions)
            {
                otherAuction.AuctionResult = AuctionResult.Refuse;
                //_auctionBillRepository.Update(otherAuction);
            }
            //SaveChanges
            _auctionBillRepository.Update(auctionBill);
            return true;
        }


        public Order AddOrder(Order order)
        {
            order.FADateTime = DateTime.Now;
            var artwork = _artworkRepository.GetById(order.ArtworkId);

            if (order.PackingType == PackingType.一般包装)
            {
                order.FeePackage = artwork.FeePackageGeneral.Value;
            }
            else
            {
                order.FeePackage = artwork.FeePackageFine.Value;
            }

            if (order.DeliveryType == DeliveryType.市内)
            {
                order.FeeDelivery = artwork.FeeDeliveryLocal.Value;
            }
            else if (order.DeliveryType == DeliveryType.外地)
            {
                order.FeeDelivery = artwork.FeeDeliveryNonlocal.Value;
            }
            else
            {
                order.FeeDelivery = 0;
            }
            order.Status = OrderStatus.生成中;
            order.OrderNumber = "1234567890";


            var result = _orderRepository.Insert(order);
            return result;
        }

        public void Deliver(int orderId, string companyName, string billNumber)
        {
            var order = _orderRepository.GetById(orderId);
            //order.DeliveryInfo.DeliveryCompany = companyName;
            //order.DeliveryInfo.DeliveryNumber = billNumber;
            //order.DeliveryInfo.Status = DeliveryStatus.已发货;

            _orderRepository.Update(order);
        }

        public ShoppingCartItem AddShoppingCartItem(int artworkId, int customerId)
        {
            var artwork = _artworkRepository.GetById(artworkId);
            var item = new ShoppingCartItem
            {
                ArtworkId = artworkId,
                CustomerId = customerId,
                Price = artwork.AuctionPrice,
                FADateTime = DateTime.Now
            };
            var result = _shoppingCartRepository.Insert(item);
            return result;
        }

        public ShoppingCartItem GetShoppingCart(int artworkId, int customerId)
        {
            var item = _shoppingCartRepository.Table.FirstOrDefault(i => i.ArtworkId == artworkId && i.CustomerId == customerId);
            return item;
        }

        public IList<ShoppingCartItem> GetShoppingCartItems(int customerId)
        {
            var list = _shoppingCartRepository.Table.Where(p => p.CustomerId == customerId).ToList();
            return list;
        }

        public IList<Order> GetOrdersByArtworkId(int artworkId)
        {
            var orders = _orderRepository.Table.Where(i => i.ArtworkId == artworkId).ToList();
            return orders;
        }

        public IList<Order> GetOrdersByArtworkId(int artworkId, OrderStatus status)
        {
            var orders = _orderRepository.Table.Where(i => i.ArtworkId == artworkId && i.Status == status).ToList();
            return orders;
        }

        public AuctionBill AddAuction(AuctionBill auctionBill)
        {
            auctionBill.BidDateTime = DateTime.Now;
            auctionBill.AuctionResult = AuctionResult.None;
            return _auctionBillRepository.Insert(auctionBill);
        }

        public IList<Order> GetOrders()
        {
            return _orderRepository.Table.ToList();
        }

        public IList<Order> GetOrdersByStatus(OrderStatus status)
        {
            return _orderRepository.Table.Where(i => i.Status == status).ToList();
        }

        public void CloseOrder(Order order)
        {
            if (order.PayStatus == PayStatus.支付成功)
            {
                return;
            }
            order.Status = OrderStatus.已关闭;
            _orderRepository.Update(order);
        }
    }
}
