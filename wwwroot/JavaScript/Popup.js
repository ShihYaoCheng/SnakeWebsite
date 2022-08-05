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
   
    // 全部領取彈窗
    $('.CollectBtn').click(function () {
        $('.AllCollectPop').addClass('products-popup-open');
    });

    // 個別彈窗
    $('.Collect-Btn').click(function (e) {
        if (window.ShowMSGState) return
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

window.getShowMSGState = function () {
    return window.ShowMSGState
}

//暫放 解決點擊卡片是否要彈窗問題
window.ShowMSGcheckbox = function () {
    window.ShowMSGState = false
    $('#ShowMSGcheckbox').click(function () {
     
        
        if (window.ShowMSGState) {
            $('#ShowMSGcheckbox')[0].src = "/images/MarketPlace/checkbox.webp"
            window.ShowMSGState = false
        } else {
            $('#ShowMSGcheckbox')[0].src = "/images/MarketPlace/checkbox_checked.webp"
            window.ShowMSGState = true
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
    
      
        if (e.target.data==true) {
            e.target.parentNode.parentNode.parentNode.parentNode.lastChild.style.display = "none"                     
            e.target.data = false          
            e.target.innerHTML = `Show Tag <img class="ShowTag-arrow" src="/images/MarketPlace/MP-arrow-gray.png">`
          
        } else {
     
            e.target.data = true
            e.target.parentNode.parentNode.parentNode.parentNode.lastChild.style.display = "block"
            e.target.innerHTML = `Hide Tag <img   class="ShowTag-arrow" src="/images/MarketPlace/MP-arrow-gray.png">`
        }
       
       // e.target.parentNode.lastChild.style.display = "contents"

    })
}