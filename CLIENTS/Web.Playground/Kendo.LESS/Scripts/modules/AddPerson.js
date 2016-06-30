var AddPerson = (function() {
    var save = function() {
        var firstName = $("#mdl_txt_firstName").val();
        var lastName = $("#mdl_txt_lastName").val();

        var person = {
            FirstName: firstName,
            LastName: lastName
        }

        App._hub.server.create(person);

        if (!$("#mdl_chk_keepOpen").is(":checked"))
            $("#_modal").modal("hide");
    };

    $(".modal-body input").on("keypress", function(e) {
        if (e.keyCode == 13) save();
    });

    return {
        Save: save
    }
}());