function SaveFacilityType()
{
    if ($("[name='FacilityType.IsActive']").val() == 1 || $("[name='FacilityType.IsActive']").val() == "true")
    {
        activeFlg = true;
    }
    else
    {
        activeFlg = false;
    }

    $("#frmFacilityType").blur();

    debugger;

    var ftViewModel = {

        FacilityType: {

            FacilityTypeName: $("[name='FacilityType.FacilityTypeName']").val(),

            FacilityTypeId: $("[name='Filter.FacilityTypeId']").val(),

            IsActive: activeFlg,
        }
    }

    var url = "";

    if ($("[name='Filter.FacilityTypeId']").val() == 0) {

        url = "/FacilityType/Insert"
    }
    else {
        url = "/FacilityType/Update"
    }

    PostAjaxWithProcessJson(url, ftViewModel, AfterSave, $("body"));

}

function AfterSave(data) {

    FriendlyMessage(data);

    ResetFacilityType();

    GetFacilityTypes();
}

function GetFacilityTypes() {

    var ftViewModel =
		{
		    FacilityType: {

		        FacilityTypeId: "",

		        FacilityTypeName: $("[name='FacilityType.FacilityTypeName']").val(),

		        IsActive: $("[name='FacilityType.IsActive']").val()

		    },
		    Pager: {

		        CurrentPage: $('#tblFacilityType').attr("data-current-page"),

		    },
		}

    PostAjaxWithProcessJson("/FacilityType/GetFacilityTypes", ftViewModel, BindFacilityTypes, $("#frmSearchFacilityType"));
}

function BindFacilityTypes(data) {

    var list = JSON.parse(data);

    var kTable = {
        dataList: ["FacilityTypeName","IsActiveStr"],
        primayKey: "FacilityTypeId",
        hiddenFields: ["FacilityTypeId", "FacilityTypeName","IsActive"],
        headerNames: ["FacilityType Name", "Is Active"],
        data: list.dt,
    }

    buildHtmlTable(kTable, $('#tblFacilityType'));

    BindPagination(list.Pager, $('#tblFacilityType'));

}

function ResetFacilityType() {

    $("[name='FacilityType.FacilityTypeName']").val("");

    $("[name='FacilityType.FacilityTypeId']").val("");

    $("[name='Filter.FacilityTypeId']").val("");

    $("[name='FacilityType.FacilityTypeName']").val("");

    if ($("[name='FacilityType.IsActive']").val() == 0 || $("[name='FacilityType.IsActive']").val() == "false")
    {
        $("[name='FacilityType.IsActive']").trigger('click');
    }

}


function Pagination(CurrentPage) {

    $('#tblFacilityType').attr("data-current-page", CurrentPage);

    GetFacilityTypes();

}

function GetSetFacilityTypeValues(obj) {

    var id = $(obj).attr("data-facilitytypeid");

    var facilitytypeName = $(obj).attr("data-facilitytypename");

    $("#hdnSearchFacilityTypeId").val(id);

    $("[name='FacilityType.FacilityTypeName']").val(facilitytypeName);

}



