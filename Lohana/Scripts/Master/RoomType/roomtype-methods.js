function SaveRoomType() {

    if ($("[name='RoomType.IsActive']").val() == 1 || $("[name='RoomType.IsActive']").val() == "true")
    {
        activeFlg = true;        
    }
    else
    {
        activeFlg = false;        
    }

    var rtViewModel = {

        RoomType: {

            RoomTypeName: $("[name='RoomType.RoomTypeName']").val(),

            RoomTypeId: $("[name='Filter.RoomTypeId']").val(),

            IsActive: activeFlg,
        }
    }

    var url = "";
  
    if ($("[name='Filter.RoomTypeId']").val() == 0)
    {

        url = "/RoomType/Insert"
    }
    else
    {
        url = "/RoomType/Update"
    }

    PostAjaxWithProcessJson(url, rtViewModel, AfterSave, $("body"));
}

function AfterSave(data) {

    FriendlyMessage(data);

    ResetRoomType();

    GetRoomTypes();
}

function GetRoomTypes()
    {
    var rtViewModel =
		{
		    RoomType: {

		        RoomTypeId: "",

		        RoomTypeName: $("[name='RoomType.RoomTypeName']").val(),

		        IsActive: $("[name='RoomType.IsActive']").val()
		    },		   
		    Pager: {

		        CurrentPage: $('#tblRoomType').attr("data-current-page"),
		    },
		}

    PostAjaxWithProcessJson("/RoomType/GetRoomTypes", rtViewModel, BindRoomTypes, $("#frmSearchRoomType"));
}

function BindRoomTypes(data) {

    var list = JSON.parse(data);

    var kTable = {
        dataList: ["RoomTypeName", "IsActiveStr"],
        primayKey: "RoomTypeId",
        hiddenFields: ["RoomTypeId","RoomTypeName","IsActive"],
        headerNames: ["Room Type","Is Active"],
        data: list.dt,
    }

    buildHtmlTable(kTable, $('#tblRoomType'));

    BindPagination(list.Pager, $('#tblRoomType'));
 
}

function ResetRoomType() {

    $("[name='RoomType.RoomTypeName']").val("");

    $("[name='RoomType.RoomTypeId']").val("");

    $("[name='Filter.RoomTypeId']").val("");

    $("[name='RoomType.RoomTypeName']").val("");


    if ($("[name='RoomType.IsActive']").val() == 0 || $("[name='RoomType.IsActive']").val() == "false")
    {
        $("[name='RoomType.IsActive']").trigger('click');
    }

}

function Pagination(CurrentPage) {

    $('#tblRoomType').attr("data-current-page", CurrentPage);

    GetRoomTypes();

}

function GetSetRoomTypeValues(obj)
{
    var id = $(obj).attr("data-roomtypeid");

    var roomtypeName = $(obj).attr("data-roomtypename");

    $("#hdnSearchRoomTypeId").val(id);

    $("[name='RoomType.RoomTypeName']").val(roomtypeName);

}


