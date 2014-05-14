/// <reference path="_references.views.js" />
/// <reference path="../webExpress/webExpress.controls.adpaters.js" />

(function () {
    art.ui.view.AdminUserList = AdminUserListClass;

    function AdminUserListClass() {
        var _self = this;
        var _searchCriteria;
        //var currentPageIndex = 0;
        window.art.ui.view.ViewBase.call(self);
        function _init() {
            _self.init = init;
            _self.refresh = refresh;
            _self.search = search;
            _self.updateAdminUser = updateAdminUser;
            //_self.auctionRefuse = auctionRefuse;
        }

        function init() {
            $("#btnSearch").click(search);
        }

        function search() {
            _searchCriteria = {
                Name: $("#txtUserName").val()
            };
            refresh();
        }
        function updateAdminUser() {
            alert("update");
        }
        function refresh() {
            var url = "/AdminUser/List";
            webExpress.utility.ajax.request(url, _searchCriteria,
                function (data) {
                    $(".data").html(data);
                });
        }
        _init();
    }
})();