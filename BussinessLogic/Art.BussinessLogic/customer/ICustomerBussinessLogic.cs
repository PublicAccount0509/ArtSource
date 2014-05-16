using System;
namespace Art.BussinessLogic
{
    public interface ICustomerBussinessLogic
    {
        Art.Data.Domain.Customer Add(Art.Data.Domain.Customer customer);
        Art.Data.Domain.Address AddAddress(Art.Data.Domain.Address address);
        bool Exist(int id);
        bool ExistNickName(string nickName);
        bool ExistPhoneNumber(string phoneNumber);
        Art.Data.Domain.Customer Get(int id);
        System.Collections.Generic.IList<Art.Data.Domain.ActivityCollect> GetActivityCollect(int customerId);
        Art.Data.Domain.Address GetAddressById(int id);
        System.Collections.Generic.IList<Art.Data.Domain.Customer> GetAll();
        System.Collections.Generic.IList<Art.Data.Domain.Address> GetMyAddresses(int userId);
        void RemoveAddress(Art.Data.Domain.Address address);
        Art.Data.Domain.Customer RetrieveCustomer(string loginName, string password);
        void UpdateAddress(Art.Data.Domain.Address address);
        void UpdateCustomer(Art.Data.Domain.Customer model);
    }
}
