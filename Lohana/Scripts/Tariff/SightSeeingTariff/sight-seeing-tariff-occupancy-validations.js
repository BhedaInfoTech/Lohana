$(document).ready(function () {

    $("#frmSightSeeingTariffOccupancy").validate({

        rules: {

            "SightSeeingTariffOccupancy.OccupancyId":
              {
                  DropdownRequired: true,
              },
            "SightSeeingTariffOccupancy.AgeFrom":
            {

                number: true,
                Age: true,
            },
            "SightSeeingTariffOccupancy.AgeTo":
           {

               number: true,
               Age: true,
           },
        },
        messages: {


            "SightSeeingTariffOccupancy.OccupancyId":
              {
                  DropdownRequired: "Occupancy is required.",
              },

            "SightSeeingTariffOccupancy.AgeFrom":
             {
                 required: "Age is required",
                 number: "Please enter number only"
             },

            "SightSeeingTariffOccupancy.AgeTo":
            {
                required: "Age is required",
                number: "Please enter number only"
            },

        }
    });



    jQuery.validator.addMethod("Age", function (value, element) {

        var result = true;

        var fromage = $("[name='SightSeeingTariffOccupancy.AgeFrom']").val();

        var toage = $("[name='SightSeeingTariffOccupancy.AgeTo']").val();

        fromage = parseInt(fromage, 10);

        toage = parseInt(toage, 10);

        if (fromage > toage) {

            result = false;
        }


        return result;

    }, "Please enter valid age.");


});