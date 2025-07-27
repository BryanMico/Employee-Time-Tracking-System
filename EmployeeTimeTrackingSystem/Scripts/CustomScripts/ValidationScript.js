function enableLiveValidation(selector) {
    $(selector).on('input', function () {
        $(this).valid();
    });
}

function closeAlert(id) {
    $('#' + id).hide();
}

function showErrorMessages(containerId, messages) {
    const $container = $('#' + containerId);
    $container.empty();
    messages.forEach(msg => {
        $container.append(`<p>${msg}</p>`);
    });
    $container.parent().show();
}

function attachLoginSubmitHandler(formSelector, errorAlertId, errorMessagesId) {
    $(formSelector).submit(function (e) {
        e.preventDefault();

        if (!$(this).valid()) {
            closeAlert(errorAlertId);
            return;
        }

        closeAlert(errorAlertId);
        $('#' + errorMessagesId).empty();

        $.ajax({
            url: $(this).attr('action'),
            type: 'POST',
            data: $(this).serialize(),
            success: function (res) {
                if (res.success) {
                    window.location.href = res.redirect;
                } else if (res.message) {
                    showErrorMessages(errorMessagesId, [res.message]);
                }
            },
            error: function () {
                showErrorMessages(errorMessagesId, ['An unexpected error occurred. Please try again.']);
            }
        });
    });
}

function attachAlertCloseHandler(alertId) {
    $(`#${alertId} .close-btn`).click(function () {
        $(this).closest('.alert').hide();
    });
}

function initLoginForm(formSelector, errorAlertId, errorMessagesId, inputSelector) {
    enableLiveValidation(inputSelector);
    attachLoginSubmitHandler(formSelector, errorAlertId, errorMessagesId);
    attachAlertCloseHandler(errorAlertId);
}

$(document).ready(function () {
    initLoginForm('#loginForm', 'loginError', 'loginErrorMessages', '.login-input');
});
