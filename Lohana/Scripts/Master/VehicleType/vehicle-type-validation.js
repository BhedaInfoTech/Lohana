$(document).ready(function () {

    $("#frmVehicleType").validate({

        rules: {

            "VehicleType.VehicleTypeName":
             {
                 required: true,
                 CheckVehicleTypeNameExist: true
             }

        },
        messages: {

            "VehicleType.VehicleTypeName":
                {
                    required: "Vehicle type name is required."
                }
        }

    });


    jQuery.validator.addMethod("CheckVehicleTypeNameExist", function (value, element) {

        return GetAjaxAlreadyExists('/VehicleType/CheckVehicleTypeNameExist', { VehicleTypeName: value }, $("#txtVehicleTypeName"), $("#hdnVehicleTypeName"));

    }, "Vehicle type name already exist.")

});
