export function TransferEvents(wssURL, USDC_Token_addr, getId) {    
    const w3 = new Web3(new Web3.providers.WebsocketProvider(wssURL)) 
    const contract = new w3.eth.Contract(window.ERC20_abi, USDC_Token_addr)
    let retrunTest ="";
    const changeNum = document.getElementById(getId);
    contract.events.Transfer({ filter: { from: "0x3DD8F133C30cbc84B246f56cf8659B21595803a5" }, fromBlock: "latest" }, function (error, event) {        
        //changeNum.innerText = changeNum.innerText - parseInt(event.returnValues.value) / (10 ** 18)        
        retrunTest = changeNum.innerText - parseInt(event.returnValues.value) / (10 ** 18)    
    })
    .on('connected', str => console.log(str))

    return retrunTest
}