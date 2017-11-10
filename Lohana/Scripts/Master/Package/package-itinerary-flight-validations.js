$(document).ready(function () {

    $("#frmPackageItineraryFlights").validate({

        ignore: ":hidden",

        rules: {

            "PackageItinerary.PackageItineraryFlight.FlightName":
             {
                 required: true
                 // number: true
             },

            "PackageItinerary.PackageItineraryFlight.FlightFrom":
            {
                required: true
                //number: true
            },

            "PackageItinerary.PackageItineraryFlight.FlightTo":
            {
                required: true
                //number: true
            },

            "PackageItinerary.PackageItineraryFlight.FlightTime":
            {
                required: true
                //number: true
            }
        },
        messages: {

            "PackageItinerary.PackageItineraryFlight.FlightName":
             {
                 required: "Flight Name is required."
                 //number: "Enter digits only."

             },

            "PackageItinerary.PackageItineraryFlight.FlightFrom":
             {
                 required: "Flight from city is required."
                 //number: "Enter digits only."

             },

            "PackageItinerary.PackageItineraryFlight.FlightTo":
             {
                 required: "Flight to city is required."
                 //number: "Enter digits only."

             },

            "PackageItinerary.PackageItineraryFlight.FlightTime":
             {
                 required: "Flight time is required."
                 //number: "Enter digits only."

             },
        }
    });

});