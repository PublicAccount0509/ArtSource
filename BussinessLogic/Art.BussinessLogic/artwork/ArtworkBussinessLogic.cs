using Art.BussinessLogic.Entities;
using Art.Common;
using Art.Data.Common;
using Art.Data.Domain;
using Art.Data.Domain.Access;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using WebExpress.Core;
using WebExpress.Core.Guards;

namespace Art.BussinessLogic
{
    public class ArtworkBussinessLogic : IArtworkBussinessLogic
    {
        //public static readonly ArtworkBussinessLogic Instance = new ArtworkBussinessLogic();

        private IRepository<ArtworkType> _artworkTypeRepository;
        private IRepository<Artwork> _artworkRepository;
        private IRepository<Comment> _commentRepository;
        private IRepository<ArtMaterial> _artMaterialRepository;
        private IRepository<ArtShape> _artShapeRepository;
        private IRepository<ArtTechnique> _artTechniqueRepository;
        private IRepository<ArtPlace> _artPlaceRepository;
        private IRepository<ActivityShare> _activityShareRepository;
        private IRepository<ActivityCollect> _activityCollectRepository;
        private IRepository<ActivityPraise> _activityPraiseRepository;
        private IRepository<ShoppingCartItem> _shoppingCartRepository;

        public ArtworkBussinessLogic(IRepository<ArtworkType> artworkTypeRepository,
            IRepository<Artwork> artworkRepository,
            IRepository<ArtMaterial> artMaterialRepository,
            IRepository<ArtShape> artShapeRepository,
            IRepository<ArtTechnique> artTechniqueRepository,
            IRepository<ArtPlace> artPlaceRepository,
            IRepository<ActivityShare> activityShareRepository,
            IRepository<ActivityCollect> activityCollectRepository,
            IRepository<ActivityPraise> activityPraiseRepository,
            IRepository<Comment> commentRepository,
            IRepository<ShoppingCartItem> shoppingCartRepository
        )
        {
            _artworkTypeRepository = artworkTypeRepository;
            _artworkRepository = artworkRepository;
            _artMaterialRepository = artMaterialRepository;
            _artShapeRepository = artShapeRepository;
            _artTechniqueRepository = artTechniqueRepository;
            _artPlaceRepository = artPlaceRepository;
            _activityShareRepository = activityShareRepository;
            _activityCollectRepository = activityCollectRepository;
            _activityPraiseRepository = activityPraiseRepository;
            _commentRepository = commentRepository;
            _shoppingCartRepository = shoppingCartRepository;
        }

        public List<ArtworkType> GetArtworkTypes()
        {
            var types = _artworkTypeRepository.Table.ToList();


            var types2 = _artworkTypeRepository.Table.ToList();

            return types;
        }

        public ArtworkType GetArtworkType(int id)
        {
            return _artworkTypeRepository.GetById(id);
        }

        public ArtworkType GetArtworkTypeByName(string name)
        {
            var query = _artworkTypeRepository.Table.Where(i => i.Name == name);
            return query.FirstOrDefault();
        }

        public void AddArtworkType(ArtworkType artworkType)
        {
            _artworkTypeRepository.Insert(artworkType);
        }

        public void UpdateArtworkType(ArtworkType artworkType)
        {
            _artworkTypeRepository.Update(artworkType);
        }

        public bool CanDeleteArtworkType(ArtworkType artworkType, out List<string> reasons)
        {
            reasons = new List<string>();
            if (artworkType.Name == "漫画")
            {
                reasons.Add("cartoon can not be deleted!");
                return false;
            }

            var artworks = _artworkRepository.Table.Where(i => i.ArtworkType.Id == artworkType.Id);
            if (artworks.Any())
            {
                reasons.Add("该分类已被使用，不能删除！");
                return false;
            }

            return true;
        }

        public bool DeleteArtworkType(ArtworkType artworkType)
        {
            _artworkTypeRepository.Delete(artworkType);
            return true;
        }

        public bool Exist(int id)
        {
            return GetArtwork(id) != null;
        }

        public Artwork GetArtwork(int id)
        {
            var artwork = _artworkRepository.GetById(id);
            return artwork;
        }

        /// <summary>
        /// Gets the artworks.
        /// </summary>
        /// <returns>
        /// IList{Artwork}
        /// </returns>
        /// 创建者：黄磊
        /// 创建日期：5/12/2014 1:35 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public IList<Artwork> GetArtworks()
        {
            var artworks = _artworkRepository.Table.ToList();
            return artworks;
        }

        public IList<Artwork> GetArtworks(int[] ids)
        {
            var artworks = _artworkRepository.Table.Where(i => ids.Contains(i.Id)).ToList();
            return artworks;
        }

        public ArtMaterial GetArtMaterial(int id)
        {
            return _artMaterialRepository.GetById(id);
        }

        public ArtShape GetArtShape(int id)
        {
            return _artShapeRepository.GetById(id);
        }

        public ArtTechnique GetArtTechnique(int id)
        {
            return _artTechniqueRepository.GetById(id);
        }

        //public ArtPeriod GetPeriod(int id)
        //{
        //    return _artPeriodRepository.GetById(id);
        //}

        //public ICollection<ArtPeriod> GetPeriods()
        //{
        //    return _artPeriodRepository.Table.ToList();
        //}

        public ICollection<ArtPlace> GetArtPlaces()
        {
            return _artPlaceRepository.Table.ToList();
        }


        public ICollection<ArtPlace> GetArtPlaces(List<int> ids)
        {
            if (ids == null)
            {
                return null;
            }

            var query = from p in _artPlaceRepository.Table
                        where ids.Contains(p.Id)
                        select p;
            return query.ToList();
        }

        public void Add(Artwork artwork)
        {
            artwork.IsPublic = true;

            while (true)
            {
                //产生作品的8位身份证号, 第一位是1，后面的随机
                var strIdNumber = "1" + new Random().Next(9999999).ToString("D7");
                var idNumber = Int32.Parse(strIdNumber);
                if (_artworkRepository.Table.Any(i => i.IdentityNumber == idNumber))
                {
                    continue;
                }
                artwork.IdentityNumber = idNumber;
                break;
            }

            var imageFullFileName = CommonHelper.GetUploadFileAbsolutePath(artwork.ImageFileName);
            var images = BussinessLogicHelper.GenerateImages<ArtworkImageResizeType>(imageFullFileName);
            artwork.Images = ImageInfosTranslator.Instance.TranslateToArtworkImage(images);

            _artworkRepository.Insert(artwork);
        }

        public void Update(Artwork artwork)
        {
            var isImageChanged = !artwork.Images.First().ImagePath.Contains(Path.GetFileNameWithoutExtension(artwork.ImageFileName));
            if (isImageChanged)
            {
                var imageFullFileName = CommonHelper.GetUploadFileAbsolutePath(artwork.ImageFileName);
                var images = BussinessLogicHelper.GenerateImages<ArtworkImageResizeType>(imageFullFileName);
                artwork.Images = ImageInfosTranslator.Instance.TranslateToArtworkImage(images);
            }
            _artworkRepository.Update(artwork);
        }

        public PagedList<Artwork> SearchArtworks(ArtworkSearchCriteria criteria)
        {
            Guard.IsNotNull<ArgumentNullException>(criteria.PagingRequest, "PagingRequest");
            var hasOrdered = false;
            var query = _artworkRepository.Table;
            if (!string.IsNullOrEmpty(criteria.NamePart))
            {
                query = query.Where(i => i.Name.Contains(criteria.NamePart));
            }

            if (criteria.ArtworkTypeId.HasValue)
            {
                query = query.Where(i => i.ArtworkType.Id == criteria.ArtworkTypeId.Value);
            }

            if (criteria.ArtMaterialId.HasValue)
            {
                query = query.Where(i => i.ArtMaterial.Id == criteria.ArtMaterialId.Value);
            }

            if (criteria.ArtistId.HasValue)
            {
                query = query.Where(i => i.Artist.Id == criteria.ArtistId.Value);
            }

            if (criteria.BeginYear.HasValue)
            {
                query = query.Where(i => i.ArtYear >= criteria.BeginYear.Value);
            }

            if (criteria.EndYear.HasValue)
            {
                query = query.Where(i => i.ArtYear <= criteria.EndYear.Value);
            }

            if (criteria.MinPrice.HasValue)
            {
                query = query.Where(i => i.AuctionPrice >= criteria.MinPrice.Value);
            }

            if (criteria.MaxPrice.HasValue)
            {
                query = query.Where(i => i.AuctionPrice <= criteria.MaxPrice.Value);
            }

            if (criteria.FromDate.HasValue)
            {
                query = query.Where(i => i.FADateTime >= criteria.FromDate);
            }

            if (criteria.CollectionCustomerId.HasValue)
            {
                query = from a in query
                        join ac in _activityCollectRepository.Table
                        on a.Id equals ac.ArtworkId
                        where ac.CustomerId == criteria.CollectionCustomerId.Value
                        orderby ac.Id descending
                        select a;

                hasOrdered = true;
            }

            if (criteria.PraiseCustomerId.HasValue)
            {
                query = from a in query
                        join ap in _activityPraiseRepository.Table
                        on a.Id equals ap.ArtworkId
                        where ap.CustomerId == criteria.PraiseCustomerId.Value
                        orderby ap.Id descending
                        select a;
            }

            var firstOrderByItem = criteria.OrderByItems.FirstOrDefault();
            if (firstOrderByItem == null && !hasOrdered)
            {
                firstOrderByItem = new OrderByItem<Artwork>(i => i.Id, SortOrder.Descending);
            }

            if (firstOrderByItem !=null)
            { 
                if (hasOrdered)
                {
                    query = (query as IOrderedQueryable<Artwork>).ThenObjectSort(firstOrderByItem.KeySelector, firstOrderByItem.Direction);
                }
                else
                {
                    query = query.ObjectSort(firstOrderByItem.KeySelector, firstOrderByItem.Direction);
                }
            }

            var orderedQuery = query as IOrderedQueryable<Artwork>;

            for (int i = 1; i < criteria.OrderByItems.Count; i++)
            {
                var item = criteria.OrderByItems[i];

                orderedQuery = orderedQuery.ThenObjectSort(item.KeySelector, firstOrderByItem.Direction);
            }

            var result = new PagedList<Artwork>(orderedQuery, criteria.PagingRequest.PageIndex, criteria.PagingRequest.PageSize);

            return result;
        }

        private PagedList<Artwork> SearchArtworks(string namePart, int? artworkTypeId, int? artMaterialId, int? artistId, PagingRequest paging)
        {
            Guard.IsNotNull<ArgumentNullException>(paging, "paging");

            var query = _artworkRepository.Table;
            if (!string.IsNullOrEmpty(namePart))
            {
                query = query.Where(i => i.Name.Contains(namePart));
            }

            if (artworkTypeId.HasValue)
            {
                query = query.Where(i => i.ArtworkType.Id == artworkTypeId);
            }

            if (artMaterialId.HasValue)
            {
                query = query.Where(i => i.ArtMaterial.Id == artMaterialId);
            }

            if (artistId.HasValue)
            {
                query = query.Where(i => i.Artist.Id == artistId);
            }

            query = query.OrderBy(i => i.Id);

            var result = new PagedList<Artwork>(query, paging.PageIndex, paging.PageSize);

            return result;
        }

        public void Delete(Artwork artwork)
        {
            foreach (var comment in artwork.Comments)
            {
                _commentRepository.Delete(comment);
            }
            _artworkRepository.Delete(artwork);
        }

        /// <summary>
        /// Exists the share.
        /// </summary>
        /// <param name="artworkId">The artworkId</param>
        /// <param name="customerId">The customerId</param>
        /// <returns>
        /// Boolean
        /// </returns>
        /// 创建者：黄磊
        /// 创建日期：5/14/2014 6:38 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public bool ExistShare(int artworkId, int customerId)
        {
            return _activityShareRepository.Table.Any(p => p.ArtworkId == artworkId && p.CustomerId == customerId);
        }

        public ActivityShare Share(int artworkId, int customerId)
        {
            var entity = new ActivityShare();
            entity.ArtworkId = artworkId;
            entity.CustomerId = customerId;
            entity.FADatetime = DateTime.Now;
            var result = _activityShareRepository.Insert(entity);
            return result;
        }

        public int GetSharedCount(int artworkId)
        {
            return _activityShareRepository.Table.Count(i => i.ArtworkId == artworkId);
        }

        public ActivityCollect Collect(int artworkId, int customerId)
        {
            var entity = new ActivityCollect();
            entity.ArtworkId = artworkId;
            entity.CustomerId = customerId;
            entity.FADatetime = DateTime.Now;
            var result = _activityCollectRepository.Insert(entity);
            return result;
        }

        public void CancelCollect(int artworkId, int customerId)
        {
            var entity = _activityCollectRepository.Table.Where(i => i.ArtworkId == artworkId && i.CustomerId == customerId).FirstOrDefault();
            _activityCollectRepository.Delete(entity);
        }

        public int GetCollectedCount(int artworkId)
        {
            var count = _activityCollectRepository.Table.Where(i => i.ArtworkId == artworkId).Count();
            return count;
        }


        public int GetCollectCount(int customerId)
        {
            var count = _activityCollectRepository.Table.Where(i => i.CustomerId == customerId).Count();
            return count;
        }

        public int GetPraiseCount(int customerId)
        {
            var count = _activityPraiseRepository.Table.Where(i => i.CustomerId == customerId).Count();
            return count;
        }

        public int GetShareCount(int customerId)
        {
            var count = _activityShareRepository.Table.Where(i => i.CustomerId == customerId).Count();
            return count;
        }

        public bool ExistPraise(int artworkId, int customerId)
        {
            var query = _activityPraiseRepository.Table.Where(i => i.ArtworkId == artworkId && i.CustomerId == customerId);
            return query.Any();
        }

        public ActivityPraise Praise(int artworkId, int customerId)
        {
            var entity = new ActivityPraise();
            entity.ArtworkId = artworkId;
            entity.CustomerId = customerId;
            entity.FADatetime = DateTime.Now;
            var result = _activityPraiseRepository.Insert(entity);
            return result;
        }
        public void CancelPraise(int artworkId, int customerId)
        {
            var entity = _activityPraiseRepository.Table.Where(i => i.ArtworkId == artworkId && i.CustomerId == customerId).FirstOrDefault();
            _activityPraiseRepository.Delete(entity);
        }

        public bool ExistCollect(int artworkId, int customerId)
        {
            return _activityCollectRepository.Table.Any(p => p.ArtworkId == artworkId && p.CustomerId == customerId);
        }

        public int GetPraisedCount(int artworkId)
        {
            var count = _activityPraiseRepository.Table.Where(i => i.ArtworkId == artworkId).Count();
            return count;
        }

        /// <summary>
        /// Gets the artworks by artist identifier.
        /// </summary>
        /// <param name="artistId">The artistId</param>
        /// <returns>
        /// Artwork[][]
        /// </returns>
        /// 创建者：黄磊
        /// 创建日期：5/14/2014 2:22 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public Artwork[] GetArtworksByArtistId(int artistId)
        {
            return _artworkRepository.Table.Where(p => p.Artist.Id == artistId).ToArray();
        }

        public int GetCommentCount(int customerId)
        {
            var count = _commentRepository.Table.Where(i => i.CustomerId == customerId).Count();
            return count;
        }

        public IList<Comment> GetComments(int customerId)
        {
            return _commentRepository.Table.Where(i => i.Customer.Id == customerId).ToList();
        }

        public Comment AddComment(Comment comment)
        {
            comment.FADateTime = DateTime.Now;
            var result = _commentRepository.Insert(comment);
            return result;
        }

        //public IList<Artwork> DeveryWays(int[] artworkIds)
        //{
        //    var artworks = _artworkRepository.Table;
        //    //先遍历参数Id
        //    return (from artworkId in artworkIds
        //            //用id去查找实体
        //            let art = (from artwork in artworks where artwork.Id == artworkId select artwork).FirstOrDefault()
        //            //实体不为空返回实体
        //            where art != null
        //            select art
        //           ).ToList();
        //}
    }
}
