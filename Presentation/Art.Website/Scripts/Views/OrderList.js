(function () {
    art.ui.view.OrderList = OrderListClass;

    function OrderListClass() {
        var _self = this;

        var _currentOrderId;
        var _searchCriteria = { PagingRequest: { PageIndex: 0, PageSize: 2 } };

        function _init() {
            _self.init = init;
            _self.search = search;
            _self.refresh = refresh;

            _self.accept = accept;
            _self.reject = reject;
            _self.deliver = deliver;
            _self.refund = refund;
        }

        function init() {
            $("#btnSearch").click(search);

            $(document).on("click", ".grid-pager a[pageIndex]", function () {
                var pageIndex = $(this).attr("pageIndex");
                refresh(pageIndex);
            });

            $(document).on("click", "a.wait-fh", function () {
                _currentOrderId = $(this).closest("tbody").attr("orderId");
            });

            $("#btnDelivery").click(function () {
                var companyName = $("#txtCompanyName").val();
                var billNumber = $("#txtBillNumber").val();
                deliver(companyName, billNumber);
            });
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

                }
                , function (data) {
                    $(".data").html(data.responseText);
                    _currentPageIndex = pageIndex;
                });
        }

        function accept() {

        }

        function reject(reason) {

        }

        function deliver(companyName, billNumber) {
            var url = "/Order/Deliver";
            var model = { Id: _currentOrderId, CompanyName: companyName, BillNumber: billNumber };
            webExpress.utility.ajax.request(url, model, function () {
                alert(333);
            });
        }

        function refund(info) {

        }

        _init();
    }
})();