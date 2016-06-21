var App = (function () {
    var hub = $.connection.dataHub;
    var start = $.connection.hub.start();

    return {
        promise: start,
        _hub: hub,
        Hub: hub.client
    }
}());