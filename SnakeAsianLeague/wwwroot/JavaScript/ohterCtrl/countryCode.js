﻿export function countryCode(state) {  
    
    const countryCode = window.country_code_List.id_to_countrycode
    let countryCodeKeyList = []
    let countryCodeValueList =[]
    let countryCodeID =[]
    let countryCodeNumber = []

    Object.values(countryCode).map((e) => {
        countryCodeValueList.push(e)
    })

    Object.keys(countryCode).map((e) => {
        countryCodeKeyList.push(e)
    })

    countryCodeValueList.map((countryCodeArea ,index) => {
        countryCodeID = []
        countryCodeNumber = []
        
        Object.keys(countryCodeArea).map((Area) => {
            countryCodeID.push(Area)    

        })
        Object.values(countryCodeArea).map((Area) => {
            countryCodeNumber.push(Area)

        })

        let optgroupElement = document.createElement("optgroup");
        optgroupElement.label = countryCodeKeyList[index]

        countryCodeNumber.map((e, i) => {
            optgroupElement.innerHTML = optgroupElement.innerHTML + `
            <option value="${e}" data-i18n="countryCode_data:country_code.${countryCodeID[i]}"></option>
            `
        })  

        document.getElementById("LoginSelectText").appendChild(optgroupElement)
        if (state == "SignUp") document.getElementById("SignUpSelectText").appendChild(optgroupElement)
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
    "id_to_countrycode": {
        "Asia": {
            "TW": "+886",
            "US": "+1",
            "CN": "+86",
            "AE": "+971",
            "AF": "+93",
            "AG": "+1268",
            "AI": "+1264",
            "AR": "+54",
            "AT": "+43",
            "AU": "+61",
            "AW": "+297",
            "BD": "+880",
            "BE": "+32",
            "BH": "+973",
            "BM": "+1441",
            "BO": "+591",
            "BR": "+55",
            "BT": "+975",
            "CA": "+1",
            "CG": "+243",
            "CH": "+41",
            "CM": "+237",
            "CO": "+57",
            "DE": "+49",
            "DK": "+45",
            "DO": "+1767",
        },
        "Europe": {
            "EG": "+20",
            "ES": "+34",
            "FR": "+33",
            "FI": "+358",
            "FJ": "+679",
            "GD": "+1473",
            "GE": "+995",
            "GH": "+233",
            "GR": "+30",
            "GT": "+502",
            "GY": "+967",
            "HK": "+852",
            "HN": "+504",
            "HT": "+509",
            "ID": "+62",
            "IE": "+353",
            "IN": "+91",
            "IS": "+354",
            "IT": "+39",
            "IQ": "+964",
            "JM": "+1876",
            "JO": "+962",
            "JP": "+81",
            "KE": "+254",
            "KH": "+975",
            "KP": "+82",
            "KW": "+965",
            "KZ": "+7",
            "LC": "+1758",
            "LK": "+94",
        },
        "Africa": {
            "LU": "+352",
            "MA": "+212",
            "MG": "+261",
            "MK": "+389",
            "ML": "+60",
            "MO": "+853",
            "MV": "+960",
            "MX": "+52",
            "NG": "+234",
            "NI": "+505",
            "NO": "+47",
            "NR": "+674",
            "NZ": "+64",
            "PA": "+507",
            "PG": "+675",
            "PK": "+92",
            "PT": "+351",
            "PY": "+595",
            "RO": "+40",
            "RU": "+7",
            "RW": "+250",
            "SA": "+966",
            "SC": "+248",
            "SD": "+249",
            "SE": "+46",
            "SG": "+65",
            "SV": "+503",
            "SY": "+381",
            "TO": "+676",
            "TR": "+90",
            "TL": "+66",
            "UA": "+380",
            "UG": "+256",
            "UK": "+44",
            "UY": "+598",
            "UZ": "+998",
            "VE": "+58",
            "YE": "+967"
        }
        
        
    }
}