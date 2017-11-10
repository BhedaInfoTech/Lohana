$(document).ready(function () {

    GetAutocompleteScript("Package Vehicle");

    GetPackageItineraryVehicle();

    $(document).on('click', '#btnAddPackageItineraryVehicles', function (event) {
        debugger;
        if ($("#frmPackageItineraryVehicles").valid()) {
            SavePackageItineraryVehicles();
        }
    });

    $(document).on('change', "#tblPackageItineraryVehicles [name='c1']", function (event) {

        if ($(this).prop('checked')) {

            debugger

            var id = $(this).attr("data-packageitineraryVehicleid");

            $("#hdnSearchPackageItineraryVehicleId").val(id);

            GetPackageItineraryVehicleById();

            //$("#divPlanServices1").show();

            $("#btnDeletePackageItineraryVehicles").removeAttr("disabled");

        }

    });

    $("#btnDeletePackageItineraryVehicles").click(function () {

        DeletePackageItineraryVehicle();

    });


});