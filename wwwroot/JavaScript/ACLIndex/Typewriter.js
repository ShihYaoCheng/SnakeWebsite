export function TypeWriter() {
    window.ACLS3RulesCarousel = true
    window.addEventListener('scroll', () => {
        
        var visibleHeight = window.innerHeight //可視介面高度
        var nowHeight = document.documentElement.scrollTop //現在高度
        // var allHeight = document.body.scrollHeight //所有高度
        var RulesScrollHeight = document.getElementById("ACLS3RulesCarousel").scrollHeight //滾動高度
        var RulesClientHeight = document.getElementById("ACLS3RulesCarousel").clientHeight //自身高度        
        //現在高度 > 自身高度+滾動高度+瀏覽器可見高度
        if (nowHeight > RulesScrollHeight + visibleHeight + RulesClientHeight && window.ACLS3RulesCarousel) {
            window.ACLS3RulesCarousel = false
            Typewriter()
        } 
        

        function Typewriter() {
            var Typewriter = document.querySelectorAll(".Typewriter")
            var TimeSave = []

            for (var i = 0; i < 10000; i++) {
                clearTimeout(i)
            }
            Typewriter.forEach((e) => {
                for (let i in e.children) {
                    if (e.children[i].tagName == "IMG" || e.children[i].tagName == "DIV") continue
                    if (typeof (e.children[i]) != "object") break
                    e.children[i].style.display = "none";
                    e.children[i].classList.remove("Typewriter-1Ani")

                }
            })
            Typewriter.forEach((e) => {
                for (let i in e.children) {
                    if (typeof (e.children[i]) != "object") break
                    if (e.children[i].tagName == "IMG" || e.children[i].tagName == "DIV") continue
                    test(e.children[i], i)
                }
            })
            function test(e, index) {
                TimeSave.push(setTimeout(() => {
                    e.style.display = "block";
                    e.classList.add("Typewriter-1Ani")
                }, 800 * index))
            }

        }

    })

}