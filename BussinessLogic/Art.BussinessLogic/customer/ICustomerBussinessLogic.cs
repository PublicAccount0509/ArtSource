using Art.Data.Domain;
using System;
using System.Collections.Generic;
namespace Art.BussinessLogic
{
    public interface ICustomerBussinessLogic
    {
        Customer Add(Customer customer);
        Address AddAddress(Address address);
        bool Exist(int id);
        bool ExistNickName(string nickName);
        bool ExistPhoneNumber(string phoneNumber);
        Customer Get(int id);
        IList<ActivityCollect> GetActivityCollect(int customerId);
        Address GetAddressById(int id);
        IList<Customer> GetAll();
        IList<Address> GetMyAddresses(int userId);
        void RemoveAddress(Address address);
        Customer RetrieveCustomer(string loginName, string password);
        void UpdateAddress(Address address);
        void UpdateCustomer(Customer model);
        IList<Comment> GetCommons(int userId);
    }
}
