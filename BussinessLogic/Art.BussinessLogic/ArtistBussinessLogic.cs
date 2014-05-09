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
    public class ArtistBussinessLogic
    {
        public static readonly ArtistBussinessLogic Instance = new ArtistBussinessLogic();

        private readonly IRepository<Artist> _artistRepository;
        private readonly IRepository<Profession> _professionRepository;
        private readonly IRepository<Genre> _genreRepository;

        private ArtistBussinessLogic()
        {
            _artistRepository = new EfRepository<Artist>();
            _professionRepository = new EfRepository<Profession>();
            _genreRepository = new EfRepository<Genre>();
        }

        public Artist GetArtist(int artistId)
        {
            var artist = _artistRepository.GetById(artistId);
            return artist;
        }

        public IList<Artist> GetArtists()
        {
            var artists = _artistRepository.Table.ToList();
            return artists;
        }

        public PagedList<Artist> SearchArtists(string namePart, int? professionId, PagingRequest paging)
        {
            Guard.IsNotNull<ArgumentNullException>(paging, "paging");

            var query = _artistRepository.Table;
            if (!string.IsNullOrEmpty(namePart))
            {
                query = query.Where(i => i.Name.Contains(namePart));
            }

            if (professionId.HasValue)
            {
                query = query.Where(i => i.Professions.Any(p => p.Id == professionId.Value));
            }

            query = query.OrderBy(i => i.Id);

            var result = new PagedList<Artist>(query, paging.PageIndex, paging.PageSize);

            return result;
        }

        public Profession[] GetArtistProfessions(int artistId)
        {
            var profs = from p in _professionRepository.Table
                        where p.Id == 1 || p.Id == 2
                        select p;
            return profs.ToArray();
        }

        public Profession[] GetProfessions()
        {
            var professions = _professionRepository.Table.ToArray();
            return professions;
        }

        public Profession GetProfession(int id)
        {
           return _professionRepository.GetById(id);
        }
        /// <summary>
        /// Gets the name of the profession by.
        /// </summary>
        /// <param name="name">The name</param>
        /// <returns>
        /// The Profession
        /// </returns>
        /// 创建者：黄磊
        /// 创建日期：5/9/2014 5:44 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public Profession GetProfessionByName(string name)
        {
            var profession = _professionRepository.Table.Where( p=>name == p.Name);
            return profession.FirstOrDefault();
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
           var result =  _artistRepository.Insert(artist);
           return result;
        }

        public void Update(Artist artist)
        {
            _artistRepository.Update(artist);
        }

        public void Delete(Artist artist)
        {
            _artistRepository.Delete(artist);
        }

        public bool CanUnpublish(Artist artist)
        {
            List<string> reasons;
            return CanUnpublish(artist, out reasons);
        }

        public bool CanUnpublish(Artist artist, out List<string> reasons)
        {
            reasons = new List<string>();
            if (artist.Name == "齐白石")
            {
                reasons.Add("齐白石老人不能取消发布");

                return false;
            }
            return true;
        }

        public ICollection<Profession> GetProfessions(List<int> ids)
        {
            if (ids == null)
            {
                return null;
            }

            var query = from p in _professionRepository.Table
                        where ids.Contains(p.Id)
                        select p;
            return query.ToList();
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
        /// <summary>
        /// Searches the professions.
        /// </summary>
        /// <returns>
        /// IList{Profession}
        /// </returns>
        /// 创建者：黄磊
        /// 创建日期：5/9/2014 2:35 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public IList<Profession> SearchProfessions()
        {
            var query = _professionRepository.Table.ToList();

            //var result = new List<Profession>(query);
            return query;
        }
        /// <summary>
        /// The method will 
        /// </summary>
        /// <param name="profession">The profession</param>
        /// 创建者：黄磊
        /// 创建日期：5/9/2014 12:55 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public void Add(Profession profession)
        {
            _professionRepository.Insert(profession);
        }
        /// <summary>
        /// The method will 
        /// </summary>
        /// <param name="profession">The profession</param>
        /// 创建者：黄磊
        /// 创建日期：5/9/2014 12:53 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public void UpdateProfession(Profession profession)
        {
            _professionRepository.Update(profession);
        }
        /// <summary>
        /// The method will 
        /// </summary>
        /// <param name="profession">The profession</param>
        /// 创建者：黄磊
        /// 创建日期：5/9/2014 5:00 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public void DeleteProfession(Profession profession)
        {
            _professionRepository.Delete(profession);
        }
    }
}
