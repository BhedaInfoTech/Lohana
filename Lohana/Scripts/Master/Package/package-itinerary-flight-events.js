$(document).ready(function () {

    GetAutocompleteScript("Package Flight");

    GetPackageItineraryFlight();

    $(document).on('click', '#btnAddPackageItineraryFlights', function (event) {
        debugger;
        if ($("#frmPackageItineraryFlights").valid()) {
            SavePackageItineraryFlights();
        }
    });

    $(document).on('change', "#tblPackageItineraryFlights [name='c1']", function (event) {

        if ($(this).prop('checked')) {

            debugger

            var id = $(this).attr("data-packageitineraryflightid");

            $("#hdnSearchPackageItineraryFlightId").val(id);

            GetPackageItineraryFlightById();

            //$("#divPlanServices1").show();

            $("#btnDeletePackageItineraryFlights").removeAttr("disabled");

        }

    });

    $("#btnDeletePackageItineraryFlights").click(function () {

        DeletePackageItineraryFlight();

    });


});