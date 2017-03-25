$(function () {
    $(document).ajaxStart(function () {
        $(".loader").show();
    });

    $(document).ajaxStop(function () {
        $(".loader").hide();
    });

    var id = $("#PosUserId").val();
    $.ajax({
        url: '/User/GeneralContent/',
        type: "GET",
        data: { id: id }
    }).done(function (result) {
        $("#general-content").html(result);
    });

    $.ajax({
        url: '/User/WebsiteContent/',
        type: "GET",
        data: { id: id }
    }).done(function (result) {
        $("#website-content").html(result);
    })
})