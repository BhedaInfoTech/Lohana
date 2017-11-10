$(document).ready(function () {

    $("#frmPackageItineraryHotels").validate({

        ignore: ":hidden",

        rules: {

            "PackageItinerary.PackageItineraryHotel.LocationId":
             {
                 required: true
                // number: true
             },

            "PackageItinerary.PackageItineraryHotel.HotelId":
            {
                required: true
                //number: true
            },

            "PackageItinerary.PackageItineraryHotel.SupplierId":
                {
                    required: true
                },

            "PackageItinerary.PackageItineraryHotel.HotelCost":
                {
                    required: true
                },
        },
        messages: {

            "PackageItinerary.PackageItineraryHotel.LocationId":
             {
                 required: "Hotel Location is required."
                 //number: "Enter digits only."

             },

            "PackageItinerary.PackageItineraryHotel.HotelId":
             {
                 required: "Hotel is required."
                 //number: "Enter digits only."

             },

            "PackageItinerary.PackageItineraryHotel.SupplierId":
                {
                    required: "Supplier is required."
                    //number: "Enter digits only."
                },

            "PackageItinerary.PackageItineraryHotel.HotelCost":
                {
                    required: "Cost is required."
                    //number: "Enter digits only."
                },
        }
    });

});