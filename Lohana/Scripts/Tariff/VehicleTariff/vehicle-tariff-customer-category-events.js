$(function () {

    $('[name = "VehicleTariff.CustomerCategoryId"]').change(function () {

        GetCustomerCategoryDetailsById($(this).val());

    });

    $("#btnAddVehicleTariffCustomerCategory").click(function () {
        if ($("#frmVehicleTariffCustomerCategoryDetails").valid()) {
            SaveVehicleTariffCustomerCategoryDetails();
        }
    });

    $("#btnEditVehicleTariffCustomerCategory").click(function () {
        GetVehicleTariffCustomerCategoryById();
    });

    /*$(document).on('change', "#tblVehicleTariffCustomerCategoryDetails  [name='c1']", function (event) {

        if ($(this).prop('checked')) {

            GetSetVehicleTarifCustomerCategoryDetails($(this));

            $("#btnDeleteVehicleTariffCustomerCategory").removeAttr("disabled");


        }

    });*/

    $("#btnResetVehicleTariffCustomerCategory").click(function () {

        document.getElementById("frmVehicleTariffCustomerCategoryDetails").reset();

        ResetVehicleTariffCustomerCategoryDetails();

    })

    $("#btnDeleteVehicleTariffCustomerCategory").click(function () {

        DeleteVehicleTariffCustomerCategoryDetails();

    });


});