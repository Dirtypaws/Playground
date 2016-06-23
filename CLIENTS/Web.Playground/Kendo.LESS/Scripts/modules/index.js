var Index = (function () {


    var grid = $("#grd_data").kendoGrid({
        height: 550,
        sortable: true,
        editable: false,
        reorderable: true,
        selectable: "row",
        columnMenu: true,
        columns: [
            { field: "Name" },
            { field: "InStock", template: "<input type='checkbox' data-toggle='toggle' disabled data-on='Yes' data-off='No' #= InStock ? 'checked' : '' #/>" },
            { field: "Price" }
        ],
        
        dataSource: {
            type: "signalr",
            autoSync: true,
            schema: {
                model: {
                    id: "ID",
                    fields: {
                        "ID": { type: "string" },
                        "Name": { type: "string" },
                        "Price": { type: "number" },
                        "InStock": { type: "bool" }
                    }
                }
            },
            sort: [{ field: "Name", dir: "desc" }],
            transport: {
                signalr: {
                    promise: App.promise,
                    hub: App._hub,
                    server: {
                        read: "get",
                        create: "create",
                        update: "update"
                    },
                    client: {
                        read: "get",
                        create: "create",
                        update: "update",
                        destroy: "delete"
                    }
                }
            }
        }
    }).data("kendoGrid");

    var create = function() {
        App._hub.server.create();
    }

    App._hub.client.get = function(e) {
        console.log(e);
    }

    App.Hub.create = function(e) {
        console.log(e);
    }

    return {
        Grid: grid,
        Create: create
    };
}());