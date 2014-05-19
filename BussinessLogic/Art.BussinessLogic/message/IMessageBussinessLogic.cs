using System;
namespace Art.BussinessLogic
{
    public interface IMessageBussinessLogic
    {
        void AddComment();
        void AddReply(int commentId, string repliedText);
        void Approve(Art.Data.Domain.Comment comment);
        void DeleteSystemNotices(Art.Data.Domain.SystemNotice[] notices);
        Art.Data.Domain.Comment GetComment(int commentId);
        System.Collections.Generic.IList<Art.Data.Domain.SystemNotice> GetSystemNotices(int[] noticeIds);
        void PublishSystemNotice(string title, string content);
        WebExpress.Core.PagedList<Art.Data.Domain.Comment> SearchComments(DateTime? startDate, DateTime? endDate, Art.Data.Common.CommentState? state, WebExpress.Core.PagingRequest paging);
        WebExpress.Core.PagedList<Art.Data.Domain.SystemNotice> SearchSystemNotice(DateTime? startDate, DateTime? endDate, WebExpress.Core.PagingRequest paging);
        void UnApprove(Art.Data.Domain.Comment comment);
    }
}
