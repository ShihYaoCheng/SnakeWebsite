window.Valentine2023Schedule = function (value, lang) {
    value = JSON.parse(value)
    let eventsList = []
    for (var i in value) {
        value[i].title = lang == "en" ? value[i].i18n[1] + value[i].title  : value[i].i18n[0] + value[i].title 
        eventsList.push(value[i])
    } 
    var calendarEl = document.getElementById('Valentine2023Schedule');

    var calendar = new FullCalendar.Calendar(calendarEl, {
        initialView: 'dayGridMonth',
        timeZone: 'local',
        initialDate: '2023-02-01', // will be parsed as local
        //navLinks: true,
        height: 1200,
        locale: lang == "en" ? "en-us" : "zh-tw",
        headerToolbar: {
           /* left: 'prev,title,next',*/
            left: 'title',
            center: '',
            right: ''
        },
        events: value,


    });

    calendar.render();


    var soloFinal = document.querySelectorAll(".soloFinal")
    var squadFinal = document.querySelectorAll(".squadFinal")
    if (squadFinal.length != 0) {
        
        squadFinal.forEach((e) => {
            e.parentElement.parentElement.parentElement.style.background = "#6d66fd"
            e.parentElement.parentElement.style.margin = "0px";
        })
        soloFinal.forEach((e) => {
            e.parentElement.parentElement.parentElement.style.background = "#06dac4"
            e.parentElement.parentElement.style.margin = "0px";
        })
    }


   

   
  
    //.

  
}