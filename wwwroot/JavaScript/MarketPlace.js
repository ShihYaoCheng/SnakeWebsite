window.heartClick = function () {
    
    // $('NFT-Link').on('click', function(e) {
    //     console.log(".NFTcard a")
    //     if (e.target === $(this).find('.heart')[0]) {
    //       e.preventDefault()
    //     }
    // })

    $('.heart, .Filter-heart').click(function(){
        $(this).toggleClass('heartClickRed')
    })
}
window.FilterButtonClick = function () {
    $('.Filter-Button:not(#Filter-Button-Reset)').click(function(){
        console.log('FilterButtonClick')
        $(this).toggleClass('Filter-Button-Click')
    })
}

window.FilterArrowSlideClick = function () {
    $('.Filter-Title').click(function(){
        console.log('FilterArrowSlideClick')
        $(this).parent().children('.Filter-Options').slideToggle('fast');
        $(this).children('.Filter-arrow').toggleClass('Filter-arrow-toggle');
    })
    $('#Filter-mobile').click(function(){
        console.log('Filter-mobile-Slide')
        $('.marketPlaceSidebar').slideToggle('fast'); 
        $('.Filter-mobile-arrow').toggleClass('Filter-mobile-arrow-toggle'); 
    })


    $('.Filter-Web').click(function(){
        if($(window).width() > 1000){
            
                console.log('Filter > 1000')
                $('.Filter-Title-Block').addClass('Filter-Web');
                $('.marketPlaceSidebar-scroll').addClass('marketPlaceSidebar-scroll-Web');
            
                $('.marketPlaceSidebar-Web').toggleClass('height-unset'); 
                $('.marketPlaceSidebar-scroll-Web').slideToggle('fast'); 
                $('.Filter-web-arrow').toggleClass('Filter-web-arrow-toggle'); 

        }else{
            console.log('Filter < 1000')

            $('.Filter-Title-Block').removeClass('Filter-Web');
            $('.marketPlaceSidebar-scroll').removeClass('marketPlaceSidebar-scroll-Web');
            $('.marketPlaceSidebar-Web').removeClass('height-unset'); 

        }
    })


    $(window).resize(function () { 
        if($(window).width() > 1000){
            
            console.log('Filter > 1000')
            $('.Filter-Title-Block').addClass('Filter-Web');
            $('.marketPlaceSidebar-scroll').addClass('marketPlaceSidebar-scroll-Web');

        }else{
            console.log('Filter < 1000')

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

