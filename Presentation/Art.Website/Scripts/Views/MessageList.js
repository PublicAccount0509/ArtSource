  
(function () {
    art.ui.view.SystemNoticeList = SystemNoticeListClass;
    art.ui.view.CommentList = CommentListClass;
    function SystemNoticeListClass() {
        var _self = this;
        var _criteria = { StartDate: "", EndDate: "", PagingRequest: { PageIndex: 0, PageSize: 10 } };

        function _init() {
            _self.setCriteria = setCriteria;

            _self.publish = publish;
            _self.refresh = refresh;
            _self.remove = remove;
        }

        function setCriteria(startDate, endDate) {
            _criteria.StartDate = startDate;
            _criteria.EndDate = endDate;
        }

        function publish(title, content, onSuccess) {
            var url = "/Message/Publish";
            webExpress.utility.ajax.request(url, { title: title, content: content },
                function () {
                    if (onSuccess) {
                        onSuccess();
                    }
                    setCriteria("", "");
                    refresh(0);
                },
                function () {
                }
            );
        }

        function refresh(pageIndex) {
            var url = "/Message/NoticeList";
            if (pageIndex !== undefined) {
                _criteria.PagingRequest.PageIndex = pageIndex;
            }
            webExpress.utility.ajax.request(url, _criteria,
                function (data) { 
                    renderRecordsHtml(data);
                },
                function () {
                }
             );
        }

        function remove(noticeIds) {
            var url = "/Message/DeleteNotices";
            webExpress.utility.ajax.request(url, { noticeIds: noticeIds }, function (data) {
                refresh();
            }, function (data) {
                console.log("delete failture");
            });
        }

        function renderRecordsHtml(html) {
            $(".noticeData").html(html);
            $(".noticeData .grid-pager a[pageIndex]").click(function () {
                refresh($(this).attr("pageIndex"));
            });
        }

        _init();
    }

    function CommentListClass() {
        var _self = this;
        var _criteria = { StartDate: "", EndDate: "", State: 0, PagingRequest: { PageIndex: 0, PageSize: 10 } };
        var _currentTr;
        function _init() {
            _self.approve = approve;
            _self.unApprove = unApprove;
            _self.reply = reply;
            _self.refresh = refresh;

            _self.setCriteria = setCriteria;
            _self.setCurrentTr = setCurrentTr;
        }

        function approve() {
            var commentId = getCurrentCommentId();
            var url = "/Message/Approve";
            webExpress.utility.ajax.request(url, { commentId: commentId },
                function () {
                    renderRecordDomState(CommentSate.Approved);
                },
                function () {
                }
            );
        }

        function unApprove() {
            var commentId = getCurrentCommentId();
            var url = "/Message/UnApprove";
            webExpress.utility.ajax.request(url, { commentId: commentId },
                function () {
                    renderRecordDomState(CommentSate.UnApproved);
                },
                function () {
                }
            );
        }

        function reply(repliedText,onSuccessHandler) {
            var commentId = getCurrentCommentId();
            var url = "/Message/Reply";
            webExpress.utility.ajax.request(url, { commentId: commentId, repliedText: repliedText },
                function () {
                    if (onSuccessHandler) {
                        onSuccessHandler();
                    }
                    renderRecordDomState(CommentSate.Replied);
                },
                function () {
                }
            );
        }

        function refresh(pageIndex) {
            var url = "/Message/CommentList";
            if (pageIndex !== undefined) {
                _criteria.PagingRequest.PageIndex = pageIndex;
            }
            webExpress.utility.ajax.request(url, _criteria,
                function (data) {
                    renderRecordsHtml(data);
                },
                function () {
                }
             );
        }

        function setCriteria(startDate, endDate, state) {
            _criteria.StartDate = startDate;
            _criteria.EndDate = endDate;
            _criteria.State = state;
        }

        function getCurrentCommentId() {
            return $(_currentTr).attr("commentId");
        }

        function setCurrentTr(tr) {
            _currentTr = tr;
        }

        function renderRecordDomState(state) {
            if (state == CommentSate.Approved) {
                $(_currentTr).find("td.state").html('<span class="t-gray">审核通过"</span>');
                $(_currentTr).find("td.command").html('<a class="J_reply" href="javascript:void(0)">回复</a>');
            }
            else if (state == CommentSate.UnApproved) {
                $(_currentTr).find("td.state").html('<span class="t-gray">审核不通过"</span>');
                $(_currentTr).find("td.command").html('-');
            }
            else if (state == CommentSate.Replied) {
                $(_currentTr).find("td.state").html('<span class="t-gray">己回复"</span>');
                $(_currentTr).find("td.command").html('-');
            }
        }

        function renderRecordsHtml(html) {
            $(".commentData").html(html);
            $(".commentData .grid-pager a[pageIndex]").click(function () {
                refresh($(this).attr("pageIndex"));
            });
        }

        _init();
    }

    var CommentSate = {
        Approving: 0,
        Approved: 1,
        UnApproved: 2,
        Replied: 3
    };

})();