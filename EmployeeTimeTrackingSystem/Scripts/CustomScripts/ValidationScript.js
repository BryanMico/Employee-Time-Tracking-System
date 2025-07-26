function enableLiveValidation(selector) {
    $(selector).on('input', function () {
        $(this).valid();
    });
}

function closeAlert(id) {
    var alertBox = document.getElementById(id);
    alertBox.style.display = 'none';
}

$(document).ready(function () {
    enableLiveValidation('.login-input');
});