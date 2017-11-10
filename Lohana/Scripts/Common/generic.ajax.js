

function PostAjaxJson(url, data, callback) {

    $.ajax({

        url: url,

        data: JSON.stringify(data),

        datatype: 'json',

        type: 'POST',

        contentType: 'application/json',

        Async: false,

        beforeSend: function () {


        },

        complete: function () {


        },

        success: function (data) {

            callback(data);

        },

        error: function (xhr, textStatus, exception) {

            var message;

            var statusErrorMap = {

                '400': "Server understood the request, but request content was invalid.(BAD REQUEST )",

                '401': "Unauthorized access.",

                '403': "Forbidden resource can't be accessed.",

                '500': "Internal server error.",

                '503': "Service unavailable.",

                '404': "Not Found."
            };

            if (xhr.status) {

                message = statusErrorMap[xhr.status];

                if (!message) {
                    message = "Unknown Error \n.";
                }

                FriendlyMessage(xhr.status);

            } else if (exception == 'parsererror') {
                message = "Error.\nParsing JSON Request failed.";

            } else if (exception == 'timeout') {
                message = "Request Time out.";

            } else if (exception == 'abort') {
                message = "Request was aborted by the server";

            } else {
                message = "Unknown Error \n.";
            }

        }


    });
}

function PostAjaxWithProcessJson(url, data, callback, element) {
    $.ajax({

        url: url,

        data: JSON.stringify(data),

        datatype: 'json',

        type: 'POST',

        contentType: 'application/json',

        Async: false,

        beforeSend: function () {
            $(element).block({
                css: {
                    border: 'none',
                    padding: '15px',
                    backgroundColor: '#000',
                    '-webkit-border-radius': '10px',
                    '-moz-border-radius': '10px',
                    opacity: .5,
                    color: '#fff'
                }
            });
        },

        complete: function () {
            $(element).unblock();
        },

        success: function (data)
        {
            if (data.ErrorCode == "401")
            {
                FriendlyMessage(data)
            }
            else
            {
                callback(data);
            }
        },

        error: function (xhr, textStatus, exception) {

            var message;

            var statusErrorMap = {

                '400': "Server understood the request, but request content was invalid.(BAD REQUEST )",

                '401': "Unauthorized access.",

                '403': "Forbidden resource can't be accessed.",

                '500': "Internal server error.",

                '503': "Service unavailable.",

                '404': "Not Found."
            };

            if (xhr.status) {

                message = statusErrorMap[xhr.status];

                if (!message) {
                    message = "Unknown Error \n.";
                }

            } else if (exception == 'parsererror') {
                message = "Error.\nParsing JSON Request failed.";

            } else if (exception == 'timeout') {
                message = "Request Time out.";

            } else if (exception == 'abort') {
                message = "Request was aborted by the server";

            } else {
                message = "Unknown Error \n.";
            }

        }


    });
}

function PostFileUploadAjaxWithProcessJson(url, data, callback, element) {
    $.ajax({

        type: "POST",

        url: url,

        contentType: false,

        processData: false,

        data: data,

        beforeSend: function () {
            $(element).block({
                css: {
                    border: 'none',
                    padding: '15px',
                    backgroundColor: '#000',
                    '-webkit-border-radius': '10px',
                    '-moz-border-radius': '10px',
                    opacity: .5,
                    color: '#fff'
                }
            });
        },

        complete: function () {
            $(element).unblock();
        },

        success: function (data) {
            if (data.ErrorCode == "401") {
                FriendlyMessage(data)
            }
            else {
                callback(data);
            }
        },

        error: function (xhr, textStatus, exception) {

            var message;

            var statusErrorMap = {

                '400': "Server understood the request, but request content was invalid.(BAD REQUEST )",

                '401': "Unauthorized access.",

                '403': "Forbidden resource can't be accessed.",

                '500': "Internal server error.",

                '503': "Service unavailable.",

                '404': "Not Found."
            };

            if (xhr.status) {

                message = statusErrorMap[xhr.status];

                if (!message) {
                    message = "Unknown Error \n.";
                }

            } else if (exception == 'parsererror') {
                message = "Error.\nParsing JSON Request failed.";

            } else if (exception == 'timeout') {
                message = "Request Time out.";

            } else if (exception == 'abort') {
                message = "Request was aborted by the server";

            } else {
                message = "Unknown Error \n.";
            }

        }


    });
}

function GetAjaxAlreadyExists(url, data, param, oldParam) {
    var result = true;
    if ($(param).val() != "" && $(oldParam).val() != $(param).val()) {

        $.ajax({
            url: url,
            data: data,
            method: 'GET',
            async: false,
            success: function (data) {
                if (data == true) {
                    result = false;
                }
            }
        });
    }
    return result;
}

function GetAjax(url, data, callback) {



    $.ajax({
        url: url,
        data: data,
        method: 'GET',
        async: false,
        success: function (data) {
            callback(data);
        }
    });


}



