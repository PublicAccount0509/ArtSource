using System;
namespace Art.BussinessLogic
{
   public  interface IArtworkBussinessLogic
    {
        void Add(Art.Data.Domain.Artwork artwork);
        void AddArtworkType(Art.Data.Domain.ArtworkType artworkType);
        void CancelCollect(int artworkId, int customerId);
        bool CanDeleteArtworkType(Art.Data.Domain.ArtworkType artworkType, out System.Collections.Generic.List<string> reasons);
        Art.Data.Domain.ActivityCollect Collect(int artworkId, int customerId);
        void Delete(Art.Data.Domain.Artwork artwork);
        bool DeleteArtworkType(Art.Data.Domain.ArtworkType artworkType);
        System.Collections.Generic.IList<Art.Data.Domain.Artwork> DeveryWays(int[] artworkIds);
        bool Exist(int id);
        bool ExistCollect(int artworkId, int customerId);
        bool ExistPraise(int artworkId, int customerId);
        bool ExistShare(int artworkId, int customerId);
        Art.Data.Domain.ArtMaterial GetArtMaterial(int id);
        System.Collections.Generic.ICollection<Art.Data.Domain.ArtPlace> GetArtPlaces(System.Collections.Generic.List<int> ids);
        Art.Data.Domain.ArtShape GetArtShape(int id);
        Art.Data.Domain.ArtTechnique GetArtTechnique(int id);
        Art.Data.Domain.Artwork GetArtwork(int id);
        System.Collections.Generic.IList<Art.Data.Domain.Artwork> GetArtworks();
        Art.Data.Domain.Artwork[] GetArtworksByArtistId(int artistId);
        Art.Data.Domain.ArtworkType GetArtworkType(int id);
        Art.Data.Domain.ArtworkType GetArtworkTypeByName(string name);
        System.Collections.Generic.List<Art.Data.Domain.ArtworkType> GetArtworkTypes();
        int GetCollectCount(int artworkId);
        System.Collections.Generic.ICollection<Art.Data.Domain.ArtPlace> GetPlaces();
        int GetPraiseCount(int artworkId);
        int GetShareCount(int artworkId);
        Art.Data.Domain.ActivityPraise Praise(int artworkId, int customerId);
        WebExpress.Core.PagedList<Art.Data.Domain.Artwork> SearchArtworks(string namePart, int? artworkTypeId, int? artMaterialId, int? artistId, WebExpress.Core.PagingRequest paging);
        WebExpress.Core.PagedList<Art.Data.Domain.Artwork> SearchArtworks(WebExpress.Core.PagingRequest paging);
        Art.Data.Domain.ActivityShare Share(int artworkId, int customerId);
        void Update(Art.Data.Domain.Artwork artwork);
        void UpdateArtworkType(Art.Data.Domain.ArtworkType artworkType);
    }
}
