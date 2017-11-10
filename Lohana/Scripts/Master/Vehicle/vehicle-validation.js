$(document).ready(function () {

    $("#frmVehicle").validate({
                 
        rules: {

            "Vehicle.VehicleName":
             {
                 required: true,
                 CheckVehicleNameExist: true,
             },

            "Vehicle.VehicleTypeId":
            {
                VehicleType: true,
            },

            "Vehicle.VehicleBrandId":
            {
                VehicleBrand: true,
            },


            "Vehicle.SeatCapacity":
            {
                required: true,
                number:true
            },

        },
            messages: {

                "Vehicle.VehicleName":
                 {
                     required:"Vehicle name is required."
                 },
                      
                "Vehicle.SeatCapacity":
                 {
                     required: "Seat capacity is required.",
                     number: "Enter digit only."
                 },
            }
});
    
      jQuery.validator.addMethod("CheckVehicleNameExist", function (value, element) {
                               
         return GetAjaxAlreadyExists('/Vehicle/CheckVehicleNameExist', { VehicleName: value }, $("#txtVehicleName"), $("#hdnVehicleName"));

      }, "Vehicle name is already exist.");

      jQuery.validator.addMethod("VehicleType", function (value, element) {
        var result = true;

        if ($("#drpVehicleTypeId").val() == "0") {
            result = false;
        }

        return result;

      }, "Vehicle type is required.");

      jQuery.validator.addMethod("VehicleBrand", function (value, element) {
          var result = true;

          if ($("#drpVehicleBrandId").val() == "0") {
              result = false;
          }

          return result;

      }, "Vehicle brand is required.");

});


