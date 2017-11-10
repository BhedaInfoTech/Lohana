$(document).ready(function () {

    $("#frmSightSeeingTariffBasic").validate({

        rules: {
            "SightSeeingTariff.SightSeeingId":
            {
                DropdownRequired: true,
            },

            "IsSameHotelVendor":
				{
				    IsSameHotelVendor: true,
				}
        },
        messages: {
            "SightSeeingTariff.SightSeeingId":
            {
                DropdownRequired: "SightSeeing is required.",
            },
        }


    });

    jQuery.validator.addMethod("IsSameSightSeeingVendor", function (value, element) {
        var result = true;

        if ($("[name='Filter.SightSeeingTariffId']").val() == 0) {
            GetAjax("/SightSeeingTariff/IsSameSightSeeingVendorExists", { vendorId: $("[name='SightSeeingTariff.VendorId']").val(), sightseeingId: $("[name='SightSeeingTariff.SightSeeingId']").val() }, function (data) {
                result = data;
            });
        }

        return result;

    }, "Same sightseeing, vendor is already exists.");
});
















