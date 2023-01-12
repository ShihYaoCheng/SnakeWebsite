window.signUpMobile = function (code) {
    //
    //`https://dev.origingaia.com/InvitationCode/QRcodeSaveInvitation?${new URLSearchParams({ 'code': code})}`
    //
    fetch(`https://${window.location.host}/api/user/InvitationCode/QRcodeSaveInvitation?code=${code}`,
        {
            method: "POST",           
        }
        )
        .then((response) => {
            console.log("response", response)
        })
        .catch((error) => {
            console.log("error", error)       
        })


    setTimeout(() => {
        if (!window.MSStream && /iPad|iPhone|iPod/.test(navigator.userAgent)) {
            window.location.href = "https://apps.apple.com/us/app/%E7%A2%B0%E7%A2%B0%E8%9B%87-2/id1504212624"

        } else if (/android|webos|blackberry|iemobile|opera mini|mobile/i.test(navigator.userAgent)) {
            window.location.href = "https://play.google.com/store/apps/details?id=com.cqigames.snakeknight"

        } else {
            window.location.href = `/SignUp/${code}`
        }

    }, 500)
    
    
}