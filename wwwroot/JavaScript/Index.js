window.QRcode_Slide = function (QRcode_Slide) {
    $('.QRcode_Slide').slideToggle();
}

// awardsSlide: function () {
//     $('.awards_line_detail').hide();
//     $('.line_01').children('.awards_line_detail').show();
//     $('.awards_line').click(function (e) {
//         e.preventDefault();
//         $(this).children('.awards_line_detail').slideToggle();
//     });
// },

window.event_banner_Slide = function (event_banner_Slide) {
    $('.event_banner_bg').slideToggle();
    $(".event_banner").toggleClass("event_banner_Slide_close");
    $(".event_banner_logo").toggleClass("event_banner_logo_Slide_close");
}

window.eventBannerClose = function () {
    $('.event_banner').hide();
}