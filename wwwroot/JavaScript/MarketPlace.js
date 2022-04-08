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
