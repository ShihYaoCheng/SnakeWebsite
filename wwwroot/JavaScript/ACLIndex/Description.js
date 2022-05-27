export var description = {
    calendar: function () {
        let calendarEl = document.getElementById('calendar');
        let calendar = new FullCalendar.Calendar(calendarEl, {
            initialDate: '2021-09-01',
            locale: 'zh-tw'
        });
        calendar.render();
        const colors = {
            p_normal: '#D9D9D9',
            p_weekly: '#c5d9ee',
            p_month: '#8caed0',
            p_season: '#457bb1',
            t_normal: '#D9D9D9',
            t_day: '#F5C0C0',
            t_month: '#f38d8d',
            t_season: '#ca4444',

        }

        function setCalendar() {
            const currentMonth = calendar.currentData.currentDate.getMonth()
            const colorValues = Object.values(colors)
            let data = description.currentData || description.personalData
            if (!data[currentMonth]) return

            $(`td`).css("background", "none")
            $('.fc-daygrid-day-events').text("")

            data[currentMonth].days.forEach((e, i) => {
                $(`td[data-date=${e.date}]`).css({
                    "background": colorValues[e.color]
                })
                $(`td[data-date=${e.date}] .fc-daygrid-day-events`).text(e.code)
            })
        }

        setCalendar()
        if (description.currentData === null || description.currentData === description.personalData) {
            description.calendarTab(0)
        } else {
            description.calendarTab(1)
        }

        $('.fc-prev-button').on('click', setCalendar)
        $('.fc-next-button').on('click', setCalendar)

    },

    calendarTab: function (index) {
        switch (index) {
            case 0:
                description.currentData = description.personalData
                break;
            case 1:
                description.currentData = description.teamData
                break;
        }

        $(".schedule_button").removeClass("schedule_button_click");
        $(".schedule_button").eq(index).addClass("schedule_button_click");
        $(".schedule_p_all").css({ display: "none" });
        $(".schedule_p_all").eq(index).css({ display: "flex" });

    },

    personalData: {
        8: {
            days: [
                {
                    date: '2021-09-06',
                    code: 'D1-1',
                    award: 1
                },
                {
                    date: '2021-09-07',
                    code: 'D1',
                    color: '1'
                },
                {
                    date: '2021-09-08',
                    code: 'D2-2',
                    color: '0'
                },
                {
                    date: '2021-09-09',
                    code: 'D2',
                    color: '1'
                },
                {
                    date: '2021-09-13',
                    code: 'D3-1',
                    color: '0'
                },
                {
                    date: '2021-09-14',
                    code: 'D3',
                    color: '1'
                },
                {
                    date: '2021-09-15',
                    code: 'D4-1',
                    color: '0'
                },
                {
                    date: '2021-09-16',
                    code: 'D4',
                    color: '1'
                },
                {
                    date: '2021-09-20',
                    code: 'D5-1',
                    color: '0'
                },
                {
                    date: '2021-09-21',
                    code: 'D5',
                    color: '1'
                },
                {
                    date: '2021-09-22',
                    code: 'D6-1',
                    color: '0'
                },
                {
                    date: '2021-09-23',
                    code: 'D6',
                    color: '1'
                },
                {
                    date: '2021-09-24',
                    code: 'M1-1',
                    color: '0'
                },
                {
                    date: '2021-09-25',
                    code: 'M1',
                    color: '2'
                },
            ]
        },
        9: {
            days: [
                {
                    date: '2021-10-04',
                    code: 'D7-1',
                    color: '0'
                },
                {
                    date: '2021-10-05',
                    code: 'D7',
                    color: '1'
                },
                {
                    date: '2021-10-06',
                    code: 'D8-1',
                    color: '0'
                },
                {
                    date: '2021-10-07',
                    code: 'D8',
                    color: '1'
                },
                {
                    date: '2021-10-11',
                    code: 'D9-1',
                    color: '0'
                },
                {
                    date: '2021-10-12',
                    code: 'D9',
                    color: '1'
                },
                {
                    date: '2021-10-13',
                    code: 'D10-1',
                    color: '0'
                },
                {
                    date: '2021-10-14',
                    code: 'D10',
                    color: '1'
                },
                {
                    date: '2021-10-18',
                    code: 'D11-1',
                    color: '0'
                },
                {
                    date: '2021-10-19',
                    code: 'D11',
                    color: '1'
                },
                {
                    date: '2021-10-20',
                    code: 'D12-1',
                    color: '0'
                },
                {
                    date: '2021-10-21',
                    code: 'D12',
                    color: '1'
                },
                {
                    date: '2021-10-22',
                    code: 'M2-1',
                    color: '0'
                },
                {
                    date: '2021-10-23',
                    code: 'M2',
                    color: '2'
                },
            ]
        },
        10: {
            days: [
                {
                    date: '2021-11-01',
                    code: 'D13-1',
                    color: '0'
                },
                {
                    date: '2021-11-02',
                    code: 'D13',
                    color: '1'
                },
                {
                    date: '2021-11-03',
                    code: 'D14-1',
                    color: '0'
                },
                {
                    date: '2021-11-04',
                    code: 'D14',
                    color: '1'
                },
                {
                    date: '2021-11-08',
                    code: 'D15-1',
                    color: '0'
                },
                {
                    date: '2021-11-09',
                    code: 'D15',
                    color: '1'
                },
                {
                    date: '2021-11-10',
                    code: 'D16-1',
                    color: '0'
                },
                {
                    date: '2021-11-11',
                    code: 'D16',
                    color: '1'
                },
                {
                    date: '2021-11-15',
                    code: 'D17-1',
                    color: '0'
                },
                {
                    date: '2021-11-16',
                    code: 'D17',
                    color: '1'
                },
                {
                    date: '2021-11-17',
                    code: 'D18-1',
                    color: '0'
                },
                {
                    date: '2021-11-18',
                    code: 'D18',
                    color: '1'
                },
                {
                    date: '2021-11-19',
                    code: 'M3-1',
                    color: '0'
                },
                {
                    date: '2021-11-20',
                    code: 'M2',
                    color: '2'
                },
                {
                    date: '2021-11-25',
                    code: 'S1-1',
                    color: '0'
                },
                {
                    date: '2021-11-26',
                    code: 'S1-1',
                    color: '0'
                },
                {
                    date: '2021-11-27',
                    code: 'S1',
                    color: '3'
                },
            ]
        },
    },

    teamData: {
        8: {
            days: [
                {
                    date: '2021-09-07',
                    code: 'W1-1',
                    color: '0'
                },
                {
                    date: '2021-09-08',
                    code: 'W1-2',
                    color: '0'
                },
                {
                    date: '2021-09-09',
                    code: 'W1-3',
                    color: '0'
                },
                {
                    date: '2021-09-10',
                    code: 'W1-4',
                    color: '0'
                },
                {
                    date: '2021-09-11',
                    code: 'W1-5',
                    color: '0'
                },
                {
                    date: '2021-09-12',
                    code: 'W1',
                    color: '5'
                },
                {
                    date: '2021-09-14',
                    code: 'W2-1',
                    color: '0'
                },
                {
                    date: '2021-09-15',
                    code: 'W2-2',
                    color: '0'
                },
                {
                    date: '2021-09-16',
                    code: 'W2-3',
                    color: '0'
                },
                {
                    date: '2021-09-17',
                    code: 'W2-4',
                    color: '0'
                },
                {
                    date: '2021-09-18',
                    code: 'W2-5',
                    color: '0'
                },
                {
                    date: '2021-09-19',
                    code: 'W2',
                    color: '5'
                },
                {
                    date: '2021-09-21',
                    code: 'M1-1',
                    color: '0'
                },
                {
                    date: '2021-09-22',
                    code: 'M1-2',
                    color: '0'
                },
                {
                    date: '2021-09-23',
                    code: 'M1-3',
                    color: '0'
                },
                {
                    date: '2021-09-24',
                    code: 'M1-4',
                    color: '0'
                },
                {
                    date: '2021-09-25',
                    code: 'M1-5',
                    color: '0'
                },
                {
                    date: '2021-09-26',
                    code: 'M1',
                    color: '6'
                },
            ]
        },
        9: {
            days: [
                {
                    date: '2021-10-05',
                    code: 'W3-1',
                    color: '0'
                },
                {
                    date: '2021-10-06',
                    code: 'W3-2',
                    color: '0'
                },
                {
                    date: '2021-10-07',
                    code: 'W3-3',
                    color: '0'
                },
                {
                    date: '2021-10-08',
                    code: 'W3-4',
                    color: '0'
                },
                {
                    date: '2021-10-09',
                    code: 'W3-5',
                    color: '0'
                },
                {
                    date: '2021-10-10',
                    code: 'W3',
                    color: '5'
                },
                {
                    date: '2021-10-12',
                    code: 'W4-1',
                    color: '0'
                },
                {
                    date: '2021-10-13',
                    code: 'W4-2',
                    color: '0'
                },
                {
                    date: '2021-10-14',
                    code: 'W4-3',
                    color: '0'
                },
                {
                    date: '2021-10-15',
                    code: 'W4-4',
                    color: '0'
                },
                {
                    date: '2021-10-16',
                    code: 'W4-5',
                    color: '0'
                },
                {
                    date: '2021-10-17',
                    code: 'W4',
                    color: '5'
                },
                {
                    date: '2021-10-19',
                    code: 'M2-1',
                    color: '0'
                },
                {
                    date: '2021-10-20',
                    code: 'M2-2',
                    color: '0'
                },
                {
                    date: '2021-10-21',
                    code: 'M2-3',
                    color: '0'
                },
                {
                    date: '2021-10-22',
                    code: 'M2-4',
                    color: '0'
                },
                {
                    date: '2021-10-23',
                    code: 'M2-5',
                    color: '0'
                },
                {
                    date: '2021-10-24',
                    code: 'M2',
                    color: '6'
                },
            ]
        },
        10: {
            days: [
                {
                    date: '2021-11-02',
                    code: 'W1-1',
                    color: '0'
                },
                {
                    date: '2021-11-03',
                    code: 'W5-2',
                    color: '0'
                },
                {
                    date: '2021-11-04',
                    code: 'W5-3',
                    color: '0'
                },
                {
                    date: '2021-11-05',
                    code: 'W5-4',
                    color: '0'
                },
                {
                    date: '2021-11-06',
                    code: 'W5-5',
                    color: '0'
                },
                {
                    date: '2021-11-07',
                    code: 'W5',
                    color: '5'
                },
                {
                    date: '2021-11-09',
                    code: 'W6-1',
                    color: '0'
                },
                {
                    date: '2021-11-10',
                    code: 'W6-2',
                    color: '0'
                },
                {
                    date: '2021-11-11',
                    code: 'W6-3',
                    color: '0'
                },
                {
                    date: '2021-11-12',
                    code: 'W6-4',
                    color: '0'
                },
                {
                    date: '2021-11-13',
                    code: 'W6-5',
                    color: '0'
                },
                {
                    date: '2021-11-14',
                    code: 'W6',
                    color: '5'
                },
                {
                    date: '2021-11-16',
                    code: 'M3-1',
                    color: '0'
                },
                {
                    date: '2021-11-17',
                    code: 'M3-2',
                    color: '0'
                },
                {
                    date: '2021-11-18',
                    code: 'M3-3',
                    color: '0'
                },
                {
                    date: '2021-11-19',
                    code: 'M3-4',
                    color: '0'
                },
                {
                    date: '2021-11-20',
                    code: 'M3-5',
                    color: '0'
                },
                {
                    date: '2021-11-21',
                    code: 'M3',
                    color: '6'
                },
                {
                    date: '2021-11-28',
                    code: 'S1',
                    color: '7'
                },
            ]
        },
    },

    // award_list[0].ch.cash,
    award_list: [
        {
            id: 0,
            name: '個人白銀賽',
            champion: {
                total: "6,000",
                cash: '5,400',
                mycard: '600',
                gift: '',
                other_gift_00: '',
                other_gift_01: '',
                other_gift_02: '',
            },
            second: {
                total: '3,000',
                cash: '2,600',
                mycard: '400',
                gift: '',
                other_gift_00: '',
                other_gift_01: '',
                other_gift_02: '',
            },
            third: {
                total: '1,000',
                cash: '800',
                mycard: '200',
                gift: '',
                other_gift_00: '',
                other_gift_01: '',
                other_gift_02: '',
            },
        },
        {
            id: 1,
            name: '個人鑽石賽',
            champion: {
                total: '18,000',
                cash: '16,200',
                mycard: '1,800',
                gift: '',
                other_gift_00: '',
                other_gift_01: '',
                other_gift_02: '',
            },
            second: {
                total: '9,000',
                cash: '8,000',
                mycard: '1,000',
                gift: '',
                other_gift_00: '',
                other_gift_01: '',
                other_gift_02: '',
            },
            third: {
                total: '3,000',
                cash: '2,600',
                mycard: '400',
                gift: '',
                other_gift_00: '',
                other_gift_01: '',
                other_gift_02: '',
            },
        },
        {
            id: 2,
            name: '個人大師賽',
            champion: {
                total: '60,000',
                cash: '24,010',
                mycard: '6,000',
                gift: '',
                other_gift_00: '電競手機 1隻',
                other_gift_01: '',
                other_gift_02: '',
            },
            second: {
                total: '30,000',
                cash: '12,100',
                mycard: '3,000',
                gift: '',
                other_gift_00: '平板 1個',
                other_gift_01: '',
                other_gift_02: '',
            },
            third: {
                total: '10,000',
                cash: '9,000',
                mycard: '1,000',
                gift: '',
                other_gift_00: '',
                other_gift_01: '',
                other_gift_02: '',
            },
        },
        // 隊伍
        {
            id: 3,
            name: '隊伍白銀賽',
            champion: {
                total: '30,000',
                cash: '27,000',
                mycard: '3,000',
                gift: '',
                other_gift_00: '',
                other_gift_01: '',
                other_gift_02: '',
            },
            second: {
                total: '15,000',
                cash: '13,400',
                mycard: '1,600',
                gift: '',
                other_gift_00: '',
                other_gift_01: '',
                other_gift_02: '',
            },
            third: {
                total: '5,000',
                cash: '4,400',
                mycard: '600',
                gift: '',
                other_gift_00: '',
                other_gift_01: '',
                other_gift_02: '',
            },
        },
        {
            id: 4,
            name: '隊伍鑽石賽',
            champion: {
                total: '90,000',
                cash: '51,010',
                mycard: '9,000',
                gift: '',
                other_gift_00: '電競手機 1隻',
                other_gift_01: '',
                other_gift_02: '',
            },
            second: {
                total: '45,000',
                cash: '25,500',
                mycard: '4,600',
                gift: '',
                other_gift_00: '平板 1個',
                other_gift_01: '',
                other_gift_02: '',
            },
            third: {
                total: '15,000',
                cash: '13,400',
                mycard: '1,600',
                gift: '',
                other_gift_00: '',
                other_gift_01: '',
                other_gift_02: '',
            },
        },
        {
            id: 5,
            name: '隊伍大師賽',
            champion: {
                total: '300,000',
                cash: '150,040',
                mycard: '30,000',
                gift: '',
                other_gift_00: '電競手機 4隻',
                other_gift_01: '',
                other_gift_02: '',
            },
            second: {
                total: '150,000',
                cash: '75,020',
                mycard: '15,000',
                gift: '',
                other_gift_00: '電競手機 2隻',
                other_gift_01: '',
                other_gift_02: '',
            },
            third: {
                total: '50,000',
                cash: '30,100',
                mycard: '5,000',
                gift: '',
                other_gift_00: '平板 1個',
                other_gift_01: '',
                other_gift_02: '',
            },
        },
        // 免費公益賽
        {
            id: 6,
            name: '個人公益賽',
            champion: {
                total: '3,000',
                cash: '2,600',
                mycard: '400',
                gift: '',
                other_gift_00: '',
                other_gift_01: '',
                other_gift_02: '',
            },
            second: {
                total: '1,500',
                cash: '1,300',
                mycard: '200',
                gift: '',
                other_gift_00: '',
                other_gift_01: '',
                other_gift_02: '',
            },
            third: {
                total: '500',
                cash: '300',
                mycard: '200',
                gift: '',
                other_gift_00: '',
                other_gift_01: '',
                other_gift_02: '',
            },
        },
        {
            id: 7,
            name: '隊伍公益賽',
            champion: {
                total: '15,000',
                cash: '13,400',
                mycard: '1,600',
                gift: '',
                other_gift_00: '',
                other_gift_01: '',
                other_gift_02: '',
            },
            second: {
                total: '7,500',
                cash: '6,700',
                mycard: '800',
                gift: '',
                other_gift_00: '',
                other_gift_01: '',
                other_gift_02: '',
            },
            third: {
                total: '2,500',
                cash: '2,100',
                mycard: '400',
                gift: '',
                other_gift_00: '',
                other_gift_01: '',
                other_gift_02: '',
            },
        },
    ],

    Data: [
        {
            kind: 1,  //1:個人 2:隊伍
            month: 9, //比賽月份
            day: 17,   //比賽日期
            title: '白銀四強決賽 #D1',
            card: '', //背景顏色
            qualifying_all: ['9 / 13'],  //資格賽
            award: 0, //獎項??
            title_bg: 1 //title顏色 (1:白銀 2:鑽石 3:大師)
        },
        {
            kind: 1,
            month: 9,
            day: 18,
            title: '白銀四強決賽 #D2',
            card: '',
            qualifying_all: ['9 / 15'],
            award: 0,
            title_bg: 1
        },
        {
            kind: 2, //2:隊伍
            month: 9,
            day: 19,
            title: '白銀四強決賽 #W1',
            card: '',
            qualifying_all: ['9 / 14', '9 / 15', '9 / 16', '9 / 17', '9 / 18'],
            award: 3, //隊伍白銀3
            title_bg: 1
        },
        {
            kind: 1,
            month: 9,
            day: 21,
            title: '白銀四強決賽 #D3',
            card: '',
            qualifying_all: ['9 / 20'],
            award: 0,
            title_bg: 1
        },
        {
            kind: 1,
            month: 9,
            day: 23,
            title: '白銀四強決賽 #D4',
            card: '',
            qualifying_all: ['9 / 22'],
            award: 0,
            title_bg: 1
        },
        {
            kind: 2, //2:隊伍
            month: 9,
            day: 26,
            title: '白銀四強決賽 #W2',
            card: '',
            qualifying_all: ['9 / 21', '9 / 22', '9 / 23', '9 / 24', '9 / 25'],
            award: 3, //隊伍白銀3
            title_bg: 1
        },
        {
            kind: 1,
            month: 9,
            day: 28,
            title: '白銀四強決賽 #D5',
            card: '',
            qualifying_all: ['9 / 27'],
            award: 0,
            title_bg: 1
        },
        {
            kind: 1,
            month: 9,
            day: 30,
            title: '白銀四強決賽 #D6',
            card: '',
            qualifying_all: ['9 / 29'],
            award: 0,
            title_bg: 1
        },
        {
            kind: 1,
            month: 10,
            day: 2,
            title: '鑽石四強決賽 #M1',
            card: '',
            qualifying_all: ['10 / 1'],
            award: 1, //個人鑽石1
            title_bg: 2
        },
        {
            kind: 2, //2:隊伍
            month: 10,
            day: 3,
            title: '鑽石四強決賽 #M1',
            card: '',
            qualifying_all: ['9 / 28', '9 / 29', '9 / 30', '10 / 1', '10 / 2'],
            award: 4, //隊伍鑽石4
            title_bg: 2
        },
        {
            kind: 1, 
            month: 10,
            day: 5,
            title: '公益四強決賽 #F1',
            card: 'free',
            qualifying_all: ['10 / 4'],
            award: 6, //未定
            title_bg: 1
        },
        {
            kind: 1, //個人
            month: 10,
            day: 7,
            title: '公益四強決賽 #F2',
            card: 'free',
            qualifying_all: ['10 / 6'],
            award: 6, //未定
            title_bg: 1
        },
        {
            kind: 2, //隊伍
            month: 10,
            day: 10,
            title: '公益四強決賽 #F1',
            card: 'free',
            qualifying_all: ['10 / 5', '10 / 6', '10 / 7', '10 / 8', '10 / 9'],
            award: 7, //未定
            title_bg: 1
        },
        {
            kind: 1,  //1:個人 2:隊伍
            month: 10, //比賽月份
            day: 12,   //比賽日期
            title: '白銀四強決賽 #D7',
            card: '', //背景顏色
            qualifying_all: ['10 / 11'],  //資格賽
            award: 0, //獎項??
            title_bg: 1 //title顏色 (1:白銀 2:鑽石 3:大師)
        },
        {
            kind: 1,
            month: 10,
            day: 14,
            title: '白銀四強決賽 #D8',
            card: '',
            qualifying_all: ['10 / 13'],
            award: 0,
            title_bg: 1
        },
        {
            kind: 2, //2:隊伍
            month: 10,
            day: 17,
            title: '白銀四強決賽 #W3',
            card: '',
            qualifying_all: ['10 / 12', '10 / 13', '10 / 14', '10 / 15', '10 / 16'],
            award: 3, //隊伍白銀3
            title_bg: 1
        },
        {
            kind: 1,
            month: 10,
            day: 19,
            title: '白銀四強決賽 #D9',
            card: '',
            qualifying_all: ['10 / 18'],
            award: 0,
            title_bg: 1
        },
        {
            kind: 1,
            month: 10,
            day: 21,
            title: '白銀四強決賽 #D10',
            card: '',
            qualifying_all: ['10 / 20'],
            award: 0,
            title_bg: 1
        },
        {
            kind: 2, //2:隊伍
            month: 10,
            day: 24,
            title: '白銀四強決賽 #W4',
            card: '',
            qualifying_all: ['10 / 19', '10 / 20', '10 / 21', '10 / 22', '10 / 23'],
            award: 3, //隊伍白銀3
            title_bg: 1
        },
        {
            kind: 1,
            month: 10,
            day: 26,
            title: '白銀四強決賽 #D11',
            card: '',
            qualifying_all: ['10 / 25'],
            award: 0,
            title_bg: 1
        },
        {
            kind: 1,
            month: 10,
            day: 28,
            title: '白銀四強決賽 #D12',
            card: '',
            qualifying_all: ['10 / 27'],
            award: 0,
            title_bg: 1
        },
        {
            kind: 1,
            month: 10,
            day: 30,
            title: '鑽石四強決賽 #M2',
            card: '',
            qualifying_all: ['10 / 29'],
            award: 1, //個人鑽石1
            title_bg: 2
        },
        {
            kind: 2, //2:隊伍
            month: 10,
            day: 31,
            title: '鑽石四強決賽 #M2',
            card: '',
            qualifying_all: ['10 / 26', '10 / 27', '10 / 28', '10 / 29', '10 / 30'],
            award: 4, //隊伍鑽石4
            title_bg: 2
        },
        // 11月
        {
            kind: 1, 
            month: 11,
            day: 2,
            title: '公益四強決賽 #F3',
            card: 'free',
            qualifying_all: ['11 / 1'],
            award: 6, //未定
            title_bg: 1
        },
        {
            kind: 1, //個人
            month: 11,
            day: 4,
            title: '公益四強決賽 #F4',
            card: 'free',
            qualifying_all: ['11 / 3'],
            award: 6, //未定
            title_bg: 1
        },
        {
            kind: 2, //隊伍
            month: 11,
            day: 7,
            title: '公益四強決賽 #F2',
            card: 'free',
            qualifying_all: ['11 / 2', '11 / 3', '11 / 4', '11 / 5', '11 / 6'],
            award: 7, //未定
            title_bg: 1
        },
        {
            kind: 1,  //1:個人 2:隊伍
            month: 11, //比賽月份
            day: 9,   //比賽日期
            title: '白銀四強決賽 #D13',
            card: '', //背景顏色
            qualifying_all: ['11 / 8'],  //資格賽
            award: 0, //獎項
            title_bg: 1 //title顏色 (1:白銀 2:鑽石 3:大師)
        },
        {
            kind: 1,
            month: 11,
            day: 11,
            title: '白銀四強決賽 #D14',
            card: '',
            qualifying_all: ['11 / 10'],
            award: 0,
            title_bg: 1
        },
        {
            kind: 2, //2:隊伍
            month: 11,
            day: 14,
            title: '白銀四強決賽 #W5',
            card: '',
            qualifying_all: ['11 / 9', '11 / 10', '11 / 11', '11 / 12', '11 / 13'],
            award: 3, //隊伍白銀3
            title_bg: 1
        },
        {
            kind: 1,
            month: 11,
            day: 16,
            title: '白銀四強決賽 #D15',
            card: '',
            qualifying_all: ['11 / 15'],
            award: 0,
            title_bg: 1
        },
        {
            kind: 1,
            month: 11,
            day: 18,
            title: '白銀四強決賽 #D16',
            card: '',
            qualifying_all: ['11 / 17'],
            award: 0,
            title_bg: 1
        },
        {
            kind: 2, //2:隊伍
            month: 11,
            day: 21,
            title: '白銀四強決賽 #W6',
            card: '',
            qualifying_all: ['11 / 16', '11 / 17', '11 / 18', '11 / 19', '11 / 20'],
            award: 3, //隊伍白銀3
            title_bg: 1
        },
        {
            kind: 1,
            month: 11,
            day: 23,
            title: '白銀四強決賽 #D17',
            card: '',
            qualifying_all: ['11 / 22'],
            award: 0,
            title_bg: 1
        },
        {
            kind: 1,
            month: 11,
            day: 25,
            title: '白銀四強決賽 #D18',
            card: '',
            qualifying_all: ['11 / 24'],
            award: 0,
            title_bg: 1
        },
        {
            kind: 1,
            month: 11,
            day: 27,
            title: '鑽石四強決賽 #M3',
            card: '',
            qualifying_all: ['11 / 26'],
            award: 1, //個人鑽石1
            title_bg: 2
        },
        {
            kind: 2, //2:隊伍
            month: 11,
            day: 28,
            title: '鑽石四強決賽 #M3',
            card: '',
            qualifying_all: ['11 / 23', '11 / 24', '11 / 25', '11 / 26', '11 / 27'],
            award: 4, //隊伍鑽石4
            title_bg: 2
        },
        {
            kind: 1, 
            month: 11,
            day: 30,
            title: '公益四強決賽 #F5',
            card: 'free',
            qualifying_all: ['11 / 29'],
            award: 6, //未定
            title_bg: 1
        },
        // 12月
        {
            kind: 1, //個人
            month: 12,
            day: 2,
            title: '公益四強決賽 #F6',
            card: 'free',
            qualifying_all: ['12 / 1'],
            award: 6, //未定
            title_bg: 1
        },
        {
            kind: 2, //隊伍
            month: 12,
            day: 5,
            title: '公益四強決賽 #F3',
            card: 'free',
            qualifying_all: ['11 / 30', '12 / 1', '12 / 2', '12 / 3', '12 / 4'],
            award: 7, //未定
            title_bg: 1
        },
        {
            kind: 1, //個人
            month: 12,
            day: 11,
            title: '大師四強決賽 #S1',
            card: '',
            qualifying_all: ['12 / 9', '12 / 10'],
            award: 2, //個人大師
            title_bg: 3
        },
        {
            kind: 2, //隊伍
            month: 12,
            day: 12,
            title: '大師四強決賽 #S1',
            card: '',
            qualifying_all: ['12 / 7', '12 / 8', '12 / 9', '12 / 10', '12 / 11'],
            award: 5, //隊伍大師
            title_bg: 3
        },
    ],

    currentData: null,

    awardsSlide: function () {
        $('.awards_line_detail').hide();
        $('.line_01').children('.awards_line_detail').show();
        $('.awards_line').click(function (e) {
            e.preventDefault();
            $(this).children('.awards_line_detail').slideToggle();
        });
    },

    scheduleRender: function () {
        description.Data.forEach((e, i) => {
            // console.log('data', e);
            // console.log('description.award_list', description.award_list[e.award]);
            let qualifying_all = ''
            if (e.qualifying_all.length) {
                e.qualifying_all.forEach(e => {
                    let qualifying = `
                        <div class="qualifying">${e}</div>
                    `
                    qualifying_all += qualifying
                });
            }
            let template = `
            <div class="schedule_row_bg">
                <div class="schedule_row">
                    <div class="schedule_date">${e.month}<p> 月 </p>${e.day}<p> 日</p>
                    </div>
                    <div class="schedule_block">
                        ${e.kind == 1 ? '' : '<div class="schedule_card personal_card"></div>'}  
                        <div class="schedule_card ${e.kind == 1 ? 'personal_card' : 'team_card'}">
                            <div class="card_background ${e.card}" >
                                <div class="schedule_card_title card_bg_0${e.title_bg}">${e.title}</div>
                                <div class="qualifying_all">
                                    <p>資格賽</p>
                                    ${qualifying_all}
                                </div>
                                <div class="awards_all">
                                    <div class="awards_line line_01">
                                        <div class="awards_line_title">
                                            <div class="awards_icon_text">
                                                <img class="awards_icon" src="/images/Description/crown01.png" alt="">
                                                <p class="awards_text">冠軍</p>
                                            </div>
                                            <div class="awards_text_all">
                                                <p class="awards_text_P">總價值</p>
                                                <p class="awards_text_total">${description.award_list[e.award].champion.total}</p>
                                                <p class="awards_text_P">台幣</p>
                                            </div>
                                        </div>
                                        <div class="awards_line_detail">
                                            <div class="detail_line"></div>
                                            <div class="detail_line_all">
                                                <div class="detail_row">
                                                    <p class="detail_p cash_title">現金<span class="detail_span cash">${description.award_list[e.award].champion.cash}</span>(稅前)</p>
                                                    <p class="detail_p mycard_title">MyCard點數<span class="detail_span mycard_point">${description.award_list[e.award].champion.mycard}</span>點</p>
                                                </div>
                                                <div class="detail_row">
                                                    <p class="detail_p gift_title">神秘禮物<span class="detail_span gift_name">${description.award_list[e.award].champion.gift}</span></p>
                                                    <p class="detail_p other_gift_00">${description.award_list[e.award].champion.other_gift_00}</p>
                                                </div>
                                                <div class="detail_row">
                                                    <p class="detail_p other_gift_01">${description.award_list[e.award].champion.other_gift_01}</p>
                                                    <p class="detail_p other_gift_02">${description.award_list[e.award].champion.other_gift_02}</p>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="awards_line line_02">
                                        <div class="awards_line_title">
                                            <div class="awards_icon_text">
                                                <img class="awards_icon" src="/images/Description/crown02.png" alt="">
                                                <p class="awards_text">亞軍</p>
                                            </div>
                                            <div class="awards_text_all">
                                                <p class="awards_text_P">總價值</p>
                                                <p class="awards_text_total">${description.award_list[e.award].second.total}</p>
                                                <p class="awards_text_P">台幣</p>
                                            </div>
                                        </div>
                                        <div class="awards_line_detail">
                                            <div class="detail_line"></div>
                                            <div class="detail_line_all">
                                                <div class="detail_row">
                                                    <p class="detail_p cash_title">現金<span class="detail_span cash">${description.award_list[e.award].second.cash}</span>(稅前)</p>
                                                    <p class="detail_p mycard_title">MyCard點數<span class="detail_span mycard_point">${description.award_list[e.award].second.mycard}</span>點</p>
                                                </div>
                                                <div class="detail_row">
                                                    <p class="detail_p gift_title">神秘禮物<span class="detail_span gift_name">${description.award_list[e.award].second.gift}</span></p>
                                                    <p class="detail_p other_gift_00">${description.award_list[e.award].second.other_gift_00}</p>
                                                </div>
                                                <div class="detail_row">
                                                <p class="detail_p other_gift_01">${description.award_list[e.award].second.other_gift_01}</p>
                                                <p class="detail_p other_gift_02">${description.award_list[e.award].second.other_gift_02}</p>
                                            </div>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="awards_line line_03">
                                        <div class="awards_line_title">
                                            <div class="awards_icon_text">
                                                <img class="awards_icon" src="/images/Description/crown03.png" alt="">
                                                <p class="awards_text">季軍</p>
                                            </div>
                                            <div class="awards_text_all">
                                                <p class="awards_text_P">總價值</p>
                                                <p class="awards_text_total">${description.award_list[e.award].third.total}</p>
                                                <p class="awards_text_P">台幣</p>
                                            </div>
                                        </div>
                                        <div class="awards_line_detail">
                                            <div class="detail_line"></div>
                                            <div class="detail_line_all">
                                                <div class="detail_row">
                                                    <p class="detail_p cash_title">現金<span class="detail_span cash">${description.award_list[e.award].third.cash}</span>(稅前)</p>
                                                    <p class="detail_p mycard_title">MyCard點數<span class="detail_span mycard_point">${description.award_list[e.award].third.mycard}</span>點</p>
                                                </div>
                                                <div class="detail_row">
                                                    <p class="detail_p gift_title">神秘禮物<span class="detail_span gift_name">${description.award_list[e.award].third.gift}</span></p>
                                                    <p class="detail_p other_gift_00">${description.award_list[e.award].third.other_gift_00}</p>
                                                </div>
                                                <div class="detail_row">
                                                <p class="detail_p other_gift_01">${description.award_list[e.award].third.other_gift_01}</p>
                                                <p class="detail_p other_gift_02">${description.award_list[e.award].third.other_gift_02}</p>
                                            </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                        ${e.kind == 1 ? '<div class="schedule_card team_card"></div>' : ''}
                    </div>
                </div>
            </div>
            `

            $('.schedule_list').append(template);
        })
    },

    mobileScheduleSwitch : function () {
        function scheduleSwitch(){
            if(window.innerWidth < 700){
                $('#date_team_icon').css('opacity','0.3')
                $('#date_personal_icon').css('filter','drop-shadow(1px 1px 10px rgb(255, 255, 255))')
                $('.card_title_icon').on('click', function (e) {
                    const kind = $(e.target).attr('id')
                    if(kind === 'date_personal_icon'){
                        $('.team_card').hide()
                        $('.personal_card').show()
                        $('#date_team_icon').css('opacity','0.5')
                        $('#date_team_icon').css('filter','none')
                        $('#date_personal_icon').css('opacity','1')
                        $('#date_personal_icon').css('filter','drop-shadow(1px 1px 10px rgb(255, 255, 255))')
                        
                    }else{
                        $('.personal_card').hide()
                        $('.team_card').show()
                        $('#date_team_icon').css('opacity','1')
                        $('#date_team_icon').css('filter','drop-shadow(1px 1px 10px rgb(255, 255, 255))')
                        $('#date_personal_icon').css('opacity','0.5')
                        $('#date_personal_icon').css('filter','none')
                    }
                });
            }else{
                $('.card_title_icon').off('click');
                $('.team_card').show()
                $('.personal_card').show()
                $('#date_personal_icon').css('opacity','1')
                $('#date_team_icon').css('opacity','1')
                $('#date_team_icon').css('filter','none')
                $('#date_personal_icon').css('filter','none')
            }
        }
        // if(window.innerWidth < 700){
        //     $('.team_card').hide()
        // }
        scheduleSwitch() 
        $(window).on('resize', function () {
            scheduleSwitch() 
        });

        // 多於消失 暫留
        // $(".team_card").each(function(){
        //     if($(this).children().length === 0){
        //         console.log($(this));
        //         console.log($(this).parents('.schedule_row_bg'));
        //         $(this).parent('.schedule_row_bg').hide()
        //     }else{
        //         $(this).hide()
        //     }
        // })
    }
}

