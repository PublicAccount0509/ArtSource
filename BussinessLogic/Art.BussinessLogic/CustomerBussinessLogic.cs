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
        private CustomerBussinessLogic()
        {
            _customerRepository = new EfRepository<Customer>();
        }

        public CustomerRegisterResult Register(Customer customer)
        {
            if (string.IsNullOrEmpty(customer.LoginName) )
            {
                return CustomerRegisterResult.LoginNameAlreadyExists;
            }
            if (_customerRepository.Table.Where(i=>i.LoginName == customer.LoginName).Any())
            {
                return CustomerRegisterResult.LoginNameAlreadyExists;
            }
            _customerRepository.Insert(customer);
            return  CustomerRegisterResult.Success;
        }

        public IList<Customer> GetAll()
        {
            return _customerRepository.Table.ToList();
        }

        public Customer Get(int id)
        {
            return _customerRepository.GetById(id);
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
