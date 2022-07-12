function animateReset() {
    $('.TravelMap').removeClass('animate_start')
    $('.TelescopicSight').removeClass('TelescopicSight-move')
    $('.RegionalBadge-name').css("opacity","0");
    setTimeout(() => $('.TravelMap').addClass('animate_start'), 10)
}

function travelMapMove(num) {
    const TravelMap_types = ['Della', 'Potronis', 'Nord', 'Chaoyang', 'Faline', 'Ruins']
    const $text = $('.RegionalFlag-name p')
    const $flag = $('.RegionalFlag-icon')
    const $landmark = $('.TravelMap-landmark-icon')
    const $TravelMap = $('.TravelMap')

    const current_type = TravelMap_types[num - 1]

    $TravelMap.attr('class', `TravelMap TravelMap-0${num}-${current_type}`)
    $text.text(current_type)
    $flag.attr('src', $flag.attr('src').replace(/knight_icon_0(\d)/, `knight_icon_0${num}`))
    $landmark.attr('src', $landmark.attr('src').replace(/landmark-0(\d)/, `landmark-0${num}`))
    animateReset()
}


export function telescopicSightMove() {
    TravelMapAll()
    console.log('telescopicSightMove')
    $('.RegionalBadge-icon-block img').on('click', function () {
        const id = $(this).attr('id')
        const num = id.slice(id.length - 1)
        travelMapMove(num)
        $(this).siblings('.RegionalBadge-name').css("opacity","1");
    })
}

function TravelMapAll() {
    console.log('TravelMapAll')
    let position = ''
    $(document).ready(function () {

        const rect = $('.TravelMapAll')[0].getBoundingClientRect()
        //控制rect出現頁面高度 ex: (...) - 100
        position = (rect.top - rect.height) 
    });

    $(window).on('scroll', init)

    function init() {
        console.log('NFTindexFlagReel scrollY')
        if (window.scrollY > position) {
            // 滑到此處雲開始移動
            $('.TravelMap-cloud').addClass('animate_start')
            $(window).unbind('scroll')
        }
    }
}