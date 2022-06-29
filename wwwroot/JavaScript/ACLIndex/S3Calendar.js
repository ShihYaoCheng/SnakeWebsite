export function S3Calendar(SchedulesData) {
    //整理資料
   
    if (SchedulesData == null) return  
    var eventsData = []
    var GuildData = []
    var FinalTime = []
    var individualData = []
    var TilleType = ['Silver', 'Silver', 'Diamond', 'Master', 'Charity']
    var beginType = ['#', 'W', 'M', 'S', 'F']
    var beginNumQ = [0, 0, 0, 0, 0]
    var beginNumS = [0, 0, 0, 0, 0]
    SchedulesData.forEach((e) => {
        //區分公益個人、團體賽
        if (e.guildSchedule != '') {
            //拿到門票、給顏色
            if (e.guildATIssue != -1) {
                beginNumQ[e.guildGameType] += 1
                GuildData.push(
                    {
                        title: beginType[e.guildGameType] + beginNumQ[e.guildGameType]  + ' ' + TilleType[e.guildGameType] + ' ' + 'Qualification(Squad)' ,// e.guildSchedule.slice(0, e.guildSchedule.length - 2),
                        start: e.date,
                        backgroundColor: '#a86ce3',
                        borderColor: '#a86ce3',
                    }
                )
              
            }
            //決賽日
            if (e.guildFinalType != -1) {
                GuildData[GuildData.length - 1]["end"] = e.date
                var FinalTimeArray = e.guildFinalTime
    
                FinalTimeArray = FinalTimeArray.slice(1, FinalTimeArray.length - 1).split(',')

                FinalTime.push(
                    {
                        title: beginType[e.guildGameType] + beginNumQ[e.guildGameType]  + ' ' + TilleType[e.guildGameType] + ' ' + 'Final'+' ' + '(Squad)' ,
                        start: e.date.slice(0, 10),
                        display: 'background',
                        backgroundColor: '#C7B69A',
                        className: 'FinalTime',
                        GuildFinalTime: e.GuildFinalTime,
                        id: FinalTimeArray[0].replaceAll('"', ''),                      
                    }
                )
            }
        }

        if (e.individualSchedule != '') {
            //拿到門票
            if (e.indATIssue != -1) {
                beginNumS[e.indGameType]+=1
                individualData.push(
                    {
                        title:    TilleType[e.indGameType] + ' ' + 'Qualification',
                        start: e.date,
                    }
                )
                if (e.indGameType == 4) {
                    individualData[individualData.length - 1]['title'] = beginType[e.indGameType] + beginNumS[e.indGameType] +' '+ individualData[individualData.length - 1]['title']
                    individualData[individualData.length - 1]["backgroundColor"] = '#81D298'
                    individualData[individualData.length - 1]["borderColor"] = '#81D298'

                } else {
                    individualData[individualData.length - 1]['title'] = beginType[e.indGameType] + beginNumS[e.indGameType] + ' ' +  individualData[individualData.length - 1]['title']
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
        
            if (info.el.classList.contains('FinalTime')) { hoverDiv(info) }
        }
    });


    calendar.render();

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
                        <p>${StartingTime +'&nbsp;&nbsp;&nbsp;  ' + info.event._def.publicId +'(GMT+8)'} </p>
                    </div>
                </div>
                `   
    }
}