window.Carousel = function (Carousel) {
    $("#character").owlCarousel({
        items: 1,
        autoplay: true,
        autoplayTimeout: 5000,
        loop: true,
        nav: true,
    });
    
}

window.ACLS3RulesCarousel = function () {
    $(".ACLS3RulesCarousel").owlCarousel({
        loop: true,
        margin: 2,
        //mouseDrag: false,
        responsive: {
            0: {
                items: 1
            }
        }

    });
    var owl = $('.ACLS3RulesCarousel');
    owl.owlCarousel();

    owl.on('dragged.owl.carousel', function (event) {
        Typewriter()
    })
    //���r�ʵe
    function Typewriter() {
        var Typewriter = document.querySelectorAll(".Typewriter")
        var TimeSave = []

        for (var i = 0; i < 10000; i++) {
            clearTimeout(i)
        }
        Typewriter.forEach((e) => {
            for (let i in e.children) {
                if (e.children[i].tagName == "IMG" || e.children[i].tagName == "DIV") continue
                if (typeof (e.children[i]) != "object") break

                e.children[i].style.display = "none";
                e.children[i].classList.remove("Typewriter-1Ani")

            }
        })
        Typewriter.forEach((e) => {
            for (let i in e.children) {
                if (e.children[i].tagName == "IMG" || e.children[i].tagName == "DIV") continue
                if (typeof (e.children[i]) != "object") break
                test(e.children[i], i)
            }
        })
        function test(e, index) {
            TimeSave.push(setTimeout(() => {
                e.style.display = "block";
                e.classList.add("Typewriter-1Ani")
            }, 800 * index))
        }

    }

}

window.ACLS3ScheduleCarousel = function () {
    $(".ACLS3ScheduleCarousel").owlCarousel({
        loop: true,
        margin: 10,
        dots: false,
        //mouseDrag: false,
        responsive: {
            0: {
                items: 1
            }
        }

    });

    var owl = $('.ACLS3ScheduleCarousel');
    owl.owlCarousel();

    $('.ScheduleMonth-next').click(function () {
        owl.trigger('next.owl.carousel');
    })
    $('.ScheduleMonth-prev').click(function () {
        // With optional speed parameter
        // Parameters has to be in square bracket '[]'
        owl.trigger('prev.owl.carousel', [300]);
    })


}


window.GameFiCarousel = function () {
   
    new Swiper('.GameFi-Carousel-Block', {
        spaceBetween: 100,
        // autoplay: {
        //     delay: 2000,
        // },
        slidesPerView: 1,
        loop: true,
        breakpoints: {
            300: {
                slidesPerView: 1,
            },
            500: {
                slidesPerView: 2,
            },
            700: {
                slidesPerView: 2.5,
            },
            1000: {
                slidesPerView: 3,
            },
            1200: {
                slidesPerView: 3.5,
            },
            1500: {
                slidesPerView: 4,
            },
        },
        navigation: {
            nextEl: ".swiper-button-next",
            prevEl: ".swiper-button-prev",
        },
        pagination: {
            el: ".swiper-pagination",
            clickable: true,
        },
    });
    // $("#GameFi-Carousel").owlCarousel({
    //     autoplay: true,
    //     autoplayTimeout: 5000,
    //     loop: true,
    //     nav: true,
    //     responsive:{
    //         0:{
    //             items:1
    //         },
    //         600:{
    //             items:2
    //         },
    //         1000:{
    //             items:3
    //         }
    //     }
    // });
}


window.NFTindexCarouselJS = function () {
    // export function NFTindexCarousel() {
    // console.log('NFTindexCarousel init22', Swiper);
    const swiper = new Swiper('.NFTindex-Carousel-Block', {
        spaceBetween: 100,

        // 不自動輪播
        // autoplay: {
        //     delay: 3500,
        // },
        // slidesPerView: 1,

        // 不循環
        // loop: true,
        breakpoints: {
            600: {
                slidesPerView: 1,
            },
            700: {
                slidesPerView: 1,
            },
            1000: {
                slidesPerView: 2,
            },
            1200: {
                slidesPerView: 3,
            },
            1500: {
                slidesPerView: 3,
            },
        },
        navigation: {
            nextEl: ".swiper-button-next",
            prevEl: ".swiper-button-prev",
        },
        pagination: {
            el: ".swiper-pagination",
            clickable: true,
        },
    });
    swiper.on('slideChange', function () {
        $('.lazy').lazy();
    });
}


window.NewYear2023_CarouselJS = function () {
    // export function NFTindexCarousel() {
    // console.log('NewYear2023_CarouselJS init22', Swiper);
    new Swiper('.NewYear2023-Carousel-Block', {
        spaceBetween: 100,

        // 不自動輪播
        // autoplay: {
        //     delay: 3500,
        // },
        // slidesPerView: 1,

        // 不循環
        // loop: true,
        breakpoints: {
            slidesPerView: 1,
        },
        navigation: {
            nextEl: ".swiper-button-next",
            prevEl: ".swiper-button-prev",
        },
        pagination: {
            el: ".swiper-pagination",
            clickable: true,
        },
    });
    
}

window.Valentine2023_CarouselJS = function () {
    // export function NFTindexCarousel() {
    // console.log('Valentine2023_CarouselJS init22', Swiper);
    new Swiper('.Valentine2023-Carousel-Block', {
        spaceBetween: 100,

        // 不自動輪播
        // autoplay: {
        //     delay: 3500,
        // },
        // slidesPerView: 1,

        // 不循環
        // loop: true,
        breakpoints: {
            slidesPerView: 1,
        },
        navigation: {
            nextEl: ".swiper-button-next",
            prevEl: ".swiper-button-prev",
        },
        pagination: {
            el: ".swiper-pagination",
            clickable: true,
        },
    });
    
}