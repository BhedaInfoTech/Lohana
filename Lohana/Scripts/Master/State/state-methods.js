function SaveState() {

    if ($("[name='State.IsActive']").val() == 1 || $("[name='State.IsActive']").val() == "true")
    {
        activeFlg = true;
    }
    else
    {
        activeFlg = false;
    }

    $("#frmState").blur();

    var sViewModel = {

        State: {

            CountryId: $("#drpCountry").val(),

            StateCode: $("[name='State.StateCode']").val(),

            StateName: $("[name='State.StateName']").val(),

            StateId: $("[name='Filter.StateId']").val(),

            IsActive: activeFlg

        }
    }

    var url = "";


    if ($("[name='Filter.StateId']").val() == 0) {

        url = "/State/Insert"
    }
    else {
        url = "/State/Update"
    }


    PostAjaxWithProcessJson(url, sViewModel, AfterSave, $("body"));

}

function AfterSave(data) {

    FriendlyMessage(data);

    ResetState();

    GetStates();
}

function GetStates() {

    var sViewModel =
		{
		    State: {

		        StateId: "",

		        CountryId: $("#drpCountry").val(),

		        StateCode: $("[name='State.StateCode']").val(),

		        StateName: $("[name='State.StateName']").val(),

		        IsActive: $("[name='State.IsActive']").val()
		    },
		    Pager:
                {

                    CurrentPage: $('#tblState').attr("data-current-page"),
		    },
		}

    PostAjaxWithProcessJson("/State/GetStates", sViewModel, BindStates, $("#frmSearchState"));
}

function BindStates(data) {

    var list = JSON.parse(data);

    var kTable = {
        dataList: ["CountryName", "StateCode", "StateName", "IsActiveStr"],
        primayKey: "StateId",
        hiddenFields: ["StateId", "CountryId", "CountryName", "StateCode", "StateName", "IsActive"],
        headerNames: ["Country Name", "State Code", "State Name", "Is Active"],
        data: list.dt,
    }

    buildHtmlTable(kTable, $('#tblState'));

    BindPagination(list.Pager, $('#tblState'));

}

function ResetState() {

	$("#drpCountry").html("");

    $("[name='State.StateCode']").val("");

    $("[name='State.StateName']").val("");

    $("[name='State.StateId']").val("");

    $("[name='Filter.StateId']").val("");

    if ($("[name='State.IsActive']").val() == 0 || $("[name='State.IsActive']").val() == "false")
    {
        $("[name='State.IsActive']").trigger('click');
    }
}


function Pagination(CurrentPage) {

    $('#tblState').attr("data-current-page", CurrentPage);

    GetStates();

}

function GetSetStateValues(obj) {

    var id = $(obj).attr("data-stateid");

    var countryid = $(obj).attr("data-countryid");

    var stateCode = $(obj).attr("data-statecode");

    var stateName = $(obj).attr("data-statename");

    $("#hdnSearchStateId").val(id);

    $("[name='State.StateCode']").val(stateCode);

    $("[name='State.CountryId']").val(countryid);

    $("[name='State.CountryId']").attr("data-value", countryid);

    GetAutocompleteById("State.CountryId");

    $("[name='State.StateName']").val(stateName);


}








