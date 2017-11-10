$(document).ready(function () {

    GetAutocompleteScript("Package Bus");

    GetPackageItineraryBus();

    $(document).on('click', '#btnAddPackageItineraryBuss', function (event) {
        debugger;
        if ($("#frmPackageItineraryBuss").valid()) {
            SavePackageItineraryBuss();
        }
    });

    $(document).on('change', "#tblPackageItineraryBuss [name='c1']", function (event) {

        if ($(this).prop('checked')) {

            debugger

            var id = $(this).attr("data-packageitineraryBusid");

            $("#hdnSearchPackageItineraryBusId").val(id);

            GetPackageItineraryBusById();
              
            $("#btnDeletePackageItineraryBuss").removeAttr("disabled");

        }

    });

    $("#btnDeletePackageItineraryBuss").click(function () {

        DeletePackageItineraryBus();

    });


});