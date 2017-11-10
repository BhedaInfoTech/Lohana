$(document).ready(function () {

    GetAutocompleteScript("Vehicle");

    document.getElementById("btnEditVehicle").disabled = true;

    GetVehicles();

   // $('.switchery').trigger('click'); 

    $(document).on('change', "[name='c1']", function (event) {

        debugger;

        if ($(this).prop('checked')) {           

            GetSetVehicleValues($(this));

            document.getElementById("btnEditVehicle").disabled = false;

            //SetActive($("[name='Vehicle.IsActive']"), $(this).attr("data-isactive"));

           // alert($(this).attr("data-isactive"));

        }

    });

    $("#btnSearchVehicle").click(function () {

        $("#tblVehicle").attr("data-current-page", "0");

        GetVehicles();
    });


    $("#btnEditVehicle").click(function () {

        $("#frmSearchVehicle").attr("action", "/Vehicle/GetVehicleById");

        $("#frmSearchVehicle").submit();

    });


    $("#btnResetVehicle").click(function () {

        document.getElementById("frmSearchVehicle").reset();
    });
});


