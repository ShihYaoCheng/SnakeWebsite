export function dayjsInit() {
    
    // console.log('dayjs', dayjs);
    dayjs().format()

    // 倒數
    setInterval(() => {

        const differenceDate = dayjs('2022-02-07 23:59').diff(dayjs()) //計算時間差的毫秒數

        // 計算相差天數
        const days = Math.floor(differenceDate / (24 * 3600 * 1000))

        // 計算相差小時數
        const leave1 = differenceDate % (24 * 3600 * 1000) // 計算天數後剩餘的毫秒數
        const hours = Math.floor(leave1 / (3600 * 1000))

        // 計算相差分鐘數
        const leave2 = leave1 % (3600 * 1000) // 計算小時數後剩餘的毫秒數
        const minutes = Math.floor(leave2 / (60 * 1000))

        // 計算相差秒數
        const leave3 = leave2 % (60 * 1000) // 計算分鐘數後剩餘的毫秒數
        const seconds = Math.round((leave3 / 1000))

        // console.log("倒數" + days + "日" + hours + "時" + minutes + "分" + seconds + "秒");

        if(seconds > 0){
            var countdown = "<span>倒數 </span>" + days + "<span> 日 </span>" + hours + "<span> 時 </span>" + minutes + "<span> 分 </span>" + seconds + "<span> 秒</span>";
        }else{
            var countdown = "<span>倒數 </span>" + 0 + "<span> 日 </span>" + 0 + "<span> 時 </span>" + 0 + "<span> 分 </span>" + 0 + "<span> 秒</span>";
            // $('.event_banner_goToEvent_pc_txt p').text('報名截止')
        }
        $('#timeCountdown').html(countdown);

    }, 1000);

}
