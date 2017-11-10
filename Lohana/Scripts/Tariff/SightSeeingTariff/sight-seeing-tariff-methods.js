
function SaveSightSeeingTariffBasic() {


    $("#frmSightSeeingTariffBasic").blur();

    var sstViewModel = {

        SightSeeingTariff: {

            SightSeeingTariffId: $("[name='Filter.SightSeeingTariffId']").val(),

            VendorId: $("#drpVendor").val(),

            SightSeeingId: $("#drpSightSeeing").val(),           

        }
    }
    var url = "";

    if ($("[name='Filter.SightSeeingTariffId']").val() == 0) {

        url = "/SightSeeingTariff/InsertSightSeeingTariff"
    }
    else {

        url = "/SightSeeingTariff/UpdateSightSeeingTariff"
    }
    PostAjaxJson(url, sstViewModel, AfterBasicSave);
}

function AfterBasicSave(data) {

    FriendlyMessage(data);

    ResetBasic();

    GetSightSeeingTariffBasic();


}

function ResetBasic() {

    $("#drpVendor").html("");

    $("#drpSightSeeing").html("");

    $("#hdnSearchSightSeeingTariffId").val('');

    $("#tblSightSeeingTariffBasic [name='c1']").removeAttr("checked");

}

function  GetSightSeeingTariffBasic() {

    var sstViewModel =
		{
		    SightSeeingTariff: {

		        VendorId: $("#drpVendor").val(),

		        SightSeeingId: $("#drpSightSeeing").val(),
		    },
		    Pager: {

		        CurrentPage: $('#tblSightSeeingTariffBasic').attr("data-current-page"),
		    },
		}

    PostAjaxJson("/SightSeeingTariff/GetSightSeeingTariffBasic", sstViewModel, BindSightSeeingTariffBasic);
}

function BindSightSeeingTariffBasic(data) {
    var list = JSON.parse(data);

    var kTable = {
        dataList: ["VendorName", "SightSeeingName"],
      
        primayKey: ["SightSeeingTariffId","VendorId","SightSeeingId"],
        hiddenFields: ["SightSeeingTariffId", "VendorId", "SightSeeingId", "VendorName", "SightSeeingName"],
        headerNames: ["Vendor Name", "Sight Seeing Name"],
        data: list.dt,
    }

    buildHtmlTable(kTable, $('#tblSightSeeingTariffBasic'));

    BindPagination(list.Pager, $('#tblSightSeeingTariffBasic'), "SightSeeingTariffBasicPagination");

}


function GetSetSightSeeingTariffValues(obj) {


    var id = $(obj).attr("data-sightseeingtariffid");

    var vendorid = $(obj).attr("data-vendorid");

    var sightseeingid = $(obj).attr("data-sightseeingid");

    var vendorname = $(obj).attr("data-vendorname");

    var sightseeingname = $(obj).attr("data-sightseeingname");

    $("#drpVendor").attr("data-value", vendorid);

    $("#drpSightSeeing").attr("data-value", sightseeingid);

    $("#lblVendorName").text(vendorname);


    $("#lblSightSeeingeName").text(sightseeingname);

    GetAutocompleteById("SightSeeingTariff.SightSeeingId");

    GetAutocompleteById("SightSeeingTariff.VendorId");

    $("[name='SightSeeingTariffOccupancy.SightSeeingTariffId']").val(id);

    ResetOccupancy();

    GetSightSeeingTariffOccupancy();
}