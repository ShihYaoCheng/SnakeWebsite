export function ScrollMagicSet() {
    var controller = new ScrollMagic.Controller();

    var scene = new ScrollMagic.Scene({
        triggerElement: ".redBlock"
    })
    .setClassToggle(".redBlock", "show")
    .addTo(controller);
}