using Art.BussinessLogic;
using Art.Data.Common;
using Art.Data.Domain;
using Art.Website.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using WebExpress.Core;
using WebExpress.Core.Guards;
using WebExpress.Website.Exceptions;
using Autofac;
using System.IO;
using System.Diagnostics;
using Art.BussinessLogic.Entities;
namespace Art.Website.Controllers
{
    [Authorize]
    public class ArtistController : Controller
    {
        private IArtistBussinessLogic _artistBussinessLogic;
        private IArtworkBussinessLogic _artworkBussinessLogic;
        public ArtistController(IArtistBussinessLogic artistBussinessLogic, IArtworkBussinessLogic artworkBussinessLogic)
        {
            _artistBussinessLogic = artistBussinessLogic;
            _artworkBussinessLogic = artworkBussinessLogic;
        }

        public ActionResult Index()
        {
            return View();
        }

        #region Edit Page
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var artist = _artistBussinessLogic.GetArtist(id);
            Guard.IsNotNull<DataNotFoundException>(artist);

            var model = GetArtistEditModel(artist);

            return View(model);
        }

        public ActionResult Detail(int id)
        {
            var artist = _artistBussinessLogic.GetArtist(id);
            Guard.IsNotNull<DataNotFoundException>(artist);

            var model = ArtistDetailModelTranslator.Instance.Translate(artist);

            return PartialView("_Detail", model);
        }

        public JsonResult Delete(int id)
        {
            var artist = _artistBussinessLogic.GetArtist(id);
            if (artist.IsPublic)
            {
                return Json(new ResultModel(false, "该艺术家已发布，不能删除！"));
            }

            if (artist.Artworks.Any())
            {
                return Json(new ResultModel(false, "该艺术家有作品，不能删除！"));
            }
            _artistBussinessLogic.Delete(artist);
            var model = new ResultModel(true, string.Empty);
            return Json(model);
        }

        public JsonResult Publish(int id)
        {
            var artist = _artistBussinessLogic.GetArtist(id);
            artist.IsPublic = true;
            _artistBussinessLogic.Update(artist);
            var model = new ResultModel(true, string.Empty);
            return Json(model);
        }

        public JsonResult UnPublish(int id)
        {
            var artist = _artistBussinessLogic.GetArtist(id);
            if (artist.Artworks.Any(i => i.IsPublic))
            {
                return Json(new ResultModel(false, "该艺术家有已发布的作品，不能删除！"));
            }

            artist.IsPublic = false;
            _artistBussinessLogic.Update(artist);

            return Json(new ResultModel(true, string.Empty));
        }

        public ViewResult Add()
        {
            var artist = new Artist();
            var model = GetArtistEditModel(artist);
            return View("Edit", model);
        }

        [HttpPost]
        //添加艺术家
        public JsonResult Add(ArtistModel model)
        {
            string errormagess;
            if (!CheckArtistModel(model, out errormagess))
            {
                return Json(new ResultModel(false, errormagess, 0));
            }

            var artist = ArtistTranslator.Instance.Translate(model);

            var newArtist = _artistBussinessLogic.Add(artist);

            var result = new ResultModel(true, "add successfully!", newArtist.Id);
            return Json(result);
            //return Json(new ResultModel(true, "add successfully!", 1));
        }


        [HttpPost]
        public JsonResult Update(ArtistModel model)
        {
            string errormagess;
            if (!CheckArtistModel(model, out errormagess))
            {
                return Json(new ResultModel(false, errormagess, 0));
            }
            var artist = ArtistTranslator.Instance.Translate(model);

            _artistBussinessLogic.Update(artist);

            var result = new ResultModel(true, "update successfully!");

            return Json(result);
        }
        private Artist GetArtistInfo(ArtistModel from)
        {
            var logic = DependencyResolver.Current.GetService<IArtistBussinessLogic>();
            Artist to = from.Id > 0 ? logic.GetArtist(from.Id) : new Artist();
            to.Gender = from.Gender;
            to.Name = from.Name;
            to.Birthday = from.Birthday;
            to.Deathday = from.Deathday;
            to.Degree = from.Degree;
            to.School = from.School;
            to.PrizeItems = from.PrizeItems;
            to.Masterpiece = from.Masterpiece;
            to.MasterpieceTypeId = from.MasterpieceTypeId;
            if (!string.IsNullOrEmpty(from.AvatarFileName))
            {
                to.AvatarFileName = Path.GetFileName(from.AvatarFileName);
            }

            to.ArtistTypes = logic.GetArtistTypes(from.ArtistTypeIds);
            to.SkilledGenres = logic.GetSkilledGenres(from.SkilledGenreIds);
            //Thread.Sleep(3000);
            return to;
        }
        /// <summary>
        /// Checks the artist model.
        /// </summary>
        /// <param name="model">The model</param>
        /// <param name="errormagess">The errormagess</param>
        /// <returns>
        /// Boolean
        /// </returns>
        /// 创建者：黄磊
        /// 创建日期：5/13/2014 11:09 AM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public bool CheckArtistModel(ArtistModel model, out string errormagess)
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
                //非空验证
                if (string.IsNullOrEmpty(model.Name))
                {
                    errormagess = "请填写姓名！";
                    ret = false;
                }
                if (model.Name.Trim().Length == 0)
                {
                    errormagess = "请填写姓名！";
                    ret = false;
                }
                else if (model.Birthday == null)
                {
                    errormagess = "请填写出生日期";
                    ret = false;
                }
                else if (model.Deathday != null && model.Birthday >= model.Deathday)
                {
                    errormagess = "出生日期大于卒日期";
                    ret = false;
                }
                else if (string.IsNullOrEmpty(model.PrizeItems))
                {
                    errormagess = "请填写得过奖项 ";
                    ret = false;
                }
                else if (model.PrizeItems.Trim().Length == 0)
                {
                    errormagess = "请填写得过奖项 ";
                    ret = false;
                }
                else if (model.ArtistTypeIds.Count == 0)
                {
                    errormagess = "请选择流派 ";
                    ret = false;
                }
                else if (model.SkilledGenreIds.Count == 0)
                {
                    errormagess = "请选择擅长 ";
                    ret = false;
                }
                else if (string.IsNullOrEmpty(model.Masterpiece))
                {
                    errormagess = "请填写代表作品 ";
                    ret = false;
                }
                else if (model.Masterpiece.Trim().Length == 0)
                {
                    errormagess = "请填写代表作品 ";
                    ret = false;
                }
                else if (model.MasterpieceTypeId == 0)
                {
                    errormagess = "请选择作品分类 ";
                    ret = false;
                }
                else if (string.IsNullOrEmpty(model.AvatarFileName))
                {
                    errormagess = "请选择作者头像 ";
                    ret = false;
                }
                else if (model.AvatarFileName.Trim().Length == 0)
                {
                    errormagess = "请选择作者头像 ";
                    ret = false;
                }
                //长度验证
                //else if (model.Name.Length > 30)
                //{
                //    errormagess = "姓名必须在30个字符以内 ";
                //    ret = false;
                //}
                //else if (model.PrizeItems.Length > 30)
                //{
                //    errormagess = "得过奖项必须在30个字符以内 ";
                //    ret = false;
                //}
            }
            return ret;
        }
        #endregion

        #region List Page
        public ActionResult List(ArtistSearchCriteriaModel criteria)
        {
            var model = GetPagedArtistModel(criteria);
            return PartialView("_List", model);
        }

        private PagedArtistModel GetPagedArtistModel(ArtistSearchCriteriaModel model)
        {
            var artistItems = new List<ArtistItem>();
            var criteria = new ArtistSearchCriteria(model.PagingRequest)
            {
                ArtistTypeId = model.ArtistTypeId,
                NamePart = model.NamePart
            };
            var pagedArtists = _artistBussinessLogic.SearchArtists(criteria);
            foreach (var item in pagedArtists)
            {
                var artist = ArtistItemTranslator.Instance.Translate(item);
                artist.CanUnPublish = true;// _artistBussinessLogic.CanUnpublish(item);
                artistItems.Add(artist);
            }

            var result = new PagedArtistModel(artistItems, pagedArtists.PagingResult);
            return result;
        }

        [HttpGet]
        public ActionResult List()
        {
            var model = new ArtistManageModel();

            var defaultCriteria = new ArtistSearchCriteriaModel(10);
            model.PagedArtists = GetPagedArtistModel(defaultCriteria);

            var types = _artistBussinessLogic.GetArtistTypes();
            model.ArtistTypes = ArtistTypeTranslator.Instance.Translate(types).ToList();

            return View(model);
        }


        private ArtistEditModel GetArtistEditModel(Artist artist)
        {
            var artistTypes = _artistBussinessLogic.GetArtistTypes();
            var genres = _artistBussinessLogic.GetGenres();
            var artworkTypes = _artworkBussinessLogic.GetArtworkTypes();
            var model = new ArtistEditModel
            {
                Artist = ArtistTranslator.Instance.Translate(artist),
                SourceArtistTypes = ArtistTypeTranslator.Instance.Translate(artistTypes).ToArray(),
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
            var models = GetArtistTypesModel();
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
        public PartialViewResult ArtistTypeList()
        {
            var artworkTypes = GetArtistTypesModel();
            return PartialView("_TypesList", artworkTypes);
        }

        /// 创建者：黄磊
        /// 创建日期：5/9/2014 3:59 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        private IList<ArtistTypeModel> GetArtistTypesModel()
        {
            var types = _artistBussinessLogic.GetArtistTypes();
            var models = ArtistTypeTranslator.Instance.Translate(types);
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
        public JsonResult AddArtistType(ArtistTypeModel model)
        {
            var artist = ArtistTypeTranslator.Instance.Translate(model);

            if (_artistBussinessLogic.GetArtistTypeByName(model.Name) != null)
            {
                return Json(new ResultModel(false, "已存在相同名称的分类!"));
            }
            _artistBussinessLogic.Add(artist);

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
        public JsonResult UpdateArtistType(ArtistTypeModel model)
        {
            var artistType = ArtistTypeTranslator.Instance.Translate(model);

            var ret = _artistBussinessLogic.GetArtistTypeByName(model.Name);
            if (ret != null && ret.Id != model.Id)
            {
                return Json(new ResultModel(false, "已存在相同名称的分类!"));
            }
            _artistBussinessLogic.UpdateArtistType(artistType);

            var result = new ResultModel(true, "update successfully!");

            return Json(result);
        }

        /// 创建者：黄磊
        /// 创建日期：5/9/2014 5:33 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        [HttpPost]
        public JsonResult DeleteArtistType(int id)
        {
            var artistType = _artistBussinessLogic.GetArtistType(id);
            if (artistType.Artists.Count > 0)
            {
                return Json(new ResultModel(false, "请将该分类下的艺术家全部删除后，方可进行分类的删除~"));
            }
            _artistBussinessLogic.DeleteArtistType(artistType);

            var result = new ResultModel(true, "Delete successfully!");

            return Json(result);
        }

        #endregion
    }
}
