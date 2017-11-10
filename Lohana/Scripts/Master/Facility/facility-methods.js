function SaveFacility() {

    if ($("[name='Facility.IsActive']").val() == 1 || $("[name='Facility.IsActive']").val() == "true")
    {
        activeFlg = true;
    }
    else
    {
        activeFlg = false;
    }

    $("#frmFacility").blur();

    var fViewModel = {

        Facility: {

            FacilityTypeId: $("#drpFacilityType").val(),

            FacilityName: $("[name='Facility.FacilityName']").val(),

            FacilityId: $("[name='Filter.FacilityId']").val(),

            IsActive: activeFlg

        }
    }

    var url = "";

    if ($("[name='Filter.FacilityId']").val() == 0) {

        url = "/Facility/Insert"
    }
    else
    {
        url = "/Facility/Update"
    }

    PostAjaxWithProcessJson(url, fViewModel, AfterSave, $("body"));
}

function AfterSave(data) {

    FriendlyMessage(data);

    ResetFacility();

    GetFacilities();
}

function GetFacilities() {

    var fViewModel =
		{
		    Facility: {

		        FacilityId: "",

		        FacilityTypeId: $("#drpFacilityType").val(),

		        FacilityCode: $("[name='Facility.FacilityCode']").val(),

		        FacilityName: $("[name='Facility.FacilityName']").val(),

		        IsActive: $("[name='Facility.IsActive']").val()
		    },
		    Pager: {

		        CurrentPage: $('#tblFacility').attr("data-current-page"),
		    },
		}

    PostAjaxWithProcessJson("/Facility/GetFacilities", fViewModel, BindFacilities, $("#frmSearchFacility"));
}

function BindFacilities(data) {

    var list = JSON.parse(data);

    var kTable = {
        dataList: ["FacilityTypeName", "FacilityName", "IsActiveStr"],
        primayKey: "FacilityId",
        hiddenFields: ["FacilityId", "FacilityTypeName", "FacilityTypeId", "FacilityName", "IsActive"],
        headerNames: ["Facility Type","Facility Name", "Is Active"],
        data: list.dt,
    }

    buildHtmlTable(kTable, $('#tblFacility'));

    BindPagination(list.Pager, $('#tblFacility'));

}

function ResetFacility() {

    $("#drpFacilityType").val("0");

    $("[name='Facility.FacilityName']").val("");

    $("[name='Facility.FacilityId']").val("");

    $("[name='Filter.FacilityId']").val("");

    if ($("[name='Facility.IsActive']").val() == 0 || $("[name='Facility.IsActive']").val() == "false")
    {
        $("[name='Facility.IsActive']").trigger('click');
    }  
}

function Pagination(CurrentPage) {

    $('#tblFacility').attr("data-current-page", CurrentPage);

    GetFacilities();

}

function GetSetFacilityValues(obj) {

    var id = $(obj).attr("data-facilityid");

    var facilitytypeid = $(obj).attr("data-facilitytypeid");

    var facilityname = $(obj).attr("data-facilityname");

    $("#hdnSearchFacilityId").val(id);

    $("[name='Facility.FacilityType']").val(facilitytypeid);

    $("[name='Facility.FacilityName']").val(facilityname);


}







