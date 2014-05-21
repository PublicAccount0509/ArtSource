/// <reference path="_references.views.js" />
/// <reference path="../webExpress/webExpress.ui.control.adapter.js" />

(function () {
    window.art.ui.view.AuctionListClass = AuctionListClass;
    function AuctionListClass() {
        var _self = this;
        var DEFAULT_PAGESIZE = 10;
        var _searchCriteria = { PagingRequest: { PageIndex: 0, PageSize: DEFAULT_PAGESIZE } };
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
            
            art.ui.control.Pager.enablePaging(document, refresh);
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