using Art.BussinessLogic;
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
            model.ArtworkTypes = GetArtworkTypes();
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
            if (string.IsNullOrEmpty(model.Text))
            {
                return Json(new ResultModel(false, "分类不可为空"));
            }

            for (int i = 0; i < model.ArtMaterials.Count; i++)
            {
                if (string.IsNullOrEmpty(model.ArtMaterials[i].Text))
                {
                    return Json(new ResultModel(false, "材质不可为空"));
                }
            }

            for (int i = 0; i < model.ArtShapes.Count; i++)
            {
                if (string.IsNullOrEmpty(model.ArtShapes[i].Text))
                {
                    return Json(new ResultModel(false, "形制不可为空"));
                }
            }

            for (int i = 0; i < model.ArtTechniques.Count; i++)
            {
                if (string.IsNullOrEmpty(model.ArtTechniques[i].Text))
                {
                    return Json(new ResultModel(false, "技法不可为空"));
                }
            }


            var artworkType = ArtworkTypeModelTranslator.Instance.Translate(model);
            ArtworkBussinessLogic.Instance.AddArtworkType(artworkType);

            var result = new ResultModel(true, string.Empty);
            return Json(result);
        }

        public void Test()
        {
            var artworkType = ArtworkBussinessLogic.Instance.GetArtworkType(2);
            artworkType.ArtMaterials.Remove(artworkType.ArtMaterials.First());
            artworkType.ArtMaterials.Add(new ArtMaterial { Name = "ttttttttttt" });

            ArtworkBussinessLogic.Instance.UpdateArtworkType(artworkType);
        }

        public ActionResult UpdateArtworkType(ArtworkTypeModel model)
        {
            var artworkType = ArtworkTypeModelTranslator.Instance.Translate(model);
            ArtworkBussinessLogic.Instance.UpdateArtworkType(artworkType);

            var result = new ResultModel(true, string.Empty);
            return Json(result);

        }

        public PartialViewResult ArtworkTypes()
        {
            var artworkTypes = GetArtworkTypes();
            return PartialView("_TypesList", artworkTypes);
        }

        private IList<ArtworkTypeModel> GetArtworkTypes()
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
            var artwork = ArtworkModelTranslator.Instance.Translate(model);

            ArtworkBussinessLogic.Instance.Add(artwork);

            var result = new ResultModel(true, "add successfully!");
            return Json(result);
        }

        [HttpPost]
        public JsonResult Update(ArtworkModel model)
        {
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
            return View(model);
        }

        public ActionResult List(ArtworkSearchCriteria criteria)
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
