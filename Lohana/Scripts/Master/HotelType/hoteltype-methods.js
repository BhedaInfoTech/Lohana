function SaveHotelType() {

    var activeFlg = true;

    if ($("[name='HotelTypeInfo.IsActive']").val() == 1 || $("[name='HotelTypeInfo.IsActive']").val() == "true") {
        activeFlg = true;
    }
    else {
        activeFlg = false;
    }

    var HotelTypeViewModel = {

        HotelTypeInfo: {

            HotelType: $("[name='HotelTypeInfo.HotelType']").val(),

            
            HotelTypeId: $("[name='Filter.HotelTypeId']").val(),

            IsActive: activeFlg
        }
    }

    var url = "";


    if ($("[name='Filter.HotelTypeId']").val() == 0) {

        url = "/HotelType/Insert"
    }
    else {
        url = "/HotelType/Update"
    }


    PostAjaxWithProcessJson(url, HotelTypeViewModel, AfterSave, $("body"));

}

function AfterSave(data) {

    FriendlyMessage(data);

    ResetHotelType();

    GetHotelType();
}

function GetHotelType() {

    var hViewModel =
		{
		    HotelTypeInfo: {

		        HotelType: "",

		        HotelType: $("[name='HotelTypeInfo.HotelType']").val(),

		        HotelTypeId: $("[name='Filter.hdnSearchHotelTypeId']").val(),

		        

		        IsActive: $("[name='HotelTypeInfo.IsActive']").val()
		    },
		    Pager: {

		        CurrentPage: $('#tblHotelType').attr("data-current-page"),
		    },
		}

    PostAjaxWithProcessJson("/HotelType/GetHotelType", hViewModel, BindHotelType, $("#frmhdnSearchHotelTypeId"));
}

function BindHotelType(data) {
    var list = JSON.parse(data);

    var kTable = {
        dataList: ["HotelType", "IsActiveStr"],
        primayKey: "HotelTypeId",
        hiddenFields: ["HotelTypeId", "HotelType", "IsActive"],
        headerNames: ["HotelType", "Is Active"],
        data: list.dt,
    }

    buildHtmlTable(kTable, $('#tblHotelType'));

    BindPagination(list.Pager, $('#tblHotelType'));
}

function ResetHotelType() {

    $("[name='HotelTypeInfo.HotelType']").val("");

    if ($("[name='HotelTypeInfo.IsActive']").val() == 0 || $("[name='HotelTypeInfo.IsActive']").val() == "false") {
        $("[name='HotelTypeInfo.IsActive']").trigger('click');
    }

}

function Pagination(CurrentPage) {

    $('#tblHotelType').attr("data-current-page", CurrentPage);

    GetHotelType();

}

function GetSetHotelTypeValues(obj) {
    var id = $(obj).attr("data-HotelTypeId");

    var HotelType = $(obj).attr("data-HotelType");

    

    $("#hdnSearchHotelTypeId").val(id);

    $("[name='HotelTypeInfo.HotelType']").val(HotelType);

   

}


