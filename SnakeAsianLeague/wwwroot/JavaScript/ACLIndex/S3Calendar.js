﻿window.S3Calendar =function (getlang, SchedulesData) {
    //整理資料

 
    var lang = getlang
    if (SchedulesData == null) return
    var eventsData = []
    var GuildData = []
    var FinalTime = []
    var individualData = []
    var TilleType = { "en": ['Silver', 'Silver', 'Diamond', 'Master', 'Charity'], "tw": ['白銀', '白銀', '鑽石', '大師', '公益'] }  //['Silver', 'Silver', 'Diamond', 'Master', 'Charity']
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
                        title: beginType[e.guildGameType] + beginNumQ[e.guildGameType] + ' ' + TilleType[lang][e.guildGameType] + ' ' + 'Qualification(Squad)' ,// e.guildSchedule.slice(0, e.guildSchedule.length - 2),
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
                        title: beginType[e.guildGameType] + beginNumQ[e.guildGameType] + ' ' + TilleType[lang][e.guildGameType] + ' ' + 'Final'+' ' + '(Squad)' ,
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
                        title: TilleType[lang][e.indGameType] + ' ' + 'Qualification',
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

    console.log(eventsData)

    //設定行事曆
    var calendarEl = document.getElementById('S3calendar');
    var calendar = new FullCalendar.Calendar(calendarEl, {
        initialView: 'dayGridMonth',
        timeZone: 'local',
        initialDate: '2023-01-01', // will be parsed as local
        //navLinks: true,
        height: 1000,

        headerToolbar: {
            left: '',
            center: 'prev,title,next',
            right: ''
        },
        locale: lang == "en" ?"en-us" :"zh-tw",
        events: eventsData,
        eventDidMount: function (info) {
        
            if (info.el.classList.contains('FinalTime')) { hoverDiv(info) }
        }
    });


    calendar.render();
    //render()
    //hoverDiv()

    function hoverDiv(info) {
        console.log(info, info.event._def.title, info.event._instance.range.start)
        var nowDate = new Date(info.event._instance.range.start)
        var StartingTime = nowDate.getFullYear() + '-' + (nowDate.getMonth() + 1) + '-' + nowDate.getDate()
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
    //function render() {
    //    console.log("test")
    //    calendar.render();
    //}
}