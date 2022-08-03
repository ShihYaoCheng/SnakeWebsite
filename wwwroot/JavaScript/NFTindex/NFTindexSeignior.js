export function NFTindexSeigniorReel() {
    console.log('NFTindexSeigniorReel')
    let positionReel = ''
    $(document).ready(function () {

        const SeigniorReel = $('.PPSRidersNFT-IconsAll')[0].getBoundingClientRect()
        //控制rect出現頁面高度 ex: (...) - 100
        positionReel = (SeigniorReel.top - SeigniorReel.height) - 400
    
    });

    $(window).on('scroll', init)

    function init() {
        console.log('NFTindexSeigniorReel scrollY  123213')
        if (window.scrollY > positionReel) {
            $('.PPSRidersNFT-IconsAll').addClass('animate_start')
            $(window).unbind('scroll')
        }
    }
}