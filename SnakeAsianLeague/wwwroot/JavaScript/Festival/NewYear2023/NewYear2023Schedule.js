window.NewYear2023Schedule = function () {
    console.log('t123132')
    var calendarEl = document.getElementById('NewYear2023Schedule');
    console.log(calendarEl)
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
    
     
      
    });

    calendar.render();
}