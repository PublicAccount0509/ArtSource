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
        public string LoginName { get; set; }
        public string PassWord { get; set; }
        public string Position { get; set; }
        public string Contact { get; set; }
    }

    public class AdminUserModelTranslator : TranslatorBase<AdminUser, AdminUserModel>
    {
        public static readonly AdminUserModelTranslator Instance = new AdminUserModelTranslator();

        public override AdminUserModel Translate(AdminUser from)
        {
            var to = new AdminUserModel();
            to.Id = from.Id;
            to.Name = from.Name;
            to.LoginName = from.LoginName;
            to.PassWord = from.Password;
            to.Position = from.Position;
            to.Contact = from.Contact;
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