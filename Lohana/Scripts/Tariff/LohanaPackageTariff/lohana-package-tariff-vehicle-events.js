$(document).ready(function () {

    GetVehicleListing();

    $("#btnSearchVehicle").click(function () {

        $("#tblVehicleTariffPriceDetails").attr("data-current-page", "0");

        GetVehicleListing();

    });
    $(document).on('change', "#tblVehicleTariffPriceDetails [name='c1']", function (event) {


        if ($(this).prop('checked')) {

            var vehicletariffid = $(this).attr("data-vehicletariffid");

            var vehicleid = $(this).attr("data-vehicleid");

            var vendorname = $(this).attr("data-vendorname");

            var vehiclename = $(this).attr("data-vehiclename");

            var packagename = $(this).attr("data-packagename");

            var vehicletariffpricedetailsid = $(this).attr("data-vehicletariffpricedetalsid");

            $("[name='LohanaPackageTariffVehicle.VehicleId']").val(vehicleid),

            $("[name='LohanaPackageTariffVehicle.VehicleTariffId']").val(vehicletariffid),

            $("[name='LohanaPackageTariffVehicle.VehicleTariffPriceDetailsId']").val(vehicletariffpricedetailsid)
          
            $("#lblVehicleDetails").text(vendorname + "/" + vehiclename + "/" + packagename);

        }

    });

    $(document).on('change', "#tblLohanaPackageTariffVehicle [name='c1']", function (event) {


        if ($(this).prop('checked'))
        {

            var id = $(this).attr("data-lohanapackagetariffvehicleid");

            var noofnight = $(this).attr("data-noofnight");

            var vehicletariffid = $(this).attr("data-vehicletariffid");

            var vehicleid = $(this).attr("data-vehicleid");

            var vendorname = $(this).attr("data-vendorname");

            var vehiclename = $(this).attr("data-vehiclename");

            var packagename = $(this).attr("data-packagename");

            $("#hdnLohanaPackageTariffVehicleId").val(id);
         
            $("[name='LohanaPackageTariffVehicle.NoOfNight']").val(noofnight);

            $("[name='LohanaPackageTariffVehicle.VehicleId']").val(vehicleid),

            $("[name='LohanaPackageTariffVehicle.VehicleTariffId']").val(vehicletariffid)      

            var Details = vendorname + "/" + vehiclename + "/" + packagename;

            $("#lblVehicleDetails").text(Details);

            $("#btnDeleteVehicle").removeAttr("disabled");

        }

    });

    $("#btnAddVehicle").click(function () {

        if ($("#frmLohanaPackageTariffVehicle").valid()) {

            SaveVehicle();
        }
    });

    $("#btnResetVehicle").click(function () {

        document.getElementById("frmLohanaPackageTariffVehicle").reset();

        $("#lblVehicleDetails").text('');

        ResetVehicle();

    });

    $("#btnDeleteVehicle").click(function () {

        DeleteVehicle();

    });

});