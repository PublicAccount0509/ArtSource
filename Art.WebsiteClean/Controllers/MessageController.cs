using Art.BussinessLogic;
using Art.Website.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Art.Website.Controllers
{
    public class MessageController : Controller
    {
        [HttpGet]
        public ActionResult List()
        {  
            var model = new MessageModel();
            model.SystemNoticeModel = GetPagedSystemNoticeModel(new SystemNoticeSearchCriteria(10));
            model.CommentModel = GetPagedCommentModel(new CommentSearchCriteria(10));

            return View(model);
        }

        #region For System Notice
        public ActionResult NoticeList(SystemNoticeSearchCriteria criteria)
        {
            var model = GetPagedSystemNoticeModel(criteria);
            return PartialView("_NoticeList", model);
        }

        public JsonResult DeleteNotices(int[] noticeIds)
        {
            var notices = MessageBussinessLogic.Instance.GetSystemNotices(noticeIds);
            MessageBussinessLogic.Instance.DeleteSystemNotices(notices.ToArray());
            var model = new ResultModel(true, string.Empty);
            return Json(model);
        }

        private PagedSystemNoticeModel GetPagedSystemNoticeModel(SystemNoticeSearchCriteria criteria)
        {
            var pagedSystemNotice = MessageBussinessLogic.Instance.SearchSystemNotice(criteria.StartDate, criteria.EndDate, criteria.PagingRequest);
            var notices = SystemNoticeModelTranslator.Instance.Translate(pagedSystemNotice.ToList());
            var model = new PagedSystemNoticeModel(notices, pagedSystemNotice.PagingResult);
            return model;
        }

        public JsonResult Publish(string title, string content)
        {
            MessageBussinessLogic.Instance.PublishSystemNotice(title, content);
            var result = new ResultModel(true, string.Empty);
            return Json(result);
        }
        #endregion

        #region For Comment
        private PagedCommentModel GetPagedCommentModel(CommentSearchCriteria criteria)
        {
            var pagedComments = MessageBussinessLogic.Instance.SearchComments(criteria.StartDate, criteria.EndDate, criteria.State, criteria.PagingRequest);
            var notices = CommentModelTranslator.Instance.Translate(pagedComments.ToList());
            var model = new PagedCommentModel(notices, pagedComments.PagingResult);
            return model;
        }

        public ActionResult CommentList(CommentSearchCriteria criteria)
        {
            var model = GetPagedCommentModel(criteria);
            return PartialView("_CommentList", model);
        }

        public JsonResult Approve(int commentId)
        {
            var comment = MessageBussinessLogic.Instance.GetComment(commentId);
            MessageBussinessLogic.Instance.Approve(comment);
            var result = new ResultModel(true, string.Empty);
            return Json(result);
        }

        public JsonResult UnApprove(int commentId)
        {
            var comment = MessageBussinessLogic.Instance.GetComment(commentId);
            MessageBussinessLogic.Instance.UnApprove(comment);
            var result = new ResultModel(true, string.Empty);
            return Json(result);
        }

        public JsonResult Reply(int commentId,string repliedText)
        {
            MessageBussinessLogic.Instance.AddReply(commentId, repliedText);
            var result = new ResultModel(true, string.Empty);
            return Json(result);
        }


        #endregion
    }
}
