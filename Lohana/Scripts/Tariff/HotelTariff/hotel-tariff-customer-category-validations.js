$(document).ready(function () {


    $("#frmHotelTariffCustomerCategory").validate({
        rules:
            {
                "HotelTariffCustomerCategory.CustomerCategoryId":
                 {
                     DropdownRequired: true,
                 },
                "HotelTariffCustomerCategory.Margin":
                 {
                     required: true,
                     number: true,
                 },
                

            },
        messages: {

            "HotelTariffCustomerCategory.CustomerCategoryId":
                {
                    DropdownRequired: "Customer category is required."
                },
            "HotelTariffCustomerCategory.Margin":
               {
                   required: "Margin is required.",
                   number: "Enter digits only."
               }
            
        }
    });

});