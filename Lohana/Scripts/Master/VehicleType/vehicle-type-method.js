function SaveVehicleType() {

    var activeFlg = true;

    if ($("[name='VehicleType.IsActive']").val() == 1 || $("[name='VehicleType.IsActive']").val() == "true")
    {
        activeFlg = true;
    }
    else {
        activeFlg = false;
    }

    var vtViewModel = {

        VehicleType: {

            VehicleTypeName: $("[name='VehicleType.VehicleTypeName']").val(),

            VehicleTypeId: $("[name='Filter.VehicleTypeId']").val(),

            IsActive: activeFlg
        }
    }

    var url = "";


    if ($("[name='Filter.VehicleTypeId']").val() == 0) {

        url = "/VehicleType/Insert"
    }
    else {
        url = "/VehicleType/Update"
    }


    PostAjaxWithProcessJson(url, vtViewModel, AfterSave, $("body"));

}

function AfterSave(data) {

    FriendlyMessage(data);

    ResetVehicleType();

    GetVehicleTypes();
}

function GetVehicleTypes() {

    var vtViewModel =
		{
		    VehicleType: {

		        VehicleTypeId: "",

		        VehicleTypeName: $("[name='VehicleType.VehicleTypeName']").val(),

		        IsActive: $("[name='VehicleType.IsActive']").val()
		    },
		    Pager: {

		        CurrentPage: $('#tblVehicleType').attr("data-current-page"),
		    },
		}

    PostAjaxWithProcessJson("/VehicleType/GetVehicleTypes", vtViewModel, BindVehicleTypes, $("#frmVehicleType"));
}

function BindVehicleTypes(data) {

    var list = JSON.parse(data);

    var kTable = {
        dataList: ["VehicleTypeName", "IsActiveStr"],
        primayKey: "VehicleTypeId",
        hiddenFields: ["VehicleTypeId", "VehicleTypeName", "IsActive"],
        headerNames: ["Vehicle Type Name", "Is Active"],
        data: list.dt,
    }

    buildHtmlTable(kTable, $('#tblVehicleType'));

    BindPagination(list.Pager, $('#tblVehicleType'));
}

function ResetVehicleType() {

    $("[name='VehicleType.VehicleTypeName']").val("");

    $("[name='VehicleType.VehicleTypeId']").val("");

    $("[name='Filter.VehicleTypeId']").val("");

    if ($("[name='VehicleType.IsActive']").val() == 0 || $("[name='VehicleType.IsActive']").val() == "false") {

        $("[name='VehicleType.IsActive']").trigger('click');
    }

}

function Pagination(CurrentPage) {

    $('#tblVehicleType').attr("data-current-page", CurrentPage);

    GetVehicleTypes();

}

function GetSetVehicleTypeValues(obj) {

    var id = $(obj).attr("data-vehicletypeid");

    var vehicleTypeName = $(obj).attr("data-vehicletypename");

    $("#hdnVehicleTypeId").val(id);

    $("[name='VehicleType.VehicleTypeName']").val(vehicleTypeName);

}
