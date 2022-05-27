window.heartClick = function () {

    // $('NFT-Link').on('click', function(e) {
    //     console.log(".NFTcard a")
    //     if (e.target === $(this).find('.heart')[0]) {
    //       e.preventDefault()
    //     }
    // })

    $('.heart, .Filter-heart').click(function () {
        $(this).toggleClass('heartClickRed')
    })
}
window.FilterButtonClick = function () {
    $('.Filter-Button:not(#Filter-Button-Reset)').click(function () {
        console.log('FilterButtonClick')
        $(this).toggleClass('Filter-Button-Click')
    })
}

window.FilterArrowSlideClick = function () {
    $('.Filter-Title').click(function () {
        console.log('FilterArrowSlideClick')
        $(this).parent().children('.Filter-Options').slideToggle('fast');
        $(this).children('.Filter-arrow').toggleClass('Filter-arrow-toggle');
    })
    $('#Filter-mobile').click(function () {
        console.log('Filter-mobile-Slide')
        $('.marketPlaceSidebar').slideToggle('fast');
        $('.Filter-mobile-arrow').toggleClass('Filter-mobile-arrow-toggle');
    })


    $('.Filter-Web').click(function () {
        if ($(window).width() > 1000) {

            // console.log('Filter > 1000')
            $('.Filter-Title-Block').addClass('Filter-Web');
            $('.marketPlaceSidebar-scroll').addClass('marketPlaceSidebar-scroll-Web');

            $('.marketPlaceSidebar-Web').toggleClass('height-unset');
            $('.marketPlaceSidebar-scroll-Web').slideToggle('fast');
            $('.Filter-web-arrow').toggleClass('Filter-web-arrow-toggle');

        } else {
            // console.log('Filter < 1000')

            $('.Filter-Title-Block').removeClass('Filter-Web');
            $('.marketPlaceSidebar-scroll').removeClass('marketPlaceSidebar-scroll-Web');
            $('.marketPlaceSidebar-Web').removeClass('height-unset');

        }
    })


    $(window).resize(function () {
        if ($(window).width() > 1000) {

            // console.log('Filter > 1000')
            $('.Filter-Title-Block').addClass('Filter-Web');
            $('.marketPlaceSidebar-scroll').addClass('marketPlaceSidebar-scroll-Web');

        } else {
            // console.log('Filter < 1000')

            $('.Filter-Title-Block').removeClass('Filter-Web');
            $('.marketPlaceSidebar-scroll').removeClass('marketPlaceSidebar-scroll-Web');
            $('.marketPlaceSidebar-Web').removeClass('height-unset');
            $('.marketPlaceSidebar-scroll').show();
        }
    });


    // $('.Filter-Web').click(function(){

    //     if($(window).width() > 1000){
    //     console.log('Filter > 1000')
    //     $('.Filter-Title-Block').addClass('Filter-Web');
    //     $('.marketPlaceSidebar-scroll').addClass('marketPlaceSidebar-scroll-Web');

    //     $('.marketPlaceSidebar-Web').toggleClass('height-unset'); 
    //     $('.marketPlaceSidebar-scroll-Web').slideToggle('fast'); 
    //     $('.Filter-web-arrow').toggleClass('Filter-web-arrow-toggle'); 
    //     }else{
    //         console.log('Filter < 1000')

    //         $('.Filter-Title-Block').removeClass('Filter-Web');
    //         $('.marketPlaceSidebar-scroll').removeClass('marketPlaceSidebar-scroll-Web');
    //         $('.marketPlaceSidebar-Web').removeClass('height-unset'); 

    //     }

    // })








}
window.updateTextInput = function (val) {
    console.log('rangeInput')
    // $('#textInputRange').val(val);
}

// window.FilterRange = function () {
//     console.log('FilterRange')

//     var skipSlider = document.getElementById("skipstep");
//     var skipValues = [
//         document.getElementById("skip-value-lower"),
//         document.getElementById("skip-value-upper")
//     ];
//     var MinValue = Number($('#skip-value-lower input').text());
//     var MaxValue = Number($('#skip-value-upper').text());


//     // $('.textInputRange').keyup(function () { 
//     //     // inputMinValue.text('#input-value-lower');
//     //     var inputMinValue = $('#input-value-lower').val();
//     //     var MinValue = parseInt($('#skip-value-lower').text());
//     //     console.log(inputMinValue)


               
//     // });


//     noUiSlider.create(skipSlider, {
//         start: [MinValue, MaxValue],
//         connect: true,
//         behaviour: "drag",
//         step: 1,
//         range: {
//             min: MinValue,
//             max: MaxValue
//         },
//         format: {
//             from: function (value) {
//                 return parseInt(value);
//             },
//             to: function (value) {
//                 return parseInt(value);
//             }
//         }
//     });

//     skipSlider.noUiSlider.on("update", function (values, handle) {
//         skipValues[handle].innerHTML = values[handle];
//     });

// }

