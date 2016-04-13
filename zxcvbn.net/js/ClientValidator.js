(function ($) {
    var zxcvbnWarning = function (value) {
        var value = $(value).val();
        var zx = zxcvbn(value);
        var msg = "Please use a stronger password.";
        if (zx.feedback) {
            msg += '<ul>';
            if (zx.feedback.warning)
                msg += '<li>' + zx.feedback.warning + '</li>';
            zx.feedback.suggestions.forEach(function (s) {
                msg += '<li>' + s + '</li>';
            })
            msg += '</ul>';
        }
        return msg;
    }

    $.validator.addMethod('strongpassword', function (value, element, params) {
        if (zxcvbn(value).score < 3)
            return false;
        return true
    }, zxcvbnWarning);

    $.validator.addMethod('verystrongpassword', function (value, element, params) {
        if (zxcvbn(value).score < 4)
            return false;
        return true
    }, zxcvbnWarning);

    $.validator.unobtrusive.adapters.add("strongpassword", [], function (options) {
        options.rules["strongpassword"] = options.element;
    });

    $.validator.unobtrusive.adapters.add("verystrongpassword", [], function (options) {
        options.rules["verystrongpassword"] = options.element;
    });
})(jQuery);