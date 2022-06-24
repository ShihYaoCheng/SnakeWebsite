export function S3Calendar() {

        var calendarEl = document.getElementById('S3calendar');
        var calendar = new FullCalendar.Calendar(calendarEl, {
            initialView: 'dayGridMonth',
            navLinks: true,
            height:1000,
            headerToolbar: {
                left: '',
                center: 'prev,title,next',
                right:''
            },
            events: [{
                title: '練習',
                start: '2022-06-07T02:00:00',
                end: '2022-06-09T14:00:00',

            },
            {
                title: '練習a',
                start: '2022-06-07T02:00:00',
                end: '2022-06-09T14:00:00',
          
            },

            ]

        });

        calendar.render();
 
}