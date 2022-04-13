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
    console.log('GameFiCarousel init1');
    $("#GameFi-Carousel").owlCarousel({
        autoplay: true,
        autoplayTimeout: 5000,
        loop: true,
        nav: true,
        responsive:{
            0:{
                items:1
            },
            600:{
                items:2
            },
            1000:{
                items:5
            }
        }
    });
}