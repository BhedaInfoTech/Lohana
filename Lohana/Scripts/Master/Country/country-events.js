/// <reference path="../../jquery.uploadify.js" />

$(document).ready(function () {

	GetCountries();

    $(document).on('change',"[name='c1']", function (event) {

    	if ($(this).prop('checked'))
    	{
    		GetSetCountryValues($(this));

    		SetActive($("[name='Country.IsActive']"), $(this).attr("data-isactive"));
        }
    });

    $("#btnSaveCountry").click(function () {

        if ($("#frmCountry").valid())
        {
            SaveCountry();
        }

    });

    $("#btnSearchCountry").click(function () {

        $("#tblCountry").attr("data-current-page", "0");

        GetCountries();

      

    });

    $("#btnResetCountry").click(function ()
    {
    	ResetCountry();
    });

});
