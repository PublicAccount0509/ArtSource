 
(function () { 
    art.ui.view.ViewBase = ViewBaseClass;

    function ViewBaseClass() {
        var _self = this;

        function _init() {
            _self.attachBindingAttribute = attachBindingAttribute;
        }

        function attachBindingAttribute() {
            var properties = $("[property-name]");
            var controlAdapters = webExpress.controls.adpaters;
            for (var i = 0; i < properties.length; i++) {
                var $property = $(properties[i]);
                $property.addClass("control-group");
                var controlType = $property.attr("control-type");
                var adapter = controlAdapters[controlType];
                var controls = $property.find("*").andSelf().filter(adapter.controlSelector);
                for (var j = 0; j < controls.length; j++) {
                    var control = controls[j];
                    var propName = $property.attr("property-name");
                    control.name = propName;

                    var bindStr = $(control).attr("data-bind");
                    if (typeof (adapter.valueField) == "function") {
                        bindStr += "," + adapter.valueField(propName);
                    }
                    else {
                        bindStr += "," + adapter.valueField + ":" + propName;
                    }

                    if ($property.attr("data-source")) {
                        bindStr += "," + "source:" + $property.attr("data-source");
                    }

                    $(control).attr("data-bind", bindStr);
                }
            }
        }

        _init();
    }
})();