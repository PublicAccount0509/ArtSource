//using Art.BussinessLogic;
//using Art.Data.Domain;
using Art.Website.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Art.Website.Controllers.WebServiceController
{
    public class CustomerController : ApiController
    {
        // GET api/customer
        //public IEnumerable<CustomerModel> Get()
        //{
        //    var customers = CustomerBussinessLogic.Instance.GetAll();
        //    var models = CustomerModelTranslator.Instance.Translate(customers);
        //    return models;
        //}

        //// GET api/customer/5
        //public CustomerModel Get(int id)
        //{
        //    var customer = CustomerBussinessLogic.Instance.Get(id);
        //    var model = CustomerModelTranslator.Instance.Translate(customer);
        //    return model;
        //}


        //public int Register(CustomerRegisterModel model)
        //{
        //    if (string.IsNullOrEmpty(model.Name) || string.IsNullOrEmpty(model.Password))
        //    {
        //        return 1;
        //    }

        //    var customer = CustomerRegisterModelTranslator.Instance.Translate(model);
        //    var result = CustomerBussinessLogic.Instance.Register(customer);

        //    return result == CustomerRegisterResult.Success ? 0 : 1;
        //}

        //// POST api/customer
        //public void Post(CustomerRegisterModel model)
        //{
        //}

        // PUT api/customer/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/customer/5
        public void Delete(int id)
        {
        }
    }
}
