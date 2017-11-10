function SaveBusiness() {

    if ($("[name='Business.IsActive']").val() == 1 || $("[name='Business.IsActive']").val() == "true")
    {
        activeFlg = true;
    }
    else
    {
        activeFlg = false;
    }

    $("#frmBusiness").blur();

    var bViewModel = {

        Business: {

            BusinessName: $("[name='Business.BusinessName']").val(),

            BusinessId: $("[name='Filter.BusinessId']").val(),

            IsActive: activeFlg,

        }
    }

    var url = "";

    if ($("[name='Filter.BusinessId']").val() == 0) {

        url = "/Business/Insert"
    }
    else {
        url = "/Business/Update"
    }

    PostAjaxWithProcessJson(url, bViewModel, AfterSave, $("body"));

}

function AfterSave(data) {

    FriendlyMessage(data);

    ResetBusiness();

    GetBusinesses();
}

function GetBusinesses() {

    var bViewModel =
		{
		    Business: {

		        BusinessId: "",

		        BusinessName: $("[name='Business.BusinessName']").val(),

		        IsActive: $("[name='Business.IsActive']").val()
		    },
		    Pager: {

		        CurrentPage: $('#tblBusiness').attr("data-current-page"),
		    },
		}

    PostAjaxWithProcessJson("/Business/GetBusinesses", bViewModel, BindBusinesses, $("#frmSearchBusiness"));
}

function BindBusinesses(data) {


    var list = JSON.parse(data);

    var kTable = {
        dataList: ["BusinessName","IsActiveStr"],
        primayKey: "BusinessId",
        hiddenFields: ["BusinessId", "BusinessName","IsActive"],
        headerNames: ["Service Name","Is Active"],
        data: list.dt,
    }

    buildHtmlTable(kTable, $('#tblBusiness'));

    BindPagination(list.Pager, $('#tblBusiness'));

}

function ResetBusiness() {

    $("[name='Business.BusinessName']").val("");

    $("[name='Business.BusinessId']").val("");

    $("[name='Filter.BusinessId']").val("");

    if ($("[name='Business.IsActive']").val() == 0 || $("[name='Business.IsActive']").val() == "false")
    {
        $("[name='Business.IsActive']").trigger('click');
    }
}

function Pagination(CurrentPage) {

    $('#tblBusiness').attr("data-current-page", CurrentPage);

    GetBusinesses();

}

function GetSetBusinessValues(obj) {

    var id = $(obj).attr("data-businessid");    

    var businessName = $(obj).attr("data-businessname");

    $("#hdnSearchBusinessId").val(id);

    $("[name='Business.BusinessName']").val(businessName);

}






