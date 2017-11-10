$(document).ready(function () {

    $("#frmState").validate({

        rules: {
          
            "State.StateName":
             {
                 required: true,
                 CheckStateNameExist: true
             },
            "State.CountryId":
                {
                    Country: true
                },
            "State.StateCode":
                {
                    required: true,
                    CheckStateCodeExist: true
                }

        },
        messages: {

            "State.StateName":
                {
                    required: "State name is required."
                },
            "State.StateCode":
               {
                   required: "State code is required."
               }
        }

    });

    jQuery.validator.addMethod("CheckStateNameExist", function (value, element) {

        return GetAjaxAlreadyExists('/State/CheckStateNameExist', { StateName: value }, $("#txtStateName"), $("#hdnStateName"));

    }, "State name already exist.")

    jQuery.validator.addMethod("CheckStateCodeExist", function (value, element) {

        return GetAjaxAlreadyExists('/State/CheckStateCodeExist', { StateCode: value }, $("#txtStateCode"), $("#hdnStateCode"));

    }, "State code already exist.")


    jQuery.validator.addMethod("Country", function (value, element) {
        var result = true;

        if ($("#drpCountry").val() == 0 || $("#drpCountry").val() == null)
        {
            result = false;
        }

        return result;

    }, "Country is required.");

});





