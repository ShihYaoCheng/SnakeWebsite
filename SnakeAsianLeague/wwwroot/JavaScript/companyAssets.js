export async function getSRCquantity() {
	const web3 = await new Web3(Web3.givenProvider)

	const SRC_addr = "0xaBF22878C673C20865D9A1247c86FDe7B1165B7e"
	const ERC20_abi = window.ERC20_abi

	try {		
		const accounts = await web3.eth.getAccounts();
		const tokenContract = await new web3.eth.Contract(
			ERC20_abi,
			SRC_addr
		);
		let SRC_decimals = parseInt(await tokenContract.methods.decimals().call())
		const SRCtotalSupply = (await tokenContract.methods.totalSupply().call() / 10 ** SRC_decimals).toString()	
		return SRCtotalSupply
	} catch (err) {
		console.error(err);
		alert("取得失敗");
	}

}



export async function getCompanyUSDT(SRCSwap_address, wssURL) {
	
	/*引用web3 、獲取地址跟鍊*/
	const web3 = new Web3(new Web3.providers.WebsocketProvider(wssURL))
	const w3 = new Web3(Web3.givenProvider)
	const address = await w3.eth.requestAccounts() //要換company_address

	/* SRCSwap */
	const SRCSwap_addr = SRCSwap_address
	const SRCSwap_abi = window.SRCSwap_abi
	try {	
		const SRCSwap_dai_contract = new web3.eth.Contract(SRCSwap_abi, SRCSwap_addr);
		console.log(SRCSwap_dai_contract.methods)
		//let decimals = await SRCSwap_dai_contract.methods.decimals().call()
		const CompanyUSDT = (await SRCSwap_dai_contract.methods.balanceOfUSDT().call()/10**6 ).toString()	
		return CompanyUSDT
	} catch (err) {
		console.error(err);
		alert("取得失敗");
	}
}