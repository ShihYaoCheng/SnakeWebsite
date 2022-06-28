export function S3Calendar(SchedulesData) {
    //整理資料
    console.log(SchedulesData)
    if (SchedulesData == null) return
    console.log(SchedulesData)
    var eventsData = []
    var GuildData = []
    var FinalTime= [] 
    var individualData=[]
    SchedulesData.forEach((e) => {
        //區分公益個人、團體賽
        if (e.guildSchedule != '') {
            //拿到門票、給顏色
            if (e.guildATIssue!=-1) {            
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
                FinalTime.push(
                    {
                        title: e.guildSchedule,
                        start: e.date.slice(0, 10),
                        display: 'background',
                        backgroundColor: '#C7B69A',
                        className: 'FinalTime',
                        GuildFinalTime: e.GuildFinalTime,
                        id: GuildData.length,
                       

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
                    
                } else  {
                    individualData[individualData.length - 1]["backgroundColor"] = '#6CB9E4'
                    individualData[individualData.length - 1]["borderColor"]= '#6CB9E4'
                }
            }

            if (e.indFinalType != -1) {
                individualData[individualData.length - 1]["end"] = e.date.slice(0, 11) +"01:00:00"
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
            right:''
        },    
        events: eventsData,
        eventDidMount: function (info) {
           // hoverDivtest(info);
        }
    });
   
   
    calendar.render();
    console.log(calendar.title)
   // hoverDiv()

    function hoverDiv() {
        console.log(document.querySelectorAll('.FinalTime'))
        document.querySelectorAll('.FinalTime').forEach((e) => {
          

                e.innerHTML = `

    <div class="fc-event-title"> ${FinalTime[0].title} </div>

    <div class="finals-Data-Pop PopR">

        <p class="finals-Data-Pop-title"> ${FinalTime[0].title} </p>
        <div class="finals-Data-Popt-Time">
            <p> Starting Time：</p>
            <p>${FinalTime[0].start} </p>
        </div>

    </div>
    `
    
          
        })
    }
}