$(document).ready(function () {

    GetAutocompleteScript("Package Train");

    GetPackageItineraryTrain();

    $(document).on('click', '#btnAddPackageItineraryTrains', function (event) {
        debugger;
        if ($("#frmPackageItineraryTrains").valid()) {
            SavePackageItineraryTrains();
        }
    });

    $(document).on('change', "#tblPackageItineraryTrains [name='c1']", function (event) {

        if ($(this).prop('checked')) {

            debugger

            var id = $(this).attr("data-packageitineraryTrainid");

            $("#hdnSearchPackageItineraryTrainId").val(id);

            GetPackageItineraryTrainById();

            //$("#divPlanServices1").show();

            $("#btnDeletePackageItineraryTrains").removeAttr("disabled");

        }

    });

    $("#btnDeletePackageItineraryTrains").click(function () {

        DeletePackageItineraryTrain();

    });


});