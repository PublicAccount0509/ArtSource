using Art.Data.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebExpress.Core;
using WebExpress.Core.Paging;

namespace Art.Website.Models
{
    public class PagedSystemNoticeModel
    {
        public PagedSystemNoticeModel(IList<SystemNoticeModel> systemNotices, PagingResult pagingResult)
        {
            this.SystemNotices = systemNotices;
            this.PagingResult = pagingResult;
        }
        public IList<SystemNoticeModel> SystemNotices { get; set; }
        public PagingResult PagingResult { get; set; }
    }

    public class SystemNoticeModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public bool IsSuccessful { get; set; }
        public DateTime Date { get; set; }
        public AdminUserModel AdminUser { get; set; }
    }

    public class SystemNoticeModelTranslator : TranslatorBase<SystemNotice, SystemNoticeModel>
    {
        public static readonly SystemNoticeModelTranslator Instance = new SystemNoticeModelTranslator();

        public override SystemNoticeModel Translate(SystemNotice from)
        {
            var to = new SystemNoticeModel();
            to.Id = from.Id;
            to.Title = from.Title;
            to.Content = from.Content;
            to.IsSuccessful = from.IsSuccessful;
            to.Date = from.FADateTime;
            to.AdminUser = AdminUserModelTranslator.Instance.Translate(from.AdminUser);
            return to;
        }

        public override SystemNotice Translate(SystemNoticeModel from)
        {
            var to = new SystemNotice();
            to.Id = from.Id;
            to.Title = from.Title;
            to.Content = from.Content;
            to.IsSuccessful = from.IsSuccessful;
            //to.FADateTime = from.Date;
            to.AdminUser = AdminUserModelTranslator.Instance.Translate(from.AdminUser);
            return to;
        }
    }
}