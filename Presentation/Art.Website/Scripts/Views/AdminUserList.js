/// <reference path="_references.views.js" />
/// <reference path="../webExpress/webExpress.controls.adpaters.js" />

(function () {
    art.ui.view.AdminUserList = AdminUserListClass;

    function AdminUserListClass() {
        var _self = this;
        var _searchCriteria;
        //var currentPageIndex = 0;
        window.art.ui.view.ViewBase.call(_self);

        function _init() {
            _self.init = init;
            _self.refresh = refresh;
            _self.search = search;
            _self.updateAdminUser = updateAdminUser;
            _self.resetPassword = resetPassword;
            _self.addAdminUser = addAdminUser;
            _self.deleteAdminUser = deleteAdminUser;
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

        function updateAdminUser(model) {
            var url = "/AdminUser/Edit" ;
            webExpress.utility.ajax.request(url, model,
            function (response) {
                if (response.IsSuccess) {
                    alert("保存成功");
                    refresh();
                }
                else {
                    alert(response.Message);
                }
            });
        }

        function addAdminUser(model) {
            var url = "/AdminUser/Add";
            webExpress.utility.ajax.request(url, model,
            function (response) {
                if (response.IsSuccess) {
                    alert("保存成功");
                    refresh();
                }
                else {
                    alert(response.Message);
                }
            });
        }
        //function checkPassword(userid, password) {
        //    var checkpasswordurl = "/AdminUser/CheckPassword";
        //    webExpress.utility.ajax.request(checkpasswordurl, { Id: userid, PassWord: password },
        //        function(data) {
        //            alert(data.IsSuccess);
        //            if (!data.IsSuccess) {
        //                $("#txtypassworderror").show();
        //                $("#J_ypassword").focus();
        //            }
        //        });
        //}
        function deleteAdminUser(id) {
            alert("delete " + id);
            var url = "/AdminUser/Delete";
            webExpress.utility.ajax.request(url, {id : id },
            function (response) {
                if (response.IsSuccess) {
                    alert("删除成功");
                    refresh();
                }
                else {
                    alert(response.Message);
                }
            });
        }

        function resetPassword(model) {
            var checkpasswordurl = "/AdminUser/CheckPassword";
            var resetPasswordurl = "/AdminUser/ResetPassword";
            webExpress.utility.ajax.request(checkpasswordurl, { Id: model.Id, PassWord: model.Password },
                function(data) {
                    if (!data.IsSuccess) {
                        $("#txtypassworderror").text("原密码错误");
                        $("#txtypassworderror").show();
                        $("#J_ypassword").focus();
                    } else {
                        webExpress.utility.ajax.request(resetPasswordurl, model,
                            function(response) {
                                if (response.IsSuccess) {
                                    alert("保存成功");
                                    refresh();
                                } else {
                                    alert(response.Message);
                                }
                            });
                    }
                });
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