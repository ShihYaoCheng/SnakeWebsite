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
		const totalSupply = (await tokenContract.methods.totalSupply().call() / 10 ** SRC_decimals).toString()	
		return totalSupply
	} catch (err) {
		console.error(err);
		alert("取得失敗");
	}

}



export async function getCompanyUSDT(USDT_address, company_address) {
	console.log(company_address)
	/*引用web3 、獲取地址跟鍊*/
	const w3 = new Web3(Web3.givenProvider)
	const address = await w3.eth.requestAccounts() //要換company_address

	/*USDT */
	const USDT_token_addr = USDT_address
	const USDT_abi = window.ERC20_abi
	const dai_contract = new w3.eth.Contract(USDT_abi, USDT_token_addr)

	let decimals = await dai_contract.methods.decimals().call()
	let addr_USDT_balance = (await dai_contract.methods.balanceOf(address[0]).call() / 10 ** decimals).toString()

	return addr_USDT_balance
}