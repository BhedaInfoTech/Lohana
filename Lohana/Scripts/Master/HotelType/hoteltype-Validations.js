$(document).ready(function () {

    $("#frmHotelType").validate({

        rules: {

            "HotelTypeInfo.HotelType":
            {
                required: true,
                CheckHotelTypeExist: true
            },
            

        },
        messages: {

            "HotelTypeInfo.HotelType":
                {
                    required: "Hotel Type is required."
                },
            
        }

    });

    jQuery.validator.addMethod("CheckHotelTypeExist", function (value, element) {

        return GetAjaxAlreadyExists('/HotelType/CheckHotelTypeExist', { HotelType: value }, $("#txtHotelType"), $("#hdnHotelType"));
    }, "Hotel Type already exist.");


    

});





