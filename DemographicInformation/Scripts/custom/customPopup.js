function viewPersonDetails(popupTitle, personId, mode) {

    $('#btnUpdate').hide();
    $('#btnDelete').hide();
    $('#btnPopulate').hide();

    var x = $("#personPopup");
    var popupWidth = 400;

    if (mode === 0) { // VIEW PERSON
        x.load("/person/Edit?Id=" + personId, function () {
            x.dialog({
                modal: true, title: popupTitle, resizable: false, width: popupWidth
            });

            $("#btnUpdate").hide();
            $("#btnDelete").hide();
            $('#btnPopulate').hide();
        });
    }
    else if (mode === 1) { // EDIT PERSON
        x.load("/person/Edit?Id=" + personId, function () {
            x.dialog({
                modal: true, title: popupTitle, resizable: false, width: popupWidth
            });

            $("#btnUpdate").show();
            $("#btnDelete").hide();
            $('#btnPopulate').hide();
        });
    }
    else if (mode === 2) { // DELETE PERSON

        x.load("/person/Edit?Id=" + personId, function () {
            x.dialog({
                modal: true, title: popupTitle, resizable: false, width: popupWidth
            });

            $("#btnUpdate").hide();
            $("#btnDelete").show();
            $('#btnPopulate').hide();
        });
    }
    else if (mode === 3) { // CREATE PERSON
        $('#Id').val('');
        $('#Name').val('');
        $('#Phone').val('');
        $('#Email').val('');
        $('textarea[id="Address"]').val('');

        x.load("/person/Create", function () {
            x.dialog({
                modal: true, title: popupTitle, resizable: false, width: popupWidth
            });

            $('#btnUpdate').hide();
            $('#btnDelete').hide();
            $('#btnPopulate').show();
        });
    }
}