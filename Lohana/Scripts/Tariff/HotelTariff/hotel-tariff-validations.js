$(document).ready(function () {

    $("#frmHotelTariffBasic").validate({

        rules: {
        	"HotelTariff.CityId":
            {
            	DropdownRequired: true,
            },
           
            "HotelTariff.HotelId":
             {
             	DropdownRequired: true,
                 
             },
            "IsSameHotelVendor":
				{
					IsSameHotelVendor:true,
				}
        },
        messages: {
        	"HotelTariff.CityId":
            {
            	DropdownRequired: "City is required.",
            },

        	"HotelTariff.HotelId":
             {
             	DropdownRequired: "Hotel is required.",

             }
        }
      

    });

    jQuery.validator.addMethod("IsSameHotelVendor", function (value, element)
    {
    	var result = true;

    	if ($("[name='Filter.HotelTariffId']").val() == 0)
    	{
    		GetAjax("/HotelTariff/IsSameHotelVendorExists", { vendorId: $("[name='HotelTariff.VendorId']").val(), hotelId: $("[name='HotelTariff.HotelId']").val() }, function (data)
    		{
    			result = data;
    		});
    	}

    	return result;

    }, "Same hotel, vendor is already exists.");
});
















