export function ScrollMagicSet() {
	//設定start的高度	
	$(".Start").height($(window).height() + 3000)

	var airshipPath = {
		entry: {			
			autoRotate: false,
			values: [
				{ scale: 1.05 ,x: 100, y:100 },
				{ scale: 1.1, x: 200, y:80},
				{ scale: 1.15, x: 300, y: 150 },
			]
		},
		step1: {
			autoRotate: false,
			values: [
				{ scale: 1.2, y: 150 },
				{ scale: 1.25, y: 100 },
				{ scale: 1.3, y: 150 },
			]
		},
		End: {
			curviness: 1.25,
			autoRotate: false,
			values: [
			
				{ scale: 1.5,y: 100 },
			]
		}
	
	};
	var QRCodePath = {
		entry: {
			autoRotate: false,
			values: [
				{ x: 200, y: -90 },
				{ x: 250, y: -150 },
				{ x: 300, y: -180 },
			]
		},
	/*	step1: {
			autoRotate: false,
			values: [
				{  y: -175},
				{ y: -185 },
				{ y: -180 },
			]
		},
		End: {
			curviness: 1.25,
			autoRotate: false,
			values: [
				{ y: -175 },
				{ y: -185 },
				{ y: -180 },
			]
		}
		*/
	};
	var MountPath = {
		entry: {
			autoRotate: false,
			values: [
				{ x: 5,y: -120},
			
			]
		},
		step1: {
			autoRotate: false,
			values: [
				{  x: -5, y: -115, width: $(window).width()*1.2},
				{  x: 5, y: -105, width: $(window).width() * 1.15 },
				{  x: 0, y: -100, width: $(window).width() * 1.1 },
			]
		},
		End: {
			autoRotate: false,
			values: [
				{
					x: 0, y: -110, width: $(window).width(), left: 0
				},
			]
		}
	}
	var CityPath = {
		entry: {
			autoRotate: false,
			values: [
				{ y: -200, x: 5},
				{ y: -450, x: 0},
			]
		},
		step1: {
			autoRotate: false,
			values: [
				{ scale: 1.1, x: -50, scale: 1.1},
				{ scale: 1.2, x: -80, scale: 1.2 },
				{ scale: 1.3, x: -100, scale: 1.5 },
			]
		},
		End: {
			autoRotate: false,
			values: [			
				{ x: -200, bottom: "5%", y: 0, scale: 1.6 },
			]
		}
	}
	var CloudPath = {
		entry: {
			autoRotate: false,
			values: [
				{ y: -200 },
			]
		},
		End: {
			autoRotate: false,
			values: [
				{ bottom: "-1%", y: 0, width: $(window).width() },
			]
		}
	}

	// create tween
	var airshipTween = new TimelineMax()
		.add(TweenMax.to($(".airship"), 3, { css: { bezier: airshipPath.entry }, ease: Power1.easeInOut }))
		.add(TweenMax.to($(".airship"), 4, { css: { bezier: airshipPath.step1 }, ease: Power1.easeInOut }))
		.add(TweenMax.to($(".airship"), 10, { css: { bezier: airshipPath.End }, ease: Power1.easeInOut }))

	var QRCodeTween = new TimelineMax()
		.add(TweenMax.to($(".StartQRcode"), 3, { css: { bezier: QRCodePath.entry }, ease: Power1.easeInOut }))
	/*	.add(TweenMax.to($(".StartQRcode"), 4, { css: { bezier: QRCodePath.step1 }, ease: Power1.easeInOut }))
		.add(TweenMax.to($(".StartQRcode"), 10, { css: { bezier: QRCodePath.End }, ease: Power1.easeInOut }))*/

	var MountTween = new TimelineMax()
		.add(TweenMax.to($(".StartMount"), 3, { css: { bezier: MountPath.entry }, ease: Power1.easeInOut }))
		.add(TweenMax.to($(".StartMount"), 4, { css: { bezier: MountPath.step1 }, ease: Power1.easeInOut }))
		.add(TweenMax.to($(".StartMount"), 10, { css: { bezier: MountPath.End }, ease: Power1.easeInOut }))

	var City = new TimelineMax()
		.add(TweenMax.to($(".StartCity"), 3, { css: { bezier: CityPath.entry }, ease: Power1.easeInOut }))
		.add(TweenMax.to($(".StartCity"), 4, { css: { bezier: CityPath.step1 }, ease: Power1.easeInOut }))
		.add(TweenMax.to($(".StartCity"), 10, { css: { bezier: CityPath.End }, ease: Power1.easeInOut }))

	var Cloud = new TimelineMax()
		.add(TweenMax.to($(".buttonCloud"), 5, { css: { bezier: CloudPath.entry }, ease: Power1.easeInOut }))
		.add(TweenMax.to($(".buttonCloud"), 12, { css: { bezier: CloudPath.End }, ease: Power1.easeInOut }))


	// 製作場景
    var controller = new ScrollMagic.Controller();
	var airshipScene = new ScrollMagic.Scene({
        triggerElement: ".Start-Container",
		duration: 3000,		
        triggerHook:0     
    })
    //.setClassToggle(".redBlock", "show")  //增加class
    .setPin('.Start-Container')
	.setTween(airshipTween)
	//.addIndicators({ name: "airship" })
	.addTo(controller);

	var MountScene = new ScrollMagic.Scene({
		triggerElement: ".Start-Container",
		duration: 3000,
		offset: 0,
		triggerHook: 0
	})
		.setTween(MountTween)
		.addTo(controller);

	var CityScene = new ScrollMagic.Scene({
		triggerElement: ".Start-Container",
		duration:3000,
		triggerHook: 0
	})		
		.setTween(City)
		.addTo(controller);

	var CloudScene = new ScrollMagic.Scene({
		triggerElement: ".Start-Container",
		duration: 3000,
		offset:0,
		triggerHook:0
	})	
		.setTween(Cloud)
		.addTo(controller);

	var QRCodeScene = new ScrollMagic.Scene({
		triggerElement: ".Start-Container",
		
		offset: 0,
		triggerHook: 0
	})
		.setTween(QRCodeTween)
		.addTo(controller);



	

}



export function AboutReel() {

	// 製作場景
	var controller = new ScrollMagic.Controller();
	 AboutReel = new ScrollMagic.Scene({
		triggerElement: ".reel-Container",		
		triggerHook: 1,//1,
		duration: 1000,
	})		
		.setClassToggle(".Paper-BG", "reelMove")		
		.addTo(controller);

	//進入場景後，將場景給關閉
	AboutReel
	.on("enter", function (e) {		
		AboutReel.enabled(false);
		setTimeout(() => {
			document.querySelector(".Paper-BG").classList.add("Paper-BG-show")			
		}, 3000)
			
	
	})

}