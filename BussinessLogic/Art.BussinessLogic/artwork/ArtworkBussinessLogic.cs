using Art.BussinessLogic.Entities;
using Art.Common;
using Art.Data.Common;
using Art.Data.Domain;
using Art.Data.Domain.Access;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using WebExpress.Core;
using WebExpress.Core.Guards;

namespace Art.BussinessLogic
{
    public class ArtworkBussinessLogic : Art.BussinessLogic.IArtworkBussinessLogic
    {
        //public static readonly ArtworkBussinessLogic Instance = new ArtworkBussinessLogic();

        private IRepository<ArtworkType> _artworkTypeRepository;
        private IRepository<Artwork> _artworkRepository;
        private IRepository<ArtMaterial> _artMaterialRepository;
        private IRepository<ArtShape> _artShapeRepository;
        private IRepository<ArtTechnique> _artTechniqueRepository;
        private IRepository<ArtPlace> _artPlaceRepository;
        private IRepository<ActivityShare> _activityShareRepository;
        private IRepository<ActivityCollect> _activityCollectRepository;
        private IRepository<ActivityPraise> _activityPraiseRepository;

        public ArtworkBussinessLogic(IRepository<ArtworkType> artworkTypeRepository,
            IRepository<Artwork> artworkRepository,
            IRepository<ArtMaterial> artMaterialRepository,
            IRepository<ArtShape> artShapeRepository,
            IRepository<ArtTechnique> artTechniqueRepository,
            IRepository<ArtPlace> artPlaceRepository,
            IRepository<ActivityShare> activityShareRepository,
            IRepository<ActivityCollect> activityCollectRepository,
            IRepository<ActivityPraise> activityPraiseRepository
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

        public ICollection<ArtPlace> GetPlaces()
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

            artwork.Images = GetImages(artwork.ImageFileName);

            _artworkRepository.Insert(artwork);
        }

        public void Update(Artwork artwork)
        {
            var isImageChanged = !artwork.Images.First().ImagePath.Contains(Path.GetFileNameWithoutExtension(artwork.ImageFileName));
            if (isImageChanged)
            {
                artwork.Images = GetImages(artwork.ImageFileName);
            }
            _artworkRepository.Update(artwork);
        }

        private List<ArtworkImage> GetImages(string imageFileName)
        {
            var imageFullFileName = CommonHelper.GetUploadFileAbsolutePath(imageFileName);
            var images = new List<ArtworkImage>();

            var enumType = typeof(ArtworkImageResizeType);
            var items = Enum.GetValues(enumType);
            foreach (var item in items)
            {
                var mi = enumType.GetMember(item.ToString()).First();
                var attributes = mi.GetCustomAttributes(false);

                var attribute = attributes.FirstOrDefault(i => typeof(IImageFileTransformer).IsAssignableFrom(i.GetType()));
                if (attribute != null)
                {
                    var transformer = attribute as IImageFileTransformer;
                    var destFullFileName = string.Format("{0}\\{1}_{2}{3}", Path.GetDirectoryName(imageFullFileName), Path.GetFileNameWithoutExtension(imageFullFileName), item.ToString(), Path.GetExtension(imageFullFileName));
                    var size = transformer.Transform(imageFullFileName, destFullFileName);
                    images.Add(new ArtworkImage
                    {
                        ImagePath = Path.GetFileName(destFullFileName),
                        ImageType = (ArtworkImageResizeType)(int)item,
                        Width = size.Width,
                        Height = size.Height
                    });
                }
            }
            return images;
        }

        public PagedList<Artwork> SearchArtworks(ArtworkSearchCriteria criteria)
        {
            Guard.IsNotNull<ArgumentNullException>(criteria.PagingRequest, "PagingRequest");

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

            if (criteria.CollectionCustomerId.HasValue)
            {
                query = from a in query
                        join ac in _activityCollectRepository.Table
                        on a.Id equals ac.ArtworkId
                        where ac.CustomerId == criteria.CollectionCustomerId.Value
                        select a;
            }

            if (criteria.PraiseCustomerId.HasValue)
            {
                query = from a in query
                        join ac in _activityPraiseRepository.Table
                        on a.Id equals ac.ArtworkId
                        where ac.CustomerId == criteria.PraiseCustomerId.Value
                        select a;
            }

            query = query.OrderBy(i => i.Id);

            var result = new PagedList<Artwork>(query, criteria.PagingRequest.PageIndex, criteria.PagingRequest.PageSize);

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

        public int GetShareCount(int artworkId)
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

        public int GetCollectCount(int artworkId)
        {
            var count = _activityShareRepository.Table.Where(i => i.ArtworkId == artworkId).Count();
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


        public bool ExistCollect(int artworkId, int customerId)
        {
            return _activityCollectRepository.Table.Any(p => p.ArtworkId == artworkId && p.CustomerId == customerId);
        }

        public int GetPraiseCount(int artworkId)
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
