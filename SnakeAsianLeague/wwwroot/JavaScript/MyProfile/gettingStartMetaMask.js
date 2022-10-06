export async function gettingStartMetaMask() {
   
    if (typeof window.ethereum == 'undefined') {
        console.log("undefined")
        alert("please install MetaMask")
        location.href = '/GettingStarted/create-metamask';
    } else {
        const Accounts = await ethereum.request({ method: 'eth_requestAccounts' });
        console.log(Accounts)
        if (Accounts[0] != "") {
            return true
        } else {
            return false
        }       
    }
}