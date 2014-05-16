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
    public class OrderBussinessLogic
    {
        //public static readonly OrderBussinessLogic Instance = new OrderBussinessLogic();

        private readonly IRepository<Order> _orderRepository;
        private readonly IRepository<Customer> _customerRepository;
        private readonly IRepository<Artwork> _artworkRepository;

        private readonly IRepository<Address> _addressRepository;

        private readonly IRepository<AuctionBill> _auctionBillRepository;
        private OrderBussinessLogic(EfRepository<Order> orderRepository,
            EfRepository<Customer> customerRepository,
            EfRepository<Address> addressRepository,
            EfRepository<Artwork> artworkRepository,
            EfRepository<AuctionBill> auctionBillRepository)
        {
            _orderRepository = orderRepository;
            _customerRepository = customerRepository;
            _addressRepository = addressRepository;
            _artworkRepository = artworkRepository;
            _auctionBillRepository = auctionBillRepository;
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
            query =
                query.Where(p =>
                    //(!criteria.StartDate.HasValue || p.BidDateTime >= criteria.StartDate.Value.BeginOfDay())
                    //&& (!criteria.EndDate.HasValue || p.BidDateTime <= criteria.EndDate.Value.EndOfDay())
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
    }
}
