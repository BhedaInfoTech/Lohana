$(document).ready(function () {

    $("#frmTaxFormulaCalDemo").validate({

        rules: {

            "Hotel.publishprice":
            {
                required: true,
                number: true
            },
            "Hotel.specialprice":
            {
                required: true,
                number: true,
                checkSpecialPriceRange: true
            }
        },
        messages: {

            "Hotel.publishprice":
                {
                    required: "Publish Price is Required.",
                    number: "Please enter number."
                },
            "Hotel.specialprice":
                {
                    required: "Special Price is Required.",
                    number: "Please enter number."
                }
        }

    });


    jQuery.validator.addMethod("checkSpecialPriceRange", function (value, element)
    {
        return checkSpecialPriceRange();

    }, "Special Price cannot be less than Publish Price.");

});

function checkSpecialPriceRange()
{
    var result = true;

    var publishPrice = parseFloat($("input.publishprice").val());

    var specialPrice = parseFloat($("input.specialprice").val());

    if (specialPrice > publishPrice)
    {
        result = false;
    }

    return result;
}





