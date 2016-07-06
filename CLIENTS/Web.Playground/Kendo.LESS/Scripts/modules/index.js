var Index = (function () {


    var grd_persons = $("#grd_persons").kendoGrid({
        height: 550,
        sortable: true,
        editable: false,
        reorderable: true,
        selectable: "row",
        columnMenu: true,
        change: _person_change,
        filterable: {
            mode: "row"
        },
        pageable: {
            pageSize: 20,
            messages: {
                display: "{2} data items"
            }
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
                        ID: { type: "string" },
                        FirstName: { type: "string" },
                        LastName: { type: "string" },
                        Phones: [
                            {
                                PhoneNumber: { type: "string" },
                                PhoneNumberTypeID: { type: "number" }
                            }
                        ]
                    }
                }
            },
            //sort: [{ field: "LastName", dir: "asc" }],
            transport: {
                signalr: {
                    promise: App.promise,
                    hub: App._hub,
                    server: {
                        read: "getPersons",
                        create: "createPerson",
                        update: "updatePerson",
                        destroy: "deletePerson"
                    },
                    client: {
                        read: "getPersons",
                        create: "createPerson",
                        update: "updatePerson",
                        destroy: "deletePerson"
                    }
                }
            }
        }
    }).data("kendoGrid");

    var grd_phones = $("#grd_phones").kendoGrid({
        height: 550,
        sortable: true,
        editable: false,
        reorderable: true,
        selectable: "row",
        columnMenu: true,
        change: _phone_change,
        filterable: {
            mode: "row"
        },
        pageable: {
            buttonCount: 1,
            pageSize: 20,
            messages: {
                display: "{2} data items"
            }
        },
        columns: [
            {
                field: "PhoneNumber",
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
                    fields: {
                        PersonID: { type: "int" },
                        PhoneNumber: { type: "string" },
                        PhoneNumberTypeID: { type: "string" },

                        ModifiedDate: { type: "date" }
                    }
                }
            },
            //sort: [{ field: "LastName", dir: "asc" }],
            transport: {
                signalr: {
                    promise: App.promise,
                    hub: App._hub,
                    server: {
                        read: "getPhones",
                        create: "createPhone",
                        update: "updatePhone",
                        destroy: "deletePhone"
                    },
                    client: {
                        read: "getPhones",
                        create: "createPhone",
                        update: "updatePhone",
                        destroy: "deletePhone"
                    }
                }
            }
        }
    }).data("kendoGrid");

    var createPerson = function() {
        App.Modal(_rootUrl + "Home/AddPerson");
    }

    var createPhone = function () {
        App.Modal(_rootUrl + "Home/AddPhone");
    }

    App._hub.client.get = function(e) {
        console.log(e);
    }

    App.Hub.create = function(e) {
        console.log(e);
    }

    function _person_change(a, b) {
        var selected = grd_persons.dataItem(grd_persons.select());
        
        if (selected) {
            grd_phones.dataSource.filter({
                field: "PersonID",
                operator: "eq",
                value: selected.ID
            });
        } else {
            grd_phones.dataSource.filter({});
        }
    }

    function _phone_change() {
        var selected = grd_phones.dataItem(grd_phones.select());

        if (selected) {
            grd_persons.dataSource.filter({
                field: "Phones",
                operator: function (itm, val) {
                    if (itm.map(function (item) { return item.PhoneNumber; }).indexOf(val) != -1)
                        return true;
                    return false;
                },
                value: selected.PhoneNumber
            });

        } else {
            grd_persons.dataSource.filter({});
        }
    }

    return {
        Controls: {
            Grid_Persons: grd_persons,
            Grid_Phones: grd_phones
        },
        CreatePerson: createPerson,
        CreatePhone: createPhone
    };
}());