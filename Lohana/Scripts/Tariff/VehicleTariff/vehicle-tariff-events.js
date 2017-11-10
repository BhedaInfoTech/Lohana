$(document).ready(function () {

    $("#divKm").hide();
    $("#divHour").hide();
    $("#divPackage").hide();
    $("#divTransfer").hide();

    SearchVehicleTariffBasicDetails();

    GetAutocompleteScript("VehicleTariff");

    $("#btnAddVehicleTariffBasicDetails").click(function () {

        if ($("#frmVehicleTariffBasicDetails").valid()) {

            SaveVehicleTariffBasicDetails();
        }

    });

    $(document).on('change', "#tblVehicleTariffBasicDetails [name='c1']", function (event) {

        if ($(this).prop('checked')) {

            GetSetVehicleTarifBasicDetails($(this));

            SetActive($("[name='VehicleTariff.Status']"), $(this).attr("data-status"));

            $("#lblStatus").text($(this).attr("data-status"));

            GetVehicleTariffPriceDetails();
  

        }

    });

    $("#btnResetVehicleTariffBasicDetails").click(function () {

        document.getElementById("frmVehicleTariffBasicDetails").reset();

        ResetVehicleTariffBasicDetails();

    });

    $("#btnSearchVehicleTariffBasicDetails").click(function () {

        SearchVehicleTariffBasicDetails();

    });



});