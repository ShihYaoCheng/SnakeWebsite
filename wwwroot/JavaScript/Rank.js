window.rank = {
    boxShow: function (id) {
        $('.rank_list_all').hide();
        $(`#rank_${id}`).show();
        function btnActive(){
            $(".tab_button").removeClass("tab_button_clicked");
            $(".tab_button").eq(index).addClass("tab_button_clicked");
        }
        switch (id) {
            case 'personal':
                index = 0
                $(".rank_bg").removeClass("team_bg");
                $(".rank_bg").addClass("personal_bg");
                break;
            case 'team':
                index = 1
                $(".rank_bg").removeClass("personal_bg");
                $(".rank_bg").addClass("team_bg");
                break;
        }
        btnActive()
    },

    

}

