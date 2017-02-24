
$(document).ready(function () {

    $(".cssmenu").children("ul").children('li').on("click", function (e) {
        $(".active").removeClass('active');
        $(e.target).parent().addClass('active');
    });

});
