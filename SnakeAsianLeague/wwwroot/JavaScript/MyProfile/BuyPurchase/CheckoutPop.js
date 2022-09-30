export function CheckoutPop() {
    const productsPopupClose = document.getElementById("productsPopupClose")
    const CheckoutPopBtn = document.getElementById("CheckoutPopBtn")
    const CheckoutPop = document.getElementById("CheckoutPop")
    

    productsPopupClose.addEventListener('click', () => {
        CheckoutPop.style.display='none'
    })
    CheckoutPopBtn.addEventListener('click', () => {
        CheckoutPop.style.display = 'none'
    })
}