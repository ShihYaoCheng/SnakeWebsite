window.NewYear2023Schedule = function (value) {  
    value = JSON.parse(value)
    console.log(value)
    var calendarEl = document.getElementById('NewYear2023Schedule');

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
        events: value,
     
      
    });

    calendar.render();
}