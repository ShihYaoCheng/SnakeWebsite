export async function ErrorNetwork(chainId) {

	const w3 = new Web3(Web3.givenProvider)
	const address = await w3.eth.requestAccounts()
	const networkID = await w3.eth.net.getId()

	console.log(chainId, networkID )
	if (parseInt(chainId.slice(2)) != networkID) {
		return false
	}
	return true
}


