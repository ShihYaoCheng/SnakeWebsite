export async function getAddress() {
    //暫放
    ethereum.request({ method: 'eth_requestAccounts' });
    const web3 = new Web3(Web3.givenProvider)  
    const getAddress = await web3.eth.requestAccounts()
    $("#userAddress")[0].innerText = getAddress[0].slice(0, 5) + "...." + getAddress[0].slice(38)
}