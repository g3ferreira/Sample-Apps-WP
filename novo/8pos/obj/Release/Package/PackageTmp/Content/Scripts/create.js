$(document).ready(function () {
    $("#PhoneNumber").mask("(000) 000-0000");
    $("#ZipCode").mask("0000-0000");
    $("#Price").mask('000,000.00', { reverse: true });

    $("#open-library").click(function () {
        var elem = $("#company-name");
        var val = $("#company-name").val();
        if (!val.trim()) {
            elem.css("border-color", "#ff2d2d");
            elem.focus();
        } else {
            $("#logo-library").modal("show");
            elem.css("border-color", "#ccc");
        }
        $("#logo-library form .row").show();
        $("#logo-library form .row:last-child").hide();
    });

    $('.input-file').change(function () {
        var id = $(this).attr('id');
        var input = $(this);
        var reader = new FileReader();

        reader.onload = function (e) {
            var img_selected = $("label[for=" + id + "]");
            img_selected.find("img").attr("src", e.target.result);
        };

        reader.readAsDataURL(input.get(0).files[0]);
    });

    $(".img-selected").on("mouseover focus", function () {
        var parent = $(this).attr("id");
        var id = parent.substr(-4);
        $("div[id*=opt-" + id + "]").show();
    });

    $(".arrow-change").click(function () {
        var parent = $(this).parent().attr("id");
        var id = parent.substr(-4);
        $("input[id*=" + id + "]").click();
    });

    var colors = {
        yellow: "#ffc600",
        orange: "#ff7800",
        red: "#ff2d2d",
        pink: "#f61a68",
        purple: "#511684",
        blue: "#252e9f",
        light_blue: "#7eaef6",
        cyano: "#3ce7e5",
        teal: "#1a5352",
        light_green: "#54d357",
        green: "#258e28",
        brown: "#533f20",
        beige: "#b1936c",
        black: "#000000",
        gray: "#6c6c6c"
    };

    var colorsList = $("ul#colors");

    $.each(colors, function (i, value) {
        var li = $("<li/>").appendTo(colorsList);
        $("<div class='circle'/>")
                .addClass(i)
                .attr("id", value)
                .appendTo(li);
    });

    $("button[id*='btn-layout-']").click(function () {
        $("#Theme").val($(this).attr("id"));
        $(this).text("SELECTED").removeClass("btn-white").addClass("btn-orange").css("padding", "10px 20px");
    });

    $(".circle").click(function () {
        $("ul li").find("div.fa").removeClass("fa fa-check");
        $(this).addClass('fa fa-check');
        $("#logo-library form .row").hide();
        $("#logo-library form .row:last-child").show();

        var id = $(this).attr("id");
        $("#ColorPattern").val(id);
        $("div[id*='layout-']").css("background-color", id);
        var company_name = $("#company-name").val().toUpperCase().trim();

        $("#logo1").clearCanvas();
        $("#logo2").clearCanvas();
        $("#logo3").clearCanvas();

        $("#logo1").drawText({
            fillStyle: id,
            x: 120, y: 30,
            fontSize: "20pt",
            fontFamily: "Lato",
            text: company_name,
            maxWidth: 120
        }).drawRect({
            strokeStyle: id,
            strokeWidth: 6,
            x: 120, y: 30,
            width: 240,
            height: 60
        });

        $("#logo2").drawText({
            fillStyle: id,
            x: 120, y: 50,
            fontSize: 20,
            fontFamily: "Lato",
            text: company_name
        });

        $("#logo3").drawText({
            fillStyle: id,
            x: 150, y: 30,
            fontSize: 30,
            align: 'left',
            fontFamily: "Permanent Marker, cursive",
            text: company_name,
            maxWidth: 100
        });
    });

    $('canvas').click(function () {
        var canvas = $(this)[0];
        var canvas_img = canvas.toDataURL("image/png");
        $("#input-logo").hide();
        $("#img-logo").css("display", "flex");
        $("#img-logo").find("img").attr("src", canvas_img);
        $("#logo-library").modal('toggle');
    });
});