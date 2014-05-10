(function () {
    webExpress.control.confirmWindow = ConfirmWindowClass;
    webExpress.control.confirmWindow.events = {};
    webExpress.control.confirmWindow.events.ok = "ok";
    webExpress.control.confirmWindow.events.cancel = "cancel";
    function ConfirmWindowClass(title, message) {
        var _self = this;

        function _init() {
            _self.show = show;
        }

        function show() {

        }
        _init();
    }
})()