using Art.Common;
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
    public class ArtworkBussinessLogic
    {
        public static readonly ArtworkBussinessLogic Instance = new ArtworkBussinessLogic();

        private readonly IRepository<ArtworkType> _artworkTypeRepository;
        private readonly IRepository<Artwork> _artworkRepository;
        private readonly IRepository<ArtMaterial> _artMaterialRepository;
        private readonly IRepository<ArtShape> _artShapeRepository;
        private readonly IRepository<ArtTechnique> _artTechniqueRepository;
        //private readonly IRepository<ArtPeriod> _artPeriodRepository;
        private readonly IRepository<ArtPlace> _artPlaceRepository;
        private readonly IRepository<ActivityShare> _activityShareRepository;
        private readonly IRepository<ActivityCollect> _activityCollectRepository;
        private readonly IRepository<ActivityPraise> _activityPraiseRepository;

        private ArtworkBussinessLogic()
        {
            _artworkTypeRepository = new EfRepository<ArtworkType>();
            _artworkRepository = new EfRepository<Artwork>();
            _artMaterialRepository = new EfRepository<ArtMaterial>();
            _artShapeRepository = new EfRepository<ArtShape>();
            _artTechniqueRepository = new EfRepository<ArtTechnique>();
            //_artPeriodRepository = new EfRepository<ArtPeriod>();
            _artPlaceRepository = new EfRepository<ArtPlace>();
            _activityShareRepository = new EfRepository<ActivityShare>();
            _activityCollectRepository = new EfRepository<ActivityCollect>();
            _activityPraiseRepository = new EfRepository<ActivityPraise>();
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

            var fullFileName = CommonHelper.GetUploadFileAbsolutePath(artwork.ImageFileName);
            artwork.Images = GetImages(fullFileName);

            _artworkRepository.Insert(artwork);
        }

        private List<ArtworkImage> GetImages(string imageFullFileName)
        {
            var images = new List<ArtworkImage>();

            var destFullFileName = string.Format("{0}/{1}_{2}{3}", Path.GetDirectoryName(imageFullFileName), Path.GetFileNameWithoutExtension(imageFullFileName), Data.Common.ArtworkImageResizeType.Size_W290_MinH240.ToString(), Path.GetExtension(imageFullFileName));
            var imageSize = ImageTransformer.Instance.ResizeImageToWidth(imageFullFileName, destFullFileName, 290, 240);
            images.Add(new ArtworkImage
            {
                ImagePath = Path.GetFileName(destFullFileName),
                ImageType = Data.Common.ArtworkImageResizeType.Size_W290_MinH240,
                Width = imageSize.Width,
                Height = imageSize.Height
            });

            destFullFileName = string.Format("{0}/{1}_{2}{3}", Path.GetDirectoryName(imageFullFileName), Path.GetFileNameWithoutExtension(imageFullFileName), Data.Common.ArtworkImageResizeType.Size_W600_H420.ToString(), Path.GetExtension(imageFullFileName));
            imageSize = ImageTransformer.Instance.ResizeImageToSize(imageFullFileName, destFullFileName, 600, 420);
            images.Add(new ArtworkImage
            {
                ImagePath = Path.GetFileName(destFullFileName),
                ImageType = Data.Common.ArtworkImageResizeType.Size_W600_H420,
                Width = imageSize.Width,
                Height = imageSize.Height
            });

            return images;
        }

        public void Update(Artwork artwork)
        {
            _artworkRepository.Update(artwork);
        }

        public PagedList<Artwork> SearchArtworks(PagingRequest paging)
        {
            return SearchArtworks(null, null, null, null, paging);
        }

        public PagedList<Artwork> SearchArtworks(string namePart, int? artworkTypeId, int? artMaterialId, int? artistId, PagingRequest paging)
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
    }
}
