﻿using Art.BussinessLogic.Entities;
using Art.Common;
using Art.Data.Common;
using Art.Data.Domain;
using Art.Data.Domain.Access;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebExpress.Core;
using WebExpress.Core.Guards;

namespace Art.BussinessLogic
{
    public class ArtistBussinessLogic : IArtistBussinessLogic
    {
        //public static readonly ArtistBussinessLogic Instance = new ArtistBussinessLogic();

        private IRepository<Artist> _artistRepository;
        private IRepository<ArtistType> _artistTypeRepository;
        private IRepository<Genre> _genreRepository;
        private IRepository<ActivityFollow> _activityFollowRepository;

        public ArtistBussinessLogic(IRepository<Artist> artistRepository,
            IRepository<ArtistType> artistTypeRepository,
            IRepository<Genre> genreRepository,
            IRepository<ActivityFollow> activityFollowRepository
        )
        {
            _artistRepository = artistRepository;
            _artistTypeRepository = artistTypeRepository;
            _genreRepository = genreRepository;
            _activityFollowRepository = activityFollowRepository;
        }

        public Artist GetArtist(int artistId)
        {
            var artist = _artistRepository.GetById(artistId);
            return artist;
        }
        /// <summary>
        /// The method will 
        /// </summary>
        /// <param name="id">The id</param>
        /// <returns>
        /// The Boolean
        /// </returns>
        /// 创建者：黄磊
        /// 创建日期：5/14/2014 4:32 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public bool Exist(int id)
        {
            return GetArtist(id) != null;
        }

        public IList<Artist> GetArtists()
        {
            var artists = _artistRepository.Table.ToList();
            return artists;
        }

        public PagedList<Artist> SearchArtists(ArtistSearchCriteria criteria)
        {
            Guard.IsNotNull<ArgumentNullException>(criteria.PagingRequest, "PagingRequest");

            var query = _artistRepository.Table;
            if (!string.IsNullOrEmpty(criteria.NamePart))
            {
                query = query.Where(i => i.Name.Contains(criteria.NamePart));
            }

            if (criteria.ArtistTypeId.HasValue)
            {
                query = query.Where(i => i.ArtistTypes.Any(p => p.Id == criteria.ArtistTypeId.Value));
            }

            query = query.OrderBy(i => i.Id);

            var result = new PagedList<Artist>(query, criteria.PagingRequest.PageIndex, criteria.PagingRequest.PageSize);

            return result;
        }

        public ArtistType[] GetArtistTypes()
        {
            var types = _artistTypeRepository.Table.ToArray();
            return types;
        }

        public ArtistType GetArtistType(int id)
        {
            return _artistTypeRepository.GetById(id);
        }

        /// 创建者：黄磊
        /// 创建日期：5/9/2014 5:44 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public ArtistType GetArtistTypeByName(string name)
        {
            var type = _artistTypeRepository.Table.Where(p => name == p.Name);
            return type.FirstOrDefault();
        }

        public Genre[] GetGenres()
        {
            var genres = _genreRepository.Table.ToArray();
            return genres;
        }

        public Genre GetGenre(int id)
        {
            var genre = _genreRepository.GetById(id);
            return genre;
        }

        public Artist Add(Artist artist)
        {
            artist.IsPublic = true;

            var imageFullFileName = CommonHelper.GetUploadFileAbsolutePath(artist.AvatarFileName);
            var images = BussinessLogicHelper.GenerateImages<ArtistImageType>(imageFullFileName);
            artist.Images = ImageInfosTranslator.Instance.TranslateToArtistImage(images);

            var result = _artistRepository.Insert(artist);
            return result;
        }

        public void Update(Artist artist)
        {
            var isImageChanged = !artist.Images.First().ImagePath.Contains(Path.GetFileNameWithoutExtension(artist.AvatarFileName));
            if (isImageChanged)
            {
                var imageFullFileName = CommonHelper.GetUploadFileAbsolutePath(artist.AvatarFileName);
                var images = BussinessLogicHelper.GenerateImages<ArtworkImageResizeType>(imageFullFileName);
                artist.Images = ImageInfosTranslator.Instance.TranslateToArtistImage(images);
            }

            _artistRepository.Update(artist);
        }

        public void Delete(Artist artist)
        {
            _artistRepository.Delete(artist);
        }

        public ICollection<ArtistType> GetArtistTypes(List<int> ids)
        {
            if (ids == null)
            {
                return null;
            }
            Trace.WriteLine(ids.Count);
            Trace.WriteLine("1111");
            var query = from p in _artistTypeRepository.Table
                        where ids.Contains(p.Id)
                        select p;
            Trace.WriteLine("222");
            var data = query.ToList();
            Trace.WriteLine(data.Count);
            return data;

        }

        public ICollection<Genre> GetSkilledGenres(List<int> ids)
        {
            if (ids == null)
            {
                return null;
            }
            var query = from p in _genreRepository.Table
                        where ids.Contains(p.Id)
                        select p;
            return query.ToList();
        }

        /// 创建者：黄磊
        /// 创建日期：5/9/2014 12:55 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public void Add(ArtistType artistType)
        {
            _artistTypeRepository.Insert(artistType);
        }

        /// 创建者：黄磊
        /// 创建日期：5/9/2014 12:53 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public void UpdateArtistType(ArtistType artistType)
        {
            _artistTypeRepository.Update(artistType);
        }

        /// 创建者：黄磊
        /// 创建日期：5/9/2014 5:00 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public void DeleteArtistType(ArtistType artistType)
        {
            _artistTypeRepository.Delete(artistType);
        }

        /// <summary>
        /// Exists the follow.
        /// </summary>
        /// <param name="artistId">The artistId</param>
        /// <param name="customerId">The customerId</param>
        /// <returns>
        /// Boolean
        /// </returns>
        /// 创建者：黄磊
        /// 创建日期：5/14/2014 2:01 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public bool ExistFollow(int artistId, int customerId)
        {
            return _activityFollowRepository.Table.Any(p => p.ArtistId == artistId && p.CustomerId == customerId);
        }
        /// <summary>
        /// Adds the follow.
        /// </summary>
        /// <param name="activityFollow">The activityFollow</param>
        /// 创建者：黄磊
        /// 创建日期：5/14/2014 2:04 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public void AddFollow(ActivityFollow activityFollow)
        {
            _activityFollowRepository.Insert(activityFollow);
        }

        /// <summary>
        /// Deletes the follow.
        /// </summary>
        /// <param name="activityFollow">The activityFollow</param>
        /// 创建者：黄磊
        /// 创建日期：5/14/2014 5:32 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public void DeleteFollow(ActivityFollow activityFollow)
        {
            var activity =
                _activityFollowRepository.Table.FirstOrDefault(p => p.ArtistId == activityFollow.ArtistId && p.CustomerId == activityFollow.CustomerId);
            _activityFollowRepository.Delete(activity);
        }
        /// <summary>
        /// Gets the follows by customer identifier.
        /// </summary>
        /// <param name="customerId">The customerId</param>
        /// <returns>
        /// ActivityFollow[][]
        /// </returns>
        /// 创建者：黄磊
        /// 创建日期：5/14/2014 2:34 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public ActivityFollow[] GetFollowsByCustomerId(int customerId)
        {
            return _activityFollowRepository.Table.Where(p => p.CustomerId == customerId).ToArray();
        }

        public int GetFollowCount(int customerId)
        {
            var count = _activityFollowRepository.Table.Where(i => i.CustomerId == customerId).Count();
            return count;
        }
    }
}
