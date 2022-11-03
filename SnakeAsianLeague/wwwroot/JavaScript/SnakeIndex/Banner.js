export function eventBannerClose() {
    $('.event_banner').hide();
}

export function eventBannerS3Close() {
    $('.eventBannerS3').hide();
   
}

export function indexScrollEvent() {  
    
    window.addEventListener('scroll', () => {       
        if (window.location.pathname != "/") return      
        
        var visibleHeight = window.innerHeight
        var nowHeight = document.documentElement.scrollTop  
        var allHeight = document.body.scrollHeight
        //調整joinZone
        joinZone(visibleHeight, nowHeight)
        //調整banner
        bannerMove(visibleHeight, nowHeight, allHeight)       
    })

    //調整joinZone
    function joinZone(visibleHeight, nowHeight) {
        var NFTindex_BannerHeight = document.getElementById("NFTindex_Banner").scrollHeight
        var joinZone = document.querySelector(".join-container")
        /* var allHeight = document.body.scrollHeight*/
        //這是現在高度 + 螢幕高度 >  BannerHeight區塊高度 + joinZone 的自身高度跟top距離
        if (nowHeight + visibleHeight > NFTindex_BannerHeight + visibleHeight * 0.14 + joinZone.scrollHeight) {
            joinZone.classList.add("join-hover")
        } else {
            joinZone.classList.remove("join-hover")
        }
    }

    //調整banner
    function bannerMove(visibleHeight, nowHeight, allHeight) {
        var footerHeight = document.getElementById("webFooter").clientHeight
        var SnakeBanner = document.getElementById("SnakeBanner")
        if (SnakeBanner != null) {
            if (nowHeight + visibleHeight > allHeight - footerHeight) {

                SnakeBanner.style.bottom = ((nowHeight + visibleHeight - (allHeight - footerHeight)) / visibleHeight * 100).toString() + "%"
            } else {
                SnakeBanner.style.bottom = "0%"

            }
        }
    }
}


export function event_banner_Slide(event_banner_Slide) {
    $('.event_banner_bg').slideToggle();
    $(".event_banner").toggleClass("event_banner_Slide_close");
    $(".event_banner_logo").toggleClass("event_banner_logo_Slide_close");
}


