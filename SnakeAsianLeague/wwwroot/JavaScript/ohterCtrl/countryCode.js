export function countryCode(state) {  
    
    const countryCode = window.country_code_List.id_to_countryCode
    let countryCodeKeyList = []
    let countryCodeValueList =[]
    let countryCodeID =[]
    let countryCodeNumber = []

    //取得各州的內容
    Object.values(countryCode).map((e) => {
        countryCodeValueList.push(e)
    })
    //取得分 "州別" 的名子
    Object.keys(countryCode).map((e) => {
        countryCodeKeyList.push(e)
    })
    //取得各國家的代號及電話區號
    countryCodeValueList.map((countryCodeArea ,index) => {
        countryCodeID = []
        countryCodeNumber = []
        
        Object.keys(countryCodeArea).map((Area) => {
            countryCodeID.push(Area)    

        })
        Object.values(countryCodeArea).map((Area) => {
            countryCodeNumber.push(Area)

        })
        //建立分州的optgroup
        let optgroupElement = document.createElement("optgroup");
       
        //optgroupElement.label = countryCodeKeyList[index]
        optgroupElement.dataset.i18n = `[label]countryCode_data:country_code.${countryCodeKeyList[index]}`;

        console.log(optgroupElement)
        countryCodeNumber.map((e, i) => {
            optgroupElement.innerHTML = optgroupElement.innerHTML + `
            <option value="${e}" data-i18n="countryCode_data:country_code.${countryCodeID[i]}"></option>
            `
        })  

        document.getElementById("LoginSelectText").appendChild(optgroupElement)
        if (state == "SignUp") document.getElementById("SignUpSelectText").appendChild(optgroupElement)

        document.getElementById("LoginSelectText").dataset.dog="123"
    })

    //if (state == "SignUp") {
    //    countryCodeNumber.map((e, index) => {
    //        document.getElementById("SignUpSelectText").innerHTML = document.getElementById("SignUpSelectText").innerHTML + `
    //        <option value="${e}" data-i18n="countryCode_data:country_code.${countryCodeID[index]}"></option>
    //    `
    //    })
    //}
 
 
    //countryCodeNumber.map((e, index) => {
    //    document.getElementById("LoginSelectText").innerHTML = document.getElementById("LoginSelectText").innerHTML + `
    //    <option value="${e}" data-i18n="countryCode_data:country_code.${countryCodeID[index]}"></option>     
    //`
    //})
    

}

window.country_code_List = {    
    "id_to_countryCode": {
        "Asia": {
            "TW": "+886",
            "CN": "+86",
            "AE": "+971",
            "AF": "+93",
            "BD": "+880",
            "BH": "+973",
            "BT": "+975",
            "GE": "+995",
            "HK": "+852",
            "ID": "+62",
            "IN": "+91",
            "IQ": "+964",
            "JO": "+962",
            "JP": "+81",
            "KH": "+975",
            "KR": "+82",
            "KP": "+850",
            "KW": "+965",
            "KZ": "+7",
            "LK": "+94",
            "MO": "+853",
            "MV": "+960",
            "PK": "+92",
            "SA": "+966",
            "SG": "+65",
            "SY": "+381",
            "TR": "+90",
            "TL": "+66",
            "UZ": "+998",
            "YE": "+967",
            "VN": "+84",
            "MM": "+95"
        },
        "North America":{
            "US": "+1",
            "CA": "+1",
        },
        "Central America":{
            "AG": "+1268",
            "AI": "+1264",
            "AW": "+297",
            "BM": "+1441",
            "DO": "+1767",
            "GD": "+1473",
            "GT": "+502",
            "HN": "+504",
            "HT": "+509",
            "JM": "+1876",
            "LC": "+1758",
            "MX": "+52",
            "NI": "+505",
            "PA": "+507",
            "SV": "+503",
        },
        "South America":{
            "AR": "+54",
            "BO": "+591",
            "BR": "+55",
            "CO": "+57",
            "GY": "+967",
            "PY": "+595",
            "UY": "+598",
            "VE": "+58",
        },
        "Europe": {
            "AT": "+43",
            "BE": "+32",
            "CH": "+41",
            "DE": "+49",
            "DK": "+45",
            "ES": "+34",
            "FR": "+33",
            "FI": "+358",
            "GR": "+30",
            "IE": "+353",
            "IS": "+354",
            "IT": "+39",
            "LU": "+352",
            "MK": "+389",
            "NO": "+47",
            "PT": "+351",
            "RO": "+40",
            "RU": "+7",
            "SE": "+46",
            "UA": "+380",
            "GB": "+44",
        },
        "Oceania": {
            "AU": "+61",
            "FJ": "+679",
            "NR": "+674",
            "NZ": "+64",
            "PG": "+675",
            "TO": "+676",
        },
        "Africa": {
            "CG": "+243",
            "CM": "+237",
            "EG": "+20",
            "GH": "+233",
            "KE": "+254",
            "MA": "+212",
            "MG": "+261",
            "ML": "+60",
            "NG": "+234",
            "RW": "+250",
            "SC": "+248",
            "SD": "+249",
            "UG": "+256",
        },
        
    }
}