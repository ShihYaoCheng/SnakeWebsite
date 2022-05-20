window.FooterContactHide = function () {   
    var footerContact = document.getElementById("footerContact")     
    var contactClose = document.getElementById("contactClose")
    var appreciateGoback = document.getElementById("appreciateGoback")
    var contactContainer = document.getElementById("contactContainer")
    var contact06 = document.getElementById("contact06")
   
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
        contactContainer.style.display = "flex"
        contact06.style.display="block"
    }
}

window.FooterContactShow = function () {
    var footerContact = document.getElementById("footerContact")
    footerContact.style.display = "block"
}

window.FooterAnimation = function () {
    var contactContainer = document.getElementById("contactContainer")
    var contact06 = document.getElementById("contact06")
    var openEnvelop = document.getElementById("openEnvelop")
    var closeEnvelop = document.getElementById("closeEnvelop")
    var appreciate = document.getElementById("appreciate") 
 
    /*先縮小1.5秒*/
    contact06.classList.add('zoom-out')
    setTimeout(() => {        
        contact06.style.display = 'none'
        openEnvelop.style.display = 'block'
        openEnvelop.classList.add('zoom-in')
      
    }, 500)
    setTimeout(() => {
        openEnvelop.classList.remove('zoom-in')       
        openEnvelop.classList.add('rotate')
        openEnvelop.classList.add('zoom-out')
   
    }, 1000)
    setTimeout(() => {
        openEnvelop.style.display = 'none'
        closeEnvelop.style.display = 'block'
        appreciate.style.display = "block"
    
        contactContainer.classList.add('fly')
        closeEnvelop.classList.add("zoom-in")
        appreciate.classList.add('appreciateFly')
    }, 1500)
    setTimeout(() => {
        closeEnvelop.style.display = 'none'
        contactContainer.style.display="none"

       
        /*關閉所有動畫*/
        contact06.classList.remove('zoom-out')
        openEnvelop.classList.remove('rotate')
        openEnvelop.classList.remove('zoom-out')
        closeEnvelop.classList.remove('zoom-in')
        appreciate.classList.remove('appreciateFly')
        contactContainer.classList.remove('fly')
    }, 3000)
    
   
}