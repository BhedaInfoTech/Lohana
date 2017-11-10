$(document).ready(function () {


    $("#frmSightSeeingTariffCustomerCategory").validate({
        rules:
            {
                "SightSeeingTariffCustomerCategory.CustomerCategoryId":
                 {
                     DropdownRequired: true,
                 },
                "SightSeeingTariffCustomerCategory.Margin":
                 {
                     required: true,
                     number: true,
                 },


            },
        messages: {

            "SightSeeingTariffCustomerCategory.CustomerCategoryId":
                {
                    DropdownRequired: "Customer category is required."
                },
            "SightSeeingTariffCustomerCategory.Margin":
               {
                   required: "Margin is required.",
                   number: "Enter digits only."
               }

        }
    });

});