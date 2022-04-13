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
    $('.Filter-Button').click(function(){
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

}
window.updateTextInput = function (val) {
    console.log('rangeInput')
    // $('#textInputRange').val(val);
}
