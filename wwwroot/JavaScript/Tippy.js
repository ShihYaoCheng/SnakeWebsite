window.TippyInit = function () {
    tippy('.tippy-pop', {
        content(target) {
            return $(target).attr('data-content')
        },
        // trigger: 'click',
    });
}

/*�ɩ� �ѨMNFT�d���W���s�I�����D */
window.NFTcardAClick = function () {
    document.querySelectorAll(".NFTcardA").forEach((e) => {
        e.addEventListener('click', (e) => {           
            if (e.target.className == "Collect-Btn") {
                e.preventDefault();
            }
        })

    })

  
}