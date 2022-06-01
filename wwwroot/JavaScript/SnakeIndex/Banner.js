export function eventBannerClose() {
    $('.event_banner').hide();
}

export function BannerMove() {
    window.addEventListener('scroll', () => {
        /*可見高度 */
        var visibleHeight = window.innerHeight
        var nowHeight = document.documentElement.scrollTop
        var allHeight = document.body.scrollHeight
        var footerHeight = document.getElementById("webFooter").clientHeight
        var SnakeBanner = document.getElementById("SnakeBanner")
        if (SnakeBanner != null) {
            if (nowHeight + visibleHeight > allHeight - footerHeight) {
                SnakeBanner.style.boxShadow = "0 0 0 0 "
                SnakeBanner.style.bottom = ((nowHeight + visibleHeight - (allHeight - footerHeight)) / visibleHeight * 100 ).toString() + "%"
            } else {
                SnakeBanner.style.bottom = "0%"
                SnakeBanner.style.boxShadow = "0 -5px 10px #ffedb05b, 0 0 30px rgb(123 217 248 / 80%)"
            }
        }

    })

}


export function event_banner_Slide(event_banner_Slide) {
    $('.event_banner_bg').slideToggle();
    $(".event_banner").toggleClass("event_banner_Slide_close");
    $(".event_banner_logo").toggleClass("event_banner_logo_Slide_close");
}