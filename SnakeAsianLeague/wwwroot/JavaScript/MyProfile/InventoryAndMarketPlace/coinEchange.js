//彈窗控制
export function coinEchange(showId) {
    
    //顯示視窗
    $(showId).click(function () {
        $(".coinEchange-container").addClass("products-popup-open");
    });
    //關閉視窗
    $("#coinEchangeCancel").click(function () {
        $(".coinEchange-container").removeClass("products-popup-open");
        $(".coin-range").val(0)
        $("#GSRCincrease").val(0)
		$("#SRCincrease").val(0)
		$("#GSRCincrease").val(0)
		$("#SRCincrease").val(0)
		
		
    });
	
    //確定交易，關閉視窗
	$("#coinEchangeBtn").click(function () {
		/*web3JS($("#GSRCincrease").val() )*/
	
        $(".coinEchange-container").removeClass("products-popup-open");
        $(".coin-range").val(0)
        $("#GSRCincrease").val(0)
		$("#SRCincrease").val(0)
		

    });   
}

//轉換(提款) SRC > gSRC
export async function withdraw(SRCInput, SRC_address, SRCExchange_address) {


	const web3 = await new Web3(Web3.givenProvider)
	//web3.TransactionManager.UseLegacyAsDefault = true;
	const SRC_addr = SRC_address
	const ERC20_abi = window.ERC20_abi
	const SRCExchange_addr = SRCExchange_address

	const SRCExchange_ABI = window.SRCExchange_ABI

	const SwapNumValue = SRCInput
	let x = new BigNumber(SwapNumValue);

	var test123 = true

	try {
		//驗證貨幣
		const accounts = await web3.eth.getAccounts();
		const tokenContract = await new web3.eth.Contract(
			ERC20_abi,
			SRC_addr
		);

		let SRC_decimals = parseInt(await tokenContract.methods.decimals().call())	
		let request = await tokenContract.methods.approve(
			SRCExchange_addr,
			x.shiftedBy(SRC_decimals).toString()
		)
		.send({
			from: accounts[0],
		})
		//.on("error", function (error) {
			
		//console.log("13213")
		//console.log("request", error)
		
		//});
	


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
		console.error(err);
		alert("交易失敗");
	
		return false
	}

}

//轉換(存入) gSRC > SRC
export async function deposit(SRCInput, SRC_address, SRCExchange_address, warmUpToggle) {

	
	const web3 = await new Web3(Web3.givenProvider)
	//web3.TransactionManager.UseLegacyAsDefault = true;
	const SRC_addr = SRC_address
	const ERC20_abi = window.ERC20_abi
	const SRCExchange_addr = SRCExchange_address
	let SRCExchange_ABI = window.SRCExchange_ABI
	//預熱活動用 修改
	if (warmUpToggle) SRCExchange_ABI = window.tSRCExchange_ABI
	console.log("SRCInput", SRCInput, "SRC_address", SRC_address, "SRCExchange_address", SRCExchange_address)
	const SwapNumValue = SRCInput
	let x = new BigNumber(SwapNumValue);
	console.log("x",x)
	try {
		//驗證貨幣
		const accounts = await web3.eth.getAccounts();
		const tokenContract = await new web3.eth.Contract(
			ERC20_abi,
			SRC_addr
		);
		//精度
		let SRC_decimals = parseInt(await tokenContract.methods.decimals().call())
		console.log("xSRC_decimals", SRC_decimals)
		// 交易貨幣
		const vendor = await new web3.eth.Contract(
			SRCExchange_ABI,
			SRCExchange_addr
		);
		console.log("x", x.shiftedBy(SRC_decimals).toString())
		let request = await vendor.methods
			.deposit(x.shiftedBy(SRC_decimals).toString())
			.send({
				from: accounts[0],
			});
		console.log("request", request)
		alert("You have successfully exchange SRC tokens!");
		
	
		return true
	} catch (err) {
		console.log("error", err)	
		alert("交易失敗");
		$('.lockWindows')[0].style.display = 'none';
		return false
	}

}





//取得鍊上資料
export async function CoinexchangeData(chainId ,SRC_address,wssURL) {

	/*引用web3 、獲取地址跟鍊*/
	console.log("wssURL",wssURL)
	const web3 = new Web3(new Web3.providers.WebsocketProvider(wssURL))
	console.log("web3",web3)
	const w3 = new Web3(Web3.givenProvider)
	const address = await w3.eth.requestAccounts()
	const networkID = await w3.eth.net.getId()


	if (chainId != networkID) {
		return 0
	}
	/* SRC */
	const SRC_token_addr = SRC_address
	const SRC_abi = window.ERC20_abi
	const SRC_dai_contract = new web3.eth.Contract(SRC_abi, SRC_token_addr)
	console.log("SRC_dai_contract", SRC_dai_contract)
	let SRC_decimals = await SRC_dai_contract.methods.decimals().call()
	let addr_SRC_balance = await SRC_dai_contract.methods.balanceOf(address[0]).call() / 10 ** SRC_decimals
	console.log("addr_SRC_balance", addr_SRC_balance)
	/*ERNC*/



	//$("#userAddress")[0].innerText = address[0].slice(0, 5) + "...." + address[0].slice(38)

	
	/*回傳*/
	return addr_SRC_balance

}


export async function lockWindowsShow() {
	$('.lockWindows')[0].style.display = 'flex';
}

export async function lockWindowsHide() {
	$('.lockWindows')[0].style.display = 'none';
}

export async function changeInputValue(value) {
	$('.coin-range')[0].value = value;
}

