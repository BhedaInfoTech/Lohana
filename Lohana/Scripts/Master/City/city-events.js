$(document).ready(function () {

	GetAutocompleteScript("City");

    GetCities();

    $(document).on('change', "[name='c1']", function (event) {

        if ($(this).prop('checked')) {

            GetSetCityValues($(this));

            SetActive($("[name='City.IsActive']"), $(this).attr("data-isactive"));
        }

    });

    //$(document).on('change', "#drpCountry", function (event) {
        
    //    GetStateByCountryId($(this).val());

    //});

    $("#btnSaveCity").click(function () {

        if ($("#frmCity").valid())
        {
            SaveCity();
        }

    });

    $("#btnSearchCity").click(function ()
    {
        $("#tblCity").attr("data-current-page", "0");

        GetCities();
    });

    $("#btnResetCity").click(function ()
    {
        document.getElementById("frmSearchCity").reset();

        ResetCity();
    });

});








