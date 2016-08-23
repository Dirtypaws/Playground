var Main = (function () {
    var examples = $("#examples").isotope({
        itemSelector: ".grid-item",
        layout: "masonry",
        masonry: {
            columnWidth: 240
        }

    });

    var data = [
        { text: "Kendo", id: "kendo" },
        { text: "Bootstrap", id: "bootstrap" }
    ];
    var ddl_groups = $("#ddl_groups").select2({
        data: data,
        tags: true,
        placeholder: "Filter by application..."
    });

    $(".grid-item").on("click", function (e) {
        window.location.href = _rootUrl + $(this).attr("data-url");
    });

    $("#filters select").on("change", function (e) {
        examples.isotope({
            filter: function() {
                var itm = $(this);
                var grpMatch = false;
                if (ddl_groups.val() == null || ddl_groups.val().length === 0)
                    grpMatch = true;
                else
                    $.each(ddl_groups.val(), function(index, item) {
                        if (itm.hasClass(item) || grpMatch)
                            grpMatch = true;
                    });

                return grpMatch;
            }
        });
    });

    return {
        _controls: {
            iso: examples,
            groups: ddl_groups
        }
    };

}());