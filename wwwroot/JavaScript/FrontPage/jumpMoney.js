export function jumpMoney( old , newMoney) {
    console.log("frist", old, newMoney)
    //第一次設定
    var unity = (newMoney - old) / 3000
    var element = document.querySelector('.jumpMomey');
    var moneyData = {
        old: old,
        newMoney: newMoney,
        unity: unity,
        element: element,
    }
    console.log(moneyData, element)
    roundJump(moneyData )
    function roundJump(moneyData) {
        if (moneyData.old >= moneyData.newMoney) {
            moneyData.old = moneyData.newMoney
            moneyData.element.innerHTML = Math.floor(moneyData.old).toString().replace(/\B(?=(\d{3})+(?!\d))/g, ',')
            console.log("last",moneyData.old)
            return
        }

        moneyData.old += moneyData.unity

        moneyData.element.innerText = Math.floor(moneyData.old).toString().replace(/\B(?=(\d{3})+(?!\d))/g,',')
        console.log(moneyData.old)

        setTimeout( () => {
            roundJump(moneyData)
        },moneyData.unity )

    }
}