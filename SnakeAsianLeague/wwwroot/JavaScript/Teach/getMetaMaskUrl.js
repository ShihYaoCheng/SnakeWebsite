export function getMetaMaskUrl() {

    let MetaMaskUrl = "https://metamask.app.link/dapp/" 

    if (navigator.vendor.indexOf('Apple') != -1) MetaMaskUrl = "https://apps.apple.com/tw/app/metamask-blockchain-wallet/id1438144202" //ios
    if (/android|webos|iphone|ipad|ipod|blackberry|iemobile|opera mini|mobile/i.test(navigator.userAgent)) MetaMaskUrl = "https://play.google.com/store/apps/details?id=io.metamask&hl=zh_TW&gl=US" //安卓

    console.log(MetaMaskUrl)
    return MetaMaskUrl

}