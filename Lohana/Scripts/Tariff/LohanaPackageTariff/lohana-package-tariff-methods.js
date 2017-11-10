function SaveBasic() {

    if ($("[name='LohanaPackageTariff.IsActive']").val() == 1 || $("[name='LohanaPackageTariff.IsActive']").val() == "true") {

        activeFlg = true;
    }
    else {
        activeFlg = false;
    }

    $("#frmLohanaPackageTariffBasic").blur();

    var lpViewModel = {

        LohanaPackageTariff: {

            LohanaPackageTariffId: $("[name='LohanaPackageTariff.LohanaPackageTariffId']").val(),

            PackageTypeId: $("#drpPackageType").val(),

            PackageName: $("[name='LohanaPackageTariff.PackageName']").val(),

            DayDuration: $("[name='LohanaPackageTariff.DayDuration']").val(),

            NightDuration: $("[name='LohanaPackageTariff.NightDuration']").val(),

            IsActive:activeFlg

        }
    }
    var url = "";

    if ($("[name='LohanaPackageTariff.LohanaPackageTariffId']").val() == 0) {

        url = "/LohanaPackageTariff/InsertLohanaPackageTariff"
    }
    else {

        url = "/LohanaPackageTariff/UpdateLohanaPackageTariff"
    }

    alert(JSON.stringify(lpViewModel));

    PostAjaxJson(url, lpViewModel, AfterBasicSave);
}

function AfterBasicSave(data)
{
    FriendlyMessage(data);

    ResetBasic();

    GetBasic();
}

function ResetBasic()
{

    $("#hdnLohanaPackageTariffId").val('');

    $("#txtPackageName").val('');

    $("#txtDayduration").val('');

    $("#txtNightduration").val('');

    $("#drpPackageType").val('');

    if ($("[name='LohanaPackageTariff.IsActive']").val() == 0 || $("[name='LohanaPackageTariff.IsActive']").val() == "false") {

        $("[name='LohanaPackageTariff.IsActive']").trigger('click');
    }
}

function GetBasic() {

    var lpViewModel =
		{
		    LohanaPackageTariff: {

		        PackageName: $("[name='LohanaPackageTariff.PackageName']").val()

		    },
		    Pager: {

		        CurrentPage: $('#tblLohanaPackageTariff').attr("data-current-page"),
		    },
		}

    PostAjaxJson("/LohanaPackageTariff/GetLohanaPackageTariff", lpViewModel, BindBasic);
}

function BindBasic(data)
{
    var list = JSON.parse(data);

    var kTable = {
        dataList: ["PackageTypeName","PackageName", "Duration","IsActiveStr"],
        primayKey: ["LohanaPackageTariffId"],
        hiddenFields: ["LohanaPackageTariffId", "PackageTypeId", "PackageTypeName", "PackageName", "DayDuration", "NightDuration", "IsActive"],
        headerNames: ["Package Type","Package Name", "Duration" ,"Status"],
        data: list.dt,
    }

    buildHtmlTable(kTable, $('#tblLohanaPackageTariff'));

    BindPagination(list.Pager, $('#tblLohanaPackageTariff'), "LohanaPackageTariffBasicPagination");
}

function GetSetBasicValues(obj) {

    var id = $(obj).attr("data-lohanapackagetariffid");

    var packagetypeid = $(obj).attr("data-packagetypeid");

    var packagetypename = $(obj).attr("data-packagetypename");

    var packagename = $(obj).attr("data-packagename");

    var dayduration = $(obj).attr("data-dayduration");

    var nightduration = $(obj).attr("data-nightduration");

    $("#drpPackageType").val(packagetypeid);

    $("[name='LohanaPackageTariff.PackageName']").val(packagename),

    $("[name='LohanaPackageTariff.DayDuration']").val(dayduration),

    $("[name='LohanaPackageTariff.NightDuration']").val(nightduration),

    $("[name='LohanaPackageTariffHotel.LohanaPackageTariffId']").val(id),

    $("[name='LohanaPackageTariffVehicle.LohanaPackageTariffId']").val(id)

    ResetHotel();

    GetHotel();


}

function LohanaPackageTariffBasicPagination(CurrentPage) {

    $('#tblLohanaPackageTariff').attr("data-current-page", CurrentPage);

    GetBasic();
}