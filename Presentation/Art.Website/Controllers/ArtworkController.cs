﻿using Art.BussinessLogic;
using Art.Data.Common;
using Art.Data.Domain;
using Art.Website.Common;
using Art.Website.Filters;
using Art.Website.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebExpress.Core.Guards;
using WebExpress.Core.TypeExtensions;
using WebExpress.Website.Exceptions;

namespace Art.Website.Controllers
{

    public class ArtworkController : Controller
    {
        public ActionResult Types()
        {
            var model = new ArtworkTypesModel();
            model.ArtworkTypes = GetArtworkTypeModels();
            return View(model);
        }

        [Act("删除艺术品分类")]
        [LoggingFilter]
        public JsonResult DeleteArtworkType(int id)
        {
            var artworkType = ArtworkBussinessLogic.Instance.GetArtworkType(id);
            List<string> reasons;
            var model = new ResultModel(true, string.Empty);
            if (ArtworkBussinessLogic.Instance.CanDeleteArtworkType(artworkType, out reasons))
            {
                ArtworkBussinessLogic.Instance.DeleteArtworkType(artworkType);
            }
            else
            {
                model = new ResultModel(false, string.Join(",", reasons));
            }
            return Json(model);
        }

        [Act("添加艺术品分类")]
        [LoggingFilter]
        public JsonResult AddArtworkType(ArtworkTypeModel model)
        {
            string message;
            if (!ValidateArtworkType(model,out message))
            {
                return Json(new ResultModel(false,message));
            }

            var artworkType = ArtworkTypeModelTranslator.Instance.Translate(model);
            ArtworkBussinessLogic.Instance.AddArtworkType(artworkType);

            var result = new ResultModel(true, string.Empty);
            return Json(result);
        }

        [Act("编辑艺术品分类")]
        [LoggingFilter]
        public ActionResult UpdateArtworkType(ArtworkTypeModel model)
        {
            string message;
            if (!ValidateArtworkType(model, out message))
            {
                return Json(new ResultModel(false, message));
            }
            var artworkType = ArtworkTypeModelTranslator.Instance.Translate(model);
            ArtworkBussinessLogic.Instance.UpdateArtworkType(artworkType);

            var result = new ResultModel(true, string.Empty);
            return Json(result);
        }

        public bool ValidateArtworkType(ArtworkTypeModel model, out string message)
        {
            if (string.IsNullOrEmpty(model.Text))
            {
                message = "分类不可为空";
                return false;
            }
            var at = ArtworkBussinessLogic.Instance.GetArtworkTypeByName(model.Text);
            if (at != null && at.Id != model.Id)
            {
                message = "已存在相同名称的分类!";
                return false;
            }

            for (int i = 0; i < model.ArtMaterials.Count; i++)
            {
                if (string.IsNullOrEmpty(model.ArtMaterials[i].Text))
                {
                    message = "材质不可为空";
                    return false;
                }
            }

            if (model.ArtMaterials.GroupBy(i => i.Text).Count() != model.ArtMaterials.Count)
            {
                message = "材质名有重复";
                return false;
            }

            for (int i = 0; i < model.ArtShapes.Count; i++)
            {
                if (string.IsNullOrEmpty(model.ArtShapes[i].Text))
                {
                    message = "形制不可为空";
                    return false;
                }
            }

            if (model.ArtShapes.GroupBy(i => i.Text).Count() != model.ArtShapes.Count)
            {
                message = "形制有重复";
                return false;
            }

            for (int i = 0; i < model.ArtTechniques.Count; i++)
            {
                if (string.IsNullOrEmpty(model.ArtTechniques[i].Text))
                {
                    message = "技法不可为空";
                    return false;
                }
            }

            if (model.ArtTechniques.GroupBy(i => i.Text).Count() != model.ArtTechniques.Count)
            {
                message = "技法有重复";
                return false;
            }
            message = null;
            return true;
        }

        public void Test()
        {
            var artworkType = ArtworkBussinessLogic.Instance.GetArtworkType(2);
            artworkType.ArtMaterials.Remove(artworkType.ArtMaterials.First());
            artworkType.ArtMaterials.Add(new ArtMaterial { Name = "ttttttttttt" });

            ArtworkBussinessLogic.Instance.UpdateArtworkType(artworkType);
        }


        public PartialViewResult ArtworkTypes()
        {
            var artworkTypes = GetArtworkTypeModels();
            return PartialView("_TypesList", artworkTypes);
        }

        private IList<ArtworkTypeModel> GetArtworkTypeModels()
        {
            var artworkTypes = ArtworkBussinessLogic.Instance.GetArtworkTypes();
            var artworkTypeModels = ArtworkTypeModelTranslator.Instance.Translate(artworkTypes);
            return artworkTypeModels;
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Add()
        {
            var artwork = new ArtworkModel();
            var model = GetArtworkEditModel(artwork);
            var artistIdStr = Request.QueryString["artistId"];
            int artistId;
            if (int.TryParse(artistIdStr, out artistId))
            {
                model.Artwork.ArtistId = artistId;
            }
            return View("Edit", model);
        }

        [HttpPost]
        public JsonResult Add(ArtworkModel model)
        {
            string errormagess;
            if (!CheckArtworkModel(model, out errormagess))
            {
                return Json(new ResultModel(false, errormagess));
            }
            var artwork = ArtworkModelTranslator.Instance.Translate(model);

            ArtworkBussinessLogic.Instance.Add(artwork);

            var result = new ResultModel(true, "add successfully!");
            return Json(result);
            //return Json(new ResultModel(true, "add successfully!"));
        }

        [HttpPost]
        public JsonResult Update(ArtworkModel model)
        {
            string errormagess;
            if (!CheckArtworkModel(model, out errormagess))
            {
                return Json(new ResultModel(false, errormagess));
            }
            //bussiness check
            if (model.AuctionType == AuctionType.一口价)
            {
                model.StartDateTime = null;
                model.EndDateTime = null;
            }

            var artwork = ArtworkModelTranslator.Instance.Translate(model);

            ArtworkBussinessLogic.Instance.Update(artwork);

            var result = new ResultModel(true, "update successfully!");

            return Json(result);
        }

        /// <summary>
        /// Checks the artwork model.
        /// </summary>
        /// <param name="model">The model</param>
        /// <param name="errormagess">The errormagess</param>
        /// <returns>
        /// Boolean
        /// </returns>
        /// 创建者：黄磊
        /// 创建日期：5/13/2014 11:50 AM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        private bool CheckArtworkModel(ArtworkModel model, out string errormagess)
        {
            errormagess = string.Empty;
            var ret = true;
            if (model == null)
            {
                errormagess = "请求参数不存在！";
                ret = false;
            }
            else
            {
                if (string.IsNullOrEmpty(model.Name))
                {
                    errormagess = "请填写作品名称 ";
                    ret = false;
                }
                else if (model.Name.Trim().Length == 0)
                {
                    errormagess = "请填写作品名称 ";
                    ret = false;
                }
                else if (model.ArtistId == 0)
                {
                    errormagess = "请选择作者 ";
                    ret = false;
                }
                else if (string.IsNullOrEmpty(model.Size))
                {
                    errormagess = "请输入作品大小 ";
                    ret = false;
                }
                else if (model.Size.Trim().Length == 0)
                {
                    errormagess = "请输入作品大小 ";
                    ret = false;
                }
                else if (model.ArtYear == 0)
                {
                    errormagess = "请选择年代 ";
                    ret = false;
                }
                else if (model.ArtworkTypeId == 0)
                {
                    errormagess = "请选择作品分类 ";
                    ret = false;
                }
                else if (model.ArtMaterialId == 0)
                {
                    errormagess = "请选择材质 ";
                    ret = false;
                }
                else if (model.GenreId == 0)
                {
                    errormagess = "请选择题材 ";
                    ret = false;
                }
                else if (model.SuitablePlaceIds.Count == 0)
                {
                    errormagess = "请选择适用空间 ";
                    ret = false;
                }
                else if (string.IsNullOrEmpty(model.ImageFileName))
                {
                    errormagess = "请选择作品图片 ";
                    ret = false;
                }
                //else if (model.AuctionType == null)
                //{
                //    errormagess = "请选择拍卖方式 ";
                //    ret = false;
                //}
                else if (model.AuctionPrice == 0)
                {
                    errormagess = "请填写拍卖价格 ";
                    ret = false;
                }
                else if (!model.FeePackageGeneralEnabled && !model.FeePackageFineEnabled)
                {
                    errormagess = "至少选择一种方式包装 ";
                    ret = false;
                }
                else if (model.FeePackageGeneralEnabled && !model.FeePackageGeneral.HasValue)
                {
                    errormagess = "请填写一般包装价格 ";
                    ret = false;
                }
                else if (model.FeePackageFineEnabled && !model.FeePackageFine.HasValue)
                {
                    errormagess = "请填写精装价格 ";
                    ret = false;
                }
                else if (!model.FeeDeliveryLocalEnabled && !model.FeeDeliveryNonlocalEnabled)
                {
                    errormagess = "至少选择一种方式运费 ";
                    ret = false;
                }
                else if (model.FeeDeliveryLocalEnabled && !model.FeeDeliveryLocal.HasValue)
                {
                    errormagess = "请填写市内运费价格 ";
                    ret = false;
                }
                else if (model.FeeDeliveryNonlocalEnabled && !model.FeeDeliveryNonlocal.HasValue)
                {
                    errormagess = "请填写外地运费价格 ";
                    ret = false;
                }
            }
            return ret;
        }

        public ActionResult Edit(int id)
        {
            var artwork = ArtworkBussinessLogic.Instance.GetArtwork(id);
            Guard.IsNotNull<DataNotFoundException>(artwork);

            var artworkModel = ArtworkModelTranslator.Instance.Translate(artwork);
            var model = GetArtworkEditModel(artworkModel);
            return View("Edit", model);
        }


        [HttpGet]
        public ActionResult List()
        {
            var model = new ArtworkManageModel();


            var defaultCriteria = new ArtworkSearchCriteria(10);
            int artistId;
            if (int.TryParse(Request.QueryString["ArtistId"], out artistId))
            {
                defaultCriteria.ArtistId = artistId;
            }
            model.PagedArtworks = GetPagedArtworkModel(defaultCriteria);

            var artists = ArtistBussinessLogic.Instance.GetArtists();
            model.Artists = IdNameModelTranslator<Artist>.Instance.Translate(artists);

            var artworkTypes = ArtworkBussinessLogic.Instance.GetArtworkTypes();
            model.ArtworkTypes = GetArtworkTypeModels();
            return View(model);
        }

        public PartialViewResult List(ArtworkSearchCriteria criteria)
        {
            var model = GetPagedArtworkModel(criteria);
            return PartialView("_List", model);
        }

        public JsonResult Delete(int id)
        {
            var artwork = ArtworkBussinessLogic.Instance.GetArtwork(id);
            ArtworkBussinessLogic.Instance.Delete(artwork);
            var model = new ResultModel(true, string.Empty);
            return Json(model);
        }

        public ActionResult Detail(int id)
        {
            var artwork = ArtworkBussinessLogic.Instance.GetArtwork(id);
            var model = ArtworkDetailModelTranslator.Instance.Translate(artwork);
            return View(model);
        }

        public JsonResult CancelPublish(int id)
        {
            var artwork = ArtworkBussinessLogic.Instance.GetArtwork(id);
            artwork.IsPublic = false;
            ArtworkBussinessLogic.Instance.Update(artwork);
            var model = new ResultModel(true, string.Empty);
            return Json(model);
        }

        public JsonResult Publish(int id)
        {
            var artwork = ArtworkBussinessLogic.Instance.GetArtwork(id);
            artwork.IsPublic = true;
            ArtworkBussinessLogic.Instance.Update(artwork);
            var model = new ResultModel(true, string.Empty);
            return Json(model);
        }

        private PagedArtworkModel GetPagedArtworkModel(ArtworkSearchCriteria criteria)
        {
            var artworks = new List<ArtworkSimpleModel>();
            var pagedArtworks = ArtworkBussinessLogic.Instance.SearchArtworks(criteria.NamePart, criteria.ArtworkTypeId, criteria.ArtMaterialId, criteria.ArtistId, criteria.PagingRequest);
            foreach (var item in pagedArtworks)
            {
                var artwork = ArtworkSimpleModelTranslator.Instance.Translate(item);
                //artist.CanUnPublish = Art.BussinessLogic.ArtistBussinessLogic.Instance.CanUnpublish(item);
                artworks.Add(artwork);
            }

            var model = new PagedArtworkModel(artworks, pagedArtworks.PagingResult);
            return model;
        }

        private ArtworkEditModel GetArtworkEditModel(ArtworkModel artworkModel)
        {
            var model = new ArtworkEditModel();
            model.Artwork = artworkModel;

            var artists = ArtistBussinessLogic.Instance.GetArtists();
            model.SourceArtists = IdNameModelTranslator<Artist>.Instance.Translate(artists);

            var artworkTypes = ArtworkBussinessLogic.Instance.GetArtworkTypes();
            model.SourceArtworkTypes = ArtworkTypeModelTranslator.Instance.Translate(artworkTypes);

            var genres = ArtistBussinessLogic.Instance.GetGenres();
            model.SourceGenres = IdNameModelTranslator<Genre>.Instance.Translate(genres);

            //var periods = ArtworkBussinessLogic.Instance.GetPeriods();
            //model.SourceArtPeriods = IdNameModelTranslator<ArtPeriod>.Instance.Translate(periods);

            var places = ArtworkBussinessLogic.Instance.GetPlaces();
            model.SourceArtPlaces = IdNameModelTranslator<ArtPlace>.Instance.Translate(places);

            model.SourceAuctionTypes = EnumExtenstion.GetEnumItems<AuctionType>();



            return model;
        }

    }
}
