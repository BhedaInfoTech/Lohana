$(document).ready(function () {


    $("#frmLohanaPackageTariffVehicle").validate({
        rules:
            {

                "LohanaPackageTariffVehicle.NoOfNight":
                 {
                     required: true,
                 },

            
            },
        messages: {


            "LohanaPackageTariffVehicle.NoOfNight":
               {
                   required: "No of nights are required.",
               },
           

        }
    });

});