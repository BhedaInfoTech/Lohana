$(document).ready(function () {

    $("#frmPackageItineraryBuss").validate({

        ignore: ":hidden",

        rules: {

            "PackageItinerary.PackageItineraryBus.BusName":
             {
                 required: true
                 // number: true
             },

            "PackageItinerary.PackageItineraryBus.BusFrom":
            {
                required: true
                //number: true
            },

            "PackageItinerary.PackageItineraryBus.BusTo":
            {
                required: true
                //number: true
            },

            "PackageItinerary.PackageItineraryBus.BusTime":
            {
                required: true
                //number: true
            },

            "PackageItinerary.PackageItineraryBus.SupplierId":
           {
               required: true
               //number: true
           },

             "PackageItinerary.PackageItineraryBus.BusCost":
          {
               required: true
              //number: true
          }

        },
        messages: {

            "PackageItinerary.PackageItineraryBus.BusName":
             {
                 required: "Bus Name is required."
                 //number: "Enter digits only."

             },

            "PackageItinerary.PackageItineraryBus.BusFrom":
             {
                 required: "Bus from city is required."
                 //number: "Enter digits only."

             },

            "PackageItinerary.PackageItineraryBus.BusTo":
             {
                 required: "Bus to city is required."
                 //number: "Enter digits only."

             },

            "PackageItinerary.PackageItineraryBus.BusTime":
             {
                 required: "Bus time is required."
                 //number: "Enter digits only."

             },

            "PackageItinerary.PackageItineraryBus.SupplierId":
             {
                 required: "Supplier Id is required."
                 //number: "Enter digits only."

             },

            "PackageItinerary.PackageItineraryBus.BusCost":
             {
                 required: "Cost is required."
                 //number: "Enter digits only."

             },
        }
    });

});