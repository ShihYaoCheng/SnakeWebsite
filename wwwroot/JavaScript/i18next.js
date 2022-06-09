window.LanguageSwitch = async function (lang) {
  await i18next.changeLanguage(lang);
  // await installI18nRider.changeLanguage(lang)
  $("body").localize().attr('class', `i18n-${lang}`);
}

window.installI18n = async function () {
  const lang = localStorage['lang']
  // 網站預設語言
  const defaultLang = 'en'
  await i18next.use(i18nextHttpBackend).init(
    {
      lng: lang ? lang : defaultLang,
      fallbackLng: defaultLang,
      ns: ["data"],
      defaultNS: "data",
      backend: {
        loadPath: "./Language/{{lng}}/{{ns}}.json",
      },
    },
    function (err, t) {
      jqueryI18next.init(i18next, $);
      $("body").localize();
      $("#Language_Select").val(lang ? lang : defaultLang)
    }
  );
  $("#Language_Select").unbind('change').on("change", (e) => {
    localStorage.lang = e.target.value
    LanguageSwitch(e.target.value);
  });
}

window.NFTcardLocalize = async function () {
  $("NFTcard ").localize();
}



//window.installI18nRider = async function () {
//    const lang = localStorage['lang']
//    // 網站預設語言
//    const defaultLang = 'en'
//    await i18next.use(i18nextHttpBackend).init(
//        {
//            lng: lang ? lang : defaultLang,
//            fallbackLng: defaultLang,
//            ns: ["Ridder"],
//            defaultNS: "data",
//            backend: {
//                loadPath: "./Language/{{lng}}/{{ns}}.json",
//            },
//        },
//        function (err, t) {
//            jqueryI18next.init(i18next, $);
//            $("body").localize();
//            $("#Language_Select").val(lang ? lang : defaultLang)
//        }
//    );
//    $("#Language_Select").unbind('change').on("change", (e) => {
//        localStorage.lang = e.target.value
//        LanguageSwitch(e.target.value);
//    });
//}
