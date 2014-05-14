using Art.Data.Domain;
using Art.Data.Domain.Access;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Art.BussinessLogic
{
    public class CustomerBussinessLogic
    {
        public static readonly CustomerBussinessLogic Instance = new CustomerBussinessLogic();

        private readonly IRepository<Customer> _customerRepository;
        private readonly IRepository<ActivityCollect> _activityCollectRepository;
        private CustomerBussinessLogic()
        {
            _customerRepository = new EfRepository<Customer>();
            _activityCollectRepository = new EfRepository<ActivityCollect>();
        }

        public bool ExistPhoneNumber(string phoneNumber)
        {
            return _customerRepository.Table.Where(i=>i.PhoneNumber == phoneNumber).Any();    
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

        public bool ValidateLogin(string loginName, string password)
        {
            var query = _customerRepository.Table.Where(i => i.NickName == loginName || i.PhoneNumber == loginName);
            query = query.Where(i=>i.Password == password);
            return query.Any();
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
