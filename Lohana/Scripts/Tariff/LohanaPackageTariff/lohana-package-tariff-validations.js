$(document).ready(function () {


    $("#frmLohanaPackageTariffBasic").validate({
        rules:
            {
                
                "LohanaPackageTariff.PackageName":
                 {
                     required: true,
                 },

                "LohanaPackageTariff.DayDuration":
            {
                required: true,
                number: true

            },
                "LohanaPackageTariff.NightDuration":
                 {
                     required: true,
                     number: true
                 }


            },
        messages: {

            
            "LohanaPackageTariff.PackageName":
               {
                   required: "Package name is required.",
               },
            "LohanaPackageTariff.DayDuration":
                {
                    required: "Day duration is required",
                    number: "Enter only numbers"
                },
            "LohanaPackageTariff.NightDuration":
                {
                    required: "Night duration is required",
                    number: "Enter only numbers"
                }

        }
    });

});