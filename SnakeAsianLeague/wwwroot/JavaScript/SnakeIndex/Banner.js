export function eventBannerClose() {
    $('.event_banner').hide();
}

export function eventBannerS3Close() {
    $('.eventBannerS3').hide();
   
}

export function joinZoneMove() {
    window.addEventListener('scroll', () => {       
        if (window.location.pathname != "/") return      
        /*可見高度 */
        var visibleHeight = window.innerHeight
        var nowHeight = document.documentElement.scrollTop  
        var NFTindex_BannerHeight = document.getElementById("NFTindex_Banner").scrollHeight    
        var joinZone = document.querySelector(".join-container")    
       /* var allHeight = document.body.scrollHeight*/       
        //這是現在高度 + 螢幕高度 >  BannerHeight區塊高度 + joinZone 的自身高度跟top距離
        if (nowHeight + visibleHeight > NFTindex_BannerHeight + visibleHeight * 0.14 + joinZone.scrollHeight) {
            joinZone.classList.add("join-hover")
        } else {
            joinZone.classList.remove("join-hover")
        }       
    })
}


export function event_banner_Slide(event_banner_Slide) {
    $('.event_banner_bg').slideToggle();
    $(".event_banner").toggleClass("event_banner_Slide_close");
    $(".event_banner_logo").toggleClass("event_banner_logo_Slide_close");
}