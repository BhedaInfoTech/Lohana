function SaveDesignation() {

    if ($("[name='Designation.IsActive']").val() == 1 || $("[name='Designation.IsActive']").val() == "true") {
        activeFlg = true;
    }
    else {
        activeFlg = false;
    }

    $("#frmDesignation").blur();

    var dViewModel = {

        Designation: {

            DesignationName: $("[name='Designation.DesignationName']").val(),

            DesignationId: $("[name='Filter.DesignationId']").val(),

            IsActive: activeFlg
        }
    }

    var url = "";

    if ($("[name='Filter.DesignationId']").val() == 0) {

        url = "/Designation/Insert"
    }
    else {
        url = "/Designation/Update"
    }

    PostAjaxWithProcessJson(url, dViewModel, AfterSave, $("body"));
}

function AfterSave(data) {

    FriendlyMessage(data);

    ResetDesignation();

    GetDesignations();
}

function GetDesignations() {

    var dViewModel =
		{
		    Designation: {

		        DesignationId: "",
		  
		        DesignationName: $("[name='Designation.DesignationName']").val(),

		        IsActive: $("[name='Designation.IsActive']").val()
		    },
		    Pager: {

		        CurrentPage: $('#tblDesignation').attr("data-current-page"),
		    },
		}

    PostAjaxWithProcessJson("/Designation/GetDesignations", dViewModel, BindDesignations, $("#frmSearchDesignation"));
}

function BindDesignations(data) {


    var list = JSON.parse(data);

    var kTable = {
        dataList: ["DesignationName","IsActiveStr"],
        primayKey: "DesignationId",
        hiddenFields: ["DesignationId", "DesignationName","IsActive"],
        headerNames: ["Designation Name","Is Active"],
        data: list.dt,
    }

    buildHtmlTable(kTable, $('#tblDesignation'));

    BindPagination(list.Pager, $('#tblDesignation'));
       
}

function ResetDesignation() {

    $("[name='Designation.DesignationName']").val("");

    $("[name='Designation.DesignationId']").val("");

    $("[name='Filter.DesignationId']").val("");

    if ($("[name='Designation.IsActive']").val() == 0 || $("[name='Designation.IsActive']").val() == "false")
    {
        $("[name='Designation.IsActive']").trigger('click');
    }
}

function Pagination(CurrentPage) {

    $('#tblDesignation').attr("data-current-page", CurrentPage);

    GetDesignations();

}

function GetSetDesignationValues(obj) {

    var id = $(obj).attr("data-designationid");

    var designationName = $(obj).attr("data-designationname");

    $("#hdnSearchDesignationId").val(id);

    $("[name='Designation.DesignationName']").val(designationName);

}