﻿using Art.BussinessLogic;
using Art.WebService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Art.WebService.Controllers
{
    public class OrderController : ApiController
    {
        private IArtistBussinessLogic _artistBussinessLogic;
        private IArtworkBussinessLogic _artworkBussinessLogic;
        private ICustomerBussinessLogic _customerBussinessLogic;
        private IOrderBussinessLogic _orderBussinessLogic;
        public OrderController(IArtistBussinessLogic artistBussinessLogic,
            IArtworkBussinessLogic artworkBussinessLogic,
            ICustomerBussinessLogic customerBussinessLogic,
            IOrderBussinessLogic orderBussinessLogic)
        {
            _artistBussinessLogic = artistBussinessLogic;
            _artworkBussinessLogic = artworkBussinessLogic;
            _customerBussinessLogic = customerBussinessLogic;
            _orderBussinessLogic = orderBussinessLogic;
        }

        /// <summary>
        /// 放到购物车
        /// </summary>
        public IntResultModel AddToShopCart(AddToShopCartModel model)
        {
            if (!_artworkBussinessLogic.Exist(model.ArtworkId))
            {
                return IntResultModel.Conclude(AddToShopCartStatus.InvalidArtworkId);
            }

            if (!_customerBussinessLogic.Exist(model.UserId))
            {
                return IntResultModel.Conclude(AddToShopCartStatus.InvalidUserId);
            }

            var item = _orderBussinessLogic.GetShoppingCart(model.ArtworkId, model.UserId);
            if (item != null)
            {
                return IntResultModel.Conclude(AddToShopCartStatus.AlreadyAdded);
            }
            var result = _orderBussinessLogic.AddShoppingCartItem(model.ArtworkId, model.UserId);
            return IntResultModel.Conclude(AddToShopCartStatus.Success, result.Id);
        }

        // PUT api/order/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/order/5
        public void Delete(int id)
        {
        }
    }
}
