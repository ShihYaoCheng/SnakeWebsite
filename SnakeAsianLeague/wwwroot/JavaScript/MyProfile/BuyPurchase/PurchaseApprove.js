export async function PurchaseApprove(PurchaseInput, USDTaddress, SRCExchange_address) {


	const web3 = await new Web3(Web3.givenProvider)
	//web3.TransactionManager.UseLegacyAsDefault = true;
	const USDT_address = USDTaddress
	const ERC20_abi = window.ERC20_abi
	const SRCExchange_addr = "0x0C59F0fe842952A41A64438E46dDa826631d4B7F" //SRCExchange_address

	const SwapNumValue = PurchaseInput
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
