export async function ErrorNetwork(chainId) {

	const w3 = new Web3(Web3.givenProvider)
	const address = await w3.eth.requestAccounts()
	const networkID = await w3.eth.net.getId()

	console.log(chainId, networkID )
	if (chainId != networkID) {
		console.log("??")
		return false
	}
	return true
}


