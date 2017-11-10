function SaveCity() {

    if ($("[name='City.IsActive']").val() == 1 || $("[name='City.IsActive']").val() == "true")
    {
        activeFlg = true;
    }
    else
    {
        activeFlg = false;
    }

    $("#frmCity").blur();

    var cViewModel = {

        City: {

            CountryId: $("#drpCountry").val(),

            StateId: $("#drpState").val(),

            CityCode: $("[name='City.CityCode']").val(),

            CityName: $("[name='City.CityName']").val(),

            CityId: $("[name='Filter.CityId']").val(),

            IsActive: activeFlg

        }
    }

    var url = "";

    if ($("[name='Filter.CityId']").val() == 0)
    {
        url = "/City/Insert"
    }
    else
    {
        url = "/City/Update"
    }

    PostAjaxWithProcessJson(url, cViewModel, AfterSave, $("body"));
}

function AfterSave(data) {

    FriendlyMessage(data);

    ResetCity();

    GetCities();
}

function GetCities() {

    var cViewModel =
		{
		    City: {

		        CityId: "",

		        CountryId: $("#drpCountry").val(),

		        StateId: $("#drpState").val(),

		        CityCode: $("[name='City.CityCode']").val(),

		        CityName: $("[name='City.CityName']").val(),

		        IsActive: $("[name='City.IsActive']").val()
		    },
		    Pager: {

		        CurrentPage: $('#tblCity').attr("data-current-page"),
		    },
		}

    PostAjaxWithProcessJson("/City/GetCities", cViewModel, BindCities, $("#frmSearchCity"));
}

function BindCities(data)
{

    var list = JSON.parse(data);

    var kTable = {
        dataList: ["CountryName", "StateName", "CityCode", "CityName", "IsActiveStr"],
        primayKey: "CityId",
        hiddenFields: ["CityId", "CountryName", "CountryId", "StateName", "StateId", "CityCode", "CityName", "IsActive"],
        headerNames: ["Country Name", "State Name", "City Code", "City Name", "Is Active"],
        data: list.dt,
    }

    buildHtmlTable(kTable, $('#tblCity'));

    BindPagination(list.Pager, $('#tblCity'));

}

function ResetCity() {

    $("#drpCountry").val("0");

    $("[name='City.CountryId']").trigger("change");

    $("#drpState").val("0");

    $("[name='City.CityCode']").val("");

    $("[name='City.CityName']").val("");

    $("[name='City.CityId']").val("");

    $("[name='Filter.CityId']").val("");

    if ($("[name='City.IsActive']").val() == 0 || $("[name='City.IsActive']").val() == "false")
    {
        $("[name='City.IsActive']").trigger('click');
    }

}

function Pagination(CurrentPage) {

    $('#tblCity').attr("data-current-page", CurrentPage);

    GetCities();

}

function GetSetCityValues(obj) {

    var id = $(obj).attr("data-cityid");

    var countryid = $(obj).attr("data-countryid");

    var stateid = $(obj).attr("data-stateid");

    var cityCode = $(obj).attr("data-citycode");

    var cityName = $(obj).attr("data-cityname");

    $("#hdnSearchCityId").val(id);

    $("[name='City.CountryId']").val(countryid);

    $("[name='City.StateId']").val(stateid);

    $("[name='City.CityCode']").val(cityCode);

    $("[name='City.CityName']").val(cityName);

    $("[name='City.CountryId']").attr("data-value", countryid);

    GetAutocompleteById("City.CountryId");

    $("[name='City.StateId']").attr("data-value", countryid);

    GetAutocompleteById("City.StateId");

}



function GetStateByCountryId(countryId)
{
    
    GetAjax("/City/GetStatesByCountryId", { countryId: countryId }, BindStates);
}

function BindStates(states)
{
    $("#drpState").html("");

    var htmltext = "";

    htmltext += "<option value = '0'>Select States</option>";
    
    if (states.length > 0) {

        for (var i = 0; i < states.length ; i++) {

            htmltext += "<option value='" + states[i].StateId + "' >" + states[i].StateName + "</option>";

        }
    }

        $("#drpState").html(htmltext);   
}





































//function SetDrpStateValues()
//{
//    alert(SetDrpStateValues);


//    var cViewModel =
//		{
//		    City: {

//		        CountryId: $("[name='City.CountryId']").val(),
  
//		    }
//		}

//    PostAjaxJson("/City/SetDrpStateValues", cViewModel, BindStates);
//}


//function BindStates(response) {

//    alert(BindStates);

//    var obj = $.parseJSON(response);

//    $("#drpState").html("");

//    $("#drpState").append("<option value=''>Select State</option>");

//    $("#drpState").parents('.form-group').find('ul').html("");

//    $("#drpState").parents('.form-group').find('ul').append("<li><a style='' class='' tabindex='0'><span class='input-group-addon'>Select State.</span><i class='fa fa-globe'></i></a></li>");

//    alert(obj.States.length);

//    if (obj.States.length > 0) {

//        for (var j = 0; j < obj.States.length; j++) {

//            var i = j + 1;

//            $("#drpState").append("<option value='" + obj.States[j].StateName + "'>" + obj.States[j].StateName + "</option>");

//            $("#drpState").parents('.form-group').find('ul').append("<li rel='" + i + "' class=''><a style='' class='' tabindex='0'><span class='input-group-addon'>" + obj.States[j].StateName + "</span><i class='fa fa-globe'></i></a></li>");


//        }
//    }
//}












