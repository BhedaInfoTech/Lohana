$(document).ready(function () {


    $("#frmVehicleTariffBasicDetails").validate({
        rules:
            {
                "VehicleTariff.VendorId":
                 {
                     DropdownRequired: true,
                 },
                "VehicleTariff.PackageName":
                 {
                     required: true
                 },
                "VehicleTariff.Inclusions":
               {
                   required: true
               },
                "VehicleTariff.Exclusions":
                 {
                     required: true,
                 },
                "VehicleTariff.CancellationPolicy":
                 {
                     required: true
                 },
            },
        messages: {

            "VehicleTariff.VendorId":
                {
                    DropdownRequired: "Vendor is required."
                },
            "VehicleTariff.PackageName":
               {
                   required: "Package name is required.",
               },
            "VehicleTariff.Inclusions":
              {
                  required: "Inclusions is required.",
              },
            "VehicleTariff.Exclusions":
                  {
                      required: "Exclusions is required."
                  },
            "VehicleTariff.CancellationPolicy":
               {
                   required: "Cancellation policy is required."
               }
        }
    });

});