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
        bool Exist(int id);
        bool ExistCollect(int artworkId, int customerId);
        bool ExistPraise(int artworkId, int customerId);
        bool ExistShare(int artworkId, int customerId);
        ArtMaterial GetArtMaterial(int id);
        ICollection<Art.Data.Domain.ArtPlace> GetArtPlaces(List<int> ids);
        ArtShape GetArtShape(int id);
        ArtTechnique GetArtTechnique(int id);
        Artwork GetArtwork(int id);
        IList<Artwork> GetArtworks();
        IList<Artwork> GetArtworks(int[] artworkIds);
        Artwork[] GetArtworksByArtistId(int artistId);
        ArtworkType GetArtworkType(int id);
        ArtworkType GetArtworkTypeByName(string name);
        List<Art.Data.Domain.ArtworkType> GetArtworkTypes();
        
        ICollection<ArtPlace> GetArtPlaces();
        int GetCollectedCount(int artworkId);
        int GetCollectCount(int customerId);
        int GetPraisedCount(int artworkId);
        int GetPraiseCount(int customerId);
        int GetSharedCount(int artworkId);
        int GetShareCount(int customerId);

        int GetCommentCount(int customerId); 
        IList<Comment> GetComments(int customerId);
        Comment AddComment(Comment comment);

        ActivityPraise Praise(int artworkId, int customerId);
        void CancelPraise(int artworkId, int customerId);
        PagedList<Artwork> SearchArtworks(ArtworkSearchCriteria criteria);
        ActivityShare Share(int artworkId, int customerId);
        void Update(Artwork artwork);
        void UpdateArtworkType(ArtworkType artworkType);
    }
}
