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
export async function withdraw(SRCInput) {
	$('.lockWindows')[0].style.display = 'flex';
	const web3 = await new Web3(Web3.givenProvider)
	//web3.TransactionManager.UseLegacyAsDefault = true;
	const SRC_addr = "0xaBF22878C673C20865D9A1247c86FDe7B1165B7e"
	const ERC20_abi = window.ERC20_abi
	const SRCExchange_addr = "0x6C7c64D826E1D52f107881FfCcE01417F1B14BFa"
	const SRCExchange_ABI = window.SRCExchange_ABI

	const SwapNumValue = SRCInput
	let x = new BigNumber(parseInt(SwapNumValue));


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
			});


		// 交易貨幣
		const vendor = await new web3.eth.Contract(
			SRCExchange_ABI,
			SRCExchange_addr
		);

		request = await vendor.methods
			.withdraw(x.shiftedBy(SRC_decimals).toString())
			.send({
				from: accounts[0],
			});
		alert("You have successfully sold SRC tokens!");
		$('.lockWindows')[0].style.display = 'none';


		return true
	} catch (err) {
		console.error(err);
		alert("交易失敗");
		$('.lockWindows')[0].style.display = 'none';
		return false
	}

}

//轉換(存入) gSRC > SRC
export async function deposit(SRCInput) {
	$('.lockWindows')[0].style.display = 'flex';
	const web3 = await new Web3(Web3.givenProvider)
	//web3.TransactionManager.UseLegacyAsDefault = true;
	const SRC_addr = "0xaBF22878C673C20865D9A1247c86FDe7B1165B7e"
	const ERC20_abi = window.ERC20_abi
	const SRCExchange_addr = "0x6C7c64D826E1D52f107881FfCcE01417F1B14BFa"
	const SRCExchange_ABI = window.SRCExchange_ABI

	const SwapNumValue = SRCInput
	let x = new BigNumber(parseInt(SwapNumValue));
	console.log("11111",SwapNumValue)
	try {
		//驗證貨幣
		const accounts = await web3.eth.getAccounts();
		const tokenContract = await new web3.eth.Contract(
			ERC20_abi,
			SRC_addr
		);
		//精度
		let SRC_decimals = parseInt(await tokenContract.methods.decimals().call())

		// 交易貨幣
		const vendor = await new web3.eth.Contract(
			SRCExchange_ABI,
			SRCExchange_addr
		);
		console.log("22222")
		let request = await vendor.methods
			.deposit(x.shiftedBy(SRC_decimals).toString())
			.send({
				from: accounts[0],
			});
		console.log("request", request)
		alert("You have successfully sold SRC tokens!");
		$('.lockWindows')[0].style.display = 'none';
		console.log("33333")
		return true
	} catch (err) {
		console.log("error", err)	
		alert("交易失敗");
		$('.lockWindows')[0].style.display = 'none';
		return false
	}

}





//取得鍊上資料
export async function CoinexchangeData(chainId ,SRC_address) {

	/*引用web3 、獲取地址跟鍊*/
	const w3 = new Web3(Web3.givenProvider)
	const address = await w3.eth.requestAccounts()
	const networkID = await w3.eth.net.getId()
	if (parseInt(chainId.slice(2)) != networkID) {
		return ["false", "0"]
	}
	/* SRC */
	const SRC_token_addr = SRC_address
	const SRC_abi = window.ERC20_abi
	const SRC_dai_contract = new w3.eth.Contract(SRC_abi, SRC_token_addr)

	let SRC_decimals = await SRC_dai_contract.methods.decimals().call()
	let addr_SRC_balance = await SRC_dai_contract.methods.balanceOf(address[0]).call() / 10 ** SRC_decimals

	/*ERNC*/



	$("#userAddress")[0].innerText = address[0].slice(0, 9) + "...."

	
	/*回傳*/
	return ["true", (addr_SRC_balance).toString()  ]

}
