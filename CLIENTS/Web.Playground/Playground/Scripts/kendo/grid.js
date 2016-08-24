var Grid = (function () {

    console.log('Grid');
    var _grid = null;

    var _ddl_form_schemas = $("#ddl_form_schemas").kendoDropDownList({
        dataTextField: "Text",
        dataValueField: "ID",
        dataSource: {
            data: [
                { ID: 1, Text: "form_1" },
                { ID: 2, Text: "form_2" }
            ]
        },
        change: _changeSchema
    }).data("kendoDropDownList");

    var _ds = new kendo.data.DataSource({
        transport: {
            read: {
                type: "GET",
                dataType: "json",
                url: _rootUrl + "Kendo/GetEntries",
                data: {
                    formName: function () { return _ddl_form_schemas.text(); }
                },
                complete: function (jqXHR, textStatus) {
                    if (jqXHR.status != 200) {
                        var obj = jQuery.parseJSON(jqXHR.responseText);
                        alert(obj.result);
                    }
                }
            },
            parameterMap: function (data, type) {
                if (type != "read") { return { models: JSON.stringify(data.models) }; }
                else { return data; }
            }
        },
        pageSize: 10,
        batch: true
    });

    function _changeSchema() {

        if (_grid != null) {
            _grid.destroy();
            $("#grd_form_entries").empty();
            // $("#grd_form_entries").remove();
        }

        $.ajax({
            type: "GET",
            dataType: "json",
            url: _rootUrl + "Kendo/GetSchema?formName=" + _ddl_form_schemas.text()
        })
        .done(function (data) {

            console.log('data', data);

            // ref to grid obj
            _grid = $("#grd_form_entries").kendoGrid({
                dataSource: _ds,
                columns: data,      // dynamic columns

                autoBind: false,
                editable: false,
                navigatable: true,
                resizable: true,
                scrollable: true,
                height: 320,
                sortable: {
                    mode: "single",
                    allowUnsort: false
                },
                columnMenu: true,
                reorderable: true,
                dataBound: function () {
                    /*nothing*/
                }
            }).data('kendoGrid');

        });
    }

    // PUBLIC
    return {
        Controls: {
            _ddl_form_schemas: _ddl_form_schemas
        },

        /* methods */
        ChangeSchema: _changeSchema
    };

}());