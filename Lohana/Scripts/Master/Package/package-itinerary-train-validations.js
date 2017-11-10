$(document).ready(function () {

    $("#frmPackageItineraryTrains").validate({

        ignore: ":hidden",

        rules: {

            "PackageItinerary.PackageItineraryTrain.TrainName":
             {
                 required: true
                 // number: true
             },

            "PackageItinerary.PackageItineraryTrain.TrainFrom":
            {
                required: true
                //number: true
            },

            "PackageItinerary.PackageItineraryTrain.TrainTo":
            {
                required: true
                //number: true
            },

            "PackageItinerary.PackageItineraryTrain.TrainTime":
            {
                required: true
                //number: true
            }
        },
        messages: {

            "PackageItinerary.PackageItineraryTrain.TrainName":
             {
                 required: "Train Name is required."
                 //number: "Enter digits only."

             },

            "PackageItinerary.PackageItineraryTrain.TrainFrom":
             {
                 required: "Train from city is required."
                 //number: "Enter digits only."

             },

            "PackageItinerary.PackageItineraryTrain.TrainTo":
             {
                 required: "Train to city is required."
                 //number: "Enter digits only."

             },

            "PackageItinerary.PackageItineraryTrain.TrainTime":
             {
                 required: "Train time is required."
                 //number: "Enter digits only."

             },
        }
    });

});