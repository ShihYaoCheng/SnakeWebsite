
window.AddPolygonUSDT = async function () {
    tokenAddress = '0xc2132D05D31c914a87C6611C10748AEb04B58e8F';
    tokenSymbol = 'USDT';
    tokenDecimals = 6;
    tokenImage = 'https://polygonscan.com/token/images/tether_32.png';
    try {
        // wasAdded is a boolean. Like any RPC method, an error may be thrown.
        const wasAdded = await window.ethereum.request({
            method: 'wallet_watchAsset',
            params: {
                type: 'ERC20', // Initially only supports ERC20, but eventually more!
                options: {
                    address: tokenAddress, // The address that the token is at.
                    symbol: tokenSymbol, // A ticker symbol or shorthand, up to 5 chars.
                    decimals: tokenDecimals, // The number of decimals in the token
                    image: tokenImage, // A string url of the token logo
                },
            },
        });

        if (wasAdded) {
            console.log('Thanks for your interest!');
            return true;
        } else {
            console.log('Your loss!');
        }
        return false;
    } catch (error) {
        console.log(error);

    }


}