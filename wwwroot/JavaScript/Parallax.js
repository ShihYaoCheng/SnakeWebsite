window.ParallaxInit = function () {
    console.log('Parallax',Parallax);
    // var scene = document.getElementById('Lantern_block');
    var scene = document.querySelector('.parallax_block')
    var parallaxInstance = new Parallax(scene,{
        selector: '.move'
    });
}