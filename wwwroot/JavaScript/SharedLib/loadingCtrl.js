


export function loadingCtrl() {
    //偵測使用裝置，設定時間
    var time 
    if (window.navigator.userAgent.match(/(phone|pad|pod|iPhone|iPod|ios|iPad|Android|Mobile|BlackBerry|IEMobile|MQQBrowser|JUC|Fennec|wOSBrowser|BrowserNG|WebOS|Symbian|Windows Phone)/i)) {
        console.log('移动端')
        //移动端
        time = 30
    } else {
        console.log('PC端')
        //PC端
        time = 10
    }

    //抓取相關dom，設定圖片隱藏
    var num = 0;
    var loader = document.getElementById("loader")
    var loader_num = document.getElementById("loader_num");
    for (let i = 0; i < document.images.length; i++) {
        document.images[i].style.display = 'none'
    
    }   
    document.getElementById("loadingImg").style.display = "block"
  
    
    //開始跑百分比
    function imgLoad(img) {
        var img_length = document.images.length;       

        setTimeout(function () {
            loader_num.textContent = Math.ceil((num) / (img_length) * 100) + "%";
            num++;
            if (num < img_length) {
                imgLoad(document.images[num]);
            }
            else {
                
                document.getElementById("loader").style.display = "none";
                for (let i = 0; i < document.images.length; i++) {
                    document.images[i].style.display = 'block'
                }
            }
        }, time) //设置百分比数字变换间隔


    }
    imgLoad(document.images[num]);
}

