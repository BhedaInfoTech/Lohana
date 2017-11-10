$(document).ready(function () {

    $("#frmCountry").validate({

        rules: {

            "Country.CountryCode":
            {
                required: true,
                CheckCountryCodeExist: true
            },
            "Country.CountryName":
             {
                 required: true,
                 CheckCountryNameExist: true
             }

        },
        messages: {

            "Country.CountryCode":
                {
                    required: "Country code is required."
                },
            "Country.CountryName":
                {
                    required: "Country name is required."
                }
        }

    });

    jQuery.validator.addMethod("CheckCountryCodeExist", function (value, element) {

        return GetAjaxAlreadyExists('/Country/CheckCountryCodeExist', { CountryCode: value }, $("#txtCountryCode"), $("#hdnCountryCode"));
    }, "Country code already exist.");


    jQuery.validator.addMethod("CheckCountryNameExist", function (value, element) {

        return GetAjaxAlreadyExists('/Country/CheckCountryNameExist', { CountryName: value }, $("#txtCountryName"), $("#hdnCountryName"));

    }, "Country name already exist.")

});





