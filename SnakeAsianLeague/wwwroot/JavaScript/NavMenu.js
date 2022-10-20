// Nav點擊 登入按鈕 出現login彈窗
window.loginButton = function (loginButton) {
    console.log('loginButton');
    $(".login_block").addClass("open");
}


// 點擊背景 點擊login "X" 關閉login彈窗
window.loginClose = function () {
    $(".login_block").removeClass("open");
}


// 如果登入成功，顯示user
window.loginUserShow = function (loginUserShow) {
    console.log('loginUserShow');
    
    $("#nav-user").css({
        "display": "block",
    });
    
}

window.displayAlert = (text) => {
    alert(`${text}`);
};

window.navbarSlide = function (navbarSlide) {
    var navbarSlideContainer = $('.nav-link, .nav-item, .slide_button, .slide_button img, .userIcon, .userNumber, .userNumber p, #userIcon, .nav-link img, .nav-link p');

    $('.nav-item').unbind('click').click(function (e) {

        if($(e.target).is(navbarSlideContainer)){
            if($(this).children('.nav_ul_slide').css('display') === 'none')$('.nav_ul_slide').slideUp();
            if ($(this).children('.nav_ul_slide').length == 0)$('.nav_ul_slide,.navbar-collapse').slideUp();
            
            $(this).children('.nav_ul_slide').slideToggle("fast");
        }
        $('.nav_ul_slide li').click(function(){
            $('.nav_ul_slide, .navbar-collapse').slideUp("fast");
        })
        
    });

    // 如果點擊nav-link以外的地方，下拉選單收起
    $("body").unbind('click').click(function(e){
        if(!navbarSlideContainer.is(e.target) &&
        !navbarSlideContainer.has(e.target).length){
            $('.nav_ul_slide').slideUp("fast");
        }  
    });


    $(".navbar-toggler").unbind('click').click(function(){
        $('.navbar-collapse').slideToggle("fast");
    })
    // console.log('navbarSlide init');
}


window.selectChangeLocation = function () {
    $('#ACLSeason,#ACLSeasonNav,#FestivalSeasonNav').on('change',function(e){
        // console.log($(this))
        window.location = `/${$(this).val()}`
    })
}

window.NotFoundPageChange = function () {
    // console.log('NotFoundPageChange');
    var random = Math.floor(Math.random() * $('.NotFound_Change').length);
    $('.NotFound_Change').hide().eq(random).show();
}


