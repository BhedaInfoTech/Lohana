$(document).ready(function () {

    $("#frmCity").validate({

        rules: {

            "City.CityCode":
            {
                required: true,
                CheckCityCodeExist: true
            },
            "City.CityName":
             {
                 required: true,
                 CheckCityNameExist: true
             },
            "City.CountryId":
                {
                  Country:true,
                },
            "City.StateId":
            {
                State:true,
            }
        },
        messages: {

            "City.CityCode":
                {
                    required: "City code is required."
                },
            "City.CityName":
                {
                    required: "City name is required."
                }
        }

    });

    jQuery.validator.addMethod("CheckCityCodeExist", function (value, element) {

        return GetAjaxAlreadyExists('/City/CheckCityCodeExist', { CityCode: value }, $("#txtCityCode"), $("#hdnCityCode"));

    }, "City code already exist.");


    jQuery.validator.addMethod("CheckCityNameExist", function (value, element) {

        return GetAjaxAlreadyExists('/City/CheckCityNameExist', { CityName: value }, $("#txtCityName"), $("#hdnCityName"));

    }, "City name already exist.")


    jQuery.validator.addMethod("Country", function (value, element) {
        var result = true;

        if ($("#drpCountry").val() == null || $("#drpCountry").val() == 0 ) {
            result = false;
        }

        return result;

    }, "Country is required.");

    jQuery.validator.addMethod("State", function (value, element) {
        var result = true;

        if ($("#drpState").val() == 0 || $("#drpState").val() == null)
        {
            result = false;
        }

        return result;

    }, "State is required.");
});





