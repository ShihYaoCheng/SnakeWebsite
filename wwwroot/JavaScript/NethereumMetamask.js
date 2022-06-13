window.NethereumMetamaskInterop = {
    EnableEthereum: async () => {
        try {
            const accounts = await ethereum.request({ method: 'eth_requestAccounts' });
            ethereum.autoRefreshOnNetworkChange = false;
            ethereum.on("accountsChanged",
                function (accounts) {
                    DotNet.invokeMethodAsync('Nethereum.Metamask.Blazor', 'SelectedAccountChanged', accounts[0]);
                });
            ethereum.on("networkChanged",
                function (networkId) {

                });
            return accounts[0];
        } catch (error) {
            return null;
        }
    },
    IsMetamaskAvailable: () => {
        if (window.ethereum) return true;
        return false;
    },
    GetSelectedAddress: () => {
        return ethereum.selectedAddress;
    },

    Request: async (message) => {
        try {

            let parsedMessage = JSON.parse(message);
            console.log(parsedMessage);
            const response = await ethereum.request(parsedMessage);
            let rpcResonse = {
                jsonrpc: "2.0",
                result: response,
                id: parsedMessage.id,
                error: null
            }
            console.log(rpcResonse);

            return JSON.stringify(rpcResonse);
        } catch (e) {
            let rpcResonseError = {
                jsonrpc: "2.0",
                id: parsedMessage.id,
                error: {
                    message: e,
                }
            }
            return JSON.stringify(rpcResonseError);
        }
    },

    Send: async (message) => {
        return new Promise(function (resolve, reject) {
            console.log(JSON.parse(message));
            ethereum.send(JSON.parse(message), function (error, result) {
                console.log(result);
                console.log(error);
                resolve(JSON.stringify(result));
            });
        });
    },

    Sign: async (utf8HexMsg) => {
        return new Promise(function (resolve, reject) {
            const from = ethereum.selectedAddress;
            const params = [utf8HexMsg, from];
            const method = 'personal_sign';
            ethereum.send({
                method,
                params,
                from,
            }, function (error, result) {
                if (error) {
                    reject(error);
                } else {
                    console.log(result.result);
                    resolve(JSON.stringify(result.result));
                }

            });
        });
    },

    AddToken: async () => {
        const tokenAddress = '0xd00981105e61274c8a5cd5a88fe7e037d935b513';
        const tokenSymbol = 'TUT';
        const tokenDecimals = 18;
        const tokenImage = 'http://placekitten.com/200/300';

        try {
            // wasAdded is a boolean. Like any RPC method, an error may be thrown.
            const wasAdded = await ethereum.request({
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
    },

}