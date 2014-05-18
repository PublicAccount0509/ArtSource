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
        ICustomerBussinessLogic _logic;
        [SetUp]
        public void Setup()
        {
            _logic = MockRepository.GenerateMock<ICustomerBussinessLogic>();
            _controller = new WebService.Controllers.UserController(_logic);
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

            _logic.Expect(i => i.Add(new Customer())).Return(new Customer());
            var result2 = _controller.Register(customer);
            Assert.AreEqual((int)CustomerRegisterStatus.Success, result2.Status);
        }

    }
}
