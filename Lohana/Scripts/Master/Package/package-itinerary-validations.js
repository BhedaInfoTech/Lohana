$(document).ready(function () {

    $("#frmPackageItineraryDetails").validate({

        ignore: ":hidden",

        rules: {

            "Package.PackageDay":
             {
                 required: true,
                 number: true
             }, 
            "Package.MealId":
             {
                 Meal: true
             },
        },
        messages: {

            "Package.PackageDay":
             {
                 required: "Package day is required.",
                 number: "Enter digits only."

             }, 
        }

    });


    jQuery.validator.addMethod("Hotel", function (value, element) {
        var result = true;

        if ($("#drpHotel").val() == "0") {
            result = false;
        }

        return result;

    }, "Hotel is required.");

    jQuery.validator.addMethod("Location", function (value, element) {
        var result = true;

        if ($("#drpLocation").val() == "0") {
            result = false;
        }

        return result;

    }, "Location type is required.");

    jQuery.validator.addMethod("Meal", function (value, element) {
        var result = true;

        if ($("#drpMeal").val() == "0") {
            result = false;
        }

        return result;

    }, "Meal is required.");


    jQuery.validator.addMethod("FlightFrom", function (value, element) {
        var result = true;

        if ($("#drpflightFrom").val() == "0") {
            result = false;
        }

        return result;

    }, "Flight from is required.");

    jQuery.validator.addMethod("FlightTo", function (value, element) {
        var result = true;

        if ($("#drpflightTo").val() == "0") {
            result = false;
        }

        return result;

    }, "Flight to is required.");

    jQuery.validator.addMethod("TrainFrom", function (value, element) {
        var result = true;

        if ($("#drptrainFrom").val() == "0") {
            result = false;
        }

        return result;

    }, "Train from is required.");

    jQuery.validator.addMethod("TrainTo", function (value, element) {
        var result = true;

        if ($("#drptrainTo").val() == "0") {
            result = false;
        }

        return result;

    }, "Train to is required.");

    jQuery.validator.addMethod("BusFrom", function (value, element) {
        var result = true;

        if ($("#drpbusFrom").val() == "0") {
            result = false;
        }

        return result;

    }, "Bus from is required.");

    jQuery.validator.addMethod("BusTo", function (value, element) {
        var result = true;

        if ($("#drpbusTo").val() == "0") {
            result = false;
        }

        return result;

    }, "Bus to is required.");

    jQuery.validator.addMethod("VehicleFrom", function (value, element) {
        var result = true;

        if ($("#drpvehicleFrom").val() == "0") {
            result = false;
        }

        return result;

    }, "Vehicle from is required.");

    jQuery.validator.addMethod("VehicleTo", function (value, element) {
        var result = true;

        if ($("#drpvehicleTo").val() == "0") {
            result = false;
        }

        return result;

    }, "Vehicle to is required.");

});
