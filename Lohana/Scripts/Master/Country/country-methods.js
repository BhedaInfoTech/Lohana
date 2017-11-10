function SaveCountry() {

	var activeFlg = true;

    if ($("[name='Country.IsActive']").val() == 1 || $("[name='Country.IsActive']").val() == "true")
    {
        activeFlg = true;
    }
    else
    {
        activeFlg = false;
    }   

    var cViewModel = {

        Country: {

            CountryCode: $("[name='Country.CountryCode']").val(),

            CountryName: $("[name='Country.CountryName']").val(),

            CountryId: $("[name='Filter.CountryId']").val(),

            IsActive: activeFlg
        }
    }

    var url = "";


    if ($("[name='Filter.CountryId']").val() == 0)
    {

        url = "/Country/Insert"
    }
    else
    {
        url = "/Country/Update"
    }


    PostAjaxWithProcessJson(url,cViewModel,AfterSave,$("body"));

}

function AfterSave(data)
{
    FriendlyMessage(data);

    ResetCountry();

    GetCountries();
}

function GetCountries() {

    var cViewModel =
		{
		    Country: {

		        CountryId: "",

		        CountryCode: $("[name='Country.CountryCode']").val(),

		        CountryName: $("[name='Country.CountryName']").val(),

		        IsActive: $("[name='Country.IsActive']").val()
		    },
		    Pager: {

		    	CurrentPage: $('#tblCountry').attr("data-current-page"),
		    },
		}

    PostAjaxWithProcessJson("/Country/GetCountries", cViewModel, BindCountries, $("#frmSearchCountry"));
}

function BindCountries(data)
{
	var list = JSON.parse(data);

	var kTable = {
		dataList: ["CountryCode", "CountryName", "IsActiveStr"],
		primayKey:"CountryId",
		hiddenFields: ["CountryId", "CountryCode", "CountryName", "IsActive"],
		headerNames:["Country Code", "Country Name", "Is Active"],
		data: list.dt,
	}

	buildHtmlTable(kTable, $('#tblCountry'));

	BindPagination(list.Pager, $('#tblCountry'));
}

function ResetCountry() {

    $("[name='Country.CountryCode']").val("");

    $("[name='Country.CountryName']").val("");

    $("[name='Country.CountryId']").val("");

    $("[name='Filter.CountryId']").val("");

    if ($("[name='Country.IsActive']").val() == 0 || $("[name='Country.IsActive']").val() == "false")
    {
    	$("[name='Country.IsActive']").trigger('click');
    }

}

function Pagination(CurrentPage)
{

	$('#tblCountry').attr("data-current-page", CurrentPage);

    GetCountries();

}

function GetSetCountryValues(obj)
{
    var id = $(obj).attr("data-countryid");

    var countryCode = $(obj).attr("data-countrycode");

    var countryName = $(obj).attr("data-countryname");

    $("#hdnSearchCountryId").val(id);

    $("[name='Country.CountryCode']").val(countryCode);

    $("[name='Country.CountryName']").val(countryName);

}


