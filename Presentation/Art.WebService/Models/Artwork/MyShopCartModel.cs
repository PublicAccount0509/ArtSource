﻿using Art.Data.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebExpress.Core;

namespace Art.WebService.Models
{
    /// <summary>
    /// 获取购物车商品列表
    /// </summary>
    public class MyShopCartItemModel
    {
        /// <summary>
        /// 作品Id
        /// </summary>
        public int ArtworkId { get; set; }
        /// <summary>
        /// 作品图
        /// </summary>
        public string ImagePath { get; set; }
        /// <summary>
        /// 名称
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 作家
        /// </summary>
        public string ArtistName { get; set; }
    }

    public class MyShopCartModelTranslator : TranslatorBase<ShoppingCartItem, MyShopCartItemModel>
    {
        public static readonly MyShopCartModelTranslator Instance = new MyShopCartModelTranslator();

        public override MyShopCartItemModel Translate(ShoppingCartItem from)
        {
            var to = new MyShopCartItemModel();
            to.ArtistName = from.Artwork.Artist.Name;
            to.ArtworkId = from.ArtworkId;
            to.ImagePath = from.Artwork.ImageFileName;
            to.Name = from.Artwork.Name;
            return to;
        }

        public override ShoppingCartItem Translate(MyShopCartItemModel from)
        {
            throw new NotImplementedException();
        }
    }
}