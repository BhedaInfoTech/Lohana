$(document).ready(function () {

    $("#frmSightSeeing").validate({

        rules: {

            "SightSeeing.SightSeeingName":
             {
                 required: true,
                 CheckSightSeeingNameExist:true,
             },
            "SightSeeing.TimeFrom":
            {
                required: true,
            },
            "SightSeeing.TimeTo":
            {
                required: true,
            },

            "SightSeeing.TotalCost":
             {
                 required: true,
                 number: true,
                
             },
           "SightSeeing.CityId":
            {
             City: true,
            },
        },
        messages: {

            "SightSeeing.SightSeeingName":
                {
                    required: "Sight seeing name is required."
                },
            "SightSeeing.TimeFrom":
                {
                    required: "Time is required."
                },
            "SightSeeing.TimeTo":
                {
                    required: "Time is required."
                },
          
            "SightSeeing.TotalCost":
             {
                 required: "Total cost is required.",
                 number: "Please enter numbers only.",

             },
            
        }

    });
    
    jQuery.validator.addMethod("CheckSightSeeingNameExist", function (value, element) {

        return GetAjaxAlreadyExists('/SightSeeing/CheckSightSeeingNameExist', { SightSeeingName: value }, $("#txtSightSeeingName"), $("#hdnSightSeeingName"));

    }, "Sight seeing already exist.")

    jQuery.validator.addMethod("City", function (value, element) {

        var result = true;

        if ($("#drpCity").val() == "0") {
            result = false;
        }

        return result;

    }, "City is required.");

});
