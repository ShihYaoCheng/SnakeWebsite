export function jumpMoney(old, newMoney) {

    window.jumpMomey = true
    var controller = new ScrollMagic.Controller();
    var jumpMoneyScroll = new ScrollMagic.Scene({
        triggerElement: ".jumpMomey",
        triggerHook: 1,//1,
        duration: 0,
    })      
        .addTo(controller);

    //進入場景後，將場景給關閉
    jumpMoneyScroll
        .on("enter", function (e) {
            jumpMoneyScroll.enabled(false);
            startJump(old, newMoney)

        })


    function startJump(old, newMoney) {

        //第一次設定
        var unity = (newMoney - old) / 200
        var jumpTime = 1
        var element = document.querySelector('.jumpMomey');
        var jumpTimeout
        var moneyData = {
            old: old,
            newMoney: newMoney,
            unity: unity,
            element: element,
        }

        roundJump(moneyData)
        function roundJump(moneyData) {
            if (moneyData.old >= moneyData.newMoney) {
                moneyData.old = moneyData.newMoney
                moneyData.element.innerHTML = Math.floor(moneyData.old).toString().replace(/\B(?=(\d{3})+(?!\d))/g, ',')
                clearTimeout(jumpTimeout)
                return
            }

            moneyData.old += moneyData.unity
            if (moneyData.old + moneyData.unity * 5 >= moneyData.newMoney) {
                jumpTime += 40
                if (moneyData.old >= moneyData.newMoney) jumpTime = 1
            }


            moneyData.element.innerText = Math.floor(moneyData.old).toString().replace(/\B(?=(\d{3})+(?!\d))/g, ',')


            jumpTimeout = setTimeout(() => {
                roundJump(moneyData)
            }, jumpTime)

        }
    }
    
  
    
}