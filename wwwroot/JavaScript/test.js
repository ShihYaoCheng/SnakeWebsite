
//window.AddPolygonID =  function () {
//    document.getElementById('AddPolygonID').addEventListener('click', async () => {        
//        try {          
//            await window.ethereum.request({
//                method: 'wallet_switchEthereumChain',
//                params: [{ chainId: '0x89' }],
//            });
//        } catch (switchError) {           
//            if (switchError.code === 4902) {
//                try {
//                    await window.ethereum.request({
//                        method: 'wallet_addEthereumChain',
//                        params: [
//                            {
//                                chainId: '0x89',
//                                chainName: 'Polygon',
//                                rpcUrls: ['https://polygon-rpc.com'] /* ... */,
//                            },
//                        ],
//                    });
//                } catch (addError) {

//                }
//            }

//        }

//    })
  
//     window.ethereum.on('chainChanged', (chainId) => {
//        console.log(chainId) // 0x38 if it's BSC
//    })

//}




// window.displayAlert = (text) => {
//     alert(`test alert: ${text} !`);
    
// };

// window.testjs = function(text){
//     console.log(`這是${text}`);
// }

// 頁籤test
// tabChange: function () {
//     $("#content div").hide(); // Initially hide all content
//     $("#tabs li:first").attr("id", "current"); // Activate first tab
//     $("#content div:first").fadeIn(); // Show first tab content

//     $("#tabs a").click(function (e) {
//         e.preventDefault();
//         $("#content div").hide(); //Hide all content
//         $("#tabs li").attr("id", ""); //Reset id's
//         $(this).parent().attr("id", "current"); // Activate this
//         $("#" + $(this).attr("title")).fadeIn(); // Show content for current tab
//         // alert($(this).attr('title'));
//     });
// }


// 日曆test




// window.calendar = function (calendar) {
//     var calendarEl = document.getElementById('calendar');
//     var calendar = new FullCalendar.Calendar(calendarEl, {
//         initialView: 'dayGridMonth',
//         eventColor: '#000sss',
//         locale: 'zh-tw'
//     });
//     calendar.render();

//     // 個人日冠賽
//     const btn_1 = {
//         color: '#ffe391',
//         days: ['2021-09-07', '2021-09-09', '2021-09-14', '2021-09-16', "2021-09-21", "2021-09-23"],
//         team: ['個人日冠賽D1', '個人日冠賽D2', '2021-09-14', '2021-09-16', "2021-09-21", "2021-09-23"]
//     }
//     // 個人月冠賽
//     const btn_2 = {
//         color: '#ffad21',
//         days: ['2021-09-25', '2021-10-23', '2021-11-20']
//     }
//     // 個人季冠賽
//     const btn_3 = {
//         color: '#fe8900',
//         days: ['2021-11-27']
//     }
//     // 團隊周冠賽
//     const btn_4 = {
//         color: '#fabdbd',
//         days: ['2021-09-12', '2021-09-19', '2021-10-10', '2021-10-17', "2021-11-07", "2021-11-14"]
//     }
//     // 團隊月冠賽
//     const btn_5 = {
//         color: '#f87c7c',
//         days: ['2021-09-26', '2021-10-24', '2021-11-21']
//     }
//     // 團隊季冠賽
//     const btn_6 = {
//         color: '#c33838',
//         days: ['2021-11-28']
//     }

//     let defaultTeam = btn_1;

//     // 個人日冠賽
//     $('#btn_1').on('click', () => {

//         console.log('a team');
//         $('.fc-daygrid-day-events').css({
//             "background": "none"
//         })
//         // aaa.forEach((e, i) => {
//         //     $(`td[data-date=${e}] .fc-daygrid-day-events`).css({
//         //         "background": "black"
//         //     })
//         // })
//         btn_1.days.forEach((e, i) => {
//             $(`td[data-date=${e}] .fc-daygrid-day-events`).css({
//                 "background": btn_1.color
//             });
//             // $(`td[data-date=${e}] .fc-daygrid-day-bg`).text("team");
//         })

//         defaultTeam = btn_1
//     })

//     // 個人月冠賽
//     $('#btn_2').on('click', () => {
//         console.log('b team');
//         clearAllTeam()
//         // bbb.forEach((e, i) => {
//         //     $(`td[data-date=${e}] .fc-daygrid-day-events`).css({
//         //         "background": "yellow"
//         //     })
//         // })
//         btn_2.days.forEach((e, i) => {
//             $(`td[data-date=${e}] .fc-daygrid-day-events`).css({
//                 "background": btn_2.color
//             })
//         })
//         defaultTeam = btn_2
//     })

//     // 個人季冠賽
//     $('#btn_3').on('click', () => {
//         console.log('b team');
//         clearAllTeam()
//         btn_3.days.forEach((e, i) => {
//             $(`td[data-date=${e}] .fc-daygrid-day-events`).css({
//                 "background": btn_3.color
//             })
//         })
//         defaultTeam = btn_3
//     })


//     // 團隊周冠賽
//     $('#btn_4').on('click', () => {
//         console.log('b team');
//         clearAllTeam()
//         btn_4.days.forEach((e, i) => {
//             $(`td[data-date=${e}] .fc-daygrid-day-events`).css({
//                 "background": btn_4.color
//             })
//         })
//         defaultTeam = btn_4
//     })

//     // 團隊月冠賽
//     $('#btn_5').on('click', () => {
//         console.log('b team');
//         clearAllTeam()
//         btn_5.days.forEach((e, i) => {
//             $(`td[data-date=${e}] .fc-daygrid-day-events`).css({
//                 "background": btn_5.color
//             })
//         })
//         defaultTeam = btn_5
//     })

//     // 團隊季冠賽
//     $('#btn_6').on('click', () => {
//         console.log('b team');
//         clearAllTeam()
//         btn_6.days.forEach((e, i) => {
//             $(`td[data-date=${e}] .fc-daygrid-day-events`).css({
//                 "background": btn_6.color
//             })
//         })
//         defaultTeam = btn_6
//     })





//     $('.fc-prev-button').on('click', () => {
//         defaultTeam.days.forEach((e, i) => {
//             $(`td[data-date=${e}] .fc-daygrid-day-events`).css({
//                 "background": defaultTeam.color
//             })
//         })
//     })
//     $('.fc-next-button').on('click', () => {
//         setDefaultTeam()
//     })

//     const clearAllTeam = function () {
//         $('.fc-daygrid-day-events').css({
//             "background": "none"
//         })
//     }
//     const setDefaultTeam = () => {
//         clearAllTeam()
//         defaultTeam.days.forEach((e, i) => {
//             $(`td[data-date=${e}] .fc-daygrid-day-events`).css({
//                 "background": defaultTeam.color
//             })
//         })
//     }

//     setDefaultTeam();

//     // $(`td[data-date=2021-09-07] .fc-daygrid-day-bg`).text("個人日冠賽D1");
//     // $(`td[data-date=2021-09-09] .fc-daygrid-day-bg`).text("個人日冠賽D2");



// }

// // 個人與隊伍頁籤切換
// window.calendarTab = function (index) {
//     $(".schedule_button").removeClass("schedule_button_click");
//     $(".schedule_button").eq(index).addClass("schedule_button_click");
// }

// window.calendar2 = function () {
//     var calendarEl = document.getElementById('calendar');
//     var calendar = new FullCalendar.Calendar(calendarEl, {
//         initialView: 'dayGridMonth',
//         eventColor: '#000sss',
//         initialDate: '2021-09-01',
//         locale: 'zh-tw'
//     });
//     calendar.render();

//     const colors = {
//         normal: '#D9D9D9',
//         weekly: '#F5C0C0',
//         mouthy: '#F87878',
//         season: '#ca4444',
//     }

//     const personalData = {
//         8: {
//             days: [
//                 {
//                     date: '2021-09-06',
//                     code: '1D-1',
//                     color: '0'
//                 },
//                 {
//                     date: '2021-09-07',
//                     code: 'D1',
//                     color: '1'
//                 },
//                 {
//                     date: '2021-09-08',
//                     code: 'D2-2',
//                     color: '0'
//                 },
//                 {
//                     date: '2021-09-09',
//                     code: 'D2',
//                     color: '1'
//                 },
//                 {
//                     date: '2021-09-13',
//                     code: 'D3-1',
//                     color: '0'
//                 },
//                 {
//                     date: '2021-09-14',
//                     code: 'D3',
//                     color: '1'
//                 },
//                 {
//                     date: '2021-09-15',
//                     code: 'D4-1',
//                     color: '0'
//                 },
//                 {
//                     date: '2021-09-16',
//                     code: 'D4',
//                     color: '1'
//                 },
//                 {
//                     date: '2021-09-20',
//                     code: 'D5-1',
//                     color: '0'
//                 },
//                 {
//                     date: '2021-09-21',
//                     code: 'D5',
//                     color: '1'
//                 },
//                 {
//                     date: '2021-09-22',
//                     code: 'D6-1',
//                     color: '0'
//                 },
//                 {
//                     date: '2021-09-23',
//                     code: 'D6',
//                     color: '1'
//                 },
//                 {
//                     date: '2021-09-24',
//                     code: 'M1-1',
//                     color: '0'
//                 },
//                 {
//                     date: '2021-09-25',
//                     code: 'M1',
//                     color: '2'
//                 },
//             ]
//         }
//     }

//     const teamData = {

//     }
//     let testData = {}

//     function setCalendar() {
//         const currentMonth = calendar.currentData.currentDate.getMonth()
//         const colorValues = Object.values(colors)
//         let data = personalData
//         if (!data[currentMonth]) return
//         data[currentMonth].days.forEach((e, i) => {
//             $(`td[data-date=${e.date}]`).css({
//                 "background": colorValues[e.color]
//             })
//             $(`td[data-date=${e.date}] .fc-daygrid-day-events`).text(e.code)
//         })
//     }

//     setCalendar()
//     $('.fc-prev-button').on('click', setCalendar)
//     $('.fc-next-button').on('click', setCalendar)

// }


// 賽程規劃 0826
// awardsSlide: function () {
//     $('.awards_line_detail').hide();
//     $('.line_01').children('.awards_line_detail').show();
//     $('.awards_line').click(function (e) {
//         e.preventDefault();
//         $(this).children('.awards_line_detail').slideToggle();
//     });
// },

// scheduleRender: function () {
//     description.Data.forEach((e, i) => {
//         // console.log('data', e);
//         // console.log('description.award_list', description.award_list[e.award]);
//         let qualifying_all = ''
//         if (e.qualifying_all.length) {
//             e.qualifying_all.forEach(e => {
//                 let qualifying = `
//                     <div class="qualifying">${e}</div>
//                 `
//                 qualifying_all += qualifying
//             });
//         }
//         let template = `
//         <div class="schedule_row_bg">
//             <div class="schedule_row">
//                 <div class="schedule_date">${e.month}<p> 月 </p>${e.day}<p> 日</p>
//                 </div>
//                 <div class="schedule_block">
//                     ${e.kind == 1 ? '' : '<div class="schedule_card personal_card"></div>'}  
//                     <div class="schedule_card ${e.kind == 1 ? 'personal_card' : 'team_card'}">
//                         <div class="card_background ${e.card}" >
//                             <div class="schedule_card_title card_bg_0${e.title_bg}">${e.title}</div>
//                             <div class="qualifying_all">
//                                 <p>資格賽</p>
//                                 ${qualifying_all}
//                             </div>
//                             <div class="awards_all">
//                                 <div class="awards_line line_01">
//                                     <div class="awards_line_title">
//                                         <img class="awards_icon" src="/images/Description/crown01.webp" alt="">
//                                         <p class="awards_text">冠軍</p>
//                                         <div class="awards_text_all">
//                                             <p class="awards_text_P">價值</p>
//                                             <p class="awards_text_total">${description.award_list[e.award].champion.total}</p>
//                                             <p class="awards_text_P">現金</p>
//                                         </div>
//                                     </div>
//                                     <div class="awards_line_detail">
//                                         <div class="detail_line"></div>
//                                         <div class="detail_line_all">
//                                             <div class="detail_row">
//                                                 <p class="detail_p cash_title">現金<span class="detail_span cash">${description.award_list[e.award].champion.cash}</span>元</p>
//                                                 <p class="detail_p mycard_title">MyCard點數<span class="detail_span mycard_point">${description.award_list[e.award].champion.cash}</span>點</p>
//                                             </div>
//                                             <div class="detail_row">
//                                                 <p class="detail_p gift_title">神秘禮物<span class="detail_span gift_name">${description.award_list[e.award].champion.gift}</span></p>
//                                                 <p class="detail_p maicoin_title"><span class="detail_span maicoin_point">${description.award_list[e.award].champion.maicoin}</span></p>
//                                             </div>
//                                         </div>
//                                     </div>
//                                 </div>
//                                 <div class="awards_line line_02">
//                                     <div class="awards_line_title">
//                                         <img class="awards_icon" src="/images/Description/crown02.webp" alt="">
//                                         <p class="awards_text">亞軍</p>
//                                         <div class="awards_text_all">
//                                             <p class="awards_text_P">價值</p>
//                                             <p class="awards_text_total">3,000</p>
//                                             <p class="awards_text_P">現金</p>
//                                         </div>
//                                     </div>
//                                     <div class="awards_line_detail">
//                                         <div class="detail_line"></div>
//                                         <div class="detail_line_all">
//                                             <div class="detail_row">
//                                                 <p class="detail_p cash_title">現金<span class="detail_span cash">${description.award_list[e.award].second.cash}</span>元</p>
//                                                 <p class="detail_p mycard_title">MyCard點數<span class="detail_span mycard_point">${description.award_list[e.award].second.mycard}</span>點</p>
//                                             </div>
//                                             <div class="detail_row">
//                                                 <p class="detail_p gift_title">神秘禮物<span class="detail_span gift_name">${description.award_list[e.award].second.gift}</span></p>
//                                                 <p class="detail_p maicoin_title"><span class="detail_span maicoin_point">${description.award_list[e.award].second.maicoin}</span></p>
//                                             </div>
//                                         </div>
//                                     </div>
//                                 </div>
//                                 <div class="awards_line line_03">
//                                     <div class="awards_line_title">
//                                         <img class="awards_icon" src="/images/Description/crown03.webp" alt="">
//                                         <p class="awards_text">季軍</p>
//                                         <div class="awards_text_all">
//                                             <p class="awards_text_P">價值</p>
//                                             <p class="awards_text_total">1,000</p>
//                                             <p class="awards_text_P">現金</p>
//                                         </div>
//                                     </div>
//                                     <div class="awards_line_detail">
//                                         <div class="detail_line"></div>
//                                         <div class="detail_line_all">
//                                             <div class="detail_row">
//                                                 <p class="detail_p cash_title">現金<span class="detail_span cash">${description.award_list[e.award].third.cash}</span>元</p>
//                                                 <p class="detail_p mycard_title">MyCard點數<span class="detail_span mycard_point">${description.award_list[e.award].third.mycard}</span>點</p>
//                                             </div>
//                                             <div class="detail_row">
//                                                 <p class="detail_p gift_title">神秘禮物<span class="detail_span gift_name">${description.award_list[e.award].third.gift}</span></p>
//                                                 <p class="detail_p maicoin_title"><span class="detail_span maicoin_point">${description.award_list[e.award].third.maicoin}</span></p>
//                                             </div>
//                                         </div>
//                                     </div>
//                                 </div>
//                             </div>
//                         </div>
//                     </div>
//                     ${e.kind == 1 ? '<div class="schedule_card team_card"></div>' : ''}
//                 </div>
//             </div>
//         </div>
//         `

//         $('.schedule_list').append(template);
//     })
// },