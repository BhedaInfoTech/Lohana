

function GetVehicleDetailsById(id) {

    var vtViewModel =
        {
            VehicleTariffPriceDetail: {

                VehicleId: id
            }
        }

    $.ajax({

        url: "/VehicleTariff/GetVehicleDetailsById",

        data: JSON.stringify(vtViewModel),

        dataType: 'json',

        type: 'POST',

        contentType: 'application/json',

        success: function (data) {

            if (data != null) {

                $('#txtVehicleType').val(data[0].VehicleTypeName);

                $('#txtSeatingCapacity').val(data[0].SeatCapacity);

            }
        }
    });
}

function SaveVehicleTariffPriceDetails() {

    debugger;

    $("#frmVehicleTariffPriceDetails").blur();

    var vtViewModel = {

        VehicleTariffPriceDetail: {

            VehicleId: $("#drpVehicle").val(),

            VehicleTypeName: $("[name='VehicleTariff.VehicleType']").val(),

            SeatingCapacity: $("[name='VehicleTariff.SeatingCapacity']").val(),

            FreeKms: $("[name='VehicleTariff.FreeKm']").val(),

            KmAmount: $("[name='VehicleTariff.KmAmount']").val(),

            RupeesPerExtraKm: $("[name='VehicleTariff.RupeesPerExtraKm']").val(),

            Duration: $("[name='VehicleTariff.Duration']").val(),

            HoursAmount: $("[name='VehicleTariff.HoursAmount']").val(),

            RupeesPerExtraHours: $("[name='VehicleTariff.RupeesPerExtraHours']").val(),

            Source: $("[name='VehicleTariff.Source']").val(),

            Destination: $("[name='VehicleTariff.Destination']").val(),

            PackageAmount: $("[name='VehicleTariff.PackageAmount']").val(),

            TransferType: $("[name='VehicleTariff.TransferType']").val(),

            TransferSource: $("[name='VehicleTariff.TransferSource']").val(),

            TransferDestination: $("[name='VehicleTariff.TransferDestination']").val(),

            TransferPackageAmount: $("[name='VehicleTariff.TransferPackageAmount']").val(),

            VehicleTariffId: $("[name='VehicleTariff.VehicleTariffBasicDetailsId']").val(),

            VehicleTariffPriceDetailsId: $("#hdnSearchVehicleTariffPriceId").val()
        }
    }

    var url = "";

    if ($("#hdnSearchVehicleTariffPriceId").val() == 0) {

        url = "/VehicleTariff/InsertVehicleTariffPriceDetails"
    }
    else {

        url = "/VehicleTariff/UpdateVehicleTariffPriceDetails"
    }

    PostAjaxWithProcessJson(url, vtViewModel, AfterSave, $("body"));
}

function AfterSave(data) {

    FriendlyMessage(data);

    ResetVehicleTariffPriceDetails();

    GetVehicleTariffPriceDetails();
}

function GetVehicleTariffPriceDetails() {

    var vtViewModel =
		{
		    VehicleTariffPriceDetail: {

		        VehicleTariffId: $("#hdnVehicleTariffBasicDetailsId").val()

		    },
		    Pager: {

		        CurrentPage: $('#tblVehicleTariffPriceDetails').attr("data-current-page"),
		    },
		}

    PostAjaxWithProcessJson("/VehicleTariff/GetVehicleTariffPriceDetails", vtViewModel, BindVehicleTariffPriceDetails);
}

function BindVehicleTariffPriceDetails(data) {

    var list = JSON.parse(data);
    var kTable = {
        dataList: ["VehicleName", "FreeKmExtraStr", "DurationHourExtrastr", "SrcDestPkgStr", "SrcDestTranStr"],
        primayKey: "VehicleTariffPriceDetailsId",
        hiddenFields: ["VehicleTariffPriceDetalsId", "VehicleTariffId", "VehicleId", "VehicleName", "VehicleType", "SeatingCapacity", "FreeKms", "KmAmount", "RupeesPerExtraKm", "Duration", "HoursAmount", "RupeesPerExtraHours", "Source", "Destination", "PackageAmount", "FreeKmExtraStr", "DurationHourExtrastr", "SrcDestPkgStr", "TransferType", "TransferSource", "TransferDestination", "TransferPackageAmount", "SrcDestTranStr"],
        headerNames: ["Vehicle Name", "FreeKm-Amt-ExtraKm", "Duration-Hour-ExtraHour", "Src-Dest-PkgAmt", "Src-Dest-TranAmt"],
        data: list.dt,
    }

    buildHtmlTable(kTable, $('#tblVehicleTariffPriceDetails'));

    BindPagination(list.Pager, $('#tblVehicleTariffPriceDetails'), "VehiclePricePagination");

}

function ResetVehicleTariffPriceDetails() {

    $("#drpVehicle").val(0);
    $("[name='VehicleTariff.VehicleId']").trigger("change");
    $("#select2-drpVehicle-container").text('Select Vehicle');

    $("[name='VehicleTariff.VehicleType']").val(""),

    $("[name='VehicleTariff.SeatingCapacity']").val(""),

    $("[name='VehicleTariff.FreeKm']").val(""),

    $("[name='VehicleTariff.KmAmount']").val(""),

    $("[name='VehicleTariff.RupeesPerExtraKm']").val(""),

    $("[name='VehicleTariff.Duration']").val(""),

    $("[name='VehicleTariff.HoursAmount']").val(""),

    $("[name='VehicleTariff.RupeesPerExtraHours']").val(""),

    //$("[name='VehicleTariff.Source']").val(""),

    //$("[name='VehicleTariff.Destination']").val(""),
    $("#drpSource").val("");
    $("[name='VehicleTariff.Source']").trigger("change");
    $("#drpDestination").val("");
    $("[name='VehicleTariff.Destination']").trigger("change");
    $("[name='VehicleTariff.PackageAmount']").val(""),

    $("#drpTransferSource").val("");
    $("[name='VehicleTariff.TransferSource']").trigger("change");
    $("#drpTransferDestination").val("");
    $("[name='VehicleTariff.TransferDestination']").trigger("change");
    $("[name='VehicleTariff.TransferPackageAmount']").val(""),
    $("[name='VehicleTariff.TransferType']").val(""),

    $("#hdnSearchVehicleTariffPriceId").val('')

}

function VehiclePricePagination(CurrentPage) {


    $('#tblVehicleTariffPriceDetails').attr("data-current-page", CurrentPage);

    GetVehicleTariffPriceDetails();

}

function GetSetVehicleTarifPriceDetails(obj) {

    var id = $(obj).attr("data-vehicletariffpricedetalsid");

    var vehicleId = $(obj).attr("data-vehicleid");

    var vehicleName = $(obj).attr("data-vehiclename");

    var vehicleTypeName = $(obj).attr("data-vehicletype");

    var seatingCapacity = $(obj).attr("data-seatingcapacity");

    var freeKms = $(obj).attr("data-freekms");

    var kmAmount = $(obj).attr("data-kmamount");

    var rupeesPerExtraKm = $(obj).attr("data-rupeesperextrakm");

    var duration = $(obj).attr("data-duration");

    var hoursAmount = $(obj).attr("data-hoursamount");

    var rupeesPerExtraHours = $(obj).attr("data-rupeesperextrahours");

    var source = $(obj).attr("data-source");

    var destination = $(obj).attr("data-destination");

    var packageAmount = $(obj).attr("data-packageamount");

    var transfersource = $(obj).attr("data-transfersource");

    var transferdestination = $(obj).attr("data-transferdestination");

    var transferpackageAmount = $(obj).attr("data-transferpackageamount");

    var transfertype = $(obj).attr("data-transfertype");

    $("#hdnSearchVehicleTariffPriceId").val(id);

    $("[name='VehicleTariff.VehicleId']").attr('data-value', vehicleId);
    GetAutocompleteById("VehicleTariff.VehicleId");

    $("[name='VehicleTariff.VehicleType']").val(vehicleTypeName),

    $("[name='VehicleTariff.SeatingCapacity']").val(seatingCapacity);
    debugger;
    if (freeKms != '0' && kmAmount != '0' && rupeesPerExtraKm != '0') {
        $("[name='VehicleTariff.FreeKm']").val(freeKms);
        $("[name='VehicleTariff.KmAmount']").val(kmAmount);
        $("[name='VehicleTariff.RupeesPerExtraKm']").val(rupeesPerExtraKm);
        //$("#btnVehicleKm").addClass('active');
        if (!$("#btnVehicleKm").hasClass('active')) {
            $("#btnVehicleKm").trigger('click');
        }
    }
    else {
        if ($("#btnVehicleKm").hasClass('active')) {
            $("[name='VehicleTariff.FreeKm']").val('');
            $("[name='VehicleTariff.KmAmount']").val('');
            $("[name='VehicleTariff.RupeesPerExtraKm']").val('');
            $("#btnVehicleKm").trigger('click');
            //$("#divKm").show();
        }
    }

    if (duration != 0 && hoursAmount != 0 && rupeesPerExtraHours != 0) {
        $("[name='VehicleTariff.Duration']").val(duration);
        $("[name='VehicleTariff.HoursAmount']").val(hoursAmount);
        $("[name='VehicleTariff.RupeesPerExtraHours']").val(rupeesPerExtraHours);
        //$("#btnVehicleHour").addClass('active');
        if (!$("#btnVehicleHour").hasClass('active')) {
            $("#btnVehicleHour").trigger('click');
        }
    }
    else {
        if ($("#btnVehicleHour").hasClass('active')) {
            $("[name='VehicleTariff.Duration']").val('');
            $("[name='VehicleTariff.HoursAmount']").val('');
            $("[name='VehicleTariff.RupeesPerExtraHours']").val('');
            $("#btnVehicleHour").trigger('click');
            //$("#divHour").show();
        }
    }

    if (source != undefined && destination != undefined && packageAmount != '0') {
        $("[name='VehicleTariff.Source']").val(source);
        $("[name='VehicleTariff.Destination']").val(destination);
        $("[name='VehicleTariff.PackageAmount']").val(packageAmount);
        $("[name='VehicleTariff.Source']").attr('data-value', source);
        GetAutocompleteById("VehicleTariff.Source");
        $("[name='VehicleTariff.Destination']").attr('data-value', destination);
        GetAutocompleteById("VehicleTariff.Destination");
        //$("#btnVehiclePackage").addClass('active');
        if (!$("#btnVehiclePackage").hasClass('active')) {
            $("#btnVehiclePackage").trigger('click');
        }
        //GetSetSourceDestinationValues($(this));
    }
    else {
        if ($("#btnVehiclePackage").hasClass('active')) {
            $("[name='VehicleTariff.Source']").val('');
            $("[name='VehicleTariff.Destination']").val('');
            $("[name='VehicleTariff.PackageAmount']").val('');
            $("#btnVehiclePackage").trigger('click');
            //$("#divPackage").show();
        }
    }

    if (transfersource != '0' && transferdestination != '0' && transferpackageAmount != '0') {
        $("[name='VehicleTariff.TransferSource']").val(transfersource);
        $("[name='VehicleTariff.TransferDestination']").val(transferdestination);
        $("[name='VehicleTariff.TransferPackageAmount']").val(transferpackageAmount);
        $("[name='VehicleTariff.TransferType']").val(transfertype);
        $("[name='VehicleTariff.TransferSource']").attr('data-value', transfersource);
        GetAutocompleteById("VehicleTariff.TransferSource");
        $("[name='VehicleTariff.TransferDestination']").attr('data-value', transferdestination);
        GetAutocompleteById("VehicleTariff.TransferDestination");
        if (!$("#btnVehicleTransfer").hasClass('active')) {
            $("#btnVehicleTransfer").trigger('click');
        }
        //GetSetTransferSourceDestinationValues($(this));
    }
    else {
        if ($("#btnVehicleTransfer").hasClass('active')) {
            $("[name='VehicleTariff.TransferSource']").val('');
            $("[name='VehicleTariff.TransferDestination']").val('');
            $("[name='VehicleTariff.TransferPackageAmount']").val('');
            $("[name='VehicleTariff.TransferType']").val('');
            $("#btnVehicleTransfer").trigger('click');
            //$("#divTransfer").show();
        }
    }

    $("#lblVehicleName").text(vehicleName),

    $("#lblVehicleType").text(vehicleTypeName),

    $("#lblSeatingCapacity").text(seatingCapacity),

    $("#lblfreeKmAmt").text(freeKms + '/' + kmAmount + '/' + rupeesPerExtraKm),

    $("#lblDurationExtraHourAmt").text(duration + '/' + hoursAmount + '/' + rupeesPerExtraHours),

    $("#lblSourceDestinationPkgAmt").text(source + '/' + destination + '/' + packageAmount),

    $("#lblTransferSourceDestinationPkgAmt").text(transfersource + '/' + transferdestination + '/' + transferpackageAmount)

    ResetVehicleTariffCustomerCategoryDetails();

}

function DeleteVehicleTariffPriceDetails() {

    debugger;

    var vtViewModel =
      {
          VehicleTariffPriceDetail: {

              VehicleTariffPriceDetailsId: $("[name='VehicleTariffPriceFilter.VehicleTariffPriceDetailsId']").val(),

              VehicleTariffId: $("[name='VehicleTariff.VehicleTariffBasicDetailsId']").val()
          },

          Pager:
          {
              CurrentPage: $('#hdnCurrentPage').val()
          },
      }

    PostAjaxJson("/VehicleTariff/DeleteVehicleTariffPriceDetails", vtViewModel, AfterPriceDelete);

    $("[name='VehicleTariffPriceFilter.VehicleTariffPriceDetailsId']").val('');

}

function AfterPriceDelete(data)
{

    FriendlyMessage(data);

    ResetVehicleTariffPriceDetails();

    GetVehicleTariffPriceDetails();
}
