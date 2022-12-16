export async function gettingStartMetaMask(host) {

    if (navigator.vendor.indexOf('Apple') != -1) location.href = "https://metamask.app.link/dapp/" + host +"/GettingStarted/create-metamask";
    if (/android|webos|iphone|ipad|ipod|blackberry|iemobile|opera mini|mobile/i.test(navigator.userAgent)) location.href = "https://metamask.app.link/dapp/" + host + "/GettingStarted/create-metamask"


   
    if (typeof window.ethereum == 'undefined') {
        console.log("undefined")
        if (navigator.vendor.indexOf('Apple') == -1 && !(/android|webos|iphone|ipad|ipod|blackberry|iemobile|opera mini|mobile/i.test(navigator.userAgent))) {
            alert("please install MetaMask")
        }
       
        //location.href = '/GettingStarted/create-metamask';
    } else {
        const Accounts = await ethereum.request({ method: 'eth_requestAccounts' });
        console.log(Accounts)
        return Accounts[0] 
        //if (Accounts[0] != "") {
        //    return true
        //} else {
        //    return false
        //}       
    }
}