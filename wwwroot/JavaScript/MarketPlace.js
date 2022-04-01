window.heartClick = function () {
    $('.heart, .Filter-heart').click(function(){
        console.log("heartClick")
        $(this).toggleClass('heartClickRed')
    })
}
window.FilterButtonClick = function () {
    $('.Filter-Button').click(function(){
        console.log('FilterButtonClick')
        $(this).toggleClass('Filter-Button-Click')
    })
}

window.FilterArrowSlideClick = function () {
    $('.Filter-Title').click(function(){
        console.log('FilterArrowSlideClick')
        $(this).parent().children('.Filter-Options').slideToggle();

    })
    $('#Filter-mobile').click(function(){
        console.log('Filter-mobile-Slide')
        $('.marketPlaceSidebar').slideToggle(); 
    })

    // if($('.marketPlaceSidebar').length = 1 ){
    //     $(document).not($('.marketPlaceSidebar')).click(function(){
    //         $('.marketPlaceSidebar').slideUp();
    //     });
    // }

}