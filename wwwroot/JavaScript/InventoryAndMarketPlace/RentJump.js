export function RentJump(old, newMoney) {
 
    //第一次設定
    window.jumpMomey = true
    var unity = (newMoney - old) / 100
    var jumpTime = 1
    var element = document.querySelector('#TotalSRCCount');
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
        if (moneyData.old + moneyData.unity >= moneyData.newMoney) {
            moneyData.unity = 3
            jumpTime += 20
            if (moneyData.old >= moneyData.newMoney) jumpTime = 1
        }


        moneyData.element.innerText = Math.floor(moneyData.old).toString().replace(/\B(?=(\d{3})+(?!\d))/g, ',')


        jumpTimeout = setTimeout(() => {
            roundJump(moneyData)
        }, jumpTime)

    }
    



}