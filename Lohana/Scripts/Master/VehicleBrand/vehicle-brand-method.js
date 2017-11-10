function SaveVehicleBrand() {

    var activeFlg = true;

    if ($("[name='VehicleBrand.IsActive']").val() == 1 || $("[name='VehicleBrand.IsActive']").val() == "true") {
        activeFlg = true;
    }
    else {
        activeFlg = false;
    }

    var vbViewModel = {

        VehicleBrand: {

            VehicleBrandName: $("[name='VehicleBrand.VehicleBrandName']").val(),

            VehicleBrandId: $("[name='Filter.VehicleBrandId']").val(),

            IsActive: activeFlg
        }
    }

    var url = "";


    if ($("[name='Filter.VehicleBrandId']").val() == 0) {

        url = "/VehicleBrand/Insert"
    }
    else {
        url = "/VehicleBrand/Update"
    }


    PostAjaxWithProcessJson(url, vbViewModel, AfterSave, $("body"));

}

function AfterSave(data) {

    FriendlyMessage(data);

    ResetVehicleBrand();

    GetVehicleBrands();
}

function GetVehicleBrands() {

    var vbViewModel =
		{
		    VehicleBrand: {

		        VehicleBrandId: "",
                		        
		        VehicleBrandName: $("[name='VehicleBrand.VehicleBrandName']").val(),

		        IsActive: $("[name='VehicleBrand.IsActive']").val()
		    },
		    Pager: {

		        CurrentPage: $('#tblVehicleBrand').attr("data-current-page"),
		    },
		}

    PostAjaxWithProcessJson("/VehicleBrand/GetVehicleBrands", vbViewModel, BindVehicleBrands, $("#frmVehicleBrand"));
}

function BindVehicleBrands(data) {

    var list = JSON.parse(data);

    var kTable = {
        dataList: ["VehicleBrandName", "IsActiveStr"],
        primayKey: "VehicleBrandId",
        hiddenFields: ["VehicleBrandId", "VehicleBrandName", "IsActive"],
        headerNames: ["Vehicle Brand Name", "Is Active"],
        data: list.dt,
    }

    buildHtmlTable(kTable, $('#tblVehicleBrand'));

    BindPagination(list.Pager, $('#tblVehicleBrand'));
}

function ResetVehicleBrand() {

    $("[name='VehicleBrand.VehicleBrandName']").val("");

    $("[name='VehicleBrand.VehicleBrandId']").val("");

    $("[name='Filter.VehicleBrandId']").val("");

    if ($("[name='VehicleBrand.IsActive']").val() == 0 || $("[name='VehicleBrand.IsActive']").val() == "false") {

        $("[name='VehicleBrand.IsActive']").trigger('click');
    }

}

function Pagination(CurrentPage) {

    $('#tblVehicleBrand').attr("data-current-page", CurrentPage);

    GetVehicleBrands();

}

function GetSetVehicleBrandValues(obj) {

    var id = $(obj).attr("data-vehiclebrandid");

    var vehicleBrandName = $(obj).attr("data-vehiclebrandname");

    $("#hdnVehicleBrandId").val(id);

    $("[name='VehicleBrand.VehicleBrandName']").val(vehicleBrandName);

}
