export async function gasFeeCoinEchangePop(value) {
    const web3 = await new Web3(Web3.givenProvider)
    const getGasPrice = await web3.eth.getGasPrice() / (10 ** 9)
    console.log("getGasPrice", getGasPrice)
    console.log(value)
    if (getGasPrice > parseInt( value)) {
        return true;
    }
    else {
        return false;
    }
    
}