$(function () {

    GetAutocompleteScript("VehicleTariff");

    $('[name = "VehicleTariff.VehicleId"]').change(function () {

        GetVehicleDetailsById($(this).val());
    });

    $("#btnAddVehicleTariffPriceDetails").click(function () {

        debugger;

        if ($("#frmVehicleTariffPriceDetails").valid()) {

            SaveVehicleTariffPriceDetails();
        }
    });

    $(document).on('change', "#tblVehicleTariffPriceDetails [name='c1']", function (event) {

        if ($(this).prop('checked')) {

            GetSetVehicleTarifPriceDetails($(this));
            
            GetVehicleTariffCustomerCategoryDetails();

            $("#btnDeleteVehicleTariffPriceDetails").removeAttr("disabled");

        }

    });

    $("#btnResetVehicleTariffPriceDetails").click(function () {

        document.getElementById("frmVehicleTariffPriceDetails").reset();

        ResetVehicleTariffPriceDetails();

    })


    $("#btnDeleteVehicleTariffPriceDetails").click(function () {

        DeleteVehicleTariffPriceDetails();
    });

    $("#btnVehicleKm").click(function () {
        $("#divKm").toggle();
    });

    $("#btnVehicleHour").click(function () {
        $("#divHour").toggle();
    });

    $("#btnVehiclePackage").click(function () {
        $("#divPackage").toggle();
    });

    $("#btnVehicleTransfer").click(function () {
        $("#divTransfer").toggle();
    });
});