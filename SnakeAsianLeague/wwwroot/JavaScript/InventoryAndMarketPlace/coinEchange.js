export function coinEchange(showId) {
    
    //顯示視窗
    $(showId).click(function () {
        $(".coinEchange-container").addClass("products-popup-open");
    });
    //關閉視窗
    $("#coinEchangeCancel").click(function () {
        $(".coinEchange-container").removeClass("products-popup-open");
        $(".coin-range").val(0)
        $("#GSRCincrease").val(0)
        $("#SRCincrease").val(0)
        
    });
    //確定交易，關閉視窗
    $("#coinEchangeBtn").click(function () {
        $(".coinEchange-container").removeClass("products-popup-open");
        $(".coin-range").val(0)
        $("#GSRCincrease").val(0)
        $("#SRCincrease").val(0)
    });
    
       
}