using Art.BussinessLogic;
using Art.Data.Domain;
using Art.WebService.Controllers;
using Art.WebService.Models;
using NUnit.Framework;
using Rhino.Mocks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Art.WebService.Tests
{
    [TestFixture]
    public class UserControllerTest
    {
        UserController _controller;
        ICustomerBussinessLogic _logic1;
        IArtworkBussinessLogic _logic2;
        IArtistBussinessLogic _logic3;
        [SetUp]
        public void Setup()
        {
            _logic1 = MockRepository.GenerateMock<ICustomerBussinessLogic>();
            _logic2 = MockRepository.GenerateMock<IArtworkBussinessLogic>();
            _logic3 = MockRepository.GenerateMock<IArtistBussinessLogic>();

            _controller = new WebService.Controllers.UserController(_logic1, _logic2, _logic3);
        }

        [Test]
        public void CheckCode_Test()
        {
            var phoneNumber1 = "134";
            var result = _controller.CheckCode(phoneNumber1);
            Assert.AreEqual(Art.WebService.Models.SendCheckCodeStatus.InvlidPhoneNumber, result.Status);


            var phoneNumber2 = "13488738363";
            var result2 = _controller.CheckCode(phoneNumber2);
            Assert.AreEqual(SendCheckCodeStatus.Success, result.Status);

        }

        [Test]
        public void Register_Test()
        {
            var customer = new CustomerRegisterModel();
            customer.NickName = "wgj";
            customer.Password = "p@ssw0rd";
            var result1 = _controller.Register(customer);
            Assert.AreNotEqual((int)CustomerRegisterStatus.Success, result1.Status);

            customer.PhoneNumber = "13488738363";

            _logic1.Stub(i => i.Add(Arg<Customer>.Is.Anything)).Return(new Customer());

            var result2 = _controller.Register(customer);
            Assert.AreEqual((int)CustomerRegisterStatus.Success, result2.Status);
        }

        [Test]
        public void AddAddressTest()
        {
            var model = new AddAddressModel
            {
                Detail = "abcdef",
                PhoneNumber = "13433334444",
                ReceiptName = "dda",
                UserId = 1
            };

           var addressAdded =   _controller.AddAddress(model);
           Assert.NotNull(addressAdded);
        }

    }
}
