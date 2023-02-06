window.LanguageSwitch = async function (lang) {
  await i18next.changeLanguage(lang);
  $("body").localize().attr('class', `i18n-${lang}`);
  if(window.i18nCallback) i18nCallback();
}

window.installI18n = async function () {
   
  const lang = localStorage['lang']
  // 網站預設語言
  const defaultLang = 'en'
  await i18next.use(i18nextHttpBackend).init(
    {
      lng: lang ? lang : defaultLang,
      fallbackLng: defaultLang,
          ns: ["data", "Asian_data", "NFT_data", "Home_data", "ERNC_data", "Started_data", "Battle_data", "Inventory_data", "Company_data", "WarmUpActivities_data", "Cooperation_data","countryCode_data","NewYear2023_data","Valentine2023_data","Arena_data" ],
      defaultNS: "data",
      backend: {
        loadPath: "./Language/{{lng}}/{{ns}}.json",
      },
    },
    function (err, t) {
      jqueryI18next.init(i18next, $);
      $("body").localize();
        $("#Language_Select").val(lang ? lang : defaultLang)
        window.lang = lang ? lang : defaultLang
    }
  );
    $("#Language_Select").unbind('change').on("change", (e) => {
    window.lang = e.target.value   
  
    localStorage.lang = e.target.value
    LanguageSwitch(e.target.value);
  });
}

window.Localize = async function () {
  if ($('.NFTcard').length === 0) return
  setTimeout(() => $('.NFTcard').localize(), 10);
}

window.getlang = function () {
    const lang = localStorage['lang']
    return lang 
}