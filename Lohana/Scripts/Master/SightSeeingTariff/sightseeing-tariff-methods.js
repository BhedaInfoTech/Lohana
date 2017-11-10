//Basic Details

function SaveSightSeeingTariffBasic() {

    if ($("[name='SightSeeingTariff.IsActive']").val() == 1 || $("[name='SightSeeingTariff.IsActive']").val() == "true") {
        activeFlg = true;
    }
    else {
        activeFlg = false;
    }

    $("#frmSightSeeingTariffBasic").blur();

    var sstViewModel = {

        SightSeeingTariff: {

            SightSeeingTariffId: $("[name='Filter.SightSeeingTariffId']").val(),

            VendorId: $("#drpVendor").val(),

            PackageName: $("[name='SightSeeingTariff.PackageName']").val(),

            CancellationPolicy: $("[name='SightSeeingTariff.CancellationPolicy']").val(),

            Inclusions: $("[name='SightSeeingTariff.Inclusions']").val(),

            Exclusions: $("[name='SightSeeingTariff.Exclusions']").val(),

            IsActive: activeFlg

        }
    }
    var url = "";

    if ($("[name='Filter.SightSeeingTariffId']").val() == 0) {

        url = "/SightSeeingTariff/Insert"
    }
    else {

        url = "/SightSeeingTariff/Update"
    }
    PostAjaxJson(url, sstViewModel, AfterBasicSave);
}

function AfterBasicSave(data) {

    ResetBasic();

    GetSightSeeingTariffBasic();


}

function ResetBasic() {

    $("#hdnSightSeeingTariffId").val('');

    $("#hdnSearchSightSeeingTariffId").val('');

    $("#drpVendor").val('0');

    $("#txtPackageName").val('');

    $("#txtCancellationPolicy").val('');

    $("#txtInclusions").val('');

    $("#txtExclusions").val('');

    if ($("[name='SightSeeingTariff.IsActive']").val() == 0 || $("[name='SightSeeingTariff.IsActive']").val() == "false")
    {
        $("[name='SightSeeingTariff.IsActive']").trigger('click');

    }

}

function GetSightSeeingTariffBasic() {

    var sstViewModel =
		{
		    SightSeeingTariff: {


		    },
		    Pager: {

		        CurrentPage: $('#tblSightSeeingTariffBasicDetails').attr("data-current-page"),
		    },
		}

    PostAjaxJson("/SightSeeingTariff/GetSightSeeingTariffBasic", sstViewModel, BindSightSeeingTariffBasic);
}

function BindSightSeeingTariffBasic(data) {

    var list = JSON.parse(data);

    var kTable = {
        dataList: ["VendorName", "PackageName","IsActiveStr"],
        primayKey: "SightSeeingTariffId",
        hiddenFields: ["SightSeeingTariffId", "VendorId","VendorName","PackageName","CancellationPolicy","Inclusions","Exclusions","IsActive"],
        headerNames: ["Vendor Name", "Package Name" ,"Status"],
        data: list.dt,
    }

    buildHtmlTable(kTable, $('#tblSightSeeingTariffBasicDetails'));

    BindPagination(list.Pager, $('#tblSightSeeingTariffBasicDetails'), "SightSeeingBasicPagination");

}

function GetSetSightSeeingTariffValues(obj) {

    var id = $(obj).attr("data-sightseeingtariffid");

    var vendorid = $(obj).attr("data-vendorid");

    var vendorname = $(obj).attr("data-vendorname");

    var packagename = $(obj).attr("data-packagename");

    var cancellationpolicy = $(obj).attr("data-cancellationpolicy");

    var inclusions = $(obj).attr("data-inclusions");

    var exclusions = $(obj).attr("data-exclusions");

        $("#drpVendor").val(vendorid),

        $("[name='SightSeeingTariff.PackageName']").val(packagename),

        $("[name='SightSeeingTariff.CancellationPolicy']").val(cancellationpolicy),

        $("[name='SightSeeingTariff.Inclusions']").val(inclusions),

        $("[name='SightSeeingTariff.Exclusions']").val(exclusions),

        $("#hdnSightSeeingTariffId").val(id)

        $("#lblVendorName").text(vendorname),

        $("#lblPackageName").text(packagename),

        $("#lblInclusions").text(inclusions),

        $("#lblExclusions").text(exclusions),

        $("#lblCancellationPolicy").text(cancellationpolicy)

        $("#hdnDurationTariffId").val(id);
 
}

function SightSeeingBasicPagination(CurrentPage) {

    $('#tblSightSeeingTariffBasicDetails').attr("data-current-page", CurrentPage);

    GetSightSeeingTariffBasic();

}

