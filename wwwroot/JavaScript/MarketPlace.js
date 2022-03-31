window.heartClick = function () {
    $('.heart, .Filter-heart').click(function(){
        $(this).toggleClass('heartClickRed')
    })
}
window.FilterButtonClick = function () {
    $('.Filter-Button').click(function(){
        $(this).toggleClass('Filter-Button-Click')
    })
}