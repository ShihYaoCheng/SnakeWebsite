export function BackToTop() {
    $('a.back_to_top').click(function (e) {
        $('html, body').animate({ scrollTop: 0 }, '1000');
        e.preventDefault();
    });

    $(window).scroll(function () {
        if ($(this).scrollTop() > 300) {
            $('.back_to_top').fadeIn('2000');
        } else {
            $('.back_to_top').fadeOut('500');
        }
    });
    // jq navbar function
}