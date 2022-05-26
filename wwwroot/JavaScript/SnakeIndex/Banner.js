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

                SnakeBanner.style.bottom = ((nowHeight + visibleHeight - (allHeight - footerHeight)) / visibleHeight * 100).toString() + "%"
            } else {
                SnakeBanner.style.bottom = "0%"
            }
        }

    })

}