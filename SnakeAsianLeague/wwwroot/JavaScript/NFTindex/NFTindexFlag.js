export function NFTindexFlagReel() {
    console.log('NFTindexFlagReel')
    let position = ''
    $(document).ready(function () {

        const rect = $('.Flag-BlockAll')[0].getBoundingClientRect()
        //控制rect出現頁面高度 ex: (...) - 100
        position = (rect.top - rect.height) - 400
    
    });

    $(window).on('scroll', init)

    function init() {
        // console.log('NFTindexFlagReel scrollY')
        if (window.scrollY > position) {
            $('.Flag-BlockAll').addClass('animate_start')
            $(window).unbind('scroll',init)
        }
    }
}