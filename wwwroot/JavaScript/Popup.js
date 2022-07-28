window.Popup = function () {
    console.log('Popup');

    // 編輯姓名
    $('.products-header .Owned-edit').click(function () {
        console.log('.products-header .Owned-edit');
        $('#products-popupblock-Name').addClass('products-popup-open');
    });

    // 編輯金額
    $('#products-Income .Owned-edit').click(function () {
        console.log('.products-header .Owned-edit');
        $('#products-popupblock-AppearanceFee').addClass('products-popup-open');
    });

    // 點擊 X 關閉
    $('.products-popup-close').click(function () {
        $('.products-popup-bg').removeClass('products-popup-open');
    });

    // 點擊 背景關閉
    $(document).mouseup(function (e) {
        var container =$(".products-popupblock"); // 這邊放你想要排除的區塊
        if (!container.is(e.target) && container.has(e.target).length === 0) {
            $('.products-popup-bg').removeClass('products-popup-open');
        }
    });


}

window.CollectBtnPoP = function () {
   
    // 編輯姓名
    $('.CollectBtn').click(function () {
        $('.AllCollectPop').addClass('products-popup-open');
    });

    // 編輯姓名
    $('.Collect-Btn').click(function (e) {         
        $('.NFT-Number-Pop')[0].innerText = e.target.parentNode.parentNode.children[0].children[1].innerText
        $('.SingelAllCollectPop').addClass('products-popup-open');
    });

    // 點擊 X 關閉
    $('.products-popup-close').click(function () {
        $('.products-popup-bg').removeClass('products-popup-open');
    });

    //點擊 Confirm 關閉
    $('.products-popup-submit').click(function () {
        $('.products-popup-bg').removeClass('products-popup-open');
    });
  

    // 點擊 背景關閉
    $(document).mouseup(function (e) {
        var container = $(".products-popupblock"); // 這邊放你想要排除的區塊
        if (!container.is(e.target) && container.has(e.target).length === 0) {
            $('.products-popup-bg').removeClass('products-popup-open');
        }
    });


}

//暫放
window.ShowMSGcheckbox = function () {
    window.ShowMSGState = 1
    $('#ShowMSGcheckbox').click(function () {
        console.log(window.ShowMSGState)
        window.ShowMSGState = 1 - window.ShowMSGState
        if (window.ShowMSGState == 1) {
            $('#ShowMSGcheckbox')[0].src = "/images/MarketPlace/checkbox.webp"
        } else {
            $('#ShowMSGcheckbox')[0].src = "/images/MarketPlace/checkbox_checked.webp"
        }
       
        
    });
}

/*借放 解決NFT卡片上按鈕點擊問題 */
window.NFTcardAClick = function () {
    document.querySelectorAll(".NFTcardA").forEach((e) => {
        e.addEventListener('click', (e) => {
            if (e.target.className == "Collect-Btn" || e.target.className == "Show-tag" ) {
                e.preventDefault();
            }
        })

    })


}

window.showTag = function () {
    $('.Show-tag').click(function (e) {
        e.target.style.display = "none"
        e.target.parentNode.lastChild.style.display = "contents"

    })
}