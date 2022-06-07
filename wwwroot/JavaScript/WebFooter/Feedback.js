export function Feedback (Feedback) {

    function sendFeedback() {
        let formData = `{"userNickname":"${$("#userNickname").val()}","email":"${$("#email").val()}","mobilePhone":"${$("#phone").val()}","feedbackType":"${$("#feedbackType").val()}","content":"${$("textarea#content").val()}"}`;
        console.log("sendFeedback",formData); 
        $.ajax({
            type: "POST",
            //test
            //url: "http://localhost:8080/feedback/official/ponsnake",
            //url: "https://feedback.cqiserv.com/feedback/official/ponsnake",
            //Prod
            url: "https://feedback.cqiserv.com/feedback/official/ponsnake", 
            data: formData,
            crossDomain: true,
            contentType: "application/json;charset=UTF-8",
            success: function (data) {
                console.log(data);
                
                $('#userNickname').val("");
                $('#email').val("");
                $('#phone').val("");
                $('#feedbackType').val("");                
                $('#textarea#content').val("");
                $('#content').val("");
                //alert("感謝您的回饋，我們會持續努力做出好遊戲");
                
            },
            error: function (jqXHR, textStatus, errorThrown) {
                console.log(jqXHR.status);
                alert("請確認網路是否連線!");
            },
            beforeSend: setHeader
        });
    }
    function setHeader(xhr) {

        xhr.setRequestHeader('Access-Control-Allow-Credentials', 'true');
        xhr.setRequestHeader('Access-Control-Allow-Origin', '*');
        xhr.setRequestHeader('Access-Control-Allow-Methods', 'GET, POST, OPTIONS, HEAD')
    };


    var sendMessageButton = document.getElementById('sendMessageButton')
    sendMessageButton.addEventListener('click', () => {
        console.log("????????");
        sendFeedback();
    })

    $("#sendMessageButton").click(function () {
     
    });
}

