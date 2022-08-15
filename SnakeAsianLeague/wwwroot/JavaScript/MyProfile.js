window.myprofileSidebar = function () {
    if ($('.myprofileSidebarButton').length === 0) return
    console.log('1111111111')
    $('.myprofileSidebarButton').click(function (e) {
        $('.myprofileSidebar').toggleClass('SidebarOpen');
    });
    $('.accountManagementUl a').click(function () {
        $('.myprofileSidebar').removeClass('SidebarOpen');
    });
    
    $(document).mouseup(function (e) {
        var container = $(".myprofileSidebar"); // 這邊放你想要排除的區塊

        if (!container.is(e.target) && container.has(e.target).length === 0) {
            $('.myprofileSidebar').removeClass('SidebarOpen');

        }
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

window.InventoryFilterSidebarClick = function () {
    $('.Inventory-PPSR-Filter').click(function(){
        console.log('Inventory-PPSR-Filter')
        $('.Inventory-PPSR-Filter-Sidebar').slideToggle('fast'); 

    })
    $(document).mouseup(function (e) {
        var container =$(".Inventory-PPSR-Filter-Sidebar, .Inventory-PPSR-Filter"); // 這邊放你想要排除的區塊
        if (!container.is(e.target) && container.has(e.target).length === 0) {
            $('.Inventory-PPSR-Filter-Sidebar').slideUp('fast');

        }
    });

    if ($('.NFTcard').length === 0) {
        $('.IfNoCard').show();
    }if ($('.NFTcard').length > 0){
        $('.IfNoCard').hide();
    }
}

// 個人資產頁的篩選器使用顯示判斷
window.CardAmountLinkDisplay = function (){
    $('.Inventory-PPSR-Filter-Sidebar').click(function () {
        var FilterCheckboxClicked = $('.Inventory-PPSR-Filter-Sidebar input[type="checkbox"]:checked').length;
        var FilterButtonClicked = $('.Filter-Button-Click:not(#Filter-Button-Reset)').length;
        var FilterRadioClicked = $('.Inventory-PPSR-Filter-Sidebar input[type="radio"]:checked').length;
        var HeartClicked = $('.Filter-Header-Block .heartClickRed').length;

        if (FilterCheckboxClicked > 0 || 
            FilterButtonClicked > 0 || 
            FilterRadioClicked > 0 ||
            HeartClicked > 0){
            
            $('.Inventory-PPSR-Filter').addClass("Inventory-PPSR-Filter-Ing");
            
            console.log(FilterCheckboxClicked,'FilterCheckboxClicked')
            console.log(FilterButtonClicked,'FilterButtonClicked')
            console.log(FilterRadioClicked,'FilterRadioClicked')
            console.log(HeartClicked,'HeartClicked')
        }else{
            $('.Inventory-PPSR-Filter').removeClass("Inventory-PPSR-Filter-Ing");
        }

    });
}

window.setMateMaskLink = function () {
    var URL = "https://metamask.app.link/dapp/" + document.location.host + document.location.pathname;

    if (document.getElementById("myAnchor") != null) {
        document.getElementById("myAnchor").href = URL;
    }
};