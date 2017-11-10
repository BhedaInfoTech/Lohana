function SaveOccupancy() {

    if ($("[name='Occupancy.IsActive']").val() == 1 || $("[name='Occupancy.IsActive']").val() == "true")
    {
        activeFlg = true;
    }
    else
    {
        activeFlg = false;
    }

    $("#frmOccupancy").blur();

    var oViewModel = {

        Occupancy: {

            OccupancyName: $("[name='Occupancy.OccupancyName']").val(),

            OccupancyId: $("[name='Filter.OccupancyId']").val(),

            OccupancyValue: $("[name='Occupancy.OccupancyValue']").val(),

            OccupancyType: $("#drpOccupancyType").val(),

            IsActive: activeFlg

        }
    }

    var url = "";


    if ($("[name='Filter.OccupancyId']").val() == 0) {

        url = "/Occupancy/Insert"
    }
    else {
        url = "/Occupancy/Update"
    }

    PostAjaxWithProcessJson(url, oViewModel, AfterSave, $("body"));
}

function AfterSave(data) {

    FriendlyMessage(data);

    ResetOccupancy();

    GetOccupancies();
}

function GetOccupancies() {

    var oViewModel =
		{
		    Occupancy: {

		        OccupancyId: "",

		        OccupancyName: $("[name='Occupancy.OccupancyName']").val(),

		        OccupancyValue: $("[name='Occupancy.OccupancyValue']").val(),

		        OccupancyType: $("#drpOccupancyType").val(),

		        IsActive: $("[name='RoomType.IsActive']").val()
		    },
		    Pager: {

		        CurrentPage: $('#tblOccupancy').attr("data-current-page"),
		    },
		}

    PostAjaxWithProcessJson("/Occupancy/GetOccupancies", oViewModel, BindOccupancies, $("#frmSearchOccupancy"));
}

function BindOccupancies(data) {

    var list = JSON.parse(data);
    var kTable = {
        dataList: ["OccupancyName", "OccupancyValue", "OccupancyTypeStr", "IsActiveStr"],
        primayKey: "MealId",
        hiddenFields: ["OccupancyId", "OccupancyName", "OccupancyValue", "OccupancyType", "IsActive"],
        headerNames: ["Occupancy Name", "Occupancy Value", "Occupancy Type", "Is Active"],
        data: list.dt,
    }

    buildHtmlTable(kTable, $('#tblOccupancy'));

    BindPagination(list.Pager, $('#tblOccupancy'));
    
}

function ResetOccupancy() {

    $("[name='Occupancy.OccupancyName']").val("");

    $("[name='Occupancy.OccupancyId']").val("");

    $("[name='Filter.OccupancyId']").val("");

    $("[name='Occupancy.OccupancyValue']").val("");

    $("#drpOccupancyType").val("0");

    if ($("[name='Occupancy.IsActive']").val() == 0 || $("[name='Occupancy.IsActive']").val() == "false")
    {
        $("[name='Occupancy.IsActive']").trigger('click');
    }

}


function Pagination(CurrentPage) {

    $('#tblOccupancy').attr("data-current-page", CurrentPage);

    GetOccupancies();

}

function GetSetOccupancyValues(obj) {

    var id = $(obj).attr("data-occupancyid");

    var occupancyName = $(obj).attr("data-occupancyname");

    var occupancyValue = $(obj).attr("data-occupancyvalue");

    var occupancyType = $(obj).attr("data-occupancytype");


    $("#hdnSearchOccupancyId").val(id);

    $("[name='Occupancy.OccupancyName']").val(occupancyName);

    $("[name='Occupancy.OccupancyValue']").val(occupancyValue);
    
    $("[name='Occupancy.OccupancyType']").val(occupancyType);

}
