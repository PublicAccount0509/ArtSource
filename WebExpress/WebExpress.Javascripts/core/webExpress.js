window.webExpress = {};
webExpress.config = {};
webExpress.config.enums = {};

function EnumItem(value,text) {
    this.value = value;
    this.text = text;
}

EnumItem.prototype.toString = function () {
    return this.value;
}