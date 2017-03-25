$(document).ready(function () {    
    $("#features .panel-body").each(function(){
        var ths = $(this);
        var img = ths.css("background-image");
        var rgba = "linear-gradient(0deg, rgba(223, 115, 27, .7), rgba(223, 115, 27, .7))";
        ths.hover(function(){
            ths.css("background-image", rgba + "," + img);
        }, function (){
            ths.css("background-image", img);
        });
    });
    $("#logo-library").on("show.bs.modal", function () {
        MotionUI.animateIn($(this), 'hinge-in-from-middle-y');
    });
});
$(function () {
    $("#Birthday").combodate({
        minYear: 1937,
        maxYear: 1996
    });
    //Correcao do plugin JQuery Range Validator quando o elemento for 'checkbox'
    // extend range validator method to treat checkboxes differently
    var defaultRangeValidator = $.validator.methods.range;
    $.validator.methods.range = function (value, element, param) {
        if (element.type === 'checkbox') {
            // if it's a checkbox return true if it is checked
            return element.checked;
        } else {
            // otherwise run the default validation function
            return defaultRangeValidator.call(this, value, element, param);
        }
    }
    var validator = $("#form-create, #form-product").data('validator');
    if (validator) {
        validator.settings.ignore = "";
    }
});


