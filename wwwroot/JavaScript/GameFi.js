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
        setTimeout(() => {
            $("#Rider-Snake").addClass("PPSR-Rider-Block-Hover"); 
            $(".not-Rider-Snake").addClass("PPSR-Rider-Block-notHover"); 
        }, 0);
    }
    ,function(){
        $("#Rider-Snake").removeClass("PPSR-Rider-Block-Hover"); 
        $(".PPSR-Rider-Block").removeClass("PPSR-Rider-Block-notHover"); 
    });
    
    $("#Rider-Knight").hover(function(){
        console.log("Rider-Knight")
        setTimeout(() => {
            $("#Rider-Knight").addClass("PPSR-Rider-Block-Hover"); 
            $(".not-Rider-Knight").addClass("PPSR-Rider-Block-notHover"); 
        }, 0);
    }
    ,function(){
        $("#Rider-Knight").removeClass("PPSR-Rider-Block-Hover"); 
        $(".PPSR-Rider-Block").removeClass("PPSR-Rider-Block-notHover"); 
    });

    $("#Rider-Weapon").hover(function(){
        console.log("Rider-Weapon")
        setTimeout(() => {
            $("#Rider-Weapon").addClass("PPSR-Rider-Block-Hover"); 
            $(".not-Rider-Weapon").addClass("PPSR-Rider-Block-notHover"); 
        }, 0);
    }
    ,function(){
        $("#Rider-Weapon").removeClass("PPSR-Rider-Block-Hover"); 
        $(".PPSR-Rider-Block").removeClass("PPSR-Rider-Block-notHover"); 
    });

    $("#Rider-Pet").hover(function(){
        console.log("Rider-Pet")
        setTimeout(() => {
            $("#Rider-Pet").addClass("PPSR-Rider-Block-Hover"); 
            $(".not-Rider-Pet").addClass("PPSR-Rider-Block-notHover"); 
        }, 0);
    }
    ,function(){
        $("#Rider-Pet").removeClass("PPSR-Rider-Block-Hover"); 
        $(".PPSR-Rider-Block").removeClass("PPSR-Rider-Block-notHover"); 
    });

}

window.GameFiCharts = function () {
    console.log("GameFiCharts 33", echarts)

    var chartDom = document.querySelector('.Pie-Chart')
    // var myChart = echarts.init(chartDom, null, { renderer: 'svg' });
    var myChart = echarts.init(chartDom);
    var option;

    option = {
        series: [
            {
                name: 'Access From',
                type: 'pie',
                radius: '50%',
                label: {
                    show: false
                },
                color: ['#F2CE8F','#EF9B8F'],
                data: [
                    { value: 45, name: 'DAO TreasuryUnlock from Arena    ' },
                    { value: 55, name: 'Operation  and Development team' },
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
    console.log('chartInit 1');
    let position = ''


    $(document).ready(function () {
        const rect = $('.Pie-Chart')[0].getBoundingClientRect()
        //控制圓餅出現頁面高度 ex: (...) - 100
        position = (rect.top - rect.height) 
    });

    $(window).on('scroll', init)

    function init() {
        if (window.scrollY > position) {
            window.GameFiCharts();
            $(window).unbind('scroll')
        }
    }
}
