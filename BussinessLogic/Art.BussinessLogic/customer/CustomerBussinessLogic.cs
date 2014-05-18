using Art.Data.Domain;
using Art.Data.Domain.Access;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Art.BussinessLogic
{
    public class CustomerBussinessLogic : ICustomerBussinessLogic
    {
        //public static readonly CustomerBussinessLogic Instance = new CustomerBussinessLogic();

        private IRepository<Customer> _customerRepository;
        private IRepository<ActivityCollect> _activityCollectRepository;
        private IRepository<Address> _addressRepository;
        private IRepository<Comment> _commentRepository;

        public CustomerBussinessLogic(IRepository<Customer> customerRepository,
            IRepository<ActivityCollect> activityCollectRepository,
            IRepository<Address> addressRepository,
            IRepository<Comment> commentRepository)
        {
            _customerRepository = customerRepository;
            _activityCollectRepository = activityCollectRepository;
            _addressRepository = addressRepository;
            _commentRepository = commentRepository;
        }

        public bool ExistPhoneNumber(string phoneNumber)
        {
            return _customerRepository.Table.Where(i => i.PhoneNumber == phoneNumber).Any();
        }

        public bool ExistNickName(string nickName)
        {
            return _customerRepository.Table.Where(i => i.NickName == nickName).Any();
        }

        public Customer Add(Customer customer)
        {
            var result = _customerRepository.Insert(customer);
            return result;
        }

        public IList<Customer> GetAll()
        {
            return _customerRepository.Table.ToList();
        }


        public IList<Address> GetMyAddresses(int userId)
        {
            return _addressRepository.Table.Where(i => i.Customer.Id == userId).ToList();
        }

        public bool Exist(int id)
        {
            return Get(id) != null;
        }

        public Customer Get(int id)
        {
            return _customerRepository.GetById(id);
        }

        public IList<ActivityCollect> GetActivityCollect(int customerId)
        {
            var query = _activityCollectRepository.Table.Where(i => i.Customer.Id == customerId);
            return query.ToList();
        }

        public Customer RetrieveCustomer(string loginName, string password)
        {
            var query = _customerRepository.Table.Where(i => i.NickName == loginName || i.PhoneNumber == loginName);
            query = query.Where(i => i.Password == password);
            return query.FirstOrDefault();
        }
        /// <summary>
        /// Adds the address.
        /// </summary>
        /// <param name="address">The address</param>
        /// <returns>
        /// Address
        /// </returns>
        /// 创建者：黄磊
        /// 创建日期：5/14/2014 10:34 AM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public Address AddAddress(Address address)
        {
            //添加地址
            var insert = _addressRepository.Insert(address);
            //保存对Customer的更改
            _customerRepository.Update(address.Customer);
            return insert;
        }

        /// <summary>
        /// Gets the address by identifier.
        /// </summary>
        /// <param name="id">The id</param>
        /// <returns>
        /// Address
        /// </returns>
        /// 创建者：黄磊
        /// 创建日期：5/14/2014 10:39 AM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public Address GetAddressById(int id)
        {
            return _addressRepository.GetById(id);
        }
        /// <summary>
        /// Updates the address.
        /// </summary>
        /// <param name="address">The address</param>
        /// 创建者：黄磊
        /// 创建日期：5/14/2014 10:49 AM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public void UpdateAddress(Address address)
        {
            //保存更改
            _addressRepository.Update(address);
        }
        /// <summary>
        /// Removes the address.
        /// </summary>
        /// <param name="address">The address</param>
        /// 创建者：黄磊
        /// 创建日期：5/14/2014 11:00 AM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public void RemoveAddress(Address address)
        {
            //保存对Customer表的更改
            _customerRepository.Update(address.Customer);
            //删除地址
            _addressRepository.Delete(address);
        }

        /// <summary>
        /// Updates the customer.
        /// </summary>
        /// <param name="model">The model</param>
        /// 创建者：黄磊
        /// 创建日期：5/16/2014 10:46 AM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public void UpdateCustomer(Customer model)
        {
            _customerRepository.Update(model);
        }

        public IList<Comment> GetComments(int customerId)
        {
            return _commentRepository.Table.Where(i=>i.Customer.Id == customerId).ToList();
        }
    }

    public enum CustomerRegisterResult
    {
        LoginNameFormatInvalid,
        LoginNameAlreadyExists,
        PasswordTooShort,
        Success
    }
}
