using Art.BussinessLogic;
using Art.Data.Common;
using Art.Data.Domain;
using Art.Website.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebExpress.Core;
using WebExpress.Core.Guards;
using WebExpress.Core.TypeExtensions;
using WebExpress.Website.Exceptions;

namespace Art.Website.Controllers
{
    //[Authorize]
    public class ArtistController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        #region Edit Page
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var artist = Art.BussinessLogic.ArtistBussinessLogic.Instance.GetArtist(id);
            Guard.IsNotNull<DataNotFoundException>(artist);

            var model = GetArtistEditModel(artist);

            return View(model);
        }

        public ActionResult Detail(int id)
        {
            var artist = Art.BussinessLogic.ArtistBussinessLogic.Instance.GetArtist(id);
            Guard.IsNotNull<DataNotFoundException>(artist);

            var model = ArtistDetailModelTranslator.Instance.Translate(artist);

            return PartialView("_Detail", model);
        }

        public JsonResult Delete(int id)
        {
            var artist = Art.BussinessLogic.ArtistBussinessLogic.Instance.GetArtist(id);
            Art.BussinessLogic.ArtistBussinessLogic.Instance.Delete(artist);
            var model = new ResultModel(true, string.Empty);
            return Json(model);
        }

        public JsonResult Publish(int id)
        {
            var artist = Art.BussinessLogic.ArtistBussinessLogic.Instance.GetArtist(id);
            artist.IsPublic = true;
            Art.BussinessLogic.ArtistBussinessLogic.Instance.Update(artist);
            var model = new ResultModel(true, string.Empty);
            return Json(model);
        }

        public JsonResult UnPublish(int id)
        {
            var artist = Art.BussinessLogic.ArtistBussinessLogic.Instance.GetArtist(id);
            List<string> reasons;
            var model = new ResultModel(true, string.Empty);
            if (Art.BussinessLogic.ArtistBussinessLogic.Instance.CanUnpublish(artist, out reasons))
            {
                artist.IsPublic = false;
                Art.BussinessLogic.ArtistBussinessLogic.Instance.Update(artist);
            }
            else
            {
                model = new ResultModel(false, string.Join(",", reasons));
            }
            return Json(model);
        }


        public ViewResult Add()
        {
            var artist = new Artist();
            var model = GetArtistEditModel(artist);
            return View("Edit", model);
        }

        [HttpPost]
        public JsonResult Add(ArtistModel model)
        {
            var artist = ArtistTranslator.Instance.Translate(model);


            var newArtist = ArtistBussinessLogic.Instance.Add(artist);

            var result = new ResultModel(true, "add successfully!", newArtist.Id);
            return Json(result);
        }

        [HttpPost]
        public JsonResult Update(ArtistModel model)
        {
            var artist = ArtistTranslator.Instance.Translate(model);

            ArtistBussinessLogic.Instance.Update(artist);

            var result = new ResultModel(true, "update successfully!");

            return Json(result);
        }
        #endregion

        #region List Page
        public ActionResult List(ArtistSearchCriteria criteria)
        {
            var model = GetPagedArtistModel(criteria);
            return PartialView("_List", model);
        }

        private PagedArtistModel GetPagedArtistModel(ArtistSearchCriteria criteria)
        {
            var artistItems = new List<ArtistItem>();
            var pagedArtists = ArtistBussinessLogic.Instance.SearchArtists(criteria.NamePart, criteria.ProfessionId, criteria.PagingRequest);
            foreach (var item in pagedArtists)
            {
                var artist = ArtistItemTranslator.Instance.Translate(item);
                artist.CanUnPublish = Art.BussinessLogic.ArtistBussinessLogic.Instance.CanUnpublish(item);
                artistItems.Add(artist);
            }

            var model = new PagedArtistModel(artistItems, pagedArtists.PagingResult);
            return model;
        }

        [HttpGet]
        public ActionResult List()
        {
            var model = new ArtistManageModel();

            var defaultCriteria = new ArtistSearchCriteria(10);
            model.PagedArtists = GetPagedArtistModel(defaultCriteria);

            var professions = ArtistBussinessLogic.Instance.GetProfessions();
            model.Professions = ProfessionTranslator.Instance.Translate(professions).ToList();

            return View(model);
        }


        private ArtistEditModel GetArtistEditModel(Artist artist)
        {
            var professions = Art.BussinessLogic.ArtistBussinessLogic.Instance.GetProfessions();
            var genres = Art.BussinessLogic.ArtistBussinessLogic.Instance.GetGenres();
            var artworkTypes = Art.BussinessLogic.ArtworkBussinessLogic.Instance.GetArtworkTypes();
            var model = new ArtistEditModel
            {
                Artist = ArtistTranslator.Instance.Translate(artist),
                SourceProfessions = ProfessionTranslator.Instance.Translate(professions).ToArray(),
                SourceGenres = GenreTranslator.Instance.Translate(genres).ToArray(),
                Degrees = EnumExtenstion.GetEnumItems<Degree>(),
                ArtworkTypes = IdNameModelTranslator<ArtworkType>.Instance.Translate(artworkTypes).ToArray()
            };
            return model;
        }
        #endregion

        #region Types Page
        /// <summary>
        /// The method will 
        /// </summary>
        /// <returns>
        /// The ActionResult
        /// </returns>
        /// 创建者：黄磊
        /// 创建日期：5/9/2014 3:59 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public ActionResult Types()
        {
            var models = GetTypesModel();
            return View(models);
        }
        /// <summary>
        /// Arts the types.
        /// </summary>
        /// <returns>
        /// PartialViewResult
        /// </returns>
        /// 创建者：黄磊
        /// 创建日期：5/9/2014 3:59 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public PartialViewResult ProfessionList()
        {
            var artworkTypes = GetTypesModel();
            return PartialView("_TypesList", artworkTypes);
        }

        /// <summary>
        /// Gets the types model.
        /// </summary>
        /// <returns>
        /// IList{ProfessionModel}
        /// </returns>
        /// 创建者：黄磊
        /// 创建日期：5/9/2014 3:59 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        private IList<ProfessionModel> GetTypesModel()
        {
            var professions = ArtistBussinessLogic.Instance.GetProfessions();
            var models = ProfessionTranslator.Instance.Translate(professions);
            return models;
        }

        /// <summary>
        /// The method will 
        /// </summary>
        /// <param name="model">The model</param>
        /// <returns>
        /// The JsonResult
        /// </returns>
        /// 创建者：黄磊
        /// 创建日期：5/9/2014 12:55 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        [HttpPost]
        public JsonResult AddProfession(ProfessionModel model)
        {
            var profession = ProfessionTranslator.Instance.Translate(model);

            if (ArtistBussinessLogic.Instance.GetProfessionByName(model.Name) != null)
            {
                return Json(new ResultModel(false, "已存在相同名称的分类!"));
            }
            ArtistBussinessLogic.Instance.Add(profession);

            var result = new ResultModel(true, "add successfully!");
            return Json(result);
        }

        /// <summary>
        /// The method will 
        /// </summary>
        /// <param name="model">The model</param>
        /// <returns>
        /// The JsonResult
        /// </returns>
        /// 创建者：黄磊
        /// 创建日期：5/9/2014 12:55 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        [HttpPost]
        public JsonResult UpdateProfession(ProfessionModel model)
        {
            var profession = ProfessionTranslator.Instance.Translate(model);

            var ret = ArtistBussinessLogic.Instance.GetProfessionByName(model.Name);
            if (ret != null && ret.Id != model.Id)
            {
                return Json(new ResultModel(false, "已存在相同名称的分类!"));
            }
            ArtistBussinessLogic.Instance.UpdateProfession(profession);

            var result = new ResultModel(true, "update successfully!");

            return Json(result);
        }
        /// <summary>
        /// Deletes the profession.
        /// </summary>
        /// <param name="id">The id</param>
        /// <returns>
        /// JsonResult
        /// </returns>
        /// 创建者：黄磊
        /// 创建日期：5/9/2014 5:33 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        [HttpPost]
        public JsonResult DeleteProfession(int id)
        {
            var profession = ArtistBussinessLogic.Instance.GetProfession(id);
            if (profession.Artists.Count > 0)
            {
                return Json(new ResultModel(false, "请将该分类下的艺术家全部删除后，方可进行分类的删除~"));
            }
            ArtistBussinessLogic.Instance.DeleteProfession(profession);

            var result = new ResultModel(true, "Delete successfully!");

            return Json(result);
        }
        
        #endregion
    }
}
