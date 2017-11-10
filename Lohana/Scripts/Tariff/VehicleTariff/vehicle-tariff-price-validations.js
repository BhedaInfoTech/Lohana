$(document).ready(function () {


    $("#frmVehicleTariffPriceDetails").validate({

        ignore: ":hidden",

        rules:
            {
                "VehicleTariff.VehicleId":
                 {
                     DropdownRequired: true,
                 },
                "VehicleTariff.FreeKm":
                 {
                     required: true,
                     number: true,
                 },
                "VehicleTariff.KmAmount":
               {
                   required: true,
                   number: true,
               },
                "VehicleTariff.RupeesPerExtraKm":
                 {
                     required: true,
                     number: true,
                 },
                "VehicleTariff.Duration":
                 {
                     required: true,
                     number: true,
                 },
                "VehicleTariff.HoursAmount":
                {
                    required: true,
                    number: true,
                },
                "VehicleTariff.RupeesPerExtraHours":
                {
                    required: true,
                    number: true,
                },
                "VehicleTariff.Source":
                {
                    required: true,
                },
                "VehicleTariff.Destination":
               {
                   required: true,
               },
                "VehicleTariff.PackageAmount":
               {
                   required: true,
                   number: true,
               },
                "VehicleTariff.TransferType":
                {
                    required: true,
                },
                "VehicleTariff.TransferSource":
                {
                    required: true,
                },
                "VehicleTariff.TransferDestination":
               {
                   required: true,
               },
                "VehicleTariff.TransferPackageAmount":
               {
                   required: true,
                   number: true,
               },
            },
        messages: {

            "VehicleTariff.VehicleId":
                {
                    DropdownRequired: "Vendor is required."
                },
            "VehicleTariff.FreeKm":
               {
                   required: "Free km is required.",
                   number: "Enter digits only."
               },
            "VehicleTariff.KmAmount":
              {
                  required: "Km amount is required.",
                  number: "Enter digits only."
              },
            "VehicleTariff.RupeesPerExtraKm":
                  {
                      required: "Rupees per extra km is required.",
                      number: "Enter digits only."
                  },
            "VehicleTariff.Duration":
               {
                   required: "Duration is required.",
                   number: "Enter digits only."
               },
            "VehicleTariff.HoursAmount":
              {
                  required: "Hours amount is required.",
                  number: "Enter digits only."
              },
            "VehicleTariff.RupeesPerExtraHours":
              {
                  required: "Rupees per extra hours is required.",
                  number: "Enter digits only."
              },
            "VehicleTariff.Source":
              {
                  required: "Source is required."
              },
            "VehicleTariff.Destination":
            {
                required: "Destination is required."
            },
            "VehicleTariff.PackageAmount":
              {
                  required: "Package amount is required.",
                  number: "Enter digits only."
              },
            "VehicleTariff.TransferType":
                {
                    required: "Transfer Type is required.",
                },
            "VehicleTariff.TransferSource":
              {
                  required: "Source is required."
              },
            "VehicleTariff.TransferDestination":
            {
                required: "Destination is required."
            },
            "VehicleTariff.TransferPackageAmount":
              {
                  required: "Transfer amount is required.",
                  number: "Enter digits only."
              }
        }
    });

});