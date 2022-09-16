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