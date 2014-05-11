using Art.Data.Common;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Art.Data.Domain.Access.Initializers
{
    public class ArtDropCreateDatabaseIfModelChanges : DropCreateDatabaseIfModelChanges<ArtDbContext>
    {
        private string[] _sqlCommands;
        public ArtDropCreateDatabaseIfModelChanges(string[] sqlCommands)
        {
            _sqlCommands = sqlCommands;
        }

        protected override void Seed(ArtDbContext context)
        {
            if (_sqlCommands != null)
            {
                for (int i = 0; i < _sqlCommands.Length; i++)
                {
                    context.Database.ExecuteSqlCommand(_sqlCommands[i]);
                }
            }

            var artistTypesString = "油画家 版画家 国画家 漫画家 水墨画家 当代艺术家 摄影家";
            var artistTypes = artistTypesString.Split(' ');
            for (var i = 0; i < artistTypes.Length; i++)
            {
                var prof = new ArtistType
                {
                    Id = i + 1,
                    Name = artistTypes[i]
                };
                context.Set<ArtistType>().Add(prof);
            };

            var genresString = "风景、肖像、海景、静物、自然、人物、运动、流行文化、文本、个人记忆、怀旧、建筑、政治、动物、叙事、幽默、花卉、其他";
            var genres = genresString.Split('、');
            for (var i = 0; i < genres.Length; i++)
            {
                var genre = new Genre
                {
                    Id = i + 1,
                    Name = genres[i]
                };
                context.Set<Genre>().Add(genre);
            };

            context.SaveChanges();

            var artist = new Artist()
            {
                Name = "zhangheng",
                Birthday = DateTime.Now.AddYears(-10),
                School = "Peiking University",
                Gender = Genders.Female,
                PrizeItems = "aaaa",
                Degree = Degree.博士,
                ArtistTypes = new ArtistType[] { context.Set<ArtistType>().First() },
                SkilledGenres = new Genre[] { context.Set<Genre>().First() }
            };
            context.Set<Artist>().Add(artist);


            var user = new AdminUser
            {
                Name = "liu zhiwei",
                LoginName = "lzw",
                Password = "123",
                Position = "PM",
                Contact = "13866666666"
            };

            context.Set<AdminUser>().Add(user);


            var typeName = "artworkType1";
            var artworkType = new ArtworkType()
            {
                Name = "artworkType1"
            };
            artworkType.ArtMaterials = new List<ArtMaterial>();
            artworkType.ArtMaterials.Add(new ArtMaterial
            {
                Name = typeName + "-material-1"
            });
            artworkType.ArtShapes = new List<ArtShape>();
            artworkType.ArtShapes.Add(new ArtShape
            {
                Name = typeName + "-shape-1"
            });
            artworkType.ArtShapes.Add(new ArtShape
            {
                Name = typeName + "-shape-2"
            });
            context.Set<ArtworkType>().Add(artworkType);


            context.SaveChanges();

            var at = context.Set<ArtworkType>().First();
            at.ArtMaterials.Add(new ArtMaterial
            {
                Name = "dddd"
            });
            context.SaveChanges();


            var artPlaces = "卧室、餐厅、客厅、办公室、书房、酒吧".Split('、').Select(i => new ArtPlace { Name = i }).ToList(); // new List<ArtPlace>() { new ArtPlace { Name = "卧室" }, new ArtPlace { Name = "客厅" }, new ArtPlace { Name = "餐厅" }, new ArtPlace { Name = "办公室" } };
            context.Set<ArtPlace>().AddRange(artPlaces);

            // var artPeriods = new List<ArtPeriod>() { new ArtPeriod { Name = "50 n" }, new ArtPeriod { Name = "60 n" }, new ArtPeriod { Name = "70 n" } };

            //context.Set<ArtPeriod>().AddRange(artPeriods);

            //var auctionTypes = new List<AuctionType>() { new AuctionType { Name = "一口价 " }, new AuctionType { Name = "竞价拍-上升价格拍" }, new AuctionType { Name = "竞价拍-向下价格拍 " } };
            //context.Set<AuctionType>().AddRange(auctionTypes);

            context.SaveChanges();

            var artwork = new Artwork();
            artwork.Name = "蒙娜丽莎的微笑";
            artwork.Artist = context.Set<Artist>().First();
            artwork.ArtMaterial = context.Set<ArtMaterial>().First();
            artwork.ArtYear = 2009;// context.Set<ArtPeriod>().First();
            artwork.ArtworkType = context.Set<ArtworkType>().First();
            artwork.AuctionType = AuctionType.一口价;
            artwork.Genre = context.Set<Genre>().First();
            artwork.AuctionPrice = 998;
            artwork.CreationInspiration = "apple";
            artwork.Institution = "guowuyuan";
            artwork.SuitableArtPlaces = new List<ArtPlace> { context.Set<ArtPlace>().First() };
            artwork.Size = "80cm * 90cm";
            artwork.StartDateTime = DateTime.Now.AddDays(-3);
            artwork.EndDateTime = DateTime.Now.AddDays(3);
            context.Set<Artwork>().Add(artwork);

            var customer = new Customer() { LoginName="abc", Password="1231231" };
            context.Set<Customer>().Add(customer);

            var adminUser = new AdminUser
            {
                LoginName = "a",
                Name = "a"
            };
            context.Set<AdminUser>().Add(adminUser);
            context.SaveChanges();

            var notice = new SystemNotice();
            notice.Title = "aaaaa";
            notice.Content = "bbbbbbbbbbbbbbbbbb";
            notice.AdminUser = context.Set<AdminUser>().First();
            notice.FADateTime = DateTime.Now;
            context.Set<SystemNotice>().Add(notice);

            var comment = new Comment();
            comment.Text = "好漂亮的油画哦";
            comment.Artwork = context.Set<Artwork>().First();
            comment.Customer = context.Set<Customer>().First();
            comment.State = CommentState.Approving;
            comment.FADateTime = DateTime.Now;
            context.Set<Comment>().Add(comment);
            context.SaveChanges();
            //base.Seed(context);
        }
    }
}
