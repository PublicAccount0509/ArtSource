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
    public class ArtCreateDatabaseIfNotExists : CreateDatabaseIfNotExists<ArtDbContext>
    {
        private string[] _sqlCommands;
        public ArtCreateDatabaseIfNotExists(string[] sqlCommands)
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

            context.SaveChanges();
             
            var customer = new Customer() { NickName = "abc", Password = "1231231", PhoneNumber = "asdf" };
            context.Set<Customer>().Add(customer);

            var adminUser = new AdminUser
            {
                LoginName = "a",
                Name = "a"
            };
            context.Set<AdminUser>().Add(adminUser);
            context.SaveChanges(); 
        }
    }
}
