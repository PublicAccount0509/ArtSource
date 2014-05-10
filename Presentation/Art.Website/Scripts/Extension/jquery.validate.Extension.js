jQuery.validator.addMethod("exactlength", function (value, element, param) {
    return this.optional(element) || value.length == param;
}, jQuery.format("Please enter exactly {0} characters."));