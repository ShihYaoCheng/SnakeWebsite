export function LazyLoading() {
    const option = {
        root: null,
        rootMargin: "0px 0px 0px 0px",
        threshold: [0],
    };
  
    if (window.location.pathname == "/") return
    
    const observer = new IntersectionObserver(entries => {
        entries.forEach(image => {
            if (image.isIntersecting) {
                image.target.src = image.target.dataset.src;
                observer.unobserve(image.target);
            }
        })
    }, option)

    const imgGroup = document.getElementsByTagName("img");
    Array.prototype.forEach.call(imgGroup, element => {
        observer.observe(element)
    }
    )
}

export function LazyLoadingJQuery() {
    $('.lazy').lazy();
}

export function LazyLoadingJQueryCSS() {
    const lazyloadBackgrounds = document.querySelectorAll('.cssLazy');
    var backgroundObserver = new IntersectionObserver(function (entries, observer) {
        entries.forEach(function (entry) {
            if (entry.isIntersecting) {
                var background = entry.target;
                background.classList.remove("cssLazy")
                backgroundObserver.unobserve(background);
            }
        });
    });

    lazyloadBackgrounds.forEach(function (background) {
        backgroundObserver.observe(background);
    });
}