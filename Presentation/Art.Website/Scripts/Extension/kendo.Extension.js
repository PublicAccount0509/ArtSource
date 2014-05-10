kendo.data.binders.date = kendo.data.Binder.extend({
    init: function (element, bindings, options) {
        kendo.data.Binder.fn.init.call(this, element, bindings, options);
        this.yearControl = $("select:eq(0)", element);
        this.monthControl = $("select:eq(1)", element);
        this.dayControl = $("select:eq(2)", element);

        this._change = $.proxy(this.change, this);

        this.yearControl.on("change", this._change);
        this.monthControl.on("change", this._change);
        this.dayControl.on("change", this._change);
    },
    change: function () {
        var value = this.yearControl.val() + "-" + this.monthControl.val() + "-" + this.dayControl.val();
        this.bindings["date"].set(value);
    },
    refresh: function () {
        var value = this.bindings["date"].get();
        if (value) {
            var dateParts = value.split("-");
            this.yearControl.val(dateParts[0] * 1);
            this.monthControl.val(dateParts[1] * 1);
            this.dayControl.val(dateParts[2] * 1);
        }
    }
});

kendo.data.binders.datetime = kendo.data.Binder.extend({
    init: function (element, bindings, options) {
        kendo.data.Binder.fn.init.call(this, element, bindings, options);
        this.dateControl = $(":text", element);
        this.hourControl = $("select.hour", element);
        this.minuteControl = $("select.minute", element);
        this.secondControl = $("select.second", element);

        this._change = $.proxy(this.change, this);

        this.dateControl.on("change", this._change);
        this.hourControl.on("change", this._change);
        this.minuteControl.on("change", this._change);
        this.secondControl.on("change", this._change);
    },
    change: function () {
        var value = this.dateControl.val() + " " + webExpress.utility.string.padLeft(this.hourControl.val(), 2, '0') + ":" + webExpress.utility.string.padLeft(this.minuteControl.val(), 2, '0') + ":00";
        this.bindings["datetime"].set(value);
    },
    refresh: function () {
        var value = this.bindings["datetime"].get();
        if (value) {
            this.dateControl.val(value.substr(0, 10));
            if (value.indexOf("T") > 0) {
                var date = new Date(value);
                this.hourControl.val(date.getHours());
                this.minuteControl.val(date.getMinutes());
            }
            else {
                this.hourControl.val(value.substr(11, 2) * 1);
                this.minuteControl.val(value.substr(14, 2) * 1);
            }
        }
    }
});
