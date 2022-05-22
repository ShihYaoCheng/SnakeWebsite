window.RoadmapSlideClick = function () {
    $('.Roadmap-Mobile-Title').click(function () {
        console.log('Roadmap-Mobile-Title-Click')
        $(this).parent().children('.Roadmap-Mobile-Slide').slideToggle('fast');
        $(this).children('.Filter-arrow').toggleClass('Filter-arrow-toggle');
        $(this).parent('.Roadmap-Item-Block').toggleClass('Roadmap-Item-BG');
    })
}

window.RiderHover = function (){
    
    // $(".PPSR-Rider-Block").hover(function(){
    //     setTimeout(() => {
    //         $(".PPSR-Rider-Block").not(this).css("opacity", "0.3"); 
    //     }, 500);
    // }
    // ,function(){
    //     $(".PPSR-Rider-Block").not(this).css("opacity", "1"); 
    // });

    $("#Rider-Snake").hover(function(){
        console.log("Rider-Snake")

        $("#Rider-Snake").addClass("PPSR-Rider-Block-Hover"); 
        $(".not-Rider-Snake").addClass("PPSR-Rider-Block-notHover"); 
        $("#line-Rider-Snake").show();
        // setTimeout(() => {
        //     $("#Info-Rider-Snake").show();
        // }, 500);
        $("#Info-Rider-Snake").addClass("Info-Rider-show"); 
    }
    ,function(){
        $("#Rider-Snake").removeClass("PPSR-Rider-Block-Hover"); 
        $(".PPSR-Rider-Block").removeClass("PPSR-Rider-Block-notHover"); 
        $(".Info-Rider").removeClass("Info-Rider-show"); 
        $(".line-Rider,.Info-Rider").hide();
        $("#Info-Rider-Snake").removeClass("Info-Rider-show"); 
    });


    $("#Rider-Knight").hover(function(){
        console.log("Rider-Knight")

        $("#Rider-Knight").addClass("PPSR-Rider-Block-Hover"); 
        $(".not-Rider-Knight").addClass("PPSR-Rider-Block-notHover"); 
        $("#line-Rider-Knight").show();
        // setTimeout(() => {
        //     $("#Info-Rider-Knight").show();
        // }, 500);
        $("#Info-Rider-Knight").addClass("Info-Rider-show"); 
    }
    ,function(){
        $("#Rider-Knight").removeClass("PPSR-Rider-Block-Hover"); 
        $(".PPSR-Rider-Block").removeClass("PPSR-Rider-Block-notHover"); 
        $(".line-Rider").hide();
        $("#Info-Rider-Knight").removeClass("Info-Rider-show"); 
    });


    $("#Rider-Weapon").hover(function(){
        console.log("Rider-Weapon")

        $("#Rider-Weapon").addClass("PPSR-Rider-Block-Hover"); 
        $(".not-Rider-Weapon").addClass("PPSR-Rider-Block-notHover"); 
        $("#line-Rider-Weapon").show();
        // setTimeout(() => {
        //     $("#Info-Rider-Weapon").show();
        // }, 500);
        $("#Info-Rider-Weapon").addClass("Info-Rider-show"); 
    }
    ,function(){
        $("#Rider-Weapon").removeClass("PPSR-Rider-Block-Hover"); 
        $(".PPSR-Rider-Block").removeClass("PPSR-Rider-Block-notHover"); 
        $(".line-Rider").hide();
        $("#Info-Rider-Weapon").removeClass("Info-Rider-show"); 
    });


    $("#Rider-Pet").hover(function(){
        console.log("Rider-Pet")

        $("#Rider-Pet").addClass("PPSR-Rider-Block-Hover"); 
        $(".not-Rider-Pet").addClass("PPSR-Rider-Block-notHover"); 
        $("#line-Rider-Pet").show();
        // setTimeout(() => {
        //     $("#Info-Rider-Pet").show();
        // }, 500);
        $("#Info-Rider-Pet").addClass("Info-Rider-show"); 
    }
    ,function(){
        $("#Rider-Pet").removeClass("PPSR-Rider-Block-Hover"); 
        $(".PPSR-Rider-Block").removeClass("PPSR-Rider-Block-notHover"); 
        $(".line-Rider").hide();
        $("#Info-Rider-Pet").removeClass("Info-Rider-show"); 
    });


    $(".PPSR-Rider-Block").hover(function(){
        $("#Rider-Pet").css({"animation":"none"});
        $(".PPSR-Click-Icon").hide();
        $(".PPSR-Rider-Block").removeClass("Rider-first");
    }
    ,function(){
        $(".PPSR-Rider-Block").removeClass("PPSR-Rider-Block-Hover"); 
        $(".PPSR-Rider-Block").removeClass("PPSR-Rider-Block-notHover"); 
        $(".line-Rider,.Info-Rider").hide();
    });
}

window.CirclePopup = function (){
    // var CircleItem = $(this).data("id");

    $(".Ecosystem-Circle #Circle-Item-01").click(function () { 
        console.log("CirclePopup")
        $(".Circle-Popup > .Ecosystem-Circle-Item").hide();
        $(".Circle-Popup > #Circle-Item-01").show();
        $(".Circle-Popup-BG").show();
        setTimeout(() => {
            $(".Circle-Popup").addClass("Circle-Popup-Open");
        }, 100);
    });
    $(".Ecosystem-Circle #Circle-Item-02").click(function () { 
        console.log("CirclePopup")
        $(".Circle-Popup > .Ecosystem-Circle-Item").hide();
        $(".Circle-Popup > #Circle-Item-02").show();
        $(".Circle-Popup-BG").show();
        setTimeout(() => {
            $(".Circle-Popup").addClass("Circle-Popup-Open");
        }, 100);
    });
    $(".Ecosystem-Circle #Circle-Item-03").click(function () { 
        console.log("CirclePopup")
        $(".Circle-Popup > .Ecosystem-Circle-Item").hide();
        $(".Circle-Popup > #Circle-Item-03").show();
        $(".Circle-Popup-BG").show();
        setTimeout(() => {
            $(".Circle-Popup").addClass("Circle-Popup-Open");
        }, 100);
    });
    $(".Ecosystem-Circle #Circle-Item-04").click(function () { 
        console.log("CirclePopup")
        $(".Circle-Popup > .Ecosystem-Circle-Item").hide();
        $(".Circle-Popup > #Circle-Item-04").show();
        $(".Circle-Popup-BG").show();
        setTimeout(() => {
            $(".Circle-Popup").addClass("Circle-Popup-Open");
        }, 100);
    });

    $(".Ecosystem-Circle").click(function () { 
        // 鎖住畫面
        // $("html").addClass("noscroll");
        
        // $("html").css({
            // "height": "100vh",
            // "overflow-y":" hidden"
        // });

    });

    $(".Popup-Back, .Circle-Popup-BG").click(function () { 
        // 解開畫面
        // $("html").removeClass("noscroll");

        $(".Circle-Popup-BG").hide();
        $(".Circle-Popup").removeClass("Circle-Popup-Open");
    });
}



window.GameFiCharts = function () {
    var chartDom = document.querySelector('.Pie-Chart')
    window.myChart = echarts.init(chartDom);
    var option;

    option = {
        series: [
            {
                name: 'Access From',
                type: 'pie',
                // selectedMode: 'single',
                // radius: '90%',
                radius: ['100%', '20%'],
                label : {
                    // show : false,
                    position: 'inner',
                    fontSize: 40,
                    color: "#1F3240",
                   },
                labelLine : {
                    show : false,
                    length: 10,
                    normal: {
                        lineStyle: {
                            color: '#69ADA2',
                            width: 8,
                        },
                    },
                },
                color: ['#F2CE8F','#EF9B8F'],
                itemStyle: {
                    borderColor: '#1F3240',
                    borderWidth: 5
                  },
                data: [
                    { value: 45, name: '45%' },
                    { value: 55, name: '55%' },
                ],
                emphasis: {
                    itemStyle: {
                        shadowBlur: 10,
                        shadowOffsetX: 0,
                        shadowColor: 'rgba(0, 0, 0, 0.5)'
                    }
                }
            }
        ]
    };

    option && myChart.setOption(option);

}

window.chartInit = function () {
    let position = ''


    $(document).ready(function () {

        // 改變size時重跑一次
        $(window).resize(function(){  
            window.myChart.resize()
        });  

        const rect = $('.Pie-Chart')[0].getBoundingClientRect()
        //控制圓餅出現頁面高度 ex: (...) - 100
        position = (rect.top - rect.height) - 200
    });

    $(window).on('scroll', init)

    function init() {
        if (window.scrollY > position) {
            window.GameFiCharts();
            setTimeout(() => {
                $(".Pie-Chart-Line").show();

                $(".Pie-Chart-Label").addClass("Pie-Chart-Label-show"); 
            }, 600);
            setTimeout(() => {
                $(".Pie-Chart-Icon").addClass("Pie-Chart-Label-show"); 
            }, 1000);
            $(window).unbind('scroll')
        }
    }
}
