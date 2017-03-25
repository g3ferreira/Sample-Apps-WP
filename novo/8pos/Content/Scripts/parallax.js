function scrollBanner() {
    var scrollPos;
    var tag = document.querySelector('.parallax');
    scrollPos = window.scrollY;

    if (scrollPos <= 768 && tag) {
        tag.style.transform = "translateY(" + (-scrollPos / 2) + "px" + ")";
    }
}

window.addEventListener('scroll', scrollBanner);