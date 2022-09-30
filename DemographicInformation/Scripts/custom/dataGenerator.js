function getData() {

    $.ajax({
        url: 'https://randomuser.me/api/',
        dataType: 'json',
        success: function (data) {

            var personId = $('#Id').val();
            var name = $('#Name').val(data.results[0].name.first + ' ' + data.results[0].name.last);
            var phone = $('#Phone').val(data.results[0].phone);
            var email = $('#Email').val(data.results[0].email);
            var address = $('textarea[id="Address"]').val(data.results[0].location.street.number + ' ' + data.results[0].location.street.name + ' ' + data.results[0].location.city + ' '
                + data.results[0].location.state + ' ' + data.results[0].location.country + ' ' + data.results[0].location.postcode);
        }
    });
}