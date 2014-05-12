/// <reference path="_references.views.js" />
/// <reference path="../webExpress/webExpress.controls.adpaters.js" />

(function () {
    window.art.ui.view.AuctionListClass = AuctionListClass;
    function AuctionListClass() {
        var _self = this;
        var DEFAULT_PAGESIZE = 10;
        var _searchCriteria = { PagingRequest: { PageIndex: 0, PageSize: DEFAULT_PAGESIZE } };
        //var currentPageIndex = 0;
        window.art.ui.view.ViewBase.call(self);
        function _init() {
            _self.init = init;
            _self.refresh = refresh;
            _self.search = search;
            _self.auctionAccept = auctionAccept;
            _self.auctionRefuse = auctionRefuse;
        }

        function init() {
            $("#btnSearch").click(search);
            $(document).on("click", ".grid-pager a[pageIndex]", function () {
                var pageIndex = $(this).attr("pageIndex");
                refresh(pageIndex);
            });

            $(document).on("click", ".t-arrow-prev", function () {
                var pageIndex = _searchCriteria.PagingRequest.PageIndex - 1;
                refresh(pageIndex);
            });
            
            $(document).on("click", ".t-arrow-next", function () {
                var pageIndex = _searchCriteria.PagingRequest.PageIndex + 1;
                refresh(pageIndex);
            });
            $(document).on("click", ".t-arrow-last", function () {
                var pageIndex = parseInt($(this).attr("pageIndex")) - 1;
                refresh(pageIndex);
            });
            $(document).on("click", ".t-arrow-first", function () {
                refresh(0);
            });
            $(document).on("click", ".t-refresh", function () {
                refresh();
            });
        }

        function search() {
            _searchCriteria = {
                StartDate: $("#startdate").val(),
                EndDate: $("#enddate").val(),
                ArtworkId: $("#ddlArtwork option:selected").val(),
                ArtistsId: $("#ddlArtist option:selected").val(),
                PagingRequest: {
                    PageSize: DEFAULT_PAGESIZE
                }
            };
            refresh(0);
        }

        function auctionAccept(id, onSuccess) {
            var pData = { "id": id };
            var url = "/Order/AuctionAccept";
            webExpress.utility.ajax.request(url, pData, function (data) {
                if (data.IsSuccess) {
                    if (onSuccess) {
                        onSuccess();
                    }
                    refresh(0);
                } else {
                    alert("操作失败");
                }
            });
        }
        function auctionRefuse(id, onSuccess) {
            var pData = { "id": id };
            var url = "/Order/AuctionRefuse";
            webExpress.utility.ajax.request(url, pData, function (data) {
                if (data.IsSuccess) {
                    if (onSuccess) {
                        onSuccess();
                    }
                    refresh(0);
                } else {
                    alert("操作失败");
                }
            });
        }
        function refresh(pageIndex) {
            var url = "/Order/AuctionList";
            if (pageIndex !== undefined) {
                _searchCriteria.PagingRequest.PageIndex = pageIndex;
            }
            webExpress.utility.ajax.request(url, _searchCriteria,
                function (data) {
                    $(".data").html(data);
                    adminjs.hoveritem('.J_showMsg', '.J_userMsg');
                });
        }
        _init();
    }
})();