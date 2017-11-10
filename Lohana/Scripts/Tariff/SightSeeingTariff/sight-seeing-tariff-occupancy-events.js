$(document).ready(function () {

    

    $("#divAgeFromTo").hide();


    $(document).on('change', "#tblSightSeeingTariffOccupancy [name='c1']", function (event) {

        if ($(this).prop('checked')) {

            GetSetSightSeeingTariffOccupancyValues($(this));

            var id = $(this).attr("data-sightseeingtariffoccupancyid");           

            $("#hdnSearchSightSeeingTariffOccupancyId").val(id);
            

            $("#btnDeleteSightSeeingTariffOccupancy").removeAttr("disabled");

            GetSightSeeingTariffDuration($("#dvcalendar"));

        }

    });


    $("#btnAddSightSeeingTariffOccupancy").click(function () {

        if ($("#frmSightSeeingTariffOccupancy").valid()) {

            SaveSightSeeingTariffOccupancy();
        }
    });

    $("#btnDeleteSightSeeingTariffOccupancy").click(function () {

        DeleteSightSeeingTariffOccupancy();
    });


    $("#btnResetSightSeeingTariffOccupancy").click(function () {

        document.getElementById("frmSightSeeingTariffOccupancy").reset();

        $("#hdnSearchSightSeeingTariffOccupancyId").val('');

    });


   
   

    $(document).on('change', "#drpOccupancy", function (event) {

        var ocuupencyType = GetAutocompleteExtraParamValue("OccupancyType", $(this));
    	 
        if (ocuupencyType == 1)
        {
            $("#divAgeFromTo").hide();           
        }
        else
        {
            $("#divAgeFromTo").show();
        }

    });


});