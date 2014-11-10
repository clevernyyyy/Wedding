
/**
 *  This script will help scroll the contents of the wedding page
**/

$(document).ready(function () {
    $(window).scroll(function () {
        parallax();
    });
});


function parallax() {
    var scrolled = $(window).scrollTop();
    $('.wrapper').css('top', -(scrolled * 0.2) + 'px');
}