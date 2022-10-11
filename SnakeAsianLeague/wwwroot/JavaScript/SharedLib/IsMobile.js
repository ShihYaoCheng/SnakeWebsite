export function IsMobile() {
    if (navigator.vendor.indexOf('Apple') != -1) return true;
    return /android|webos|iphone|ipad|ipod|blackberry|iemobile|opera mini|mobile/i.test(navigator.userAgent);
}