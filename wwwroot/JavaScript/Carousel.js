window.Carousel = function (Carousel) {
    $("#character").owlCarousel({
        items: 1,
        autoplay: true,
        autoplayTimeout: 5000,
        loop: true,
        nav: true,
    });
    console.log('Carousel init1');
}

window.GameFiCarousel = function () {
    console.log('GameFiCarousel init22', Swiper);
    new Swiper('.GameFi-Carousel-Block', {
        spaceBetween: 100,
        // autoplay: {
        //     delay: 3000,
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