using Art.Data.Common;
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
    public class MessageBussinessLogic
    {
        //public static readonly MessageBussinessLogic Instance = new MessageBussinessLogic();

        private readonly IRepository<Comment> _commentRepository;
        private readonly IRepository<SystemNotice> _systemNoticeRepository;
        private readonly IRepository<Reply> _replyRepository;
        private readonly IRepository<Artwork> _artworkRepository;
        private readonly IRepository<Customer> _customerRepository;

        private MessageBussinessLogic(EfRepository<Comment> commentRepository,
            EfRepository<Reply> replyRepository,
            EfRepository<Artwork> artworkRepository,
            EfRepository<Customer> customerRepository,
            EfRepository<SystemNotice> systemNoticeRepository)
        {
            _commentRepository = commentRepository;
            _replyRepository = replyRepository;
            _artworkRepository = artworkRepository;
            _customerRepository = customerRepository;
            _systemNoticeRepository = systemNoticeRepository;
        }

        public void AddComment()
        {
            var comment = new Comment
            {
                Artwork = _artworkRepository.Table.First(),
                Customer = _customerRepository.Table.First(),
                Text = "哇好漂亮的画哦",
                State = CommentState.Approving,
                FADateTime = DateTime.Now
            };
            _commentRepository.Insert(comment);
        }

        public void AddReply(int commentId,string repliedText)
        {
            var reply = new Reply();
            reply.Text = repliedText;
            reply.Comment = _commentRepository.GetById(commentId);
            reply.FADateTime = DateTime.Now;
            reply.Comment.State = CommentState.Replied;
            _replyRepository.Insert(reply);
        }

        public PagedList<SystemNotice> SearchSystemNotice(DateTime? startDate, DateTime? endDate, WebExpress.Core.PagingRequest paging)
        {
            Guard.IsNotNull<ArgumentNullException>(paging, "paging");

            var query = _systemNoticeRepository.Table;
            if (startDate.HasValue)
            {
                var dateBegin = startDate.Value.BeginOfDay();
                query = query.Where(i => i.FADateTime >= dateBegin);
            }

            if (endDate.HasValue)
            {
                var dateEnd = endDate.Value.EndOfDay();
                query = query.Where(i => i.FADateTime <= dateEnd);
            }

            query = query.OrderByDescending(i => i.Id);

            var result = new PagedList<SystemNotice>(query, paging.PageIndex, paging.PageSize);

            return result;
        }

        public void PublishSystemNotice(string title, string content)
        {
            var notice = new SystemNotice();
            notice.Title = title;
            notice.Content = content;
            notice.FADateTime = DateTime.Now;
            notice.AdminUserId = 1;
            _systemNoticeRepository.Insert(notice);
        }

        public IList<SystemNotice> GetSystemNotices(int[] noticeIds)
        {
            var notices = _systemNoticeRepository.Table.Where(i => noticeIds.Contains(i.Id)).ToList();
            return notices;
        }

        public void DeleteSystemNotices(SystemNotice[] notices)
        {
            foreach (var notice in notices)
            {
                _systemNoticeRepository.Delete(notice);
            }
        }

        public PagedList<Comment> SearchComments(DateTime? startDate, DateTime? endDate, CommentState? state, PagingRequest paging)
        {
            Guard.IsNotNull<ArgumentNullException>(paging, "paging");

            var query = _commentRepository.Table;
            if (startDate.HasValue)
            {
                var dateBegin = startDate.Value.BeginOfDay();
                query = query.Where(i => i.FADateTime >= dateBegin);
            }

            if (endDate.HasValue)
            {
                var dateEnd = endDate.Value.EndOfDay();
                query = query.Where(i => i.FADateTime <= dateEnd);
            }

            if (state.HasValue)
            {
                query = query.Where(i => i.State == state.Value);
            }


            query = query.OrderByDescending(i => i.Id);

            var result = new PagedList<Comment>(query, paging.PageIndex, paging.PageSize);
            return result;
        }

        public Comment GetComment(int commentId)
        {
            return _commentRepository.GetById(commentId);
        }

        public void Approve(Comment comment)
        {
            comment.State = CommentState.Approved;
            _commentRepository.Update(comment);
        }

        public void UnApprove(Comment comment)
        {
            comment.State = CommentState.UnApproved;
            _commentRepository.Update(comment);
        }
    }
}
