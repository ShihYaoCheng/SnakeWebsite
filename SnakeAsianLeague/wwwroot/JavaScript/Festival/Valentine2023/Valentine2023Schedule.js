window.Valentine2023Schedule = function () {
    //function (value, lang) {
    var calendarEl = document.getElementById('Valentine2023Schedule');

    var calendar = new FullCalendar.Calendar(calendarEl, {
        initialView: 'dayGridMonth',
        timeZone: 'local',
        initialDate: '2023-02-01', // will be parsed as local
        //navLinks: true,
        height: 1200,
       /* locale: lang == "en" ? "en-us" : "zh-tw",*/
        headerToolbar: {
           /* left: 'prev,title,next',*/
            left: 'title',
            center: '',
            right: ''
        },
        //events: value,


    });

    calendar.render();
}