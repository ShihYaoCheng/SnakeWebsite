window.TippyInit = function () {
    tippy('.tippy-pop', {
        content(target) {
            return $(target).attr('data-content')
        },
        // trigger: 'click',
    });
}

