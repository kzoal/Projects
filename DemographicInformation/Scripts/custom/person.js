function allowDelete() {
    var $checkboxes = $('input[id*=chkPerson]');
    var checkedCount = $checkboxes.filter(':checked').length;
    checkedCount > 0 ? $('.deletePerson').prop('disabled', false) : $('.deletePerson').prop('disabled', true);
}

function updatePerson() {

    if (confirm("Are you sure you want to update the information?")) {
        var personId = $('#Id').val();
        var name = $('#Name').val();
        var phone = $('#Phone').val();
        var email = $('#Email').val();
        var address = $('textarea[id="Address"]').val();
        var createdBy = $('#CreatedBy').val();
        var createdOn = $('#CreatedOn').val();

        var updatePerson = { "id": personId, "name": name, "phone": phone, "email": email, "address": address, "CreatedOn": createdOn, "CreatedBy": createdBy };

        $.ajax({
            type: "POST",
            url: "person/Edit",
            data: JSON.stringify(updatePerson),
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (response) {
                if (response.result == true) {
                    alert("Update successful.");
                    location = location.href;
                }
                else {
                    alert(response.error);
                }
            }
        });
    }
}

function deletePerson() {

    if (confirm("Are you sure you want to delete this person?")) {
        $.ajax({
            type: "POST",
            url: "person/Delete",
            data: JSON.stringify({ "id": $('#Id').val() }),
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (response) {
                if (response.result == true) {
                    alert("Delete successful.");
                    location = location.href;
                }
                else {
                    alert(response.error);
                }
            }
        });

    }
}

function savePerson() {

    if (confirm("Are you sure you want to save this person?")) {
        var name = $('#Name').val();
        var phone = $('#Phone').val();
        var email = $('#Email').val();
        var address = $('textarea[id="Address"]').val();

        var newPerson = { "id": -1, "name": name, "phone": phone, "email": email, "address": address };

        $.ajax({
            type: "POST",
            url: "person/Save",
            data: JSON.stringify(newPerson),
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (response) {
                if (response.result == true) {
                    alert("Person created successfully.");
                    location = location.href;
                }
                else {
                    alert(response.error);
                }
            }
        });

    }
}

function deleteSelected() {
    if (confirm("Are you sure you want to delete the selected records?")) {

        var personsToDelete = '';
        var counter = 0;

        $('[id*=chkPerson]').each(function () {
            if ($(this)[0].checked) {
                //personsToDelete[counter] = $(this)[0].name;
                personsToDelete = personsToDelete + $(this)[0].name + ',';
                counter++;
            }           
        });

        var dataToSend = {
            ids: personsToDelete
        };

        console.log(JSON.stringify(dataToSend));        

        $.ajax({
            type: "POST",
            url: "person/Delete",
            data: JSON.stringify(dataToSend),
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (response) {
                if (response.result == true) {
                    alert("Delete successful.");
                    location = location.href;
                }
                else {
                    alert(response.error);
                }
            }
        });

    }
}