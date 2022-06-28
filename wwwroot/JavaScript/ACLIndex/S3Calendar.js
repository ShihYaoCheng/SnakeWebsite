export function S3Calendar(SchedulesData) {
    //整理資料
    console.log(SchedulesData)
    if (SchedulesData == null) return  
    var eventsData = []
    var GuildData = []
    var FinalTime = []
    var individualData = []
    SchedulesData.forEach((e) => {
        //區分公益個人、團體賽
        if (e.guildSchedule != '') {
            //拿到門票、給顏色
            if (e.guildATIssue != -1) {
                GuildData.push(
                    {
                        title: e.guildSchedule.slice(0, e.guildSchedule.length - 2),
                        start: e.date,
                        backgroundColor: '#a86ce3',
                        borderColor: '#a86ce3',

                    }
                )
            }
            //決賽日
            if (e.guildFinalType != -1) {
                GuildData[GuildData.length - 1]["end"] = e.date
                console.log(e.guildFinalTime)
              
                FinalTime.push(
                    {
                        title: e.guildSchedule,
                        start: e.date.slice(0, 10),
                        display: 'background',
                        backgroundColor: '#C7B69A',
                        className: 'FinalTime',
                        GuildFinalTime: e.GuildFinalTime,
                        id: e.guildFinalTime,
                        aa:'aa'

                    }
                )
            }
        }

        if (e.individualSchedule != '') {

            //拿到門票
            if (e.indATIssue != -1) {
                individualData.push(
                    {
                        title: e.individualSchedule,
                        start: e.date,
                    }
                )
                if (e.indGameType == 4) {
                    individualData[individualData.length - 1]["backgroundColor"] = '#81D298'
                    individualData[individualData.length - 1]["borderColor"] = '#81D298'

                } else {
                    individualData[individualData.length - 1]["backgroundColor"] = '#6CB9E4'
                    individualData[individualData.length - 1]["borderColor"] = '#6CB9E4'
                }
            }

            if (e.indFinalType != -1) {
                individualData[individualData.length - 1]["end"] = e.date.slice(0, 11) + "01:00:00"
            }

        }
    })
    eventsData.push(...GuildData)
    eventsData.push(...individualData)
    eventsData.push(...FinalTime)

    console.log(eventsData)

    //設定行事曆
    var calendarEl = document.getElementById('S3calendar');
    var calendar = new FullCalendar.Calendar(calendarEl, {
        initialView: 'dayGridMonth',
        timeZone: 'local',
        initialDate: '2022-07-01', // will be parsed as local
        //navLinks: true,
        height: 1000,

        headerToolbar: {
            left: '',
            center: 'prev,title,next',
            right: ''
        },
        events: eventsData,
        eventDidMount: function (info) {
            console.log(info  )
            if (info.el.classList.contains('FinalTime')) { hoverDiv(info) }
        }
    });


    calendar.render();
    console.log(calendar.title)
    //hoverDiv()

    function hoverDiv(info) {
        var nowDate = new Date(info.event._instance.range.start)
        var StartingTime = nowDate.getFullYear() + '-' + (nowDate.getMonth() + 1) + '-' + nowDate.getDay()
        //.parentNode.parentNode.parentNode.parentNode
        info.el.innerHTML = `
                <div class="finals-Data-Pop PopR">
                    <p class="finals-Data-Pop-title">${info.event._def.title} </p>
                    <div class="finals-Data-Popt-Time">
                        <p> Starting Time：</p>
                        <p>${StartingTime + info.event._def.publicId} </p>
                    </div>
                </div>
                `
   
    }
    //document.querySelector('.fc-prev-button').addEventListener('click', () => { hoverDiv() })
    //document.querySelector('.fc-next-button').addEventListener('click', () => { hoverDiv()} )


}