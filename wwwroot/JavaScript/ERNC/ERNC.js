export function chartInit() {
    console.log('ERNC-chartInit')

    let position = ''

    $(document).ready(function () {

        // 改變size時重跑一次
        $(window).resize(function () {
            window.myChart.resize()
        });

        const rect = $('#Pie-Chart')[0].getBoundingClientRect()
        //控制圓餅出現頁面高度 ex: (...) - 100
        position = (rect.top - rect.height) - 200
    });

    $(window).on('scroll', init)

    function init() {
        if (window.scrollY > position) {
            ERNCCharts();
            $(".Pie-Chart-Block").addClass("animate_start"); 
            $(window).unbind('scroll')
        }
    };

    function ERNCCharts() {
        var chartDom = document.querySelector('#Pie-Chart')
        window.myChart = echarts.init(chartDom);
        var option;

        option = {

            series: [
                {
                    name: 'Access From',
                    type: 'pie',
                    // selectedMode: 'single',
                    // radius: '90%',
                    radius: ['45%', '70%'],

                    // label: {
                    //     show: true,
                    //     position: 'inner',
                    //     position: 'center',
                    //     fontSize: 30,
                    //     color: "#1F3240",
                    // },

                    // emphasis: {
                    //     label: {
                    //       show: true,
                    //       fontSize: '40',
                    //       fontWeight: 'bold'
                    //     },
                    //   },

                    label: {
                        fontSize: 15,
                        lineHeight: 18,
                        color: '#ffffff',
                        overflow: "break"

                    },

                    labelLine: {
                        show: true,
                        // length: 10,
                        normal: {
                            lineStyle: {
                                color: '#ffffff',
                                width: 2,
                            },
                            // smooth: 0.2,
                            length: 30,
                        },


                    },
                    animationDelay: function (idx) {
                        return idx + 600;
                    },

                    itemStyle: {
                        color: '#00000000',
                    },

                    data: [
                        // DOA Treasury
                        { value: 45, name: 'DOA Treasury' },
                        // CQI Team
                        { value: 16, name: 'CQI Team' },
                        // Event
                        { value: 2, name: 'Event' },
                        // Develop
                        { value: 8, name: 'Develop' },
                        // Advisor
                        { value: 4, name: 'Advisor' },
                        // Public sale
                        { value: 4, name: 'Public sale' },
                        // Private Placement 
                        { value: 12, name: 'Private Placement' },
                        // Seed(0.06USD)
                        { value: 6, name: 'Seed (0.06USD)' },
                        // Charity
                        { value: 3, name: 'Charity' }
                    ],

                },

                {
                    name: 'Access From',
                    type: 'pie',
                    // selectedMode: 'single',
                    // radius: '90%',
                    radius: ['45%', '70%'],

                    label: {
                        show: false,
                        // position: 'inner',
                        position: 'center',
                        fontSize: 30,
                        color: '#ffffff'
                    },
                    itemStyle: {
                        borderRadius: 5,
                        borderColor: '#152837',
                        borderWidth: 0.5,
                        shadowBlur: 200,
                        shadowColor: 'rgba(0, 0, 0, 0.5)'
                    },
                    emphasis: {
                        label: {
                            show: true,
                            fontSize: '44',
                            fontWeight: 'bold'
                        },
                        itemStyle: {
                            shadowBlur: 10,
                            shadowOffsetX: 0,
                            shadowColor: 'rgba(0, 0, 0, 0.5)'
                          }
                    },

                    labelLine: {
                        show: true,
                        length: 10,
                        normal: {
                            lineStyle: {
                                color: '#69ADA2',
                                width: 2,
                            },
                        },
                    },
                    color: [

                        // // DOA Treasury 45%
                        new echarts.graphic.LinearGradient(0, 1, 0, 0, [{
                            offset: 0,
                            color: '#745858'
                        }, {
                            offset: 1,
                            color: '#B7836F'
                        }]),

                        // CQI Team 16%
                        new echarts.graphic.LinearGradient(0, 1, 0, 0, [{
                            offset: 0,
                            color: '#A1ADC4'
                        }, {
                            offset: 1,
                            color: '#E2EBFE'
                        }]),

                        // Event 2%
                        new echarts.graphic.LinearGradient(0, 1, 0, 0, [{
                            offset: 0,
                            color: '#CCC1DC'
                        }, {
                            offset: 1,
                            color: '#F4ECFF'
                        }]),

                        // Develop 8%
                        new echarts.graphic.LinearGradient(0, 1, 0, 0, [{
                            offset: 0,
                            color: '#99C5D4'
                        }, {
                            offset: 1,
                            color: '#AEDCEC'
                        }]),

                        // Advisor 4%
                        new echarts.graphic.LinearGradient(0, 1, 0, 0, [{
                            offset: 0,
                            color: '#DCB59A'
                        }, {
                            offset: 1,
                            color: '#FCD4B9'
                        }]),

                        // Public sale 4%
                        new echarts.graphic.LinearGradient(0, 1, 0, 0, [{
                            offset: 0,
                            color: '#EFE4BE'
                        }, {
                            offset: 1,
                            color: '#F1E7C5'
                        }]),

                        // Private Placement 12%
                        new echarts.graphic.LinearGradient(0, 1, 0, 0, [{
                            offset: 0,
                            color: '#D0E8C9'
                        }, {
                            offset: 1,
                            color: '#ECFFE6'
                        }]),

                        // Seed(0.06USD) 6%
                        new echarts.graphic.LinearGradient(0, 1, 0, 0, [{
                            offset: 0,
                            color: '#EFEFEF'
                        }, {
                            offset: 1,
                            color: '#ffffff'
                        }]),

                        // Charity 3%
                        new echarts.graphic.LinearGradient(0, 1, 0, 0, [{
                            offset: 0,
                            color: '#A9D2EF'
                        }, {
                            offset: 1,
                            color: '#CBE9FF'
                        }])
                    ],


                    data: [
                        { value: 45, name: '45%' },
                        // CQI Team
                        { value: 16, name: '16%' },
                        // Event
                        { value: 2, name: '2%' },
                        // Develop
                        { value: 8, name: '8%' },
                        // Advisor
                        { value: 4, name: '4% ' },
                        // Public sale
                        { value: 4, name: '4%' },
                        // Private Placement 
                        { value: 12, name: '12%' },
                        // Seed(0.06USD)
                        { value: 6, name: '6%' },
                        // Charity
                        { value: 3, name: '3%' }
                    ],

                }
            ]
        };

        option && myChart.setOption(option);

    }

}

export function chartInitRwd() {

    // 手機版

    let positionRwd = ''

    $(document).ready(function () {

        // 改變size時重跑一次
        $(window).resize(function () {
            window.myChartRwd.resize()
        });

        const rectRwd = $('#Pie-Chart-Rwd')[0].getBoundingClientRect()
        //控制圓餅出現頁面高度 ex: (...) - 100
        positionRwd = (rectRwd.top - rectRwd.height) - 200
    });

    $(window).on('scroll', initRwd)

    function initRwd() {
        if (window.scrollY > positionRwd) {
            ERNCChartsRwd();
            $(window).unbind('scroll',initRwd)
        }
    };


    function ERNCChartsRwd() {
        var chartDomRwd = document.querySelector('#Pie-Chart-Rwd')
        window.myChartRwd = echarts.init(chartDomRwd);
        var option;

        option = {
            tooltip: {
                trigger: 'item',

            },

            legend: {
                top: '0%',
                //   orient: 'vertical',
                left: 'center',
                selectedMode: false,
                textStyle: {
                    color: '#ffffff',
                }
            },
            series: [
                {
                    name: 'Access From',
                    type: 'pie',
                    top: '10%',
                    radius: ['50%', '80%'],
                    avoidLabelOverlap: false,

                    label: {
                        show: false,
                        position: 'center',

                    },
                    emphasis: {
                        label: {
                            show: true,
                            fontSize: '16',
                            color: '#ffffff',

                            // fontWeight: 'bold'
                        },
                        itemStyle: {
                            shadowBlur: 10,
                            shadowOffsetX: 0,
                            shadowColor: 'rgba(0, 0, 0, 0.5)'
                          }
                    },
                    labelLine: {
                        show: false
                    },
                    itemStyle: {
                        borderRadius: 5,
                        borderColor: '#152837',
                        borderWidth: 0.5,
                        shadowBlur: 200,
                        shadowColor: 'rgba(0, 0, 0, 0.5)'
                    },
                    color: [

                        // // DOA Treasury 45%
                        new echarts.graphic.LinearGradient(0, 1, 0, 0, [{
                            offset: 0,
                            color: '#745858'
                        }, {
                            offset: 1,
                            color: '#B7836F'
                        }]),
    
                        // CQI Team 16%
                        new echarts.graphic.LinearGradient(0, 1, 0, 0, [{
                            offset: 0,
                            color: '#A1ADC4'
                        }, {
                            offset: 1,
                            color: '#E2EBFE'
                        }]),
    
                        // Event 2%
                        new echarts.graphic.LinearGradient(0, 1, 0, 0, [{
                            offset: 0,
                            color: '#CCC1DC'
                        }, {
                            offset: 1,
                            color: '#F4ECFF'
                        }]),
    
                        // Develop 8%
                        new echarts.graphic.LinearGradient(0, 1, 0, 0, [{
                            offset: 0,
                            color: '#99C5D4'
                        }, {
                            offset: 1,
                            color: '#AEDCEC'
                        }]),
    
                        // Advisor 4%
                        new echarts.graphic.LinearGradient(0, 1, 0, 0, [{
                            offset: 0,
                            color: '#DCB59A'
                        }, {
                            offset: 1,
                            color: '#FCD4B9'
                        }]),
    
                        // Public sale 4%
                        new echarts.graphic.LinearGradient(0, 1, 0, 0, [{
                            offset: 0,
                            color: '#EFE4BE'
                        }, {
                            offset: 1,
                            color: '#F1E7C5'
                        }]),
    
                        // Private Placement 12%
                        new echarts.graphic.LinearGradient(0, 1, 0, 0, [{
                            offset: 0,
                            color: '#D0E8C9'
                        }, {
                            offset: 1,
                            color: '#ECFFE6'
                        }]),
    
                        // Seed(0.06USD) 6%
                        new echarts.graphic.LinearGradient(0, 1, 0, 0, [{
                            offset: 0,
                            color: '#EFEFEF'
                        }, {
                            offset: 1,
                            color: '#ffffff'
                        }]),
    
                        // Charity 3%
                        new echarts.graphic.LinearGradient(0, 1, 0, 0, [{
                            offset: 0,
                            color: '#A9D2EF'
                        }, {
                            offset: 1,
                            color: '#CBE9FF'
                        }])
                    ],
                    tooltip: {
                        show: true,
                        trigger: 'axis',
                        axisPointer: {
                            type: 'shadow'
                        },
                        // extraCssText:'white-space: pre-wrap;',
                    },
                    data: [
                        // DOA Treasury
                        { value: 45, name: 'DOA Treasury 45%' },
                        // CQI Team
                        { value: 16, name: 'CQI Team 16%' },
                        // Event
                        { value: 2, name: 'Event 2%' },
                        // Develop
                        { value: 8, name: 'Develop 8%' },
                        // Advisor
                        { value: 4, name: 'Advisor 4%' },
                        // Public sale
                        { value: 4, name: 'Public sale 4%' },
                        // Private Placement 
                        { value: 12, name: 'Private Placement 12%' },
                        // Seed(0.06USD)
                        { value: 6, name: 'Seed (0.06USD) 6%' },
                        // Charity
                        { value: 3, name: 'Charity 3%' }
                    ],
                }
            ]
        };



        option && myChartRwd.setOption(option);

    }
    ERNCChartsRwd();
}