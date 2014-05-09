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
        public static readonly OrderBussinessLogic Instance = new OrderBussinessLogic();

        private readonly IRepository<Order> _orderRepository;
        private readonly IRepository<Customer> _customerRepository;
        private readonly IRepository<Artwork> _artworkRepository;

        private readonly IRepository<Address> _addressRepository;
        private OrderBussinessLogic()
        {
            _orderRepository = new EfRepository<Order>();
            _customerRepository = new EfRepository<Customer>();
            _addressRepository = new EfRepository<Address>();
            _artworkRepository = new EfRepository<Artwork>();
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

            if (string.IsNullOrEmpty(criteria.OrderNumber))
            {
                query = query.Where(i => i.OrderNumber == criteria.OrderNumber);
            }
            query = query.OrderByDescending(i => i.Id);

            var result = new PagedList<Order>(query, criteria.PagingRequest.PageIndex, criteria.PagingRequest.PageSize);
            return result;
        }

        public List<Order> AddOrders(List<Order> orders)
        {
            var results = new List<Order>();
            foreach (var order in orders)
            {
                order.FADateTime = DateTime.Now;

                var result = _orderRepository.Insert(order);
                results.Add(result);
            }
            return results;
        }
    }
}
