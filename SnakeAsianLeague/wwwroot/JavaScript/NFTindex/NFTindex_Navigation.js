export function NFTindexNavigation() {
    console.log('NFTindexNavigation')

    const callback = (entries, observer) => {
        entries.forEach((entry) => {
            const num = $(entry.target).attr("data-num");
            if (entry.isIntersecting) {
                $(".title").eq(num - 1).addClass("on");
                $(".title-hover").eq(num - 1).addClass("title-hover-show");
            } else {
                $(".title").eq(num - 1).removeClass("on");
                $(".title-hover").eq(num - 1).removeClass("title-hover-show");
            }
        });
    };

    const observer = new IntersectionObserver(callback, {
        //調整大小  控制何時切換CLASS
        rootMargin: "-50%",
    });

    $(".sec").each((i, e) => {
        observer.observe(e);
    });

}