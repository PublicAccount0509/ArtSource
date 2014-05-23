/// <reference path="_references.views.js" />
/// <reference path="../webExpress/webExpress.ui.control.adapter.js" />

(function() {
    window.art.ui.view.ArtistList = ArtistListClass;

    function ArtistListClass() {
        var adminjs = new adminglass(); //实例化后台类
        var _self = this;
        var DEFAULT_PAGESIZE = 10;
        var _searchCriteria = { PagingRequest: { PageIndex: 0, PageSize: DEFAULT_PAGESIZE } };
        var currentElement;
        window.art.ui.view.ViewBase.call(self);

        function _init() {
            _self.init = init;
            _self.refresh = refresh;
            _self.search = search;
            _self.deleteArtist = deleteArtist;
            _self.unPublishOk = unPublishOk;
            _self.publishOk = publishOk;
        }

        function init() {
            //删除艺术家
            $(".data").on("click", ".J_deletezzBtn", function() {
                adminjs.openwinbox('#J_deletezzBox');
                currentElement = $(this);
                return false;
            });
            //删除分类
            $(document).on("click", ".J_deleteflBtn", function() {
                adminjs.openwinbox('#J_deletelistBox');
                return false;
            });
            //取消发布
            $(document).on("click", ".J_cancelBtn", function() {
                adminjs.openwinbox('#J_cancelBox');
                currentElement = $(this);
                return false;
            });
            //发布
            $(document).on("click", '.J_issueBtn', function() {
                adminjs.openwinbox('#J_issueBox');
                currentElement = $(this);
                return false;
            });
            //查看作者
            $(document).on("click", '.J_zjIinfo', function() {
                var url = $(this).attr("url");
                webExpress.utility.ajax.request(url, null,
                    function(data, status) {
                        $("#J_zjIinfoBox").html(data);
                        adminjs.closewinbox();
                        adminjs.openwinbox('#J_zjIinfoBox');
                    });
                return false;
            });

            $("#btnSearch").click(search);

            $("#btnDelete").click(deleteArtist);

            $("#btnUnPublishOK").click(unPublishOk);

            $("#btnPublishOK").click(publishOk);

            $('#btnOK').click(function() {
                alert(1);
            });
            art.ui.control.Pager.enablePaging(document, refresh);
        }

        function search() {
            _searchCriteria = {
                NamePart: $("#txtNamePart").val(),
                ArtistTypeId: $("#selectArtistTypeId").val(),
                PagingRequest: {
                    PageSize: DEFAULT_PAGESIZE
                }
            };
            refresh(0);
        }

        function deleteArtist() {
            var url = currentElement.attr("url");
            var btn = this;
            webExpress.utility.ajax.request(url, null, function(data) {
                if (data.IsSuccess) {
                    adminjs.closewinbox($(btn).closest(".add-openbox"));
                    refresh();
                } else {
                    alert(data.Message);
                }
            });
        }

        function unPublishOk() {
            var url = currentElement.attr("url");
            webExpress.utility.ajax.request(url, null, function(data) {
                if (data.IsSuccess) {
                    refresh();
                } else {
                    alert(data.Message);
                }
            });
        }

        function publishOk() {
            var url = currentElement.attr("url");
            webExpress.utility.ajax.request(url, null, function(data) {
                if (data.IsSuccess) {
                    refresh();
                } else {
                    alert(data.Message);
                }
            });
        }

        function refresh(pageIndex) {
            var url = "/Artist/List";
            if (pageIndex !== undefined) {
                _searchCriteria.PagingRequest.PageIndex = pageIndex;
            }
            webExpress.utility.ajax.request(url, _searchCriteria,
                function(data) {
                    $(".data").html(data);
                });
        }

        _init();
    }
})();