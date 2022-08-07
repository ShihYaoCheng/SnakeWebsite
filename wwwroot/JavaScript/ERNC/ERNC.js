export function chartInit() {
    console.log('ERNC-chartInit')

    let position = ''


    $(document).ready(function () {

        // 改變size時重跑一次
        $(window).resize(function () {
            window.myChart.resize()
        });

        const rect = $('.Pie-Chart')[0].getBoundingClientRect()
        //控制圓餅出現頁面高度 ex: (...) - 100
        position = (rect.top - rect.height) - 200
    });

    // $(window).on('scroll', init)

    // function init() {

    //     if (window.scrollY > position) {
    //         GameFiCharts();
    //         setTimeout(() => {
    //             $(".Pie-Chart-Line").show();

    //             $(".Pie-Chart-Label").addClass("Pie-Chart-Label-show"); 
    //         }, 600);
    //         setTimeout(() => {
    //             $(".Pie-Chart-Icon").addClass("Pie-Chart-Label-show"); 
    //         }, 1000);
    //         $(window).unbind('scroll')
    //     }
    // }

    GameFiCharts();
    setTimeout(() => {
        $(".Pie-Chart-Line").show();

        $(".Pie-Chart-Label").addClass("Pie-Chart-Label-show");
    }, 600);

    function GameFiCharts() {
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
                    radius: ['50%', '75%'],

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
                        fontSize: 12,
                        color: '#ffffff'
                    },
                    labelLine: {
                        show: true,
                        // length: 10,
                        normal: {
                            lineStyle: {
                                color: '#ffffff',
                                width: 2,
                            },
                        },
                    },

                    itemStyle: {
                        color: '#00000000'
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
                        { value: 6, name: 'Seed(0.06USD)' },
                        // Charity
                        { value: 3, name: 'Charity' }
                    ],

                },

                {
                    name: 'Access From',
                    type: 'pie',
                    // selectedMode: 'single',
                    // radius: '90%',
                    radius: ['50%', '75%'],

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
                        borderWidth: 1
                    },
                    emphasis: {
                        label: {
                            show: true,
                            fontSize: '40',
                            fontWeight: 'bold'
                        },
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
                            color: '#4e3c3c'
                        }, {
                            offset: 1,
                            color: '#966953'
                        }]),

                        // CQI Team 16%
                        new echarts.graphic.LinearGradient(0, 1, 0, 0, [{
                            offset: 0,
                            color: '#89a1d0'
                        }, {
                            offset: 1,
                            color: '#8ea7d9'
                        }]),

                        // Event 2%
                        new echarts.graphic.LinearGradient(0, 1, 0, 0, [{
                            offset: 0,
                            color: '#a18abf'
                        }, {
                            offset: 1,
                            color: '#9482ad'
                        }]),

                        // Develop 8%
                        new echarts.graphic.LinearGradient(0, 1, 0, 0, [{
                            offset: 0,
                            color: '#6c8fac'
                        }, {
                            offset: 1,
                            color: '#577792'
                        }]),

                        // Advisor 4%
                        new echarts.graphic.LinearGradient(0, 1, 0, 0, [{
                            offset: 0,
                            color: '#c08474'
                        }, {
                            offset: 1,
                            color: '#ad6b5a'
                        }]),

                        // Public sale 4%
                        new echarts.graphic.LinearGradient(0, 1, 0, 0, [{
                            offset: 0,
                            color: '#f6e09b'
                        }, {
                            offset: 1,
                            color: '#f6e09b'
                        }]),

                        // Private Placement 12%
                        new echarts.graphic.LinearGradient(0, 1, 0, 0, [{
                            offset: 0,
                            color: '#abd79e'
                        }, {
                            offset: 1,
                            color: '#8fb185'
                        }]),

                        // Seed(0.06USD) 6%
                        new echarts.graphic.LinearGradient(0, 1, 0, 0, [{
                            offset: 0,
                            color: '#ffffff'
                        }, {
                            offset: 1,
                            color: '#ffffff'
                        }]),

                        // Charity 3%
                        new echarts.graphic.LinearGradient(0, 1, 0, 0, [{
                            offset: 0,
                            color: '#74b9ff'
                        }, {
                            offset: 1,
                            color: '#72a6db'
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