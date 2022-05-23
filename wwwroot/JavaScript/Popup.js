window.Popup = function () {
    console.log('Popup');

    // 編輯姓名
    $('.products-header .Owned-edit').click(function () { 
        console.log('.products-header .Owned-edit');
        $('#products-popupblock-Name').addClass('products-popup-open');
        // e.preventDefault();
    });

    // 編輯金額
    $('#products-Income .Owned-edit').click(function () { 
        console.log('.products-header .Owned-edit');
        $('#products-popupblock-AppearanceFee').addClass('products-popup-open');
        // e.preventDefault();
    });

    // 點擊 X 關閉
    $('.products-popup-close').click(function () { 
        $('.products-popup-bg').removeClass('products-popup-open');
    });


}