var App = (function () {
    var content = $("#content");

    var routes = routie({
        "": function() {
            content.load(_rootUrl + "Home/Main");
        },
        "main": function() {
            content.load(_rootUrl + "Home/Main");
        },
        "bootstrap": function() {
            content.load(_rootUrl + "Bootstrap/Index");
        }
    });
}());