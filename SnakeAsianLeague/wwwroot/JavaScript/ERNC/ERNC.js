// 圓餅圖
export function chartInit() {
    let position = '';

    function i18nCallback() {
        const i18n_label = i18next.t('ERNC_data:chart', { returnObjects: true });
        setChart(i18n_label);
    }

    $(document).ready(function () {

        // 改變size時重跑一次
        $(window).resize(function () {
            window.myChart.resize()
        });

        const rect = $('#Pie-Chart')[0].getBoundingClientRect()
        //控制圓餅出現頁面高度 ex: (...) - 100
        position = (rect.top - rect.height) - 200

        window.i18nCallback = i18nCallback
    });

    $(window).on('scroll', init)

    function init() {
        if (window.scrollY > position) {
            const i18n_label = i18next.t('ERNC_data:chart', { returnObjects: true });
            // console.log(i18n_label);
            ERNCCharts(i18n_label);
            $(".Pie-Chart-Block").addClass("animate_start");
            $(window).unbind('scroll',init);
        }
    };

    function ERNCCharts(i18n_label){
        var chartDom = document.querySelector('#Pie-Chart')
        window.myChart = echarts.init(chartDom);
        setChart(i18n_label);
    }

    function setChart(i18n_label) {
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
                        // overflow: "break"

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
                        // DAO Treasury
                        { value: 45, name: i18n_label.label_01 },
                        // CQI Team
                        { value: 16, name: i18n_label.label_02 },
                        // Event
                        { value: 2, name: i18n_label.label_03 },
                        // Develop
                        { value: 8, name: i18n_label.label_04 },
                        // Advisor
                        { value: 4, name: i18n_label.label_05 },
                        // Public Sale
                        { value: 4, name: i18n_label.label_06 },
                        // Private Placement 
                        { value: 12, name: i18n_label.label_07 },
                        // Seed(0.06USD)
                        { value: 6, name: i18n_label.label_08 },
                        // Charity
                        { value: 3, name: i18n_label.label_09 }
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

                        // // DAO Treasury 45%
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

                        // Public Sale 4%
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
                        // Public Sale
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

// 圓餅圖RWD
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
            const i18n_label = i18next.t('ERNC_data:chart', { returnObjects: true });
            ERNCChartsRwd(i18n_label);
            $(window).unbind('scroll', initRwd)
        }
    };


    function ERNCChartsRwd(i18n_label) {
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

                        // // DAO Treasury 45%
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

                        // Public Sale 4%
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
                        // DAO Treasury
                        { value: 45, name: i18n_label.label_01 + ' 45%' },
                        // CQI Team
                        { value: 16, name: i18n_label.label_02 + ' 16%' },
                        // Event
                        { value: 2, name: i18n_label.label_03 + ' 2%' },
                        // Develop
                        { value: 8, name: i18n_label.label_04 + ' 8%' },
                        // Advisor
                        { value: 4, name: i18n_label.label_05 + ' 4%' },
                        // Public Sale
                        { value: 4, name: i18n_label.label_06 + ' 4%' },
                        // Private Placement 
                        { value: 12, name: i18n_label.label_07 + ' 12%' },
                        // Seed(0.06USD)
                        { value: 6, name: i18n_label.label_08 + ' 6%' },
                        // Charity
                        { value: 3, name: i18n_label.label_09 + ' 3%' }
                    ],
                }
            ]
        };

        option && myChartRwd.setOption(option);

    }
    
}


// PROJECT ROADMAP
export function roadMapScrollLeft() {
    console.log('roadMapScrollLeft')

    $(document).ready(function () {
        $("#btn-2022").click(function () {
            $(".Project-Block").scrollLeft(0);

            $('.Roadmap-Years').removeClass('Roadmap-Years-focus');
            $("#btn-2022").addClass('Roadmap-Years-focus');

            $(".Project-Year-Title").css('opacity','0.4');
            $("#Project-2022 .Project-Year-Title").css('opacity','1');
            $(".Project-Img-Block").css('opacity','0.4');
            $("#Project-2022 .Project-Img-Block").css('opacity','1');

            $(".Project-Year-Line").css('opacity','0');
            $('.Project-Year').removeClass('animate_start');
            $("#Project-2022").addClass('animate_start');

            $('.Project-Img').removeClass('Project-Img-focus');
            $("#Project-2022 .Project-Img").addClass('Project-Img-focus');
        });

        $("#btn-2023").click(function () {
            $(".Project-Block").scrollLeft(560);

            $('.Roadmap-Years').removeClass('Roadmap-Years-focus');
            $("#btn-2023").addClass('Roadmap-Years-focus');

            $(".Project-Year-Title").css('opacity','0.4');
            $("#Project-2023 .Project-Year-Title").css('opacity','1');
            $(".Project-Img-Block").css('opacity','0.4');
            $("#Project-2023 .Project-Img-Block").css('opacity','1');

            $(".Project-Year-Line").css('opacity','0');
            $('.Project-Year').removeClass('animate_start');
            $("#Project-2023").addClass('animate_start');

            $('.Project-Img').removeClass('Project-Img-focus');
            $("#Project-2023 .Project-Img").addClass('Project-Img-focus');
        });

        $("#btn-2024").click(function () {
            $(".Project-Block").scrollLeft(1855);

            $('.Roadmap-Years').removeClass('Roadmap-Years-focus');
            $("#btn-2024").addClass('Roadmap-Years-focus');

            $(".Project-Year-Title").css('opacity','0.4');
            $("#Project-2024 .Project-Year-Title").css('opacity','1');
            $(".Project-Img-Block").css('opacity','0.4');
            $("#Project-2024 .Project-Img-Block").css('opacity','1');

            $(".Project-Year-Line").css('opacity','0');
            $('.Project-Year').removeClass('animate_start');
            $("#Project-2024").addClass('animate_start');

            $('.Project-Img').removeClass('Project-Img-focus');
            $("#Project-2024 .Project-Img").addClass('Project-Img-focus');
        });

        // RWD
        $("#btn-2022-RWD").click(function () {
            // console.log('Roadmap-Years-RWD')
            $('.Roadmap-Years-RWD').removeClass('Roadmap-Years-focus');
            $("#btn-2022-RWD").addClass('Roadmap-Years-focus');

            $('.Project-Year').removeClass('animate_start');
            $("#Project-2022").addClass('animate_start');

            $('.Project').removeClass('Project-Img-focus-RWD');
            $("#Project-2022 .Project").addClass('Project-Img-focus-RWD');
        });

        $("#btn-2023-RWD").click(function () {
            $('.Roadmap-Years-RWD').removeClass('Roadmap-Years-focus');
            $("#btn-2023-RWD").addClass('Roadmap-Years-focus');

            $('.Project-Year').removeClass('animate_start');
            $("#Project-2023").addClass('animate_start');

            $('.Project').removeClass('Project-Img-focus-RWD');
            $("#Project-2023 .Project ").addClass('Project-Img-focus-RWD');
        });

        $("#btn-2024-RWD").click(function () {
            $('.Roadmap-Years-RWD').removeClass('Roadmap-Years-focus');
            $("#btn-2024-RWD").addClass('Roadmap-Years-focus');

            $('.Project-Year').removeClass('animate_start');
            $("#Project-2024").addClass('animate_start');

            $('.Project ').removeClass('Project-Img-focus-RWD');
            $("#Project-2024 .Project ").addClass('Project-Img-focus-RWD');
        });


    });

    $(document).mouseup(function (e) {
        var container =$(".Project"); // 這邊放你想要排除的區塊
        if (!container.is(e.target) && container.has(e.target).length === 0) {
            $('.Roadmap-Years').removeClass('Roadmap-Years-focus');
            $('.Roadmap-Years').removeClass('animate_start');
            $(".Project-Year-Title").css('opacity','1');
            // $(".Project").css('opacity','1');
            $(".Project-Img-Block").css('opacity','1');
            $(".Project-Img").css('opacity','0.6');
            $('.Project-Img').removeClass('Project-Img-focus');
            $(".Project-Year-Line").css('opacity','1');
            // $('.Roadmap-Years-RWD').removeClass('Roadmap-Years-focus');
        }
    });
}