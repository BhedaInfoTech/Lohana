$(document).ready(function () {

    $("#frmSightSeeingTariffPrice").validate({


        rules: {

            "SightSeeingTariffPrice.PublishPrice":
            {
                required: true,
                number: true
            },
            "SightSeeingTariffPrice.SpecialPrice":
            {
                required: true,
                number: true,
                //checkSpecialPriceRange: true
            }
        },
        messages: {

            "SightSeeingTariffPrice.PublishPrice":
                {
                    required: "Publish price is required.",
                    number: "Please enter number."
                },
            "SightSeeingTariffPrice.SpecialPrice":
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