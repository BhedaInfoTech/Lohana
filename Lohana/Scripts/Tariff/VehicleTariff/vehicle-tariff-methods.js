// Vehicle Tariff Basic Details


function SaveVehicleTariffBasicDetails() {

    if ($("[name='VehicleTariff.Status']").val() == 1 || $("[name='VehicleTariff.Status']").val() == "true") {
        activeFlg = true;
    }
    else {
        activeFlg = false;
    }

    $("#frmVehicleTariffBasicDetails").blur();

    var vtViewModel = {

        VehicleTariff: {

            VendorId: $("#drpVendorId").val(),

            PackageName: $("[name='VehicleTariff.PackageName']").val(),

            Inclusions: $("[name='VehicleTariff.Inclusions']").val(),

            Exclusions: $("[name='VehicleTariff.Exclusions']").val(),

            CancellationPolicy: $("[name='VehicleTariff.CancellationPolicy']").val(),

            Status: activeFlg,

            VehicleTariffId: $("[name='VehicleFilter.VehicleTariffId']").val()
        }
    }

    debugger;

    var url = "";

    if ($("[name='VehicleFilter.VehicleTariffId']").val() == 0) {

        url = "/VehicleTariff/InsertVehicleTariffBasicDetails"
    }
    else {
        url = "/VehicleTariff/UpdateVehicleTariffBasicDetails"
    }

    PostAjaxWithProcessJson(url, vtViewModel, AfterSaveBasic);
}

function AfterSaveBasic(data) {

    FriendlyMessage(data);

    ResetVehicleTariffBasicDetails();

    SearchVehicleTariffBasicDetails();
}


function BindVehicleTariffBasicDetails(data) {

    var list = JSON.parse(data);
    var kTable = {
        dataList: ["VendorName", "PackageName", "Inclusions", "Exclusions", "IsActiveStr"],
        primayKey: "VehicleTariffId",
        hiddenFields: ["VehicleTariffId", "VendorId", "VendorName", "PackageName", "Inclusions", "Exclusions", "CancellationPolicy", "Status", "IsActiveStr"],
        headerNames: ["Vendor Name", "Package Name", "Inclusions", "Exclusions", "Status"],
        data: list.dt,
    }

    buildHtmlTable(kTable, $('#tblVehicleTariffBasicDetails'));

    BindPagination(list.Pager, $('#tblVehicleTariffBasicDetails'), "Pagination");

}

function ResetVehicleTariffBasicDetails() {

    $("#drpVendorId").val(0);
    $("[name='VehicleTariff.VendorId']").trigger("change");
    $("#select2-drpVendorId-container").text('Select vendor');

    $("[name='VehicleTariff.PackageName']").val("");

    $("[name='VehicleTariff.Inclusions']").val("");

    $("[name='VehicleTariff.Exclusions']").val("");

    $("[name='VehicleTariff.CancellationPolicy']").val("");

    //$("[name='VehicleFilter.VehicleTariffId']").val();

    $("#hdnSearchVehicleTariffId").val('');

    if ($("[name='VehicleTariff.Status']").val() == 0 || $("[name='VehicleTariff.Status']").val() == "false") {
        $("[name='VehicleTariff.Status']").trigger('click');

    }
}

function Pagination(CurrentPage) {

    $('#tblVehicleTariffBasicDetails').attr("data-current-page", CurrentPage);

    SearchVehicleTariffBasicDetails();

}

function GetSetVehicleTarifBasicDetails(obj) {

    var id = $(obj).attr("data-vehicletariffid");

    var vendorId = $(obj).attr("data-vendorid");

    var vendorName = $(obj).attr("data-vendorname");

    var packageName = $(obj).attr("data-packagename");

    var inclusions = $(obj).attr("data-inclusions");

    var exclusions = $(obj).attr("data-exclusions");

    var cancellationPolicy = $(obj).attr("data-cancellationpolicy");

    $("#hdnSearchVehicleTariffId").val(id);

    $("#hdnVehicleTariffBasicDetailsId").val(id);

    $("#hdnVehicleTariffPriceDetailsId").val(id);

    $("[name='VehicleTariff.VendorId']").attr('data-value', vendorId);
    GetAutocompleteById("VehicleTariff.VendorId");

    $("[name='VehicleTariff.PackageName']").val(packageName);

    $("[name='VehicleTariff.Inclusions']").val(inclusions);

    $("[name='VehicleTariff.Exclusions']").val(exclusions);

    $("[name='VehicleTariff.CancellationPolicy']").val(cancellationPolicy);

    $("#lblVendorName").text(vendorName),

    $("#lblPackageName").text(packageName),

    $("#lblInclusions").text(inclusions),

    $("#lblExclusions").text(exclusions),

    $("#lblCancellationPolicy").text(cancellationPolicy)

    ResetVehicleTariffPriceDetails();

}

function SearchVehicleTariffBasicDetails()
{

    var vtViewModel =
       {
           VehicleTariff: {

               VendorId: $("#drpVendorId").val(),

               PackageName: $("#txtPackageName").val()

           },
           Pager: {

               CurrentPage: $('#tblVehicleTariffBasicDetails').attr("data-current-page"),
           },
       }

    PostAjaxWithProcessJson("/VehicleTariff/SearchVehicleTariffBasicDetails", vtViewModel, BindVehicleTariffBasicDetails);

}


































//// Vehicle Tariff Price Details


//function GetVehicleDetailsById(id) {

//    var vtViewModel =
//        {
//            VehicleTariffPriceDetail: {

//                VehicleId: id
//            }
//        }

//    $.ajax({

//        url: "/VehicleTariff/GetVehicleDetailsById",

//        data: JSON.stringify(vtViewModel),

//        dataType: 'json',

//        type: 'POST',

//        contentType: 'application/json',

//        success: function (data) {

//            if (data != null) {

//                debugger;

//                $('#txtVehicleType').val(data[0].VehicleTypeName);

//                $('#txtSeatingCapacity').val(data[0].SeatCapacity);

//            }
//        }
//    });
//}

//function SaveVehicleTariffPriceDetails() {


//    $("#frmVehicleTariffPriceDetails").blur();

//    var vtViewModel = {

//        VehicleTariffPriceDetail: {

//            VehicleId: $("#drpVehicle").val(),

//            VehicleTypeName: $("[name='VehicleTariff.VehicleType']").val(),

//            SeatingCapacity: $("[name='VehicleTariff.SeatingCapacity']").val(),

//            FreeKm: $("[name='VehicleTariff.FreeKm']").val(),

//            KmAmount: $("[name='VehicleTariff.KmAmount']").val(),

//            RupeesPerExtraKm: $("[name='VehicleTariff.RupeesPerExtraKm']").val(),

//            Duration: $("[name='VehicleTariff.Duration']").val(),

//            HoursAmount: $("[name='VehicleTariff.HoursAmount']").val(),

//            RupeesPerExtraHours: $("[name='VehicleTariff.RupeesPerExtraHours']").val(),

//            Source: $("[name='VehicleTariff.Source']").val(),

//            Destination: $("[name='VehicleTariff.Destination']").val(),

//            PackageAmount: $("[name='VehicleTariff.PackageAmount']").val(),

//            VehicleTariffId: $("[name='VehicleTariff.VehicleTariffBasicDetailsId']").val(),

//            VehicleTariffPriceDetailsId: $("#hdnSearchVehicleTariffPriceId").val()
//        }
//    }

//    debugger;

//    alert($("#hdnSearchVehicleTariffPriceId").val());

//    var url = "";

//    if ($("#hdnSearchVehicleTariffPriceId").val() == 0) {

//        url = "/VehicleTariff/InsertVehicleTariffPriceDetails"
//    }
//    else {
//        url = "/VehicleTariff/UpdateVehicleTariffPriceDetails"
//    }

//    PostAjaxWithProcessJson(url, vtViewModel, AfterSave, $("body"));
//}

//function AfterSave(data) {

//    FriendlyMessage(data);

//    ResetVehicleTariffPriceDetails();

//    GetVehicleTariffPriceDetails();
//}

//function GetVehicleTariffPriceDetails() {

//    var vtViewModel =
//		{
//		    VehicleTariffPriceDetail: {

//		        VehicleTariffPriceDetailsId: "",

//		    },
//		    Pager: {

//		        CurrentPage: $('#tblVehicleTariffPriceDetails').attr("data-current-page"),
//		    },
//		}

//    PostAjaxWithProcessJson("/VehicleTariff/GetVehicleTariffPriceDetails", vtViewModel, BindVehicleTariffPriceDetails, $("#frmVehicleTariffPriceDetails"));
//}

//function BindVehicleTariffPriceDetails(data) {

//    var list = JSON.parse(data);
//    var kTable = {
//        dataList: ["VehicleName", "FreeKmExtraStr", "DurationHourExtrastr", "SrcDestPkgStr"],
//        primayKey: "VehicleTariffPriceDetailsId",
//        hiddenFields: ["VehicleTariffPriceDetalsId", "VehicleId", "VehicleName", "VehicleType", "SeatingCapacity", "FreeKms", "KmAmount", "RupeesPerExtraKm", "Duration", "HoursAmount", "RupeesPerExtraHours", "Source", "Destination", "PackageAmount", "FreeKmExtraStr", "DurationHourExtrastr", "SrcDestPkgStr"],
//        headerNames: ["Vehicle Name", "FreeKm-Amt-ExtraKm", "Duration-Hour-ExtraHour", "Src-Dest-PkgAmt"],
//        data: list.dt,
//    }

//    buildHtmlTable(kTable, $('#tblVehicleTariffPriceDetails'));

//    BindPagination(list.Pager, $('#tblVehicleTariffPriceDetails'));

//}

//function ResetVehicleTariffPriceDetails() {

//    $("#drpVehicle").val(0);

//    $("[name='VehicleTariff.VehicleType']").val(""),

//    $("[name='VehicleTariff.SeatingCapacity']").val(""),

//    $("[name='VehicleTariff.FreeKm']").val(""),

//    $("[name='VehicleTariff.KmAmount']").val(""),

//    $("[name='VehicleTariff.RupeesPerExtraKm']").val(""),

//    $("[name='VehicleTariff.Duration']").val(""),

//    $("[name='VehicleTariff.HoursAmount']").val(""),

//    $("[name='VehicleTariff.RupeesPerExtraHours']").val(""),

//    $("[name='VehicleTariff.Source']").val(""),

//    $("[name='VehicleTariff.Destination']").val(""),

//    $("[name='VehicleTariff.PackageAmount']").val("")

//}

//function Pagination(CurrentPage) {

//    $('#tblVehicleTariffPriceDetails').attr("data-current-page", CurrentPage);

//    GetVehicleTariffPriceDetails();

//}

//function GetSetVehicleTarifPriceDetails(obj) {

//    var id = $(obj).attr("data-vehicletariffpricedetalsid");

//    alert(id);

//    var vehicleId = $(obj).attr("data-vehicleid");

//    var vehicleName = $(obj).attr("data-vehiclename");

//    var vehicleTypeName = $(obj).attr("data-vehicletype");

//    alert(vehicleTypeName);

//    var seatingCapacity = $(obj).attr("data-seatingcapacity");

//    var freeKms = $(obj).attr("data-freekms");

//    var kmAmount = $(obj).attr("data-kmamount");

//    var rupeesPerExtraKm = $(obj).attr("data-rupeesperextrakm");

//    var duration = $(obj).attr("data-duration");

//    var hoursAmount = $(obj).attr("data-hoursamount");

//    var rupeesPerExtraHours = $(obj).attr("data-rupeesperextrahours");

//    var source = $(obj).attr("data-source");

//    var destination = $(obj).attr("data-destination");

//    var packageAmount = $(obj).attr("data-packageamount");

//    $("#hdnSearchVehicleTariffPriceId").val(id);

//    //$("#hdnVehicleTariffPriceDetailsId").val(id);

//    $("#drpVehicle").val(vehicleId),

//    $("[name='VehicleTariff.VehicleType']").val(vehicleTypeName),

//    $("[name='VehicleTariff.SeatingCapacity']").val(seatingCapacity),

//    $("[name='VehicleTariff.FreeKm']").val(freeKms),

//    $("[name='VehicleTariff.KmAmount']").val(kmAmount),

//    $("[name='VehicleTariff.RupeesPerExtraKm']").val(rupeesPerExtraKm),

//    $("[name='VehicleTariff.Duration']").val(duration),

//    $("[name='VehicleTariff.HoursAmount']").val(hoursAmount),

//    $("[name='VehicleTariff.RupeesPerExtraHours']").val(rupeesPerExtraHours),

//    $("[name='VehicleTariff.Source']").val(source),

//    $("[name='VehicleTariff.Destination']").val(destination),

//    $("[name='VehicleTariff.PackageAmount']").val(packageAmount),

//    $("#lblVehicleName").text(vehicleName),

//    $("#lblVehicleType").text(vehicleTypeName),

//    $("#lblSeatingCapacity").text(seatingCapacity),

//    $("#lblfreeKmAmt").text(freeKms + '/' + kmAmount + '/' + rupeesPerExtraKm),

//    $("#lblDurationExtraHourAmt").text(duration + '/' + hoursAmount + '/' + rupeesPerExtraHours),

//    $("#lblSourceDestinationPkgAmt").text(source + '/' + destination + '/' + packageAmount)

//}