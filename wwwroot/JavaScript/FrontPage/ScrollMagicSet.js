export function ScrollMagicSet() {

	var ScenesHeight = 0
	var nowWindownsWidth = document.body.clientWidth

	var airshipEndY = 100
	var airshipX = 1
	var airshipTop = '41%'
	var airshipScale = 1
	var QRCodeMoveY = 1
	var QRCodeMoveX = 1
	var CityX = 1
	var CityY = 1
	var CityBottom = '-10%'
	//響應式
	if (nowWindownsWidth >= 1500) {
		ScenesHeight = 800
	} else if (nowWindownsWidth < 1500 && nowWindownsWidth >= 1200 )  {
		ScenesHeight = 400
		airshipEndY= 150
		airshipScale = 1
		QRCodeMoveY = 0.5
		QRCodeMoveX = 0.5
		airshipTop = '45%'
		CityX = 0.9
		CityBottom = '-11%'
	} else if (nowWindownsWidth < 1200 && nowWindownsWidth >= 768) {
		ScenesHeight = 400
		airshipEndY = 300
		airshipX =0.5
		airshipScale = 1.1
		QRCodeMoveY = -1
		QRCodeMoveX = 0.4
		airshipTop = '57%'
		CityX=0.8
	} else if (nowWindownsWidth < 768 && nowWindownsWidth >= 564) {
		ScenesHeight = 400
		airshipEndY = 350
		airshipX = 0.3
		airshipScale = 1
		QRCodeMoveY = -1
		QRCodeMoveX = 0.3
		airshipTop = '60%'
		CityX= 0.7
	} else if (nowWindownsWidth < 564 ) {
		ScenesHeight = 400
		airshipEndY = 300
		airshipX = 0.08
		airshipScale = 1
		QRCodeMoveY = -1
		QRCodeMoveX = 0
		airshipTop = '60%'
		CityX =0.6
	}

	if (nowWindownsWidth < 376) {
		CityX = 0.09
		CityY = 0.3
		airshipX = 0.1
		QRCodeMoveY = -0.5
	}

	//設定start的高度	
	$(".Start").height($(window).height() + ScenesHeight)
	var StartLogoPath = {
		entry: {
			autoRotate: false,
			values: [
				{ scale: airshipScale * 0.7, y: -100 },
				{ scale: airshipScale * 0.4, y: -200 },
				{ scale: airshipScale * 0.1, y: -300 },
			]
		},
	}
	var airshipPath = {
		entry: {			
			autoRotate: false,
			values: [
				{ scale: airshipScale * 1.05,x: airshipX * 20, y:150 },
				{ scale: airshipScale * 1.1, x: airshipX * 60, y:200},
				{ scale: airshipScale * 1.15, x: airshipX * 100, y: 250 },
			]
		},
		step1: {
			autoRotate: false,
			values: [
				{ scale: airshipScale * 1.2, x: airshipX * 400, y: 250 },
				{ scale: airshipScale * 1.25, x: airshipX * 600, y: 300 },
				{ scale: airshipScale * 1.3, x: airshipX * 700, y: 350 },
			]
		},
		End: {
			curviness: 1.25,
			autoRotate: false,
			values: [

				{ scale: airshipScale * 1.3, y: 0, top: airshipTop },
			]
		}
	
	};
	var QRCodePath = {
		entry: {
			autoRotate: false,
			values: [
				/*{ x: QRCodeMoveX * 150, y: QRCodeMoveY*-90 },
				{ x: QRCodeMoveX * 200, y: QRCodeMoveY*-150 },
				{ x: QRCodeMoveX * 250, y: QRCodeMoveY*-180 },*/
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
				{  x: -5, y: -115, width: $(window).width()*1.1},
				{  x: 5, y: -105, width: $(window).width() * 1.05 },
				{  x: 0, y: -100, width: $(window).width() * 1.07 },
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
				{ y: -200 * CityY, x: 5},
				{ y: -450 * CityY, x: 0},
			]
		},
		step1: {
			autoRotate: false,
			values: [
				{ scale: 1.1, x: CityX*-10, scale: 1.1},
				{ scale: 1.2, x: CityX*-20, scale: 1.2 },
				{ scale: 1.3, x: CityX*-40, scale: 1.5 },
			]
		},
		End: {
			autoRotate: false,
			values: [			
				{ x: CityX * -200, bottom: CityBottom, y: 0, scale: 1.5 },
			]
		}
	}
	var CloudPath = {
		entry: {
			autoRotate: false,
			values: [
				{ y: -200, scale: 4 },
				{ y: -300, scale: 3 },
			]
		},
		step1: {
			autoRotate: false,
			values: [
				{ y: -300, scale:2},	
			]
		},
		End: {
			autoRotate: false,
			values: [
				{ bottom: "-5%", y: 0, width: $(window).width(), scale: 1},
			]
		}
	}

	// create tween
	var StartLogoTween = new TimelineMax()
		.add(TweenMax.to($(".StartLogo"), 3, { css: { bezier: StartLogoPath.entry }, ease: Power1.easeInOut }))

	var airshipTween = new TimelineMax()
		.add(TweenMax.to($(".airship"), 2, { css: { bezier: airshipPath.entry }, ease: Power1.easeInOut }))
		.add(TweenMax.to($(".airship"), 9, { css: { bezier: airshipPath.step1 }, ease: Power1.easeInOut }))
		.add(TweenMax.to($(".airship"), 10, { css: { bezier: airshipPath.End }, ease: Power1.easeInOut }))

	var QRCodeTween = new TimelineMax()
		.add(TweenMax.to($(".StartQRcode"), 1, { css: { bezier: QRCodePath.entry }, ease: Power1.easeInOut }))
	/*	.add(TweenMax.to($(".StartQRcode"), 4, { css: { bezier: QRCodePath.step1 }, ease: Power1.easeInOut }))
		.add(TweenMax.to($(".StartQRcode"), 10, { css: { bezier: QRCodePath.End }, ease: Power1.easeInOut }))*/

	var MountTween = new TimelineMax()
		.add(TweenMax.to($(".StartMount"), 7, { css: { bezier: MountPath.entry }, ease: Power1.easeInOut }))
		.add(TweenMax.to($(".StartMount"), 4, { css: { bezier: MountPath.step1 }, ease: Power1.easeInOut }))
		.add(TweenMax.to($(".StartMount"), 10, { css: { bezier: MountPath.End }, ease: Power1.easeInOut }))

	var City = new TimelineMax()
		.add(TweenMax.to($(".StartCity"), 7, { css: { bezier: CityPath.entry }, ease: Power1.easeInOut }))
		.add(TweenMax.to($(".StartCity"), 4, { css: { bezier: CityPath.step1 }, ease: Power1.easeInOut }))
		.add(TweenMax.to($(".StartCity"), 10, { css: { bezier: CityPath.End }, ease: Power1.easeInOut }))

	var Cloud = new TimelineMax()
		.add(TweenMax.to($(".buttonCloud"), 5, { css: { bezier: CloudPath.entry }, ease: Power1.easeInOut }))
		.add(TweenMax.to($(".buttonCloud"), 5, { css: { bezier: CloudPath.step1 }, ease: Power1.easeInOut }))
		.add(TweenMax.to($(".buttonCloud"), 9, { css: { bezier: CloudPath.End }, ease: Power1.easeInOut }))


	// 製作場景
	var controller = new ScrollMagic.Controller();


	var StartLogoScene = new ScrollMagic.Scene({
		triggerElement: ".Start-Container",
		duration: ScenesHeight,
		triggerHook: 0
	})
		//.setClassToggle(".redBlock", "show")  //增加class	
		.setTween(StartLogoTween)
		//.addIndicators({ name: "airship" })
		.addTo(controller);

	var airshipScene = new ScrollMagic.Scene({
        triggerElement: ".Start-Container",
		duration: ScenesHeight,
        triggerHook:0     
    })
    //.setClassToggle(".redBlock", "show")  //增加class
	.setPin('.Start-Container')
	.setClassToggle(".airship", ".withWind")
	.setTween(airshipTween)
	//.addIndicators({ name: "airship" })
	.addTo(controller);





	var MountScene = new ScrollMagic.Scene({
		triggerElement: ".Start-Container",
		duration: ScenesHeight,
		offset: 0,
		triggerHook: 0
	})
		.setTween(MountTween)
		.addTo(controller);

	var CityScene = new ScrollMagic.Scene({
		triggerElement: ".Start-Container",
		duration: ScenesHeight,
		triggerHook: 0
	})		
		.setTween(City)
		.addTo(controller);

	var CloudScene = new ScrollMagic.Scene({
		triggerElement: ".Start-Container",
		duration: ScenesHeight,
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
	if (window.location.pathname != '/') return
	// 製作場景
	var controller = new ScrollMagic.Controller();
	 var AboutReel = new ScrollMagic.Scene({
		triggerElement: ".reel-Container",		
	
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
		}, 1000)
			
	
	})


}