var App = (function () {
    var hub = $.connection.dataHub;
    var start = $.connection.hub.start();

    var openModal = function(url) {
        var mod = $("#_modal");
        mod.load(url);
        mod.modal("show");
    };

    //hub.error(function(error) {
    //    console.log("SignalR error: " + error);
    //});

    return {
        promise: start,
        _hub: hub,
        Hub: hub.client,
        Modal: openModal
    }
}());