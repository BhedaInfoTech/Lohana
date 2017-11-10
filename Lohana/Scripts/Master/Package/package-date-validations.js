$(document).ready(function () {

    $("#frmPackageDateDetails").validate({

        rules: {

            "Package.packageStartDate":
             {
                 required: true,

             },
            "Package.packageEndDate":
             {
                 required: true

             },

            "Package.PackageCost":
            {
                required: true,
                number: true
            },


        },
        messages: {

            "Package.packageStartDate":
                {
                    required: "Start date is required."
                },
            "Package.packageEndDate":
               {
                   required: "End date is required.",
               },

            "Package.PackageCost":
            {
        required: "Package cost is required.",
        number: "Enter digits only."
            },


        }

    });

});