(function () {
    art.ui.view.OrderList = OrderListClass;

    function OrderListClass() {
        var adminjs = new adminglass(); //实例化后台类
        var _self = this;
        var DEFAULT_PAGESIZE = 10;
        var _currentOrderId;
        var _searchCriteria = { PagingRequest: { PageIndex: 0, PageSize: DEFAULT_PAGESIZE } };
        function _init() {
            _self.init = init;
            _self.search = search;
            _self.refresh = refresh;

            _self.accept = accept;
            _self.refuse = refuse;
            _self.deliver = deliver;
            _self.refund = refund;
        }

        function init() {
            $("#btnSearch").click(search);

            $(document).on("click", ".grid-pager a[pageIndex]", function () {
                var pageIndex = $(this).attr("pageIndex");
                refresh(pageIndex);
            });
            //等待发货弹框
            $(document).on('click', "#aOrderAddReminder", function () {
                _currentOrderId = $(this).closest("tbody").attr("orderId");
                $("#txtCompanyName").val("例如：圆通物流");
                $("#txtBillNumber").val("例如：9016080878");
                adminjs.openwinbox('#J_wuliubox');
                return false;
            });
            //退款弹框
            $(document).on('click', "#aRefund", function () {
                _currentOrderId = $(this).closest("tbody").attr("orderId");
                $("#txtRefundMessage").val("输入退款信息，买家姓名、退款账号等信息");
                adminjs.openwinbox('#J_refundbox');
                return false;
            });
            //拒绝弹框
            $(document).on('click', "#aOrderRefuse", function () {
                $("#txtRefuseMessage").val("输入拒绝理由");
                _currentOrderId = $(this).closest("tbody").attr("orderId");
                adminjs.openwinbox('#J_nobox');
                return false;
            });
            $("#btnDelivery").click(function () {
                var companyName = $("#txtCompanyName").val();
                var billNumber = $("#txtBillNumber").val();
                if (companyName == "" || companyName == "例如：圆通物流") {
                    alert("物流公司不可为空");
                    return;
                }
                if (billNumber == "" || billNumber == "例如：9016080878") {
                    alert("物流单号不可为空");
                    return;
                }
                deliver(companyName, billNumber);
            });

            $(document).on("click","#aOrderAccept", function () {
                _currentOrderId = $(this).closest("tbody").attr("orderId");
                accept();
            });
            $(document).on("click", "#btnConfirmRefuse", function () {
                refuse();
            });
            $(document).on("click", "#btnConfirmRefund", function() {
                refund();
            });
            art.ui.control.Pager.enablePaging(document, refresh);
        }

        function search() {
            _searchCriteria.StartDate = $("#startdate").val();
            _searchCriteria.EndDate = $("#enddate").val();
            _searchCriteria.IsPaid = $("#ddlIsPaid").val();
            _searchCriteria.Status = $("#ddlOrderStatus").val();
            _searchCriteria.OrderNumber = $("#txtOrderNumber").val();

            _searchCriteria.PagingRequest.PageIndex = 0;
            refresh();
        }

        function refresh(pageIndex) {
            var url = "/Order/List";
            if (pageIndex !== undefined) {
                _searchCriteria.PagingRequest.PageIndex = pageIndex;
            }
            webExpress.utility.ajax.request(url, _searchCriteria,
                function (data) {
                    $(".data").html(data);
                    adminjs.hoveritem('.J_showMsg', '.J_userMsg');
                });
        }

        function accept() {
            var url = "/Order/Accept";
            var model = { Id: _currentOrderId};
            webExpress.utility.ajax.request(url, model, function (data) {
                if (data) {
                    if (data.IsSuccess) {
                        refresh();
                    } else {
                        alert(data.Message);
                    }
                } else {
                    alert("请求失败");
                }
            });
        }
        //确认拒绝
        function refuse() {
            var url = "/Order/Refuse";
            var model = { Id: _currentOrderId, RefuseMessage: $("#txtRefuseMessage").val() };
            if (model.RefuseMessage == "" || model.RefuseMessage == "输入拒绝理由") {
                alert("请输入拒绝理由");
                return;
            }
            webExpress.utility.ajax.request(url, model, function (data) {
                adminjs.closewinbox('.add-openbox');
                if (data) {
                    if (data.IsSuccess) {
                        refresh();
                    } else {
                        alert(data.Message);
                    }
                } else {
                    alert("请求失败");
                }
            });
        }

        function deliver(companyName, billNumber) {
            var url = "/Order/Deliver";
            var model = { Id: _currentOrderId, DeliveryCompany: companyName, DeliveryNumber: billNumber };
            webExpress.utility.ajax.request(url, model, function (data) {
                adminjs.closewinbox('.add-openbox');
                if (data) {
                    if (data.IsSuccess) {
                        refresh();
                    } else {
                        alert(data.Message);
                    }
                } else {
                    alert("请求失败");
                }
            });
        }

        //确认退款
        function refund() {
            var url = "/Order/Refund";
            var model = { Id: _currentOrderId, RefundMessage: $("#txtRefundMessage").val() };
            if (model.RefundMessage == "" || model.RefundMessage == "输入退款信息，买家姓名、退款账号等信息") {
                alert("请输入退款理由");
                return;
            }
            webExpress.utility.ajax.request(url, model, function (data) {
                adminjs.closewinbox('.add-openbox');
                if (data) {
                    if (data.IsSuccess) {
                        refresh();
                    } else {
                        alert(data.Message);
                    }
                } else {
                    alert("请求失败");
                }
            });
        }
        _init();
    }
})();