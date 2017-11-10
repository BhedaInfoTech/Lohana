$(document).ready(function () {

    GetAutocompleteScript("Vehicle");


    $("#btnSaveVehicle").click(function () {

        if ($("#frmVehicle").valid()) {

            SaveVehicle();
        }

    });


    $("#btnResetVehicle").click(function () {

        document.getElementById("frmVehicle").reset();

        $("#hdnVehicleId").val("");
    });


    $(document).on("change", "input[type='checkbox']", function () {

        if ($(this).prop("checked")) {

            $(this).val(true);
        }
        else {

            $(this).val(false);
        }
    });

});