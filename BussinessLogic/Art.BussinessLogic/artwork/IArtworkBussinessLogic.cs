using Art.BussinessLogic.Entities;
using Art.Data.Domain;
using System;
using System.Collections.Generic;
using WebExpress.Core;
namespace Art.BussinessLogic
{
    public interface IArtworkBussinessLogic
    {
        void Add(Artwork artwork);
        void AddArtworkType(ArtworkType artworkType);
        void CancelCollect(int artworkId, int customerId);
        bool CanDeleteArtworkType(ArtworkType artworkType, out List<string> reasons);
        ActivityCollect Collect(int artworkId, int customerId);
        void Delete(Artwork artwork);
        bool DeleteArtworkType(ArtworkType artworkType);
        IList<Artwork> DeveryWays(int[] artworkIds);
        bool Exist(int id);
        bool ExistCollect(int artworkId, int customerId);
        bool ExistPraise(int artworkId, int customerId);
        bool ExistShare(int artworkId, int customerId);
        ArtMaterial GetArtMaterial(int id);
        ICollection<Art.Data.Domain.ArtPlace> GetArtPlaces(List<int> ids);
        ArtShape GetArtShape(int id);
        ArtTechnique GetArtTechnique(int id);
        Artwork GetArtwork(int id);
        IList<Art.Data.Domain.Artwork> GetArtworks();
        Artwork[] GetArtworksByArtistId(int artistId);
        ArtworkType GetArtworkType(int id);
        ArtworkType GetArtworkTypeByName(string name);
        List<Art.Data.Domain.ArtworkType> GetArtworkTypes();
        int GetCollectCount(int artworkId);
        ICollection<ArtPlace> GetPlaces();
        int GetPraiseCount(int artworkId);
        int GetShareCount(int artworkId);
        ActivityPraise Praise(int artworkId, int customerId);
        PagedList<Artwork> SearchArtworks(string namePart, int? artworkTypeId, int? artMaterialId, int? artistId, WebExpress.Core.PagingRequest paging);
        PagedList<Artwork> SearchArtworks(ArtworkSearchCriteria criteria);
        ActivityShare Share(int artworkId, int customerId);
        void Update(Artwork artwork);
        void UpdateArtworkType(ArtworkType artworkType);
    }
}
