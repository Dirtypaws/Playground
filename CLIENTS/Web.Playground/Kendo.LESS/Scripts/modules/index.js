var Index = (function () {


    var grid = $("#grd_data").kendoGrid({
        height: 550,
        sortable: true,
        editable: false,
        reorderable: true,
        selectable: "row",
        columnMenu: true,
        filterable: {
            mode: "row"
        },
        pageable: {
            pageSize: 20
        },
        columns: [
            {
                field: "LastName",
                filterable: {
                    cell: {
                        operator: "contains"
                    }
                }
            },
            {
                field: "FirstName",
                filterable: {
                    cell: {
                        operator: "contains"
                    }
                }
            }
        ],
        dataSource: {
            type: "signalr",
            autoSync: true,
            schema: {
                model: {
                    id: "ID",
                    fields: {
                        "ID": { type: "string" },
                        "FirstName": { type: "string" },
                        "LastName": { type: "numberstring" }
                    }
                }
            },
            //sort: [{ field: "LastName", dir: "asc" }],
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
        App.Modal(_rootUrl + "Home/AddPerson");
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