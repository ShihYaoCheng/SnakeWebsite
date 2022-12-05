/*
window.web3JS = async function () {
	const w3 = new Web3(Web3.givenProvider)
	const USDT_token_addr = '0xc2132D05D31c914a87C6611C10748AEb04B58e8F'
	const acc_address = "0x3DD8F133C30cbc84B246f56cf8659B21595803a5"     

	const simplified_abi = [{ "constant": true, "inputs": [], "name": "name", "outputs": [{ "name": "", "type": "string" }], "payable": false, "stateMutability": "view", "type": "function" }, { "constant": false, "inputs": [{ "name": "spender", "type": "address" }, { "name": "value", "type": "uint256" }], "name": "approve", "outputs": [{ "name": "", "type": "bool" }], "payable": false, "stateMutability": "nonpayable", "type": "function" }, { "constant": true, "inputs": [], "name": "totalSupply", "outputs": [{ "name": "", "type": "uint256" }], "payable": false, "stateMutability": "view", "type": "function" }, { "constant": false, "inputs": [{ "name": "from", "type": "address" }, { "name": "to", "type": "address" }, { "name": "value", "type": "uint256" }], "name": "transferFrom", "outputs": [{ "name": "", "type": "bool" }], "payable": false, "stateMutability": "nonpayable", "type": "function" }, { "constant": true, "inputs": [], "name": "decimals", "outputs": [{ "name": "", "type": "uint8" }], "payable": false, "stateMutability": "view", "type": "function" }, { "constant": false, "inputs": [{ "name": "spender", "type": "address" }, { "name": "addedValue", "type": "uint256" }], "name": "increaseAllowance", "outputs": [{ "name": "success", "type": "bool" }], "payable": false, "stateMutability": "nonpayable", "type": "function" }, { "constant": false, "inputs": [], "name": "unpause", "outputs": [], "payable": false, "stateMutability": "nonpayable", "type": "function" }, { "constant": true, "inputs": [{ "name": "account", "type": "address" }], "name": "isPauser", "outputs": [{ "name": "", "type": "bool" }], "payable": false, "stateMutability": "view", "type": "function" }, { "constant": true, "inputs": [], "name": "paused", "outputs": [{ "name": "", "type": "bool" }], "payable": false, "stateMutability": "view", "type": "function" }, { "constant": false, "inputs": [], "name": "renouncePauser", "outputs": [], "payable": false, "stateMutability": "nonpayable", "type": "function" }, { "constant": true, "inputs": [{ "name": "owner", "type": "address" }], "name": "balanceOf", "outputs": [{ "name": "", "type": "uint256" }], "payable": false, "stateMutability": "view", "type": "function" }, { "constant": false, "inputs": [{ "name": "account", "type": "address" }], "name": "addPauser", "outputs": [], "payable": false, "stateMutability": "nonpayable", "type": "function" }, { "constant": false, "inputs": [], "name": "pause", "outputs": [], "payable": false, "stateMutability": "nonpayable", "type": "function" }, { "constant": true, "inputs": [], "name": "symbol", "outputs": [{ "name": "", "type": "string" }], "payable": false, "stateMutability": "view", "type": "function" }, { "constant": false, "inputs": [{ "name": "spender", "type": "address" }, { "name": "subtractedValue", "type": "uint256" }], "name": "decreaseAllowance", "outputs": [{ "name": "success", "type": "bool" }], "payable": false, "stateMutability": "nonpayable", "type": "function" }, { "constant": false, "inputs": [{ "name": "to", "type": "address" }, { "name": "value", "type": "uint256" }], "name": "transfer", "outputs": [{ "name": "", "type": "bool" }], "payable": false, "stateMutability": "nonpayable", "type": "function" }, { "constant": true, "inputs": [{ "name": "owner", "type": "address" }, { "name": "spender", "type": "address" }], "name": "allowance", "outputs": [{ "name": "", "type": "uint256" }], "payable": false, "stateMutability": "view", "type": "function" }, { "inputs": [{ "name": "name", "type": "string" }, { "name": "symbol", "type": "string" }, { "name": "decimals", "type": "uint8" }, { "name": "totalSupply", "type": "uint256" }], "payable": false, "stateMutability": "nonpayable", "type": "constructor" }, { "anonymous": false, "inputs": [{ "indexed": false, "name": "account", "type": "address" }], "name": "Paused", "type": "event" }, { "anonymous": false, "inputs": [{ "indexed": false, "name": "account", "type": "address" }], "name": "Unpaused", "type": "event" }, { "anonymous": false, "inputs": [{ "indexed": true, "name": "account", "type": "address" }], "name": "PauserAdded", "type": "event" }, { "anonymous": false, "inputs": [{ "indexed": true, "name": "account", "type": "address" }], "name": "PauserRemoved", "type": "event" }, { "anonymous": false, "inputs": [{ "indexed": true, "name": "from", "type": "address" }, { "indexed": true, "name": "to", "type": "address" }, { "indexed": false, "name": "value", "type": "uint256" }], "name": "Transfer", "type": "event" }, { "anonymous": false, "inputs": [{ "indexed": true, "name": "owner", "type": "address" }, { "indexed": true, "name": "spender", "type": "address" }, { "indexed": false, "name": "value", "type": "uint256" }], "name": "Approval", "type": "event" }]
	const dai_contract = new w3.eth.Contract(simplified_abi, USDT_token_addr)
	const address = await w3.eth.requestAccounts()
    
	let decimals = await dai_contract.methods.decimals().call()
	let addr_balance = await dai_contract.methods.balanceOf(acc_address).call() / 10 ** decimals


	$(".user-address")[0].innerText = address[0].slice(0, 9) + "...."
	$("#userAddress")[0].innerText = address[0].slice(0, 9) + "...."

	$("#TotalBalance")[0].innerText = 'Total Balance: ' + addr_balance
   
	return addr_balance.toString()

  
}*/
/*Rinkeby 網路 */

window.web3JS = async function (chainId, USDT_address, SRC_address, SRCSwap_address, wssURL) {

	/*引用web3 、獲取地址跟鍊*/
	const web3 = new Web3(new Web3.providers.HttpProvider(wssURL))
	const w3 = new Web3(Web3.givenProvider)
	const address = await w3.eth.requestAccounts()
	const networkID = await w3.eth.net.getId()
	
	if (chainId != networkID) {
		return [0,0,0]
	}

	/*USDT */
	const USDT_token_addr = USDT_address
	const USDT_abi = window.ERC20_abi
	const dai_contract = new web3.eth.Contract(USDT_abi, USDT_token_addr)

	let decimals = await dai_contract.methods.decimals().call()
	let addr_USDT_balance = await dai_contract.methods.balanceOf(address[0]).call() / 10 ** decimals

	/* SRC */
	const SRC_token_addr = SRC_address
	const SRC_abi = window.ERC20_abi
	const SRC_dai_contract = new web3.eth.Contract(SRC_abi, SRC_token_addr)

	let SRC_decimals = await SRC_dai_contract.methods.decimals().call()
	let addr_SRC_balance = await SRC_dai_contract.methods.balanceOf(address[0]).call() / 10 ** SRC_decimals

	/*$(".user-address")[0].innerText = address[0].slice(0, 9) + "...."*/
	//$("#userAddress")[0].innerText = address[0].slice(0, 5) + "...." + address[0].slice(38)
	$("#USDTTotalBalance")[0].innerText = 'Balance: ' + addr_USDT_balance
	$("#SRCTotalBalance")[0].innerText = 'Balance: ' + addr_SRC_balance

	/* SRCSwap */
	const SRCSwap_addr = SRCSwap_address
	const SRCSwap_abi = window.SRCSwap_abi



	const SRCSwap_dai_contract = new web3.eth.Contract(SRCSwap_abi, SRCSwap_addr);
	console.log(SRCSwap_dai_contract.methods)
	let usdPerSRCRate = await SRCSwap_dai_contract.methods.usdPerSRC().call() / 10 ** 18
	let usdtPerSRCRate = await SRCSwap_dai_contract.methods.usdtPerSRC().call() / 10 ** 18
	$("#usdPerSRCRate")[0].innerText = "≈$ " + (usdPerSRCRate).toString().slice(0, 7) + "USD"
	$("#usdtPerSRCRate")[0].innerText = '1 SRC ≈$ ' + (usdtPerSRCRate).toString().slice(0, 7) + " USDT"

	return [addr_SRC_balance, addr_USDT_balance, parseFloat( (usdtPerSRCRate).toString().slice(0, 7))]
}



window.web3JSConfirm = async function (SwapToggle, SRCInput, USDTInput, USDT_address, SRC_address, SRCSwap_address) {

	const web3 = await new Web3(Web3.givenProvider)
	//web3.TransactionManager.UseLegacyAsDefault = true;
	const USDT_addr = USDT_address
	const SRC_addr = SRC_address
	const ERC20_abi = window.ERC20_abi
	const SRCSwap_addr = SRCSwap_address
	const SRCSwap_abi = window.SRCSwap_abi



	if (SwapToggle) {
		//SRC 轉 USDT
		SwapNumValue = SRCInput
		let x = new BigNumber(SwapNumValue);

		try {
			//驗證貨幣
			const accounts = await web3.eth.getAccounts();
			const tokenContract = await new web3.eth.Contract(
				ERC20_abi,
				SRC_addr
			);
			// Approve the contract to spend the tokens

			let SRC_decimals = parseInt(await tokenContract.methods.decimals().call())
			console.log(SRC_decimals)
			let request = await tokenContract.methods.approve(
				SRCSwap_addr,
				x.shiftedBy(SRC_decimals).toString()
			)
				.send({
					from: accounts[0],
				});

			// 交易貨幣
			const vendor = await new web3.eth.Contract(
				SRCSwap_abi,
				SRCSwap_addr
			);
			console.log("~~~~~~~成功囉", vendor)
			request = await vendor.methods
				.swapSRCtoUSDT(x.shiftedBy(SRC_decimals).toString())
				.send({
					from: accounts[0],
				});
			console.log(request,"成功囉~~~~~~~")
		
			alert("You have successfully sold SRC tokens!");
			console.log(request);
			return true
		} catch (err) {
			console.error(err);
			alert("交易失敗");
			$('.lockWindows')[0].style.display = 'none';
			return false
		}

	} else {
		/*
		// USDT 轉 SRC  
		SwapNumValue = USDTInput
		let x = new BigNumber(parseInt(SwapNumValue));

		try {
			//驗證貨幣
			const accounts = await web3.eth.getAccounts();
			const tokenContract = await new web3.eth.Contract(
				ERC20_abi,
				USDT_addr
			);
			// Approve the contract to spend the tokens

			let USDT_decimals = parseInt(await tokenContract.methods.decimals().call())	
			console.log(USDT_decimals)
			let request = await tokenContract.methods.approve(
				USDT_addr,
				x.shiftedBy(USDT_decimals).toString()
			)
				.send({
					from: accounts[0],
				});		


			// 交易貨幣
			const vendor = await new web3.eth.Contract(
				SRCSwap_abi,
				SRCSwap_addr
			);
			console.log(vendor)
			request = await vendor.methods
				.swapUSDTtoSRC(x.shiftedBy(USDT_decimals).toString())
				.send({
					from: accounts[0],
				});
			alert("You have successfully sold TEST tokens!");
			$('.lockWindows')[0].style.display = 'none';
			console.log(request);
		} catch (err) {
			console.error(err);
			alert("交易失敗");
			$('.lockWindows')[0].style.display = 'none';
		}
		*/
	}
}
