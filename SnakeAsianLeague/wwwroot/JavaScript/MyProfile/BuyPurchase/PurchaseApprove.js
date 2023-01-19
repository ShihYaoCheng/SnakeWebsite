export async function PurchaseApprove(PurchaseInput, USDTaddress, SRCExchange_address) {


	const web3 = await new Web3(Web3.givenProvider)
	//web3.TransactionManager.UseLegacyAsDefault = true;
	const USDT_address = USDTaddress
	const ERC20_abi = window.ERC20_abi
	const SRCExchange_addr = SRCExchange_address //SRCExchange_address

	const SwapNumValue = PurchaseInput
	BigNumber.config({ EXPONENTIAL_AT: [-7, 22] }) 
	let x = new BigNumber(SwapNumValue);

	
	try {
		//驗證貨幣
		const accounts = await web3.eth.getAccounts();
		const tokenContract = await new web3.eth.Contract(
			ERC20_abi,
			USDT_address
		);

		let SRC_decimals = parseInt(await tokenContract.methods.decimals().call())
		console.log("x", x.shiftedBy(SRC_decimals).toString())
		let request = await tokenContract.methods.approve(
			SRCExchange_addr,
			x.shiftedBy(SRC_decimals).toString()
		)
			.send({
				from: accounts[0],
			});

		console.log("request", request)
		// 交易貨幣
		//const vendor = await new web3.eth.Contract(
		//	SRCExchange_ABI,
		//	SRCExchange_addr
		//);

		//request = await vendor.methods
		//	.withdraw(x.shiftedBy(SRC_decimals).toString())
		//	.send({
		//		from: accounts[0],
		//	});
		//alert("You have successfully sold SRC tokens!");
		return true
	} catch (err) {
		console.error(err);		;
		return false
	}

}


export async function getUSDT(wssURL, USDT_address) {
	const web3 = new Web3(new Web3.providers.HttpProvider(wssURL))
	const w3 = new Web3(Web3.givenProvider)
	const address = await w3.eth.requestAccounts()
	const networkID = await w3.eth.net.getId()
	console.log("address", address ,"networkID", networkID)
	//if (chainId != networkID) {
	//	return 0
	//}

	const USDT_token_addr = USDT_address
	const USDT_abi = window.ERC20_abi
	const dai_contract = new web3.eth.Contract(USDT_abi, USDT_token_addr)
	let decimals = await dai_contract.methods.decimals().call()
	let addr_USDT_balance = await dai_contract.methods.balanceOf(address[0]).call() / 10 ** decimals

	return addr_USDT_balance;

}