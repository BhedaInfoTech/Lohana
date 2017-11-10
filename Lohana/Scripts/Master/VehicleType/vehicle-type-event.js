$(document).ready(function () {

    GetVehicleTypes();

    $(document).on('change', "[name='c1']", function (event) {

        if ($(this).prop('checked')) {

            GetSetVehicleTypeValues($(this));

            SetActive($("[name='VehicleType.IsActive']"), $(this).attr("data-isactive"));
        }
    });

    $("#btnSaveVehicleType").click(function () {

        if ($("#frmVehicleType").valid()) {

            SaveVehicleType();
        }

    });

    $("#btnSearchVehicleType").click(function () {

        $("#tblVehicleType").attr("data-current-page", "0");

        GetVehicleTypes();

    });

    $("#btnResetVehicleType").click(function () {

        ResetVehicleType();
    });

});
