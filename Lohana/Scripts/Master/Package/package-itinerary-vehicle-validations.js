$(document).ready(function () {

    $("#frmPackageItineraryVehicles").validate({

        ignore: ":hidden",

        rules: {

            "PackageItinerary.PackageItineraryVehicle.VehicleName":
             {
                 required: true
                 // number: true
             },

            "PackageItinerary.PackageItineraryVehicle.VehicleFrom":
            {
                required: true
                //number: true
            },

            "PackageItinerary.PackageItineraryVehicle.VehicleTo":
            {
                required: true
                //number: true
            },

            "PackageItinerary.PackageItineraryVehicle.PickUp":
            {
                required: true
                //number: true
            },

            "PackageItinerary.PackageItineraryVehicle.DropOff":
            {
                required: true
                //number: true
            },

            "PackageItinerary.PackageItineraryVehicle.VehicleTime":
            {
                required: true
                //number: true
            },

            "PackageItinerary.PackageItineraryVehicle.SupplierId":
             {
                required: true
               //number: true
             },

            "PackageItinerary.PackageItineraryVehicle.VehicleCost":
            {
                required: true,
                number: true
            },
        },
        messages: {

            "PackageItinerary.PackageItineraryVehicle.VehicleName":
             {
                 required: "Vehicle Name is required."
                 //number: "Enter digits only."

             },

            "PackageItinerary.PackageItineraryVehicle.VehicleFrom":
             {
                 required: "Vehicle from city is required."
                 //number: "Enter digits only."

             },

            "PackageItinerary.PackageItineraryVehicle.VehicleTo":
             {
                 required: "Vehicle to city is required."
                 //number: "Enter digits only."

             },

            "PackageItinerary.PackageItineraryVehicle.PickUp":
             {
                 required: "Vehicle PickUp is required."
                 //number: "Enter digits only."

             },

            "PackageItinerary.PackageItineraryVehicle.DropOff":
             {
                 required: "Vehicle DropOff is required."
                 //number: "Enter digits only."

             },

            "PackageItinerary.PackageItineraryVehicle.VehicleTime":
             {
                 required: "Vehicle time is required."
                 //number: "Enter digits only."

             },


            "PackageItinerary.PackageItineraryVehicle.SupplierId":
             {
                 required: "Supplier Id is required."
                 //number: true
             },

            "PackageItinerary.PackageItineraryVehicle.VehicleCost":
            {
                required: "Vehicle Cost is required.",
                number: "Enter digits only."
            },
        }
    });

});