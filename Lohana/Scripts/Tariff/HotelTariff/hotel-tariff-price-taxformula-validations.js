$(document).ready(function () {

    $("#frmHotelTariffPrice").validate({


        rules: {

            "HotelTariffPrice.PublishPrice":
            {
                required: true,
                number: true
            },
            "HotelTariffPrice.SpecialPrice":
            {
                required: true,
                number: true,
                //checkSpecialPriceRange: true
            }
        },
        messages: {

            "HotelTariffPrice.PublishPrice":
                {
                    required: "Publish price is required.",
                    number: "Please enter number."
                },
            "HotelTariffPrice.SpecialPrice":
                {
                    required: "Special price is required.",
                    number: "Please enter number."
                }
        }

    });


    jQuery.validator.addMethod("checkSpecialPriceRange", function (value, element) {
        return checkSpecialPriceRange();

    }, "Special price cannot be greater than publish price.");

});

function checkSpecialPriceRange() {
    var result = true;

    var publishPrice = parseFloat($("input.publishprice").val());

    var specialPrice = parseFloat($("input.specialprice").val());

    if (specialPrice > publishPrice) {
        result = false;
    }

    return result;
}





