using Art.Data.Domain;
using Art.Data.Domain.Access;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        private ArtworkBussinessLogic()
        {
            _artworkTypeRepository = new EfRepository<ArtworkType>();
            _artworkRepository = new EfRepository<Artwork>();
            _artMaterialRepository = new EfRepository<ArtMaterial>();
            _artShapeRepository = new EfRepository<ArtShape>();
            _artTechniqueRepository = new EfRepository<ArtTechnique>();
            //_artPeriodRepository = new EfRepository<ArtPeriod>();
            _artPlaceRepository = new EfRepository<ArtPlace>();
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

            var artworks =_artworkRepository.Table.Where(i=>i.ArtworkType.Id == artworkType.Id);
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

        public Artwork GetArtwork(int id)
        {
            var artwork = _artworkRepository.GetById(id);
            return artwork;
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
            _artworkRepository.Insert(artwork);
        }

        public void Update(Artwork artwork)
        {
            _artworkRepository.Update(artwork);
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

    }
}
