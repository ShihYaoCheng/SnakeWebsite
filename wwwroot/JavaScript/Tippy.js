window.TippyInit = function () {
    tippy('.tippy-pop', {
        content(target) {
            return $(target).attr('data-content')
        },
        // trigger: 'click',
    });
}

/*借放 解決NFT卡片上按鈕點擊問題 */
window.NFTcardAClick = function () {
    document.querySelectorAll(".NFTcardA").forEach((e) => {
        e.addEventListener('click', (e) => {           
            if (e.target.className == "Collect-Btn") {
                e.preventDefault();
            }
        })

    })

  
}