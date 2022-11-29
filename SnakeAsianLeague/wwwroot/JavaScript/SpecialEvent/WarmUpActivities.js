export function WarmUpActivitiesStep(){
    // console.log('WarmUpActivitiesStep')

    $('.step-Arrow').click(function(evt){
        evt.preventDefault();
        $(this).siblings().removeClass('step-Arrow-Click');
        $(this).addClass('step-Arrow-Click');
    });

    $('#step-Arrow-01').click(function () { 
        $('.step-windowTitle span, .step-Content').hide();
        $('#step-windowTitle-01, #step-Content-01').show();
    });
    $('#step-Arrow-02').click(function () { 
        $('.step-windowTitle span, .step-Content').hide();
        $('#step-windowTitle-02, #step-Content-02').show();
    });
    $('#step-Arrow-03').click(function () { 
        $('.step-windowTitle span, .step-Content').hide();
        $('#step-windowTitle-03, #step-Content-03').show();
    });
    $('#step-Arrow-04').click(function () { 
        $('.step-windowTitle span, .step-Content').hide();
        $('#step-windowTitle-04, #step-Content-04').show();
    });

}
