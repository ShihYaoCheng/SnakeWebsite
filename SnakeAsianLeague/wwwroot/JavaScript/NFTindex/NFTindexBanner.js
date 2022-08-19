export function NFTindexBanner() {
    // console.log('NFTindexBanner')
    var scene = document.getElementById('Lantern_block');
    var scene = document.querySelector('.parallax_block')
    var parallaxInstance = new Parallax(scene,{
        selector: '.ParallaxMove'
    });


    setTimeout(() => {
        // $('.products-popupblock').show();
        // $('.products-popupblock').removeClass('popupblockTest');
    }, 2000);

    // console.log(111);
}