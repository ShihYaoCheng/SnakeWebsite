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