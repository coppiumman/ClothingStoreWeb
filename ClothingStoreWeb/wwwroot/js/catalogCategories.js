window.catalogCategories = {
    scroll: function (element, distance) {
        if (!element) {
            return;
        }

        element.scrollBy({
            left: distance,
            behavior: "smooth"
        });
    }
};