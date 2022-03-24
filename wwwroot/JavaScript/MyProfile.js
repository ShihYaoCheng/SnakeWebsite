window.myprofileSidebar = function () {
    if ($('.myprofileSidebarButton').length === 0) return
    console.log('1111111111')
    $('.myprofileSidebarButton').click(function (e) {
        $('.myprofileSidebar').toggleClass('SidebarOpen');
    });
    $('.accountManagementUl a').click(function () {
        $('.myprofileSidebar').removeClass('SidebarOpen');
    });
}

window.textCopy = function () {
    console.log('textCopy')
    let text = $('.metamaskAvailable span').text()
    
    console.log("copyTip")
    
    if (!navigator.clipboard || !navigator.clipboard.writeText) {
        let textArea = document.createElement("textarea");
        textArea.value = text;
        textArea.style.opacity = "0";
        document.body.appendChild(textArea);
        textArea.focus();
        textArea.select();
        try {
            let successful = document.execCommand("copy");
            console.log("Copying text command was " + text);

        } catch (err) {
            console.log("Unable to copy value , error : " + err.message);
        }
        document.body.removeChild(textArea);
        return;
        
    }
    // console.log(text);
    navigator.clipboard.writeText(text);
    // alert("複製成功!")

    // 複製提示語
    // let copyTip = `<div id="copyTip" style="position: absolute; top: 50%;left: 50%;transform: translate(-50%, -50%);padding: 12px 25px;background: rgba(0, 0, 0, 0.6); color: #fff;font-size: 14px;">複製成功</div>`; //提示語div
    // $("#copyTip").css({"opacity": "1","z-index":"1"}); //放入document
    // setTimeout(() => {
        // $("#copyTip").css({"opacity": "0","z-index":"-1"}); //提示完即消失
    // }, 700);
    
}
window.copyTip = function () {
    // 複製提示語
    // let copyTip = `<div id="copyTip" style="position: absolute; top: 50%;left: 50%;transform: translate(-50%, -50%);padding: 12px 25px;background: rgba(0, 0, 0, 0.6); color: #fff;font-size: 14px;">複製成功</div>`; //提示語div
    $("#copyTip").css({"opacity": "1","z-index":"1"}); //放入document
    setTimeout(() => {
        $("#copyTip").css({"opacity": "0","z-index":"-1"}); //提示完即消失
    }, 700);
}
