$(document).ready(function () {

    $("#frmOccupancy").validate({

        rules: {         
            "Occupancy.OccupancyType":
            {
                OccupancyType: true,
            },
            "Occupancy.OccupancyName":
             {
                 required: true,
                 CheckOccupancyNameExist: true
             },
            "Occupancy.OccupancyValue":
             {
                 required: true,
                 number: true
             }

        },
        messages: {            
           
            "Occupancy.OccupancyName":
                {
                    required: "Occupancy name is required."
                },
            "Occupancy.OccupancyValue":
          {
              required: "Occupancy value is required.",
              number: "Enter digits only."
          }
        }

    });

    jQuery.validator.addMethod("CheckOccupancyNameExist", function (value, element) {

        return GetAjaxAlreadyExists('/Occupancy/CheckOccupancyNameExist', { OccupancyName: value }, $("#txtOccupancyName"), $("#hdnOccupancyName"));

    }, "Occupancy name already exist.")

    jQuery.validator.addMethod("OccupancyType", function (value, element) {
        var result = true;

        if ($("#drpOccupancyType").val() == "0") {
            result = false;
        }

        return result;

    }, "Occupancy type is required.");

});





