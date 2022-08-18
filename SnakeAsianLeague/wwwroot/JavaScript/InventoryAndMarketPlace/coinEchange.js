export function coinEchange(showId) {
    
    //顯示視窗
    $(showId).click(function () {
        $(".coinEchange-container").addClass("products-popup-open");
    });
    //關閉視窗
    $("#coinEchangeCancel").click(function () {
        $(".coinEchange-container").removeClass("products-popup-open");
    });
    //確定交易，關閉視窗
    $("#coinEchangeBtn").click(function () {
        $(".coinEchange-container").removeClass("products-popup-open");
    });
    
       
}