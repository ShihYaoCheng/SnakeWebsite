//是否為手機
export function IsMobile() {
    if (navigator.vendor.indexOf('Apple') != -1) return true;
    return /android|webos|iphone|ipad|ipod|blackberry|iemobile|opera mini|mobile/i.test(navigator.userAgent);
}
//是否在MetaMask
export function IsInMetaMask() {
    if (typeof window.ethereum !== 'undefined') {
        return true
    } else {
        return false
    }  
}

//導頁至MetaMask
export function autoLoginToMetaMask(url, encrypt) {
    if (typeof window.ethereum == 'undefined') {
        console.log("https://metamask.app.link/dapp/" + url + "/autologin/" + encrypt)
        window.location.href = "https://metamask.app.link/dapp/" + url + "/autologin/" + encrypt;
    } else {
        return true
    }
}