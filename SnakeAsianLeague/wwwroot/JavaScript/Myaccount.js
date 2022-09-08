window.hoverText = function (hoverText) {
    console.log('hoverText');

    (function ($) {
        $.fn.hover = function (options) {
            $(this).each(function () {
                var $this = $(this);
                var opts = $.extend({}, $.fn.hover.defaults, options);
                var hoverText = $this.data("hover");
                if (hoverText != null) {
                    var $hover = $("<div>").addClass("hover-text").html(hoverText);
                    $this.addClass("hover").append($hover);
                    var hoverWidth = $hover.outerWidth();
                    var hoverHeight = $hover.outerHeight();
                    var position = $this.position();
                    var width = $this.outerWidth();
                    $hover.css({
                        top: position['top'] - hoverHeight - 15,
                        left: position['left'] + (width / 2) - (hoverWidth / 2)
                    }).hide();
                    $this.hoverIntent(
                        function () { $hover.fadeIn(); },
                        function () { $hover.fadeOut(); }
                    );
                }
            });
            return $(this);
        }
        $.fn.hover.defaults = {
        };
    })(jQuery);

    $(document).ready(function () {
        $('[data-hover!=""]').hover();
    });


}

window.account = function (checkBoxLength) {
    // $(".window_checkbox").each((index,el)=>{
    //     console.log(`each el[${index}].val  :` ,$(el).is(':checked'));
    // })


    const total = checkBoxLength? checkBoxLength : 3
    console.log('checkBoxLength',checkBoxLength);
    console.log('total',total);


    // var check=$("input[name='window_checkbox']:checked").length;//判斷有多少個方框被勾選

    // if(check < total){
    //     alert("【必填】請閱讀並同意全部領獎規範，謝謝！");
    //     return false;//不要提交表單
    // }else{
    //     // alert("你勾選了"+check+"個項目");
    //     return true;//提交表單
    // }


    var check=$("input[name='window_checkbox']:checked").length;//判斷有多少個方框被勾選
    if(check < 1){
        alert("【必填】請閱讀並同意全部領獎規範，謝謝！");
        return false;//不要提交表單
    }else{
        // alert("你勾選了"+check+"個項目");
        return true;//提交表單
    }

}



window.afterRender = function() {
    console.log('js afterRender');
    const arr = []
    $('.status-hide').each(function (i, e) { 
        const status =$(e).text()
        if(status === "0"){
            $('.diamod_01').eq(i).addClass('diamod_currently')
        }
        if(status === "1"){
            $('.diamod_01').eq(i).addClass('diamod_currently')
        }
        if(status === "2"){
            $('.diamod_01').eq(i).addClass('diamod_currently')
            $('.diamod_02').eq(i).addClass('diamod_currently')
        }
        if(status === "3"){
            $('.diamod_01').eq(i).addClass('diamod_currently')
            $('.diamod_02').eq(i).addClass('diamod_currently')
        }
        if(status === "4"){
            $('.diamod_01').eq(i).addClass('diamod_currently')
            $('.diamod_02').eq(i).addClass('diamod_currently')
        }
        if(status === "5"){
            $('.diamod_01').eq(i).addClass('diamod_currently')
            $('.diamod_02').eq(i).addClass('diamod_currently')
            $('.diamod_03').eq(i).addClass('diamod_currently')
        }
    });
}