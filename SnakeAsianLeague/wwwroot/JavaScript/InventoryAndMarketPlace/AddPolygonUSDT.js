
window.AddPolygonUSDT = async function () {
    tokenAddress = '0xD92E713d051C37EbB2561803a3b5FBAbc4962431';
    tokenSymbol = 'TUSDT';
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




window.AddPolygonSRC = async function () {
    
    tokenAddress = '0xaBF22878C673C20865D9A1247c86FDe7B1165B7e';
    tokenSymbol = 'SRC';
    tokenDecimals = 18;
    tokenImage = $('#SRCimg')[0].currentSrc;
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