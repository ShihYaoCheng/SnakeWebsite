window.TippyInit = function () {
    window.tippyInstance = tippy('.tippy-pop', {
        content(target) {
            return $(target).attr('data-content')
        },
        // reset i18n content
        onTrigger(instance, event) {
            const { reference, setContent } = instance
            const i18nText = $(reference).attr('data-i18n')
            if (i18nText) setContent($(reference).attr('data-content'))
        },
        // trigger: 'click',
    });
}

