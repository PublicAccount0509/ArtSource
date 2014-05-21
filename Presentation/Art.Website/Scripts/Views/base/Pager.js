/// <reference path="_references.views.js" />
/// <reference path="../webExpress/webExpress.ui.control.adapter.js" />

(function () {
    art.ui.control.Pager = PagerClass;

    art.ui.control.Pager.enablePaging = function (pagerContainer, redirectToPage) {
        $(pagerContainer).on("click", ".grid-pager a[pageIndex]", function () {
            var pageIndex = $(this).attr("pageIndex");
            redirectToPage(pageIndex);
        });

        $(pagerContainer).on("click", ".t-arrow-prev", function () {
            var pageIndex = getCurrentPageIndex() - 1;
            redirectToPage(pageIndex);
        });

        $(pagerContainer).on("click", ".t-arrow-next", function () {
            var pageIndex = getCurrentPageIndex() + 1;
            redirectToPage(pageIndex);
        });
        $(pagerContainer).on("click", ".t-arrow-last", function () {
            var pageIndex = parseInt($(this).attr("pageIndex")) - 1;
            redirectToPage(pageIndex);
        });
        $(pagerContainer).on("click", ".t-arrow-first", function () {
            redirectToPage(0);
        });
        $(pagerContainer).on("click", ".t-refresh", function () {
            redirectToPage();
        }); 

        function getCurrentPageIndex() {
            return $(".t-state-active", pagerContainer).text() - 1;
        } 
    }

    function PagerClass(pagerContainer, redirectToPage) {
        var _self = this;

        function _init() {
            init(pagerContainer, redirectToPage);
        }

        function init() {
            $(pagerContainer).on("click", ".grid-pager a[pageIndex]", function () {
                var pageIndex = $(this).attr("pageIndex");
                refresh(pageIndex);
            });

            $(pagerContainer).on("click", ".grid-pager a[pageIndex]", function () {
                var pageIndex = $(this).attr("pageIndex");
                redirectToPage(pageIndex);
            });

            $(pagerContainer).on("click", ".t-arrow-prev", function () {
                var pageIndex = _searchCriteria.PagingRequest.PageIndex - 1;
                redirectToPage(pageIndex);
            });

            $(pagerContainer).on("click", ".t-arrow-next", function () {
                var pageIndex = _searchCriteria.PagingRequest.PageIndex + 1;
                redirectToPage(pageIndex);
            });
            $(pagerContainer).on("click", ".t-arrow-last", function () {
                var pageIndex = parseInt($(this).attr("pageIndex")) - 1;
                redirectToPage(pageIndex);
            });
            $(pagerContainer).on("click", ".t-arrow-first", function () {
                redirectToPage(0);
            });
            $(pagerContainer).on("click", ".t-refresh", function () {
                redirectToPage();
            });
        }

        _init();
    }
})();