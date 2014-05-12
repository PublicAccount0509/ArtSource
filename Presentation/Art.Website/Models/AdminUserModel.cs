using Art.Data.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebExpress.Core;

namespace Art.Website.Models
{
    public class AdminUserModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Position { get; set; }
    }

    public class AdminUserModelTranslator : TranslatorBase<AdminUser, AdminUserModel>
    {
        public static readonly AdminUserModelTranslator Instance = new AdminUserModelTranslator();

        public override AdminUserModel Translate(AdminUser from)
        {
            var to = new AdminUserModel();
            to.Id = from.Id;
            to.Name = from.Name;
            to.Position = from.Position;
            return to;
        }

        public override AdminUser Translate(AdminUserModel from)
        {
            var to = new AdminUser();
            to.Id = from.Id;
            to.Name = from.Name;
            to.Position = from.Position;
            return to;
        }
    }
}