window.Carousel = function (Carousel) {
    console.log('jq',$);
    $(".owl-carousel").owlCarousel({
        items: 1,
        autoplay: true,
        autoplayTimeout: 5000,
        loop: true,
        nav: true,
    });
}

window.GameFiCarousel = function (Carousel) {
    console.log('jq',$);
    $(".owl-carousel").owlCarousel({
        items: 3,
        autoplay: true,
        autoplayTimeout: 5000,
        loop: true,
        nav: true,
    });
}