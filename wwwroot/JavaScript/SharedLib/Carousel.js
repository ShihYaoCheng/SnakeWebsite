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

window.ACLS3RulesCarousel = function (Carousel) {
    $(".ACLS3RulesCarousel").owlCarousel({
        loop: true,
        margin: 10,
        //mouseDrag: false,
        responsive: {
            0: {
                items: 1
            }      
        }
        
    });
    var owl = $('.owl-carousel');
    owl.owlCarousel();
 
  
    owl.on('dragged.owl.carousel', function (event) {
        Typewriter()
    })
    function Typewriter() {
        var Typewriter = document.querySelectorAll(".Typewriter")
        var TimeSave = []

        for (var i = 0; i < 10000; i++) {
            clearTimeout(i)
        }
        Typewriter.forEach((e) => {
            for (let i in e.children) {
                if (typeof (e.children[i]) != "object") break
                e.children[i].style.display = "none";
                e.children[i].classList.remove("Typewriter-1Ani")

            }
        })
        Typewriter.forEach((e) => {
            for (let i in e.children) {
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

window.GameFiCarousel = function () {
    console.log('GameFiCarousel init22', Swiper);
    new Swiper('.GameFi-Carousel-Block', {
        spaceBetween: 100,
        autoplay: {
            delay: 2000,
        },
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