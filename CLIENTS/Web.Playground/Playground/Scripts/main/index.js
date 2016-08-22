var Main = (function () {
    var examples = $("#examples").isotope({
        itemSelector: ".grid-item",
        layout: "masonry",
        masonry: {
            columnWidth: 240
        }

    });

    $(".grid-item").on("click", function (e) {
        window.location.href = _rootUrl + $(this).attr("data-url");
    });

    return {
        _controls: {
            iso: examples
        }
    };

}());