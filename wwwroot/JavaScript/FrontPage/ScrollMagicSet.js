export function ScrollMagicSet() {
	var flightpath = {
		entry: {
			
			autoRotate: false,
			values: [
				{ x: 100, y: 10 },
			
				{ x: 200, y: -5},
			
				{ x: 300, y: 10 },
			]
		},
		down: {
			curviness: 1.25,
			autoRotate: true,
			values: [
				{ x: 300, y: 100 },
			]
		}
	
	};
	// create tween
	var tween = new TimelineMax()
		.add(TweenMax.to($(".airship"),2, { css: { bezier: flightpath.entry }, ease: Power1.easeInOut }))
		.add(TweenMax.to($(".airship"), 5, { css: { bezier: flightpath.down }, ease: Power1.easeInOut }))


    var controller = new ScrollMagic.Controller();
    var scene = new ScrollMagic.Scene({
        triggerElement: ".Start-Container",
        duration: 2000,
        triggerHook:0     
    })
    //.setClassToggle(".redBlock", "show")  //增加class
    //增加場景
    .setTween(tween)
    .setPin('.Start-Container')
	.addIndicators({ name: "airship" })
    .addTo(controller);
}