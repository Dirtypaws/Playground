var AddPerson = (function() {
    var save = function() {
        var firstName = $("#mdl_txt_firstName").val();
        var lastName = $("#mdl_txt_lastName").val();

        var person = {
            FirstName: firstName,
            LastName: lastName
        }

        App._hub.server.create(person);
    };

    return {
        Save: save
    }
}());