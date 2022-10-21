export function IsMobile() {
    if (navigator.vendor.indexOf('Apple') != -1) return true;
    return /android|webos|iphone|ipad|ipod|blackberry|iemobile|opera mini|mobile/i.test(navigator.userAgent);
}

export function IsInMetaMask() {
    if (typeof window.ethereum !== 'undefined') {
        return true
    } else {
        return false
    }
    


}