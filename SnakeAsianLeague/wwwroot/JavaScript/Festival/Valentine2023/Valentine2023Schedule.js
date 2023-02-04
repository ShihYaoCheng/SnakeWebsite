window.Valentine2023Schedule = function (value, lang) {
    value = JSON.parse(value)
    let eventsList = []
    for (var i in value) {
        value[i].title = lang == "en" ? value[i].i18n[1] + value[i].title + value[i].i18nFinal[1] : value[i].i18n[0] + value[i].title + value[i].i18nFinal[0]
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
}