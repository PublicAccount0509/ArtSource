﻿using Art.BussinessLogic.Entities;
using Art.Data.Domain;
using System;
using System.Collections.Generic;
using WebExpress.Core;
namespace Art.BussinessLogic
{
    public interface IArtistBussinessLogic
    {
        Artist Add(Artist artist);
        void Add(ArtistType artistType);
        void AddFollow(ActivityFollow activityFollow);
        ActivityFollow[] GetFollowsByCustomerId(int customerId);
        int GetFollowCount(int customerId);
        void Delete(Artist artist);
        void DeleteArtistType(ArtistType artistType);
        void DeleteFollow(ActivityFollow activityFollow);
        bool Exist(int id);
        bool ExistFollow(int artistId, int customerId);
        Artist GetArtist(int artistId);
        IList<Art.Data.Domain.Artist> GetArtists();
        ArtistType GetArtistType(int id);
        ArtistType GetArtistTypeByName(string name);
        ArtistType[] GetArtistTypes();
        ICollection<Art.Data.Domain.ArtistType> GetArtistTypes(List<int> ids); 
        Genre GetGenre(int id);
        Genre[] GetGenres();
        ICollection<Genre> GetSkilledGenres(List<int> ids);
        PagedList<Artist> SearchArtists(ArtistSearchCriteria criteria);
        void Update(Artist artist);
        void UpdateArtistType(ArtistType artistType);
    }
}
