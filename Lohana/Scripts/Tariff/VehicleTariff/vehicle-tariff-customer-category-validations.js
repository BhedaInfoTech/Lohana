$(document).ready(function () {


    $("#frmVehicleTariffCustomerCategoryDetails").validate({
        rules:
            {
                /*"VehicleTariff.CustomerCategoryId":
                 {
                     DropdownRequired: true,
                 },
                "VehicleTariff.CustomerMargin":
                 {
                     required: true,
                     number: true,
                 },*/
               // "VehicleTariff.CalculatedTotalAmount":
               //{
               //    required: true,
               //    number: true,
                //},
                "VehicleTariffCustomerCategories[0].Margin": {
                    required: true,
                    number: true,
                },
                "VehicleTariffCustomerCategories[1].Margin": {
                    required: true,
                    number: true,
                },
                "VehicleTariffCustomerCategories[2].Margin": {
                    required: true,
                    number: true,
                },
                "VehicleTariffCustomerCategories[3].Margin": {
                    required: true,
                    number: true,
                },
                "VehicleTariffCustomerCategories[4].Margin": {
                    required: true,
                    number: true,
                },
                "VehicleTariffCustomerCategories[5].Margin": {
                    required: true,
                    number: true,
                },
              
            },
        messages: {

            "VehicleTariffCustomerCategories[0].Margin": {
                required: "Margin is required.",
                number: "Enter digits only."
            },
            "VehicleTariffCustomerCategories[1].Margin": {
                required: "Margin is required.",
                number: "Enter digits only."
            },
            "VehicleTariffCustomerCategories[2].Margin": {
                required: "Margin is required.",
                number: "Enter digits only."
            },
            "VehicleTariffCustomerCategories[3].Margin": {
                required: "Margin is required.",
                number: "Enter digits only."
            },
            "VehicleTariffCustomerCategories[4].Margin": {
                required: "Margin is required.",
                number: "Enter digits only."
            },
            "VehicleTariffCustomerCategories[5].Margin": {
                required: "Margin is required.",
                number: "Enter digits only."
            },

            /*"VehicleTariff.CustomerCategoryId":
                {
                    DropdownRequired: "Customer category is required."
                },
            "VehicleTariff.CustomerMargin":
               {
                   required: "Margin is required.",
                   number: "Enter digits only."
               }*/
            //"VehicleTariff.CalculatedTotalAmount":
            //  {
            //      required: "Amount is required.",
            //      number: "Enter digits only."
            //  }
        }
    });

});