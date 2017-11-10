$(document).ready(function () {

    GetVehicleBrands();

    $(document).on('change', "[name='c1']", function (event) {

        if ($(this).prop('checked')) {

            GetSetVehicleBrandValues($(this));
                       
            SetActive($("[name='VehicleBrand.IsActive']"), $(this).attr("data-isactive"));
        }
    });

    $("#btnSaveVehicleBrand").click(function () {

        if ($("#frmVehicleBrand").valid()) {

            SaveVehicleBrand();
        }

    });

    $("#btnSearchVehicleBrand").click(function () {

        $("#tblVehicleBrand").attr("data-current-page", "0");

        GetVehicleBrands();

    });

    $("#btnResetVehicleBrand").click(function () {

        ResetVehicleBrand();
    });

});
