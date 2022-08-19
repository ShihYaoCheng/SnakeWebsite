
window.AddPolygonID = async function () {

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
