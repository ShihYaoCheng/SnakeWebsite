window.myprofileSidebar = function () {
    if ($('.myprofileSidebarButton').length === 0) return
    console.log('1111111111')
    $('.myprofileSidebarButton').click(function (e) {
        $('.myprofileSidebar').toggleClass('SidebarOpen');
    });
    $('.accountManagementUl a').click(function () {
        $('.myprofileSidebar').removeClass('SidebarOpen');
    });
    
    $(document).mouseup(function (e) {
        var container = $(".myprofileSidebar"); // 這邊放你想要排除的區塊

        if (!container.is(e.target) && container.has(e.target).length === 0) {
            $('.myprofileSidebar').removeClass('SidebarOpen');

        }
    });
}

window.textCopy = function () {
    console.log('textCopy')
    let text = $('.metamaskAvailable span').text()
    
    console.log("copyTip")
    
    if (!navigator.clipboard || !navigator.clipboard.writeText) {
        let textArea = document.createElement("textarea");
        textArea.value = text;
        textArea.style.opacity = "0";
        document.body.appendChild(textArea);
        textArea.focus();
        textArea.select();
        try {
            let successful = document.execCommand("copy");
            console.log("Copying text command was " + text);

        } catch (err) {
            console.log("Unable to copy value , error : " + err.message);
        }
        document.body.removeChild(textArea);
        return;
        
    }
    // console.log(text);
    navigator.clipboard.writeText(text);
    // alert("複製成功!")

    // 複製提示語
    // let copyTip = `<div id="copyTip" style="position: absolute; top: 50%;left: 50%;transform: translate(-50%, -50%);padding: 12px 25px;background: rgba(0, 0, 0, 0.6); color: #fff;font-size: 14px;">複製成功</div>`; //提示語div
    // $("#copyTip").css({"opacity": "1","z-index":"1"}); //放入document
    // setTimeout(() => {
        // $("#copyTip").css({"opacity": "0","z-index":"-1"}); //提示完即消失
    // }, 700);
    
}
window.copyTip = function () {
    // 複製提示語
    // let copyTip = `<div id="copyTip" style="position: absolute; top: 50%;left: 50%;transform: translate(-50%, -50%);padding: 12px 25px;background: rgba(0, 0, 0, 0.6); color: #fff;font-size: 14px;">複製成功</div>`; //提示語div
    $("#copyTip").css({"opacity": "1","z-index":"1"}); //放入document
    setTimeout(() => {
        $("#copyTip").css({"opacity": "0","z-index":"-1"}); //提示完即消失
    }, 700);
}

window.InventoryFilterSidebarClick = function () {
    $('.Inventory-PPSR-Filter').click(function(){
        console.log('Inventory-PPSR-Filter')
        $('.Inventory-PPSR-Filter-Sidebar').slideToggle('fast'); 

    })
    $(document).mouseup(function (e) {
        var container =$(".Inventory-PPSR-Filter-Sidebar, .Inventory-PPSR-Filter"); // 這邊放你想要排除的區塊
        if (!container.is(e.target) && container.has(e.target).length === 0) {
            $('.Inventory-PPSR-Filter-Sidebar').slideUp('fast');

        }
    });

    if ($('.NFTcard').length === 0) {
        $('.IfNoCard').show();
    }if ($('.NFTcard').length > 0){
        $('.IfNoCard').hide();
    }
}

// 個人資產頁的篩選器使用顯示判斷
window.CardAmountLinkDisplay = function (){
    $('.Inventory-PPSR-Filter-Sidebar').click(function () {
        var FilterCheckboxClicked = $('.Inventory-PPSR-Filter-Sidebar input[type="checkbox"]:checked').length;
        var FilterButtonClicked = $('.Filter-Button-Click:not(#Filter-Button-Reset)').length;
        var FilterRadioClicked = $('.Inventory-PPSR-Filter-Sidebar input[type="radio"]:checked').length;
        var HeartClicked = $('.Filter-Header-Block .heartClickRed').length;

        if (FilterCheckboxClicked > 0 || 
            FilterButtonClicked > 0 || 
            FilterRadioClicked > 0 ||
            HeartClicked > 0){
            
            $('.Inventory-PPSR-Filter').addClass("Inventory-PPSR-Filter-Ing");
            
            console.log(FilterCheckboxClicked,'FilterCheckboxClicked')
            console.log(FilterButtonClicked,'FilterButtonClicked')
            console.log(FilterRadioClicked,'FilterRadioClicked')
            console.log(HeartClicked,'HeartClicked')
        }else{
            $('.Inventory-PPSR-Filter').removeClass("Inventory-PPSR-Filter-Ing");
        }

    });
}




window.web3button = function () {


    console.log("web3button");


    //ethereum.networkVersion属性返回MetaMask当前接入的区块链的网络ID。一些常见的值如下：

    //1：以太坊主网
    //2：Morden测试链
    //3：Ropsten测试链
    //4：Rinkeby测试链
    //42：Kovan测试链

    console.log(ethereum.networkVersion);
    document.getElementById("networkVersion").innerHTML = "networkVersion : " + ethereum.networkVersion;

    //ethereum.isMetaMask返回true或false，表示当前用户是否安装了MetaMask。
    console.log('MetaMask installed ? ', ethereum.isMetaMask);


    document.getElementById("installed").innerHTML = "MetaMask installed ?  : " + ethereum.isMetaMask;


    console.log(ethereum.isConnected());
    document.getElementById("isConnected").innerHTML = "ethereum isConnected ?  : " + ethereum.isConnected();
    

    if (typeof window.ethereum !== 'undefined' || (typeof window.web3 !== 'undefined')) {

        // Web3 browser user detected. You can now use the provider.

        console.log(window.ethereum);
        console.log(window.web3);

        
        const provider = window['ethereum'] || window.web3.currentProvider


        console.log(provider);
        try {


            console.log(ethereum.isConnected());


            //const provider = await detectEthereumProvider();

            //if (provider) {
            //    startApp(provider); // Initialize your app
            //} else {
            //    console.log('Please install MetaMask!');
            //}



            ethereum.request({ method: 'eth_requestAccounts' })
                .then(handleAccountsChanged)
                .catch((err) => {
                    if (err.code === 4001) {
                        // EIP-1193 userRejectedRequest error
                        // If this happens, the user rejected the connection request.
                        console.log('Please connect to MetaMask.');

                        document.getElementById("err").innerHTML = "Please connect to MetaMask.";
                    } else {
                        console.error(err);
                        document.getElementById("err").innerHTML = err;
                    }
                });


            //ethereum.request({ method: 'eth_requestAccounts' });
            //const accounts = await ethereum.request({ method: 'eth_requestAccounts' });
            //const account = accounts[0];

        } catch (error) {
            console.log(error);
            document.getElementById("err").innerHTML = error;
        }
    }


    function handleAccountsChanged(accounts) {
        console.log(accounts);
    }

    ethereum.on('accountsChanged', handleAccountsChanged);

    // Later

    ethereum.removeListener('accountsChanged', handleAccountsChanged);


    
       // const accounts = await ethereum.request({ method: 'eth_requestAccounts' });
        //ethereum.autoRefreshOnNetworkChange = false;
        //ethereum.on("accountsChanged",
        //    function (accounts) {
        //        DotNet.invokeMethodAsync('Nethereum.Metamask.Blazor', 'SelectedAccountChanged', accounts[0]);
        //    });
        //ethereum.on("networkChanged",
        //    function (networkId) {

        //    });
      


    //const ethereumButton = document.querySelector('.enableEthereumButton');

    //ethereumButton.addEventListener('click', () => {
    //    //Will Start the metamask extension
    //    ethereum.request({ method: 'eth_requestAccounts' });
    //});

    //const accounts = await ethereum.request({ method: 'eth_requestAccounts' });
    //const account = accounts[0];

    //console.log(walletAddress);
    // We currently only ever provide a single account,
    // but the array gives us some room to grow.

    //const getWeb3 = async () => {
    //    return new Promise(async (resolve, reject) => {
    //        const web3 = new Web3(window.ethereum);
    //        try {

    //            await Window.ethereum.request({ method: "eth_requestAccounts" });
    //            console.log("7410");
    //            resolve(web3);
    //        } catch (error) {
    //            reject(" 7410");
    //            reject(error);
    //        }
    //    })
    //};

    //const web3 = await getWeb3();
    //const walletAddress = await web3.eth.requestAccounts();
    //const walletBalanceInWei = await web3.eth.getBalance(walletAddress[0]);
    //const walletBalanceInEth = Math.round(web3.utils.fromWei(walletBalanceInWei) * 1000) / 1000;


  

    //target.setAttribute("hidden", "hidden");

    //document.getElementById("wallet_address").innerText = walletAddress;
    //document.getElementById("wallet_balance").innerText = walletBalanceInEth;
    //document.getElementById("wallet_info").removeAttribute("hidden");

}
