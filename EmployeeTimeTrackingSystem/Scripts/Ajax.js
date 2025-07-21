
//request
function Request(url, param) {
    var returnval;

    $.ajax({
        url: url,
        type: "POST",
        async: false,
        data: param,
        success: function (res) {

            /*SessionExpried(res);*/
            returnval = res;
        },
        error: function () {
            alert("Something went Wrong!");
        }
    });

    return returnval;
}