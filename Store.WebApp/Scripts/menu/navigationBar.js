
$(document).ready(function () {

    $(".barButton").on("click", function (e) {
        $(".barButtonActive").removeClass('barButtonActive');
        $(e.target).addClass('barButtonActive');
    });

});
