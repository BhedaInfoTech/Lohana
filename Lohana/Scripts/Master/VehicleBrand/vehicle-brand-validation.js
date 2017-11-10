$(document).ready(function () {

    $("#frmVehicleBrand").validate({

        rules: {
                        
            "VehicleBrand.VehicleBrandName":
             {
                 required: true,
                 CheckVehicleBrandNameExist: true
             }

        },
        messages: {

            "VehicleBrand.VehicleBrandName":
                {
                    required: "Vehicle brand name is required."
                }
        }

    });
       

    jQuery.validator.addMethod("CheckVehicleBrandNameExist", function (value, element) {

        return GetAjaxAlreadyExists('/VehicleBrand/CheckVehicleBrandNameExist', { VehicleBrandName: value }, $("#txtVehicleBrandName"), $("#hdnVehicleBrandName"));

    }, "Vehicle brand name already exist.")

});
