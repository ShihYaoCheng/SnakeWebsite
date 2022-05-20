window.FooterContactHide = function () {   
    var footerContact = document.getElementById("footerContact")     
    var contactClose = document.getElementById("contactClose")
    var appreciateGoback = document.getElementById("appreciateGoback")
    var contactContainer = document.getElementById("contactContainer")
    var contactClose = document.getElementById("contactClose")
    footerContact.addEventListener('click', (e) => {
        if (e.target.id == "footerContact") {
            closeAction()
        } 
    })
   
    contactClose.addEventListener('click', (e) => {
            closeAction()
    })

    appreciateGoback.addEventListener('click', (e) => {
        closeAction()
    })

    function closeAction() {
        footerContact.style.display = "none"
        contactContainer.style.display = "block"
        contactClose.style.display = "flex"
    }
}

window.FooterContactShow = function () {
    var footerContact = document.getElementById("footerContact")
    footerContact.style.display = "block"
}

window.FooterAnimation = function () {
    var contactContainer = document.getElementById("contactContainer")
    var openEnvelop = document.getElementById("openEnvelop")
    var closeEnvelop = document.getElementById("closeEnvelop")
    var appreciate = document.getElementById("appreciate")
    var contactClose = document.getElementById("contactClose")

    contactClose.style.display ="none"
    /*先縮小1.5秒*/
    contactContainer.classList.add('zoom-out') 
    setTimeout(() => {        
        contactContainer.style.display = 'none'
        openEnvelop.style.display = 'block'
        openEnvelop.classList.add('zoom-in')
      
    }, 500)
    setTimeout(() => {
        openEnvelop.classList.remove('zoom-in')
        openEnvelop.classList.add('rotate')
   
    }, 1000)
    setTimeout(() => {
        openEnvelop.style.display = 'none'
        closeEnvelop.style.display = 'block'
        appreciate.style.display = "block"
    
        closeEnvelop.classList.add('fly')
        appreciate.classList.add('appreciateFly')
    }, 1500)
    setTimeout(() => {
        closeEnvelop.style.display = 'none'     

       
        /*關閉所有動畫*/
        contactContainer.classList.remove('zoom-out')
        openEnvelop.classList.remove('rotate')
        closeEnvelop.classList.remove('fly')
        appreciate.classList.remove('appreciateFly')
    }, 2000)
    
   
}