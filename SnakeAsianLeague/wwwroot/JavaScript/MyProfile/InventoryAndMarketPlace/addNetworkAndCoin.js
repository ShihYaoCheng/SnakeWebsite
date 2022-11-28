//新增鍊
window.AddPolygonID = async function (chainId, chainName, recUrls, nativeCurrencyName, nativeCurrencyDecimals) {
    const web3 = new Web3(Web3.givenProvider)
    chainId = web3.utils.toHex(chainId);

    if (navigator.vendor.indexOf('Apple') != -1 || /android|webos|iphone|ipad|ipod|blackberry|iemobile|opera mini|mobile/i.test(navigator.userAgent)) {
        try {
            await window.ethereum.request({
                method: 'wallet_addEthereumChain',
                params: [
                    {
                        chainId: chainId,
                        chainName: chainName,
                        rpcUrls: [recUrls],
                        nativeCurrency: {
                            "name": nativeCurrencyName,
                            "symbol": nativeCurrencyName,
                            "decimals": parseInt(nativeCurrencyDecimals)
                        }
                    },
                ],
            });
        } catch (addError) {

        }
    } else {
        try {
            await window.ethereum.request({
                method: 'wallet_switchEthereumChain',
                params: [{ chainId: chainId }],
            });
        } catch (switchError) {
            if (switchError.code === 4902) {
                try {
                    await window.ethereum.request({
                        method: 'wallet_addEthereumChain',
                        params: [
                            {
                                chainId: chainId,
                                chainName: chainName,
                                rpcUrls: [recUrls],
                                nativeCurrency: {
                                    "name": nativeCurrencyName,
                                    "symbol": nativeCurrencyName,
                                    "decimals": parseInt(nativeCurrencyDecimals)
                                }
                            },
                        ],
                    });
                } catch (addError) {

                }
            }

        }
    }

  




    window.addnewNetwork = async function (chainId, chainName, recUrls, nativeCurrencyName, nativeCurrencyDecimals) {
        const web3 = new Web3(Web3.givenProvider)
        chainId = web3.utils.toHex(chainId);
        try {
            await window.ethereum.request({
                method: 'wallet_addEthereumChain',
                params: [
                    {
                        chainId: chainId,
                        chainName: chainName,
                        rpcUrls: [recUrls],
                        nativeCurrency: {
                            "name": nativeCurrencyName,
                            "symbol": nativeCurrencyName,
                            "decimals": parseInt(nativeCurrencyDecimals)
                        }
                    },
                ],
            });
        } catch (addError) {

        }
    }
        

    

/*

export function AddPolygonID() {
    console.log(123)
    try {
        await window.ethereum.request({
            method: 'wallet_switchEthereumChain',
            params: [{ chainId: '0x89' }],
        });
    } catch (switchError) {
        if (switchError.code === 4902) {
            try {
                await window.ethereum.request({
                    method: 'wallet_addEthereumChain',
                    params: [
                        {
                            chainId: '0x89',
                            chainName: 'Polygon',
                            rpcUrls: ['https://polygon-rpc.com'] 
                        },
                    ],
                });
            } catch (addError) {

            }
        }

    }
}
*/
window.ethereum.on('chainChanged', (chainId) => {
    console.log(chainId) // 0x38 if it's BSC
})

}

//新增鍊上貨幣
//USDT
window.AddPolygonUSDT = async function (USDT_token_addr, USDT_Decimals) {
    tokenAddress = USDT_token_addr;
    tokenSymbol = 'USDT';
    tokenDecimals = USDT_Decimals;
    tokenImage = 'https://storage.googleapis.com/pps-nft/token/USDT.png';
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

//SRC
window.AddPolygonSRC = async function (SRC_token_addr, SRC_Decimals, warmUpToggle = false) {

    tokenAddress = SRC_token_addr;
    //預熱活動用 修改
    tokenImage = "https://storage.googleapis.com/pps-nft/token/SRC.png";
    tokenDecimals = SRC_Decimals;
    if (warmUpToggle) {
        tokenSymbol = 'TSRC';
        tokenImage = "https://storage.googleapis.com/pps-nft/token/tSRC.png";
    }
    tokenSymbol = 'SRC';   
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